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

namespace UberFrba.Abm_Turno
{
    public partial class BusquedaTurno : Form
    {

        BindingList<Turno> turnos;

        public BusquedaTurno()
        {
            InitializeComponent();
            this.buttonLimpiar_Click(null,null);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDesc.Text = "";
            turnos = new BindingList<Turno>(new SqlTurnos().getTurnos(""));
            dataGridViewTurnos.DataSource = new BindingSource(turnos, null);
        }

        private void actualizarTabla()
        {
            if (this.textBoxDesc.TextLength > 0)
            {
                turnos = new BindingList<Turno>(new SqlTurnos().getTurnos(this.textBoxDesc.Text));
                dataGridViewTurnos.DataSource = new BindingSource(turnos, null);
            }
            else
            {
                MessageBox.Show("Complete el campo descripcion");
            }

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.actualizarTabla();
        }

        private void editarTurno(object sender, EventArgs e)
        {
            new ModificarTurno(this.dataGridViewTurnos.SelectedRows[0].DataBoundItem as Turno).Show();
            this.Close();
        }
    }
}
