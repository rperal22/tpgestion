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

namespace UberFrba.Abm_Cliente
{
    public partial class altaCliente : Form
    {
        public altaCliente()
        {
            InitializeComponent();
            this.comboBoxEstado.SelectedIndex = 0;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                new SqlClientes().guardarCliente(new Cliente(this.textBoxNombre.Text, this.textBoxApellido.Text, Int32.Parse(this.textBoxDni.Text), this.textBoxDireccion.Text, Int32.Parse(this.textBoxTel.Text), this.textBoxMail.Text, this.dateTimePickerNacimiento.Value, this.comboBoxEstado.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Compruebe los campos numericos(dni,telefono)");
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxTel.Clear();
            textBoxDireccion.Clear();
            textBoxCodPos.Clear();
            textBoxMail.Clear();   
        }

        private void validar()
        {
            if (!(this.textBoxApellido.TextLength > 0 &&
                this.textBoxNombre.TextLength > 0 &&
                this.textBoxDireccion.TextLength > 0 &&
                this.textBoxCodPos.TextLength > 0 &&
                this.textBoxTel.TextLength > 0))
            {
                throw new SystemException("Complete campos obligatorios");
            } 
        }

    }
}
