﻿using System;
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

namespace UberFrba.Abm_Automovil
{
    public partial class buscadorAutomovil : Form
    {
        BindingList<Automovil> autos;
        
        public buscadorAutomovil()
        {
            InitializeComponent();
            this.buttonLimpiar_Click(null, null);
            this.comboBoxMarcas.Items.AddRange(new SqlAutomoviles().getMarcas().ToArray());
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            String busqueda = "";
            if(textBoxChofer.TextLength > 0 ) {
                busqueda = busqueda + "Auto_Chofer LIKE '%" + textBoxChofer.Text + "%'";
            }
            if( this.comboBoxMarcas.SelectedIndex != -1)
            {
                if(!busqueda.Equals("")) {
                    busqueda = busqueda + " AND ";
                }   
                busqueda = busqueda + "Auto_Marca LIKE '%" + this.comboBoxMarcas.Text + "%'";
            }

            if(textBoxModelo.TextLength > 0)
            {
                if(!busqueda.Equals("")) {
                    busqueda = busqueda + " AND ";
                }
                busqueda = busqueda + "Auto_Modelo LIKE '%" + textBoxModelo.Text + "%'";
            }
            if(textBoxPatente.TextLength > 0)
            {
                if(!busqueda.Equals("")) {
                    busqueda = busqueda + " AND ";
                }
                busqueda = busqueda + "Auto_Patente LIKE '%" + textBoxPatente.Text + "%'";
            }
            busqueda = busqueda.Trim();
            if(busqueda.Equals("")) {
                this.buttonLimpiar_Click(null, null);
                return;
            }
            autos = new BindingList<Automovil>(new SqlAutomoviles().getAutomoviles(busqueda));
            dataGridViewAutos.DataSource = new BindingSource(autos, null);
            return;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxChofer.Clear();
            this.comboBoxMarcas.SelectedIndex = -1;
            this.textBoxModelo.Clear();
            this.textBoxPatente.Clear();
            autos = new BindingList<Automovil>(new SqlAutomoviles().getAutomoviles(15));
            dataGridViewAutos.DataSource = new BindingSource(autos, null);
        }

        private void editarAuto(object sender, EventArgs e)
        {
            new modificarAutomovil(this.dataGridViewAutos.SelectedRows[0].DataBoundItem as Automovil).Show();
            this.Close();
        }

        private void buttonResetMarcas_Click(object sender, EventArgs e)
        {
            this.comboBoxMarcas.SelectedIndex = -1;
        }

    }
}
