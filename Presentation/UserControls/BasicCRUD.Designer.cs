namespace Presentation.UserControls {
    partial class BasicCRUD {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btn_create = new Button();
            btn_update = new Button();
            btn_delete = new Button();
            dgv_main = new DataGridView();
            btn_page_left = new Button();
            btn_page_right = new Button();
            lbl_page_number = new Label();
            cbx_main = new ComboBox();
            pg_attributes = new PropertyGrid();
            btn_save = new Button();
            txt_search = new TextBox();
            btn_search = new Button();
            lbl_current_action = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_main).BeginInit();
            SuspendLayout();
            // 
            // btn_create
            // 
            btn_create.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_create.Location = new Point(3, 257);
            btn_create.Name = "btn_create";
            btn_create.Size = new Size(83, 33);
            btn_create.TabIndex = 0;
            btn_create.Text = "Alta";
            btn_create.UseVisualStyleBackColor = true;
            btn_create.Click += onCreateButton;
            // 
            // btn_update
            // 
            btn_update.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_update.Location = new Point(92, 257);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(83, 33);
            btn_update.TabIndex = 1;
            btn_update.Text = "Modific.";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Click += onUpdateButton;
            // 
            // btn_delete
            // 
            btn_delete.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_delete.Location = new Point(181, 257);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(83, 33);
            btn_delete.TabIndex = 2;
            btn_delete.Text = "Baja";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += onDeleteButton;
            // 
            // dgv_main
            // 
            dgv_main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_main.Location = new Point(3, 3);
            dgv_main.Name = "dgv_main";
            dgv_main.Size = new Size(514, 248);
            dgv_main.TabIndex = 3;
            // 
            // btn_page_left
            // 
            btn_page_left.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_page_left.Location = new Point(451, 262);
            btn_page_left.Name = "btn_page_left";
            btn_page_left.Size = new Size(21, 23);
            btn_page_left.TabIndex = 4;
            btn_page_left.Text = "<";
            btn_page_left.UseVisualStyleBackColor = true;
            btn_page_left.Click += previousPage;
            // 
            // btn_page_right
            // 
            btn_page_right.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_page_right.Location = new Point(496, 262);
            btn_page_right.Name = "btn_page_right";
            btn_page_right.Size = new Size(21, 23);
            btn_page_right.TabIndex = 5;
            btn_page_right.Text = ">";
            btn_page_right.UseVisualStyleBackColor = true;
            btn_page_right.Click += nextPage;
            // 
            // lbl_page_number
            // 
            lbl_page_number.AutoSize = true;
            lbl_page_number.Location = new Point(478, 267);
            lbl_page_number.Name = "lbl_page_number";
            lbl_page_number.Size = new Size(12, 15);
            lbl_page_number.TabIndex = 6;
            lbl_page_number.Text = "-";
            // 
            // cbx_main
            // 
            cbx_main.FormattingEnabled = true;
            cbx_main.Items.AddRange(new object[] { "---" });
            cbx_main.Location = new Point(324, 262);
            cbx_main.Name = "cbx_main";
            cbx_main.Size = new Size(121, 23);
            cbx_main.TabIndex = 7;
            cbx_main.SelectionChangeCommitted += changeColumn;
            // 
            // pg_attributes
            // 
            pg_attributes.BackColor = SystemColors.Control;
            pg_attributes.Location = new Point(3, 296);
            pg_attributes.Name = "pg_attributes";
            pg_attributes.Size = new Size(247, 195);
            pg_attributes.TabIndex = 8;
            // 
            // btn_save
            // 
            btn_save.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.Location = new Point(256, 463);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 28);
            btn_save.TabIndex = 9;
            btn_save.Text = "Guardar";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += onSaveButton;
            // 
            // txt_search
            // 
            txt_search.Location = new Point(324, 291);
            txt_search.Name = "txt_search";
            txt_search.Size = new Size(100, 23);
            txt_search.TabIndex = 10;
            // 
            // btn_search
            // 
            btn_search.Location = new Point(324, 320);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(75, 23);
            btn_search.TabIndex = 11;
            btn_search.Text = "Buscar";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += onSearchButton;
            // 
            // lbl_current_action
            // 
            lbl_current_action.AutoSize = true;
            lbl_current_action.Location = new Point(256, 445);
            lbl_current_action.Name = "lbl_current_action";
            lbl_current_action.Size = new Size(22, 15);
            lbl_current_action.TabIndex = 12;
            lbl_current_action.Text = "---";
            // 
            // BasicCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_current_action);
            Controls.Add(btn_search);
            Controls.Add(txt_search);
            Controls.Add(btn_save);
            Controls.Add(pg_attributes);
            Controls.Add(cbx_main);
            Controls.Add(lbl_page_number);
            Controls.Add(btn_page_right);
            Controls.Add(btn_page_left);
            Controls.Add(dgv_main);
            Controls.Add(btn_delete);
            Controls.Add(btn_update);
            Controls.Add(btn_create);
            Name = "BasicCRUD";
            Size = new Size(520, 494);
            ((System.ComponentModel.ISupportInitialize)dgv_main).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_create;
        private Button btn_update;
        private Button btn_delete;
        private DataGridView dgv_main;
        private Button btn_page_left;
        private Button btn_page_right;
        private Label lbl_page_number;
        private ComboBox cbx_main;
        private PropertyGrid pg_attributes;
        private Button btn_save;
        private TextBox txt_search;
        private Button btn_search;
        private Label lbl_current_action;
    }
}
