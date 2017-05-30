using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class ABMTurno : Form
    {
        public ABMTurno()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            new altaTurno().Show();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            new BusquedaTurno().Show();
        }
    }
}
