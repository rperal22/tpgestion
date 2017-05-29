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
    public partial class altaTurno : Form
    {
        public altaTurno()
        {
            InitializeComponent();
            this.comboBoxEstado.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                Turno turnoAGuardar = new Turno(-1, Int32.Parse(this.textBoxHI.Text), Int32.Parse(this.textBoxHF.Text), this.textBoxDesc.Text, float.Parse(this.textBoxKM.Text), float.Parse(this.textBoxprecio.Text));
                turnoAGuardar.estado = this.comboBoxEstado.Text;
                new SqlTurnos().guardarTurno(turnoAGuardar);
                MessageBox.Show("Turno guardado correctamete");
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
    }
}
