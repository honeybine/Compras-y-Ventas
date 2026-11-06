namespace Presentation;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        btn_product_open = new Button();
        btn_client_open = new Button();
        btn_provider_open = new Button();
        SuspendLayout();
        // 
        // btn_product_open
        // 
        btn_product_open.Location = new Point(18, 13);
        btn_product_open.Name = "btn_product_open";
        btn_product_open.Size = new Size(87, 23);
        btn_product_open.TabIndex = 0;
        btn_product_open.Text = "Productos";
        btn_product_open.UseVisualStyleBackColor = true;
        btn_product_open.Click += button1_Click;
        // 
        // btn_client_open
        // 
        btn_client_open.Location = new Point(18, 42);
        btn_client_open.Name = "btn_client_open";
        btn_client_open.Size = new Size(87, 23);
        btn_client_open.TabIndex = 1;
        btn_client_open.Text = "Clientes";
        btn_client_open.UseVisualStyleBackColor = true;
        btn_client_open.Click += openClient;
        // 
        // btn_provider_open
        // 
        btn_provider_open.Location = new Point(18, 71);
        btn_provider_open.Name = "btn_provider_open";
        btn_provider_open.Size = new Size(87, 23);
        btn_provider_open.TabIndex = 2;
        btn_provider_open.Text = "Proveedores";
        btn_provider_open.UseVisualStyleBackColor = true;
        btn_provider_open.Click += openProvider;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(120, 108);
        Controls.Add(btn_provider_open);
        Controls.Add(btn_client_open);
        Controls.Add(btn_product_open);
        Name = "MainForm";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button btn_product_open;
    private Button btn_client_open;
    private Button btn_provider_open;
}
