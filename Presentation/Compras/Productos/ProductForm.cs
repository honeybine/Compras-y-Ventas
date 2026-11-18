using Common.Attributes;
using Domain.CRUD;

namespace Presentation.Compras.Productos {
    public partial class ProductForm : Form {
        public ProductForm() {
            InitializeComponent();

            basiccrud1.setUpMain<ATTR_Product>(new Product());
        }

        private void onRelateButtonPress(object sender, EventArgs e) {
            ProviderProductForm _new = new ProviderProductForm();
            _new.Show();
        }
    }
}
