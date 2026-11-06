using Common.Attributes;
using Domain.CRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation.Compras.Proveedores {
    public partial class ProviderForm : Form {
        public ProviderForm() {
            InitializeComponent();

            basiccrud1.setUpMain<ATTR_Provider>(new Provider());
        }
    }
}
