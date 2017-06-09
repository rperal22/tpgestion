using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using UberFrba.SQL;


namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private Int32 anio;
        private Int32 trimestreElegido;
        private Int32 mesInicial;
        private Int32 mesFinal;



        SqlDataAdapter da;
        DataTable dt;

        SqlConnection conexion = SqlGeneral.nuevaConexion();



        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            cbCuatrimestre.Items.Add("primer cuatrimestre");
            cbCuatrimestre.Items.Add("segundo cuatrimestre");
            cbCuatrimestre.Items.Add("tercer cuatrimestre");
            cbCuatrimestre.Items.Add("cuarto cuatrimestre");
        }

        private void btnChoferMayorRecaudacion_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SQLGROUP.consultaChoferMayorRecaudacion", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = da;
            conexion.Close();

        }

        private void btnChoferViajeMasLargo_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SQLGROUP.consultaChoferViajeMasLargo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = da;
            conexion.Close();
        }

        private void btnClienteMayorConsumo_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SQLGROUP.consultaClienteMayorConsumo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = da;
            conexion.Close();
        }

        private void btnClienteMismoAuto_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SQLGROUP.consultaClienteMismoAuto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = da;
            conexion.Close();
        }

        private void cbCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            trimestreElegido = cbCuatrimestre.SelectedIndex;
            switch (trimestreElegido)
            {
                case 0:
                    mesInicial = 1;
                    mesFinal = 3;
                    break;
                case 1:
                    mesInicial = 4;
                    mesFinal = 6;
                    break;
                case 2:
                    mesInicial = 7;
                    mesFinal = 9;
                    break;
                case 3:
                    mesInicial = 10;
                    mesFinal = 12;
                    break;
            }

            anio = Convert.ToInt32(tbAño.Text);

        }

    }
}
