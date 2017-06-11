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

        
        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            cbCuatrimestre.Items.Add("primer cuatrimestre");
            cbCuatrimestre.Items.Add("segundo cuatrimestre");
            cbCuatrimestre.Items.Add("tercer cuatrimestre");
            cbCuatrimestre.Items.Add("cuarto cuatrimestre");
            this.cbCuatrimestre.SelectedIndex = 0;
            dgvResultados.ReadOnly = true;
        }

        private void btnChoferMayorRecaudacion_Click(object sender, EventArgs e)
        {
            this.setearParametrosDeBusqueda();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SELECT TOP 5 Chofer_Nombre as 'Chofer Nombre', Chofer_Apellido as 'Chofer Apellido',SUM(Rendicion_Importe) AS 'Recaudacion' " +
	                                        "FROM SQLGROUP.Choferes c JOIN SQLGROUP.Rendiciones r ON c.Chofer_Id = r.Rendicion_Chofer_Id " +
                                            "WHERE YEAR(r.Rendicion_Fecha) = @anio AND MONTH(r.Rendicion_Fecha) BETWEEN @mesInicial AND @mesFinal " +
	                                        "GROUP BY c.Chofer_Nombre, c.Chofer_Apellido " +
	                                        "ORDER BY SUM(r.Rendicion_Importe) DESC", conexion);
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = dt;
            conexion.Close();
        }

        private void btnChoferViajeMasLargo_Click(object sender, EventArgs e)
        {
            this.setearParametrosDeBusqueda();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SELECT TOP 5 Chofer_Nombre as 'Chofer Nombre',Chofer_Apellido as 'Chofer Apellido',Viaje_Cant_Kilometros AS 'Kilometros Recorridos' " +
	                                        " FROM SQLGROUP.Choferes c INNER JOIN SQLGROUP.Viajes v ON c.Chofer_Id = v.Viaje_Chofer_Id " +
	                                        " WHERE YEAR(v.Viaje_Fecha) = @anio AND MONTH(v.Viaje_Fecha) BETWEEN @mesInicial AND @mesFinal " +
	                                        " ORDER BY v.Viaje_Cant_Kilometros DESC", conexion);
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = dt;
            conexion.Close();
        }

        private void btnClienteMayorConsumo_Click(object sender, EventArgs e)
        {
            this.setearParametrosDeBusqueda();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SELECT TOP 5 Cliente_Nombre as 'Cliente Nombre' ,Cliente_Apellido as 'Cliente Apellido', SUM(Factura_Total) AS 'Consumo total' " +
	                                        " FROM SQLGROUP.Clientes c INNER JOIN SQLGROUP.Facturas f ON c.Cliente_Id = f.Factura_Cliente_Id " +
	                                        " WHERE YEAR(f.Factura_Fecha) = @anio AND MONTH(f.Factura_Fecha) BETWEEN @mesInicial AND @mesFinal " +
	                                        " GROUP BY c.Cliente_Nombre, c.Cliente_Apellido " +
	                                        " ORDER BY SUM(f.Factura_Total) DESC", conexion);
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = dt;
            conexion.Close();
        }

        private void btnClienteMismoAuto_Click(object sender, EventArgs e)
        {
            this.setearParametrosDeBusqueda();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SELECT TOP 5 Cliente_Nombre as 'Cliente Nombre', Cliente_Apellido as 'Cliente Apellido', SQLGROUP.getAutoPatente(Viaje_Auto_Id) as  'Automovil' ,COUNT(Viaje_Auto_Id) AS 'Cantidad de viajes' " +
	                                        " FROM SQLGROUP.Clientes c INNER JOIN SQLGROUP.Viajes v ON c.Cliente_Id = v.Viaje_Cliente_Id " +
	                                        " WHERE YEAR(v.Viaje_Fecha) = @anio AND MONTH(v.Viaje_Fecha) BETWEEN @mesInicial AND @mesFinal " +
                                            " GROUP BY c.Cliente_Nombre, c.Cliente_Apellido, v.Viaje_Auto_Id " +
                                            " ORDER BY COUNT(v.Viaje_Auto_Id) DESC", conexion);
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.Parameters.Add(new SqlParameter("@mesInicial", mesInicial));
            cmd.Parameters.Add(new SqlParameter("@mesFinal", mesFinal));
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResultados.DataSource = dt;
            conexion.Close();
        }

        private void setearParametrosDeBusqueda()
        {
            if(!(cbCuatrimestre.SelectedIndex>=0)) {
                MessageBox.Show("Por favor seleccione algun trimestres");
            }
            else if((tbAño.TextLength==0)) {
                MessageBox.Show("Ingrese algun año");
            }
            else 
            {
                try {
                    anio = Convert.ToInt32(tbAño.Text);
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
                }
                catch(FormatException ex)
                {
                    MessageBox.Show("Año invalido");
                }   
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
