using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Facturacion
{
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxIniFac.Clear();
            textBoxFinFac.Clear();
            textBoxClie.Clear();
            textBoxViajes.Clear();
            textBoxTotFac.Clear();
        }
    }
}
