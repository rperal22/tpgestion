using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Entidades;
using UberFrba.SQL;

namespace UberFrba.Abm_Automovil
{
    public partial class altaAutomovil : Form
    {
        public List<Turno> turnos;
        public altaAutomovil()
        {
            InitializeComponent();
            this.turnos = new SqlTurnos().getAllTurnos();
            this.comboBox1.DisplayMember = "desc";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DataSource = this.turnos;
        }


        private void buttonRemover_Click(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}
