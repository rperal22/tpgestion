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

        public List<Viaje> getViajes(DateTime fechaInicio, DateTime fechaFin, Cliente cliente)
        {
            List<Viaje> viajes = new List<Viaje>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Viaje_Id, Viaje_Cant_Kilometros, Viaje_Fecha_INIC, Viaje_Fecha_Fin, Viaje_Chofer_Id, Viaje_Auto_Patente, Viaje_Turno_Id, Viaje_Cliente_Id " +
                                              " FROM SQLGROUP.Viajes WHERE Viaje_Cliente_Id = @id AND SQLGROUP.entreFechasNoCuentaMinutosSegundo(@fechaInicio, @fechaFin,Viaje_Fecha_Fin) = 1", conexion);
            query.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            query.Parameters.AddWithValue("@fechaFin", fechaFin);
            query.Parameters.AddWithValue("@id", cliente.id);
            conexion.Open();
            try
            {
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Viaje viaje = new Viaje(reader.GetInt32(0), (float)reader.GetDecimal(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(5), reader.GetInt32(4), reader.GetInt32(6), reader.GetInt32(7));
                    viajes.Add(viaje);
                }
                conexion.Close();
                return viajes;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public float getFacturacionViajes(DateTime fechaInicio, DateTime fechaFin, Cliente cliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT ISNULL(SUM(Turno_Precio_Base + Turno_Valor_Kilometro*Viaje_Cant_Kilometros),0) FROM SQLGROUP.Viajes, SQLGROUP.Turno WHERE SQLGROUP.entreFechasNoCuentaMinutosSegundo(@fechaInicio, @fechaFin,Viaje_Fecha_Fin) = 1  AND Viaje_Cliente_Id = @id AND Turno_Id = Viaje_Turno_Id", conexion);
            query.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            query.Parameters.AddWithValue("@fechaFin", fechaFin);
            query.Parameters.AddWithValue("@id", cliente.id);
            try
            {
                conexion.Open();
                SqlDataReader results = query.ExecuteReader();
                results.Read();
                float valor = (float)results.GetDecimal(0);
                conexion.Close();
                return valor;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
    }
}
