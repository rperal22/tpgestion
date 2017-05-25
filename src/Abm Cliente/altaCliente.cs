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
            textBoxTel.Clear();
            textBoxDireccion.Clear();
            textBoxCodPos.Clear();
            textBoxMail.Clear();
            textBoxFecNac.Clear();
      
        }

        private void button2_Click(object sender, EventArgs e) //Guardar
        {
           
                


        }


         



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {
      

        }

        private void maskedTextDNI_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
