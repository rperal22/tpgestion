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
    public partial class altaRol : Form
    {
        private List<Funcionalidad> funcionalidades;
        private List<Funcionalidad> funcSeleccionadas;

        public altaRol()
        {
            InitializeComponent();
            funcionalidades = new SqlRoles().getFuncionesTotales();
            funcSeleccionadas = new List<Funcionalidad>();
            this.comboBoxFuncionalidades.DisplayMember = "nombreFuncion";
            this.comboBoxFuncionalidades.ValueMember = "this";
            this.comboBoxFuncionalidades.DataSource = funcionalidades;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxNombre.Clear();
            this.funcSeleccionadas.Clear();
            this.actualizarTextBox();
        }

        private void ButtonRemover_Click(object sender, EventArgs e)
        {
            if (this.funcSeleccionadas.Contains(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad))
            {
                this.funcSeleccionadas.Remove(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad);
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("No esta seleccionado esta funcionalidad");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!this.funcSeleccionadas.Contains(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad))
            {
                this.funcSeleccionadas.Add(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad);
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("Ya esta agregada esta funcionalidad");
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

        }

    }
}
