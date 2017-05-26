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

namespace UberFrba
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private string username;
        private string password;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                username = textBox1.Text;
                password = textBox2.Text;
                int resultado = new SqlUsuarios().loguear(username, password);
                switch (resultado)
                {
                        case 0:
                            MessageBox.Show("Usuario inhabilitado. Por favor, contacte a su administrador de sistemas");
                            break;
                        case 1:
                            MessageBox.Show("Ha ingresado correctamente. Bienvenido al Sistema UBER FRBA");
                            // aca se creara el usuario, se cargaran sus roles y se abriran ventanas sucesivas para elegir roly funcionalidades
                            // Salvo para el admin general, el cual ira directo a la pantalla de funcionalidades, con todas las funcionalidades habilitadas
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

        private void button3_Click(object sender, EventArgs e)
        {
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
}}
