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
    public partial class modificarAutomovil : Form
    {
        public List<Turno> turnos;
        public Automovil auto;

        public modificarAutomovil(Automovil automovil)
        {
            InitializeComponent();
            this.turnos = new SqlTurnos().getAllTurnos();
            this.auto = automovil;
            this.comboBox1.DisplayMember = "desc";
            this.comboBox1.ValueMember = "this";
            this.comboBox1.DataSource = this.turnos;
            this.auto.turnos = new SqlAutomoviles().getTurnosAuto(this.auto.patente);
            this.actualizarTextBox();
            this.textBoxChofer.Text = this.auto.chofer.ToString();
            this.textBoxLicencia.Text = this.auto.licencia;
            this.textBoxMarca.Text = this.auto.marca;
            this.textBoxModelo.Text = this.auto.modelo;
            this.textBoxRodado.Text = this.auto.rodado;
            this.labelPatente.Text = this.auto.patente;
            this.comboBoxEstado.Text = this.auto.estado;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            new buscadorAutomovil().Show();
            this.Close();
        }

        private void actualizarTextBox()
        {
            String texto = "";
            foreach (Turno tur in this.auto.turnos)
            {
                texto = texto + tur.desc + Environment.NewLine;
            }
            this.textBoxTurnos.Text = texto;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();//No actualiza por ahora
                new SqlAutomoviles().actualizarAutomovil(new Automovil(this.labelPatente.Text, this.textBoxMarca.Text, this.textBoxModelo.Text, Int32.Parse(this.textBoxChofer.Text), this.auto.turnos, this.textBoxLicencia.Text, this.textBoxRodado.Text, this.comboBoxEstado.Text),this.auto.patente);
                new buscadorAutomovil().Show();
                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Compruebe el chofer");
            }
            catch (NotImplementedException ex)
            {
            }
        }

        private void validar()
        {
            if (!(this.labelPatente.Text.Length > 0 && this.textBoxMarca.Text.Length > 0 && this.textBoxModelo.Text.Length > 0))
            {
                MessageBox.Show("Completar los campos obligatorios");
                throw new NotImplementedException();
            }
            if (this.auto.turnos.Count == 0)
            {
                MessageBox.Show("Tiene que tener al menos un turno");
                throw new NotImplementedException();
            }
            Int32.Parse(this.textBoxChofer.Text);

        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (this.auto.turnos.Any(elem => ((Turno)this.comboBox1.SelectedValue).id == elem.id))
            {
                this.auto.turnos.Remove(this.auto.turnos.Find(elem => ((Turno)this.comboBox1.SelectedValue).id == elem.id));
                this.actualizarTextBox();
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!this.auto.turnos.Any(elem => ((Turno)this.comboBox1.SelectedValue).id == elem.id ))
            {
                this.auto.turnos.Add((Turno)this.comboBox1.SelectedValue);
                this.actualizarTextBox();
            }
        }
    }
}
