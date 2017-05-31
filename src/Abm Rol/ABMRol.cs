using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            new altaRol().Show();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            new listadoSeleccionModificar().Show();
        }
    }
}
