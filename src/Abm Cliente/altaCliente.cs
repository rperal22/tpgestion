using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class altaCliente : Form
    {
        public altaCliente()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDNI.Clear();
            textBoxTel.Clear();
            textBoxDireccion.Clear();
            textBoxMail.Clear();
            textBoxFecNac.Clear();
        }

        private void button2_Click(object sender, EventArgs e) //Guardar
        {
            //Conexion a base de datos
            conexionBase.ObtenerStringConexion();
            try
            {
                //Verificación de campos obligatorios
                string mensaje = "";
                
                if (textBoxNombre.Text == "")
                {
                    mensaje = mensaje + "INGRESE NOMBRE ";
                }

                if (textBoxApellido.Text == "")
                {
                    mensaje = mensaje + "INGRESE APELLIDO ";
                }

                if (textBoxDNI.Text == "")
                {
                    mensaje = mensaje + "INGRESE DNI ";
                }

                //VER TELEFONO DATO UNICO

                if (textBoxDireccion.Text == "")
                {
                    mensaje = mensaje + "INGRESE DIRECCION ";
                }

                if (textBoxCodPos.Text == "")
                {
                    mensaje = mensaje + "CODIGO POSTAL ";
                }

                if (textBoxFecNac.Text == "")
                {
                    mensaje = mensaje + "INGRESE FECHA DE NACIMIENTO ";
                }








            }
        }







        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
