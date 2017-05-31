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

namespace UberFrba.Abm_Rol
{
    public partial class ModificacionRol : Form
    {
        private Rol rol;
        List<Funcionalidad> funcionalidades;
        List<Funcionalidad> funcSeleccionadas;
        public ModificacionRol(Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.funcSeleccionadas = this.rol.funcionalidades;
            this.funcionalidades = new SqlRoles().getFuncionesTotales();
            this.comboBoxFuncionalidades.DisplayMember = "nombreFuncion";
            this.comboBoxFuncionalidades.ValueMember = "this";
            this.comboBoxFuncionalidades.DataSource = funcionalidades;
            this.comboBoxEstado.Text = rol.estado;
            this.textBoxNombre.Text = rol.nombre;
            this.textBoxDesc.Text = rol.desc;
            this.actualizarTextBox();
        }

        private void ButtonRemover_Click(object sender, EventArgs e)
        {
            if (this.funcSeleccionadas.Any(elem => elem.nombreFuncion.Equals(((Funcionalidad)this.comboBoxFuncionalidades.SelectedValue).nombreFuncion)))
            {
                this.funcSeleccionadas.Remove(this.funcSeleccionadas.Find(elem => elem.nombreFuncion.Equals(((Funcionalidad)this.comboBoxFuncionalidades.SelectedValue).nombreFuncion)));
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("No esta seleccionado esta funcionalidad");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!this.funcSeleccionadas.Any(elem => elem.nombreFuncion.Equals(((Funcionalidad)this.comboBoxFuncionalidades.SelectedValue).nombreFuncion)))
            {
                this.funcSeleccionadas.Add(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad);
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("Ya esta agregada esta funcionalidad");
        }

        private void validar()
        {
            if (this.funcSeleccionadas.Count <= 0)
            {
                SystemException ex = new SystemException("Debes seleccionar al menos una funcionalidad");
                throw ex;
            }
            if (this.textBoxNombre.TextLength <= 0)
            {
                SystemException ex = new SystemException("Debes ponerle un nombre");
                throw ex;
            }
            if (this.comboBoxEstado.SelectedIndex == -1)
            {
                SystemException ex = new SystemException("Seleccione un estado");
                throw ex;
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                new SqlRoles().actualizarRol(new Rol(this.textBoxNombre.Text, this.comboBoxEstado.Text, this.textBoxDesc.Text, this.funcSeleccionadas),rol);
                MessageBox.Show("Modificado con exito");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void actualizarTextBox()
        {
            this.textBoxFuncionalidades.Clear();
            String total = "";
            foreach (Funcionalidad func in this.funcSeleccionadas)
            {
                total += func.nombreFuncion + Environment.NewLine;
            }
            this.textBoxFuncionalidades.Text = total;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            new listadoSeleccionModificar().Show();
        }

    }
}
