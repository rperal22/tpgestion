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
        public List<Turno> turnosElegidos;

        public altaAutomovil()
        {
            InitializeComponent();
            this.turnos = new SqlTurnos().getAllTurnos();
            this.turnosElegidos = new List<Turno>();
            this.comboBox1.DisplayMember = "desc";
            this.comboBox1.ValueMember = "this";
            this.comboBox1.DataSource = this.turnos;
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (this.turnosElegidos.Contains((Turno)this.comboBox1.SelectedValue))
            {
                this.turnosElegidos.Remove((Turno)this.comboBox1.SelectedValue);
                this.actualizarTextBox();
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!this.turnosElegidos.Contains((Turno)this.comboBox1.SelectedValue))
            {
                this.turnosElegidos.Add((Turno)this.comboBox1.SelectedValue);
                this.actualizarTextBox();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                Automovil autoNuevo = new Automovil(this.textBoxPatente.Text, this.textBoxMarca.Text, this.textBoxModelo.Text, Int32.Parse(this.textBoxChofer.Text), this.turnosElegidos, this.textBoxLicencia.Text, this.textBoxRodado.Text);
                new SqlAutomoviles().guardarAutomovil(autoNuevo);
            }
            catch(FormatException ex) {
                MessageBox.Show("Compruebe el chofer");
            }
            catch (NotImplementedException ex) {
            }
        }

        private void validar()
        {
            if(!(this.textBoxPatente.Text.Length > 0 && this.textBoxMarca.Text.Length > 0 && this.textBoxModelo.Text.Length > 0)) {
                MessageBox.Show("Completar los campos obligatorios");
                throw new NotImplementedException();
            }
            if(this.turnosElegidos.Count == 0) {
                MessageBox.Show("Tiene que tener al menos un turno");
                throw new NotImplementedException();
            }
            Int32.Parse(this.textBoxChofer.Text);
           
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarTextBox()
        {
            String texto = "";
            foreach (Turno tur in this.turnosElegidos)
            {
                texto = texto + tur.desc + Environment.NewLine;
            }
            this.textBoxTurnos.Text = texto;
        }

    }
}
