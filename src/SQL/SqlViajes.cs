using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UberFrba.Entidades;



namespace UberFrba.SQL
{
    class SqlViajes
    {
        public void cargarViaje(Chofer chofer, float kilometros, Turno turno, DateTime fechaInicio, DateTime fechaFin, Automovil auto, Cliente cliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("INSERT INTO SQLGROUP.Viajes(Viaje_Cant_Kilometros,Viaje_Fecha,Viaje_Fecha_Inic, Viaje_Fecha_Fin, Viaje_Chofer_Id, Viaje_Auto_Patente, Viaje_Turno_Id, Viaje_Cliente_Id) " +
                                            " VALUES(@kilometros,@vf,@vfi,@vff,@vchi,@vap,@vti,@vci)", conexion);
            cmd.Parameters.AddWithValue("kilometros",kilometros);
            cmd.Parameters.AddWithValue("vf", fechaInicio);
            cmd.Parameters.AddWithValue("vfi", fechaInicio);
            cmd.Parameters.AddWithValue("vff", fechaFin);
            cmd.Parameters.AddWithValue("vchi", chofer.id);
            cmd.Parameters.AddWithValue("vap", auto.patente);
            cmd.Parameters.AddWithValue("vti", turno.id);
            cmd.Parameters.AddWithValue("vci", cliente.id);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
