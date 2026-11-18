
using Domain.CRUD;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace Presentation.UserControls {
    public partial class ProviderProductCRUD : UserControl {

        ProviderProduct provider_product_crud = new ProviderProduct();

        int page_number = 1;
        string searching_by_column = "---";
        bool loading = false;

        public ProviderProductCRUD() {
            InitializeComponent();

            loadColumnsToComboBox();
            loadPage();
        }

        private void loadColumnsToComboBox() {
            loading = true;

            cbx_main.Items.Clear();
            cbx_main.Items.Add("---");

            DataTable data = provider_product_crud.ReadWithPage(1);

            foreach (DataColumn column in data.Columns)
                cbx_main.Items.Add(column.ColumnName);

            cbx_main.SelectedIndex = 0;

            loading = false;
        }

        private void loadPage() {
            DataTable data;

            if (searching_by_column == "---") 
                data = provider_product_crud.ReadWithPage(page_number);
            else if (string.IsNullOrWhiteSpace(txt_search.Text))
                data = provider_product_crud.ReadFromColumnWithPage(searching_by_column, page_number);
            else
                data = provider_product_crud.ReadWhereColumnWithPage(
                    searching_by_column,
                    txt_search.Text,
                    page_number
                );

            dgv_main.DataSource = data;
            lbl_page_number.Text = page_number.ToString();
        }

        private void onCreateButton(object sender, EventArgs e) {
            if (!int.TryParse(txt_provider.Text, out int provider_id) ||
                !int.TryParse(txt_product.Text, out int product_id)) {
                MessageBox.Show("Ingrese IDs válidos para el proveedor y el producto.");
                return;
            }

            try {
                provider_product_crud.Create(provider_id, product_id);

                loadPage();

                MessageBox.Show("Relación creada correctamente.");
            } catch (Exception ex) {
                MessageBox.Show("Error al crear la relación: " + ex.Message);
            }
        }

        private void onDeleteButton(object sender, EventArgs e) {
            if (dgv_main.SelectedRows.Count == 0) {
                MessageBox.Show("Seleccione una relación para eliminar.");
                return;
            }

            DataGridViewRow row = dgv_main.SelectedRows[0];

            int provider_id = Convert.ToInt32(row.Cells["ProviderID"].Value);
            int product_id = Convert.ToInt32(row.Cells["ProductID"].Value);

            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta relación?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try {
                provider_product_crud.Delete(provider_id, product_id);

                loadPage();

                MessageBox.Show("Relación eliminada correctamente.");
            } catch (Exception ex) {
                MessageBox.Show("Error al eliminar la relación: " + ex.Message);
            }
        }

        private void changeColumn(object sender, EventArgs e) {
            if (loading || cbx_main.SelectedItem == null)
                return;

            searching_by_column = cbx_main.SelectedItem.ToString();
            page_number = 1;

            loadPage();
        }

        private void onSearchChanged(object sender, EventArgs e) {
            if (loading)
                return;

            page_number = 1;
            loadPage();
        }

        private void previousPage(object sender, EventArgs e) {
            if (page_number <= 1)
                return;

            page_number--;
            loadPage();
        }

        private void nextPage(object sender, EventArgs e) {
            page_number++;

            DataTable data;

            if (searching_by_column == "---")
                data = provider_product_crud.ReadWithPage(page_number);
            else if (string.IsNullOrWhiteSpace(txt_search.Text))
                data = provider_product_crud.ReadFromColumnWithPage(searching_by_column, page_number);
            else
                data = provider_product_crud.ReadWhereColumnWithPage(
                    searching_by_column,
                    txt_search.Text,
                    page_number
                );

            if (data.Rows.Count == 0) {
                page_number--;
                return;
            }

            dgv_main.DataSource = data;
            lbl_page_number.Text = page_number.ToString();
        }
    }
}