using Domain.CRUD;
using Presentation.Compras.Clientes;
using Presentation.Compras.Productos;
using Presentation.Compras.Proveedores;

namespace Presentation;

public partial class MainForm : Form {
    public MainForm() {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
        ProductForm newtt = new ProductForm();
        newtt.Show();
    }

    private void openClient(object sender, EventArgs e) {
        ClientForm newtt = new ClientForm();
        newtt.Show();
    }

    private void openProvider(object sender, EventArgs e) {
        ProviderForm newtt = new ProviderForm();
        newtt.Show();
    }
}