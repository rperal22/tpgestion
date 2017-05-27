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



        public altaUsuario()
        {
            InitializeComponent();
        }

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

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            tbNombreUsuario.Clear();
            tbContraseña.Clear();
            maskedTextBox1.Clear();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
