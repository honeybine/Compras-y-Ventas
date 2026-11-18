namespace Presentation.Compras.Productos {
    partial class ProductForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            basiccrud1 = new Presentation.UserControls.BasicCRUD();
            btn_relate = new Button();
            SuspendLayout();
            // 
            // basiccrud1
            // 
            basiccrud1.Location = new Point(12, 12);
            basiccrud1.Name = "basiccrud1";
            basiccrud1.Size = new Size(520, 494);
            basiccrud1.TabIndex = 0;
            // 
            // btn_relate
            // 
            btn_relate.Location = new Point(460, 381);
            btn_relate.Name = "btn_relate";
            btn_relate.Size = new Size(75, 65);
            btn_relate.TabIndex = 1;
            btn_relate.Text = "Relacionar a proveedor";
            btn_relate.UseVisualStyleBackColor = true;
            btn_relate.Click += onRelateButtonPress;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 515);
            Controls.Add(btn_relate);
            Controls.Add(basiccrud1);
            Name = "ProductForm";
            Text = "ProductForm";
            ResumeLayout(false);
        }

        #endregion

        private UserControls.BasicCRUD basiccrud1;
        private Button btn_relate;
    }
}