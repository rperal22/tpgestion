using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Entidades;
using UberFrba.SQL;

namespace UberFrba.Abm_Rol
{
    public partial class listadoSeleccionModificar : Form
    {
        public listadoSeleccionModificar()
        {
            InitializeComponent();
            BindingList<Rol> roles = new BindingList<Rol>(new SqlRoles().getRoles());
            this.dataGridViewRoles.DataSource = new BindingSource(roles, null);
        }

        private void modificarRol(object sender, MouseEventArgs e)
        {
            new ModificacionRol(this.dataGridViewRoles.SelectedRows[0].DataBoundItem as Rol).Show();
            this.Close();
        }
    }
}
