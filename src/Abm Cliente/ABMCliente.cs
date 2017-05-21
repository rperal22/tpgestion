using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            altaCliente alta = new altaCliente();
            alta.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formularioBajaCliente baja = new formularioBajaCliente();
            baja.Show(this);
        }
    }
}
