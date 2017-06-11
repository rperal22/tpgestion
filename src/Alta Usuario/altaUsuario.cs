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
using UberFrba.SQL;

namespace UberFrba.Alta_Usuario
{
    public partial class altaUsuario : Form
    {

        private string username;
        private string password;
        private int dni;
        private int flagRolChofer;
        private int flagRolCliente;

        public altaUsuario()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            tbNombreUsuario.Clear();
            tbContraseña.Clear();
            tbDni.Clear();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (!cbChofer.Checked  && !cbCliente.Checked)
            {
                MessageBox.Show("Debe elegir al menos un rol para crear su usuario");
            }
            else
            {
                if (tbNombreUsuario != null && tbContraseña != null && tbDni != null)
                {
                    username = tbNombreUsuario.Text;
                    password = tbContraseña.Text;
                    if(username.Length ==  0 && password.Length == 0 )
                    {
                        MessageBox.Show("Completar todos los campos");
                    }
                    try
                    {
                        dni = Convert.ToInt32(tbDni.Text);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("El dni acepta solo numero, comprobar.");
                    }
                    if (cbChofer.Checked == true)
                    {
                        flagRolChofer = 1;
                    }
                    else
                    {
                        flagRolChofer = 0;
                    }

                    if (cbCliente.Checked == true)
                    {
                        flagRolCliente = 1;
                    }
                    else
                    {
                        flagRolCliente = 0;
                    }

                    try
                    {
                        int resultado = new SqlAltaUsuario().crearUsuario(username, password, dni, flagRolChofer, flagRolCliente);
                        switch (resultado)
                        {
                            case 0:
                                MessageBox.Show("El nombre de usuario ya existe");
                                break;
                            case 1:
                                MessageBox.Show("Usuario creado correctamente");
                                break;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show(" Debe completar todos los campos");
                }
            }
        }



        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbChofer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbCliente_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
