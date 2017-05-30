using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Entidades;
using UberFrba.SQL;

namespace UberFrba.Abm_Turno
{
    public partial class ModificarTurno : Form
    {
        private Turno turnoEnModificacion;
        public ModificarTurno(Turno turno)
        {
            InitializeComponent();
            this.turnoEnModificacion = turno;
            this.textBoxDesc.Text = turno.desc;
            this.textBoxHF.Text = turno.hf.ToString();
            this.textBoxHI.Text = turno.hi.ToString();
            this.textBoxKM.Text = turno.valor_kilometro.ToString();
            this.textBoxprecio.Text = turno.precio_base.ToString();
            this.comboBoxEstado.Text = turno.estado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxDesc.Clear();
            textBoxKM.Clear();
            textBoxprecio.Clear();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                Turno turnoAActualizar = new Turno(turnoEnModificacion.id, Int32.Parse(this.textBoxHI.Text), Int32.Parse(this.textBoxHF.Text), this.textBoxDesc.Text, float.Parse(this.textBoxKM.Text), float.Parse(this.textBoxprecio.Text));
                turnoAActualizar.estado = this.comboBoxEstado.Text;
                new SqlTurnos().actualizarTurno(turnoAActualizar);
                MessageBox.Show("Turno actualizado correctamete");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Comprueba los campos numericos");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show("No hay descripcion");
            }
        }

        public void validar()
        {
            if (this.textBoxDesc.TextLength == 0)
            {
                throw new SystemException();
            }
            float.Parse(this.textBoxKM.Text);
            float.Parse(this.textBoxprecio.Text);
            Int32.Parse(this.textBoxHI.Text);
            Int32.Parse(this.textBoxHF.Text);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            new BusquedaTurno().Show();
            this.Close();
        }
    }
}
