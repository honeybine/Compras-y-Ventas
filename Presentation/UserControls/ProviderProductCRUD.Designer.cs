
namespace Presentation.UserControls {
    partial class ProviderProductCRUD {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgv_main;
        private System.Windows.Forms.TextBox txt_provider;
        private System.Windows.Forms.TextBox txt_product;
        private System.Windows.Forms.ComboBox cbx_main;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_page_left;
        private System.Windows.Forms.Button btn_page_right;
        private System.Windows.Forms.Label lbl_page_number;
        private System.Windows.Forms.Label lbl_provider;
        private System.Windows.Forms.Label lbl_product;
        private System.Windows.Forms.Label lbl_search_column;
        private System.Windows.Forms.Label lbl_search;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            dgv_main = new DataGridView();
            txt_provider = new TextBox();
            txt_product = new TextBox();
            cbx_main = new ComboBox();
            txt_search = new TextBox();
            btn_create = new Button();
            btn_delete = new Button();
            btn_page_left = new Button();
            btn_page_right = new Button();
            lbl_page_number = new Label();
            lbl_provider = new Label();
            lbl_product = new Label();
            lbl_search_column = new Label();
            lbl_search = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_main).BeginInit();
            SuspendLayout();
            // 
            // dgv_main
            // 
            dgv_main.AllowUserToAddRows = false;
            dgv_main.AllowUserToDeleteRows = false;
            dgv_main.AllowUserToResizeRows = false;
            dgv_main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_main.Location = new Point(12, 112);
            dgv_main.MultiSelect = false;
            dgv_main.Name = "dgv_main";
            dgv_main.ReadOnly = true;
            dgv_main.RowHeadersVisible = false;
            dgv_main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_main.Size = new Size(523, 245);
            dgv_main.TabIndex = 9;
            // 
            // txt_provider
            // 
            txt_provider.Location = new Point(12, 27);
            txt_provider.Name = "txt_provider";
            txt_provider.Size = new Size(180, 23);
            txt_provider.TabIndex = 1;
            // 
            // txt_product
            // 
            txt_product.Location = new Point(200, 27);
            txt_product.Name = "txt_product";
            txt_product.Size = new Size(180, 23);
            txt_product.TabIndex = 3;
            // 
            // cbx_main
            // 
            cbx_main.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_main.Location = new Point(12, 78);
            cbx_main.Name = "cbx_main";
            cbx_main.Size = new Size(130, 23);
            cbx_main.TabIndex = 6;
            cbx_main.SelectedIndexChanged += changeColumn;
            // 
            // txt_search
            // 
            txt_search.Location = new Point(150, 78);
            txt_search.Name = "txt_search";
            txt_search.Size = new Size(385, 23);
            txt_search.TabIndex = 8;
            txt_search.TextChanged += onSearchChanged;
            // 
            // btn_create
            // 
            btn_create.Location = new Point(390, 27);
            btn_create.Name = "btn_create";
            btn_create.Size = new Size(145, 23);
            btn_create.TabIndex = 4;
            btn_create.Text = "Alta";
            btn_create.Click += onCreateButton;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(12, 370);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(40, 25);
            btn_delete.TabIndex = 10;
            btn_delete.Text = "Baja";
            btn_delete.Click += onDeleteButton;
            // 
            // btn_page_left
            // 
            btn_page_left.Location = new Point(415, 370);
            btn_page_left.Name = "btn_page_left";
            btn_page_left.Size = new Size(35, 25);
            btn_page_left.TabIndex = 11;
            btn_page_left.Text = "<";
            btn_page_left.Click += previousPage;
            // 
            // btn_page_right
            // 
            btn_page_right.Location = new Point(495, 370);
            btn_page_right.Name = "btn_page_right";
            btn_page_right.Size = new Size(40, 25);
            btn_page_right.TabIndex = 13;
            btn_page_right.Text = ">";
            btn_page_right.Click += nextPage;
            // 
            // lbl_page_number
            // 
            lbl_page_number.Location = new Point(455, 373);
            lbl_page_number.Name = "lbl_page_number";
            lbl_page_number.Size = new Size(35, 20);
            lbl_page_number.TabIndex = 12;
            lbl_page_number.Text = "1";
            lbl_page_number.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_provider
            // 
            lbl_provider.AutoSize = true;
            lbl_provider.Location = new Point(12, 9);
            lbl_provider.Name = "lbl_provider";
            lbl_provider.Size = new Size(94, 15);
            lbl_provider.TabIndex = 0;
            lbl_provider.Text = "ID del proveedor";
            // 
            // lbl_product
            // 
            lbl_product.AutoSize = true;
            lbl_product.Location = new Point(200, 9);
            lbl_product.Name = "lbl_product";
            lbl_product.Size = new Size(89, 15);
            lbl_product.TabIndex = 2;
            lbl_product.Text = "ID del producto";
            // 
            // lbl_search_column
            // 
            lbl_search_column.AutoSize = true;
            lbl_search_column.Location = new Point(12, 60);
            lbl_search_column.Name = "lbl_search_column";
            lbl_search_column.Size = new Size(63, 15);
            lbl_search_column.TabIndex = 5;
            lbl_search_column.Text = "Buscar por";
            // 
            // lbl_search
            // 
            lbl_search.AutoSize = true;
            lbl_search.Location = new Point(150, 60);
            lbl_search.Name = "lbl_search";
            lbl_search.Size = new Size(104, 15);
            lbl_search.TabIndex = 7;
            lbl_search.Text = "Valor de búsqueda";
            // 
            // ProviderProductCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_provider);
            Controls.Add(txt_provider);
            Controls.Add(lbl_product);
            Controls.Add(txt_product);
            Controls.Add(btn_create);
            Controls.Add(lbl_search_column);
            Controls.Add(cbx_main);
            Controls.Add(lbl_search);
            Controls.Add(txt_search);
            Controls.Add(dgv_main);
            Controls.Add(btn_delete);
            Controls.Add(btn_page_left);
            Controls.Add(lbl_page_number);
            Controls.Add(btn_page_right);
            Name = "ProviderProductCRUD";
            Size = new Size(550, 410);
            ((System.ComponentModel.ISupportInitialize)dgv_main).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
