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

        private String anio;
        private String trimestre;

        
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
            cmd.Parameters.Add(new SqlParameter("@trimestre", trimestre));
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
            cmd.Parameters.Add(new SqlParameter("@trimestre", trimestre));
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
            cmd.Parameters.Add(new SqlParameter("@trimestre", trimestre));
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
            cmd.Parameters.Add(new SqlParameter("@trimestre", trimestre));
            conexion.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = da;
            conexion.Close();
        }

        private void cbCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            trimestre = cbCuatrimestre.SelectedItem.ToString();
            anio = tbAño.Text;
            
        }






    }
}
