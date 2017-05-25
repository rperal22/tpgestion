using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class altaAutomovil : Form
    {
        public altaAutomovil()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxMarca.Clear();
            textBoxPatente.Clear();
            textBoxModelo.Clear();
            textBoxChofer.Clear();
            
        }
    }
}
