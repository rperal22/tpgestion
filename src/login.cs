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
using UberFrba.Alta_Usuario;

namespace UberFrba
{
    public partial class login : Form
    {
        private string username;
        private string password;

        public login()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxUsuario.Clear();
            textBoxPassword.Clear();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text != null && textBoxPassword.Text != null)
            {
                username = textBoxUsuario.Text;
                password = textBoxPassword.Text;
                int resultado = new SqlUsuarios().loguear(username, password);
                switch (resultado)
                {
                    case 0:
                        MessageBox.Show("Usuario inhabilitado. Por favor, contacte a su administrador de sistemas");
                        break;
                    case 1:
                        this.habilitarSeleccionDeRoles();
                        break;
                    case 2:
                        MessageBox.Show("Contraseña incorrecta. Recuerde que al tercer intento fallido su usuario sera deshabilitado");
                        break;
                    case 3:
                        MessageBox.Show("No Existe el usuario");
                        break;
                }
            }
        }

        private void buttonListo_Click(object sender, EventArgs e)
        {
            new SeleccionFuncionalidades(new Usuario(username,new Rol(new SqlUsuarios().getFuncionesRoles((string)this.comboBoxRoles.SelectedItem)))).Show();
        }

        private void habilitarSeleccionDeRoles()
        {
            this.textBoxPassword.Enabled = false;
            this.textBoxUsuario.Enabled = false;
            this.labelRol.Visible = true;
            this.labelRol.Enabled = true;
            this.comboBoxRoles.Visible = true;
            this.comboBoxRoles.Enabled = true;
            this.comboBoxRoles.Items.AddRange(new SqlUsuarios().getRolesUsuario(username).ToArray());
            this.comboBoxRoles.SelectedIndex = 0;
            this.buttonListo.Visible = true;
            this.buttonListo.Enabled = true;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            altaUsuario frm = new altaUsuario();
            frm.Show();
        }
}}
