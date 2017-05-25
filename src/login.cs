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

namespace UberFrba
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private static string username;
        private static string password;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {

                username = textBox1.Text;
                password = textBox2.Text; 
                
                string connection = conexionBase.ObtenerStringConexion();
                SqlConnection conexion = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("SQLGROUP.login", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // instancio parametro de salida
                SqlParameter VariableRetorno = new SqlParameter("@a", SqlDbType.Int);
                VariableRetorno.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@usuario", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(VariableRetorno);

                conexion.Open();
                cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login

                switch (Convert.ToInt32(cmd.Parameters["@a"].Value))
                    {
                        case 4:
                            {
                                MessageBox.Show("No Existe el usuario");
                                conexion.Close();
                                break;
                            }
                        case 2:
                            {
                                MessageBox.Show("Contraseña incorrecta. Recuerde que al tercer intento fallido su usuario sera deshabilitado");
                                conexion.Close();
                                break;
                            }
                        case 3:
                            {
                                conexion.Close();
                                MessageBox.Show("Ha ingresado correctamente. Bienvenido al Sistema UBER FRBA");

                                // aca se creara el usuario, se cargaran sus roles y se abriran ventanas sucesivas para elegir roly funcionalidades
                                // Salvo para el admin general, el cual ira directo a la pantalla de funcionalidades, con todas las funcionalidades habilitadas


                                break;
                            }

                        case 1:
                            {
                                MessageBox.Show("Cantidad limite de fallos alcanzada. Al proximo intento fallido su usuario sera deshabilitado");
                                conexion.Close();
                                break;
                            }
                        case 0:
                            {
                                MessageBox.Show("Usuario inhabilitado. Por favor, contacte a su administrador de sistemas");
                                conexion.Close();
                                break;
                            }
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
