namespace Presentation.Compras.Productos {
    partial class ProviderProductForm {
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
            providerProductcrud1 = new Presentation.UserControls.ProviderProductCRUD();
            SuspendLayout();
            // 
            // providerProductcrud1
            // 
            providerProductcrud1.Location = new Point(12, 12);
            providerProductcrud1.Name = "providerProductcrud1";
            providerProductcrud1.Size = new Size(550, 410);
            providerProductcrud1.TabIndex = 0;
            // 
            // ProviderProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 418);
            Controls.Add(providerProductcrud1);
            Name = "ProviderProductForm";
            Text = "ProviderProduct";
            ResumeLayout(false);
        }

        #endregion

        private UserControls.ProviderProductCRUD providerProductcrud1;
    }
}