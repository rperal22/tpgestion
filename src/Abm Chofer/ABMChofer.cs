using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class ABMChofer : Form
    {
        public ABMChofer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            altaChofer alta = new altaChofer();
            alta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listadoSeleccionBajaChofer baja = new listadoSeleccionBajaChofer();
            baja.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
