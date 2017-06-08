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
using UberFrba.ABM_Chofer;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Entidades;
using UberFrba.Facturacion;
using UberFrba.Registro_Viajes;

namespace UberFrba
{
    public partial class SeleccionFuncionalidades : Form
    {
        public Usuario usuario; 

        public SeleccionFuncionalidades(Usuario user)
        {
            InitializeComponent();
            this.usuario = user;
            this.comboBoxFuncionalidades.DisplayMember = "nombreFuncion";
            this.comboBoxFuncionalidades.ValueMember = "this";
            this.comboBoxFuncionalidades.DataSource = this.usuario.userrol.funcionalidades;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            /*Ak comparar el textbox text selecccionado con un switch e ir poniendo 
             * las ventanas correspondientes a cada nombre*/
            if (comboBoxFuncionalidades.Text.ToLower().Equals("abm automoviles"))
            {
                new ABMAutomovil().Show();
            }
            else if (comboBoxFuncionalidades.Text.ToLower().Equals("abm turno"))
            {
                new ABMTurno().Show();
            }
            else if (comboBoxFuncionalidades.Text.ToLower().Equals("abm rol"))
            {
                new ABMRol().Show();
            }
            else if (comboBoxFuncionalidades.Text.ToLower().Equals("abm de choferes"))
            {
                new ABMChofer().Show();
            }
            else if (comboBoxFuncionalidades.Text.ToLower().Equals("registrar viaje"))
            {
                new registroViaje().Show();
            }
            else if (comboBoxFuncionalidades.Text.ToLower().Equals("facturar"))
            {
                new Facturar().Show();
            }
        }


    }
}
