using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        /*
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbNombreUsuario != null && tbContraseña != null && maskedTextBox1 != null)
            {
                username = tbNombreUsuario.Text;
                password = tbContraseña.Text;
                dni = Convert.ToInt32(maskedTextBox1);

                int resultado = new SqlAltaUsuario().crearUsuario(username, password, dni);
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

        }
        */
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            tbNombreUsuario.Clear();
            tbContraseña.Clear();
            tbDni.Clear();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (cbChofer.Checked == false && cbCliente.Checked == false)
            {
                MessageBox.Show("Debe elegir al menos un rol para crear su usuario");
            }
            else
            {
                if (tbNombreUsuario != null && tbContraseña != null && tbDni != null)
                {
                    username = tbNombreUsuario.Text;
                    password = tbContraseña.Text;
                    dni = Convert.ToInt32(tbDni.Text);

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
