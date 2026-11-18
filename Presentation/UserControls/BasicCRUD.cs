
using Common.Attributes;
using Common.Interfaces;
using System.Reflection;

namespace Presentation.UserControls {
    public partial class BasicCRUD : UserControl {
        // Es una interfas (no me anda la seta) la cual contiene las funciones necesarias, es para
        // asegurar consistencia entre multiples archivos, y para que no falte ninguna funcion.
        public ICrud? crud;

        // Crea una variable para guardar una funcion la cual toma una List<AttributeBaseClass>
        // y devuelve un object.
        // (el cual, en este caso, es una List que contiene instancias
        // de las clases de atributos)
        // Esto lo hago especificamente para poder guardar la funcion para crear una nueva
        // instancia de la clase especificada.
        Func<List<AttributeBaseClass>, object>? cast_data;
        // Aca guardo una instancia del tipo dado asi puedo usarla para tener informacion del tipo
        // despues.
        public AttributeBaseClass attribute_info;

        // Aca guardo el tipo directamente, asi me ahorro tener que hacer attribute_info.GetType()
        // siempre.
        private Type attribute_type;

        public string searching_by_column = "---";
        public string current_action = "VIENDO";

        int page_number = 1;

        public BasicCRUD() {
            InitializeComponent();

            dgv_main.SelectionChanged += onSelectionChanged;
            updateActionText();
        }

        // Empiesa configurando todo para poder ser usado por el programa.
        // [1] -    Recibe un tipo generico. En este caso, será un tipo de AttributeBaseClass,
        //          una super clase.
        // [2] -    Especifica que T *debe* ser un tipo que hereda de AttributeBaseClass.
        // [3] -    Recibe la funcion para crear una nueva instancia de la clase generica dada.
        //          Esto es para poder crear instancias del tipo dado.
        //                   [1]                            [2]              [3]
        // ------------------vvv--------------vvvvvvvvvvvvvvvvvvvvvvvvvvvv--vvvvv---
        public void setUpMain<T>(ICrud _crud) where T : AttributeBaseClass, new() {
            crud = _crud;
            // Recibe el tipo de T.
            attribute_type = typeof(T);
            // Crea instancia de T.
            attribute_info = new T();

            // Crea la función. Basicamente lo que hace es que toma "data", la castea
            // al tipo dado, y luego lo convierte en una lista.
            cast_data = data => data.Cast<T>().ToList();

            loadColumnsToComboBox();
            loadPage();

            // Se asegura para limpiar el objeto de propiedades.
            pg_attributes.SelectedObject = null;
        }

        // Carga las columnas al ComboBox para poder ser filtradas.
        void loadColumnsToComboBox() {
            cbx_main.Items.Clear();
            cbx_main.Items.Add("---");

            // Desde la información del tipo, si es que tiene columnas por las que buscar, entonces:
            if (attribute_info.SearchThroughWith != null) {
                // Agrega todas las columnas por las que se puede buscar a la ComboBox.
                foreach (string column_name in attribute_info.SearchThroughWith) {
                    cbx_main.Items.Add(column_name);
                }
            }

            cbx_main.SelectedIndex = 0;
        }

        // Carga toda la información a la DataGridView.
        void loadPage() {
            if (crud == null)
                return;

            // Crea una lista de instancias de atributos, esto es para poder mostrarlas
            List<AttributeBaseClass> data;

            // Si el usuario NO está buscando por una columna en especifico:
            if (searching_by_column == "---" || searching_by_column == "") {
                data = crud.ReadWithPage(page_number);
            } // Si no está ordenando por una columna:
            else if (string.IsNullOrWhiteSpace(txt_search.Text)) {
                data = crud.ReadFromColumnWithPage(searching_by_column, page_number);
            } // Si está buscando por un valor en una columna: 
            else {
                data = crud.ReadWhereColumnWithPage(searching_by_column, txt_search.Text, page_number);
            }

            // Limpia la DGV.
            dgv_main.DataSource = null;
            dgv_main.Columns.Clear();

            // Llama la funcion "cast_data" con data. Esto es para que data pase de ser una
            // List<AttributeBaseClass a un (por ejemplo) List<ATTR_Product>.
            // Basicamente convierte un objeto de la superclase a uno de la clase regular.
            dgv_main.DataSource = cast_data!(data);

            // Limpia la PropertyGrid.
            pg_attributes.SelectedObject = null;
        }

        // Actualisa (no me funciona la seta) el texto especificando que accion se está realisando (no me funciona la seta)
        void updateActionText() {
            lbl_current_action.Text = "Accion actual: " + current_action;
        }

