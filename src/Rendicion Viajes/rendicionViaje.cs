using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.SQL;



namespace UberFrba.Rendicion_Viajes
{
    public partial class rendicionViaje : Form
    {

        private DateTime fecha;
        private String chofer;
        private String turno;
        private Decimal rendicionTotal;

        SqlDataReader dr;
        SqlConnection conexion = SqlGeneral.nuevaConexion();



        public rendicionViaje()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbRendicionTotal.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rendicionViaje_Load(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT Chofer_Nombre FROM SQLGROUP.Choferes", conexion);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbChoferes.Items.Add(dr["Nombre_Chofer"].ToString());
            }
            dr.Close();
            conexion.Close();
        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            turno = cbTurno.SelectedItem.ToString();
        }

        private void cbChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            chofer = cbChoferes.SelectedItem.ToString();
            SqlCommand query = new SqlCommand("SELECT Turno_Descripcion FROM SQLGROUP.Turno ,SQLGROUP.Chofer_Turno, SQLGROUP.Choferes WHERE Chofer_Id = Ct_Chofer_Id AND Turno_Id = Ct_Turno_Id AND Chofer_Nombre LIKE @chofer Group BY Turno_Descripcion", conexion);
            query.Parameters.AddWithValue("@chofer", chofer);
            conexion.Open();
            dr = query.ExecuteReader();
            while (dr.Read())
            {
                cbTurno.Items.Add(dr["Turno_Descripcion"].ToString());
            }
            dr.Close();
            conexion.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fecha = dateTimePicker1.Value;
        }

        private void btnCalcularRendicion_Click(object sender, EventArgs e)
        {
            rendicionTotal = new SqlRendicion().calcularRendicion(fecha, chofer, turno);
            tbRendicionTotal.Text = rendicionTotal.ToString();

        }
    }
}
