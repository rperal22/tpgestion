using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Entidades;

namespace UberFrba
{
    public partial class SeleccionFuncionalidades : Form
    {
        public Usuario usuario; 

        public SeleccionFuncionalidades(Usuario user)
        {
            InitializeComponent();
            this.usuario = user;
            this.comboBoxFuncionalidades.Items.AddRange(usuario.userrol.funcionalidades.ToArray());
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            /*Ak comparar el textbox text selecccionado con un switch e ir poniendo 
             * las ventanas correspondientes a cada nombre*/
            if (comboBoxFuncionalidades.Text.ToLower().Equals("abm automoviles"))
            {
                new ABMAutomovil().Show();
            }
        }


    }
}
