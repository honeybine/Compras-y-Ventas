using Common.Attributes;
using Domain.CRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation.Compras.Clientes {
    public partial class ClientForm : Form {
        public ClientForm() {
            InitializeComponent();

            basiccrud1.setUpMain<ATTR_Client>(new Client());
        }
    }
}
