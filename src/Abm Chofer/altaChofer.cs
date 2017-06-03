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
    public partial class altaChofer : Form
    {
        public altaChofer()
        {
            InitializeComponent();
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                Chofer cf = new Chofer(this.textBoxNombre.Text, this.textBoxApellido.Text, Int32.Parse(this.textBoxDNI.Text), this.textBoxDireccion.Text, Int32.Parse(this.textBoxTel.Text), this.textBoxMail.Text, this.dateTimePickerNacimiento.Value);
                new SqlChoferes().guardarChofer(cf);
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validar()
        {
            if (!(textBoxApellido.TextLength > 0 && textBoxNombre.TextLength > 0 && textBoxDNI.TextLength > 0 && textBoxDireccion.TextLength > 0  && textBoxTel.TextLength > 0 )) {
                throw new SystemException("Completar datos obligatorios");
            }
        }
    }
}
