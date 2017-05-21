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
            altaChofer ver = new altaChofer();
            ver.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formularioBajaChofer ver = new formularioBajaChofer();
            ver.Show();
        }
    }
}