        // Solo acorta el nombre del tipo a ello sin ATTR_ y luego le agrega "...ID" para recibir la ID de la instancia "attributes".
        int getIDFromAttribute(AttributeBaseClass attributes) {
            string type_name = attributes.GetType().Name;

            if (type_name.StartsWith("ATTR_"))
                type_name = type_name.Substring(5);

            PropertyInfo? id_property =
                attributes.GetType().GetProperty(type_name + "ID");

            if (id_property == null)
                throw new Exception($"ID property not found in {type_name}.");

            return Convert.ToInt32(id_property.GetValue(attributes));
        }

        // Cuando cambia la selección de la DataGridView
        private void onSelectionChanged(object? sender, EventArgs e) {
            if (current_action != "VIENDO")
                return;

            if (dgv_main.CurrentRow == null)
                return;

            if (dgv_main.CurrentRow.DataBoundItem is not AttributeBaseClass attributes)
                return;

            attribute_info = attributes;
            pg_attributes.SelectedObject = attribute_info;
        }

        // Vuelve a la anterior pagina
        private void previousPage(object sender, EventArgs e) {
            if (page_number <= 1)
                return;

            page_number--;

            lbl_page_number.Text = page_number.ToString();
            loadPage();
        }

        // Vuelve a la anterior pagina
        private void nextPage(object sender, EventArgs e) {
            page_number++;

            lbl_page_number.Text = page_number.ToString();
            loadPage();
        }

        // Cambia la columna cuando se cambia el item seleccionado en la ComboBox
        private void changeColumn(object sender, EventArgs e) {
            searching_by_column = cbx_main.SelectedItem!.ToString()!;

            page_number = 1;
            lbl_page_number.Text = page_number.ToString();

            loadPage();
        }

        // Cuando se presiona el boton de crear, se cambia el modo a crear.
        private void onCreateButton(object sender, EventArgs e) {
            if (crud == null)
                return;

            // Crea una instancia del tipo attribute_type usando AttributeBaseClass como base de información.
            AttributeBaseClass? new_attributes =
                Activator.CreateInstance(attribute_type) as AttributeBaseClass;

            // Si falló, volver
            if (new_attributes == null)
                return;

            // Asigna la instancia de atributos a usar de referencia.
            attribute_info = new_attributes;

            // Actualisa la PropertyGrid
            pg_attributes.SelectedObject = attribute_info;
            pg_attributes.Refresh();

            // Deselecciona los objetos de la DataGridView
            dgv_main.ClearSelection();
            dgv_main.CurrentCell = null;

            // Cambia el modo a crear.
            current_action = "CREANDO";
            updateActionText();
        }

        // Cuando presionan el boton de modificar una fila, cambiar el modo a modificación
        private void onUpdateButton(object sender, EventArgs e) {
            if (crud == null || pg_attributes.SelectedObject == null)
                return;

            current_action = "MODIFICANDO";
            updateActionText();
        }

        // Cuando presionan el boton de borrar una fila, solo hacerlo
        private void onDeleteButton(object sender, EventArgs e) {
            if (crud == null || pg_attributes.SelectedObject == null)
                return;

            // Pregunta para confirmar.
            if (!(MessageBox.Show("¿Está seguro que quiere dar de baja esta fila?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                return;
            }

            // Recibe la ID con la función.
            int id = getIDFromAttribute(attribute_info);

            // Llama la función a la capa de dominio.
            crud.Delete(id);

            // Cambia el modo de programa.
            current_action = "VIENDO";

            updateActionText();
            loadPage();
        }

        // Cuando presionan el buscar, resetear la pagina y cargar la información
        private void onSearchButton(object sender, EventArgs e) {
            page_number = 1;
            lbl_page_number.Text = page_number.ToString();

            loadPage();
        }

        // Cuando presionan el boton de Guardar, ejecutar el codigo acorde.
        private void onSaveButton(object sender, EventArgs e) {
            if (crud == null)
                return;

            // Si el programa está creando, entonces llama la funcion para crear usando la informacion dada:
            if (current_action == "CREANDO") {
                crud.Create(attribute_info);
            } // Si está modificando, entonces entonces llama la funcion para modificar usando la informacion dada: 
            else if (current_action == "MODIFICANDO") {
                int id = getIDFromAttribute(attribute_info);
                crud.Update(id, attribute_info);
            } // Si está viendo, entonces: 
            else {
                return;
            }

            // Reiniciar el estado de programa.
            current_action = "VIENDO";

            // Crea una nueva instancia del tipo attibute_type y luego la castea a AttributeBaseClass.
            // Esto es nada mas para aun tener la base.
            attribute_info = (AttributeBaseClass)Activator.CreateInstance(attribute_type)!;

            // Limpia la PropertyGrid
            pg_attributes.SelectedObject = null;

            // Actualisa el texto
            updateActionText();
            loadPage();
        }
    }
}