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
    public partial class formularioBajaChofer : Form
    {
        public formularioBajaChofer()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDireccion.Clear();
            textBoxDNI.Clear();
            textBoxTel.Clear();
            textBoxMail.Clear();
            textBoxFecNac.Clear();
        }
    }
}
