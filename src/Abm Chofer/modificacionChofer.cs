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

namespace UberFrba.Abm_Chofer
{
    public partial class modificacionChofer : Form
    {
        private Chofer choferOriginal;
        public modificacionChofer(Chofer cf)
        {
            InitializeComponent();
            this.choferOriginal = cf;
            this.textBoxApellido.Text = cf.apellido;
            this.textBoxNombre.Text = cf.nombre;
            this.textBoxTel.Text = cf.telefono.ToString();
            this.textBoxDNI.Text = cf.dni.ToString();
            this.textBoxMail.Text = cf.mail;
            this.textBoxDireccion.Text = cf.direccion;
            this.dateTimePickerNacimiento.Value = cf.fechaNacimiento;
            this.comboBox1.Text = cf.estado;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            new listadoSeleccionBajaChofer().Show();
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                Chofer cf = new Chofer(this.textBoxNombre.Text, this.textBoxApellido.Text, Int32.Parse(this.textBoxDNI.Text), this.textBoxDireccion.Text, Int32.Parse(this.textBoxTel.Text), this.textBoxMail.Text, this.dateTimePickerNacimiento.Value, this.comboBox1.Text);
                new SqlChoferes().updateChofer(cf,choferOriginal.id);
                MessageBox.Show("Actualizado correctamente");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Compruebe los campos numericos");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxApellido.Clear();
            this.textBoxDireccion.Clear();
            this.textBoxNombre.Clear();
            this.textBoxDNI.Clear();
            this.textBoxMail.Clear();
            this.textBoxTel.Clear();
        }

        private void validar()
        {
            if (!(textBoxApellido.TextLength > 0 && textBoxNombre.TextLength > 0 && textBoxDNI.TextLength > 0 && textBoxDireccion.TextLength > 0 && textBoxTel.TextLength > 0))
            {
                throw new SystemException("Completar datos obligatorios");
            }
        }
    }
}
