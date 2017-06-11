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
            SqlCommand cmd = new SqlCommand("INSERT INTO SQLGROUP.Viajes(Viaje_Cant_Kilometros,Viaje_Fecha,Viaje_Fecha_Inic, Viaje_Fecha_Fin, Viaje_Chofer_Id, Viaje_Auto_Id, Viaje_Turno_Id, Viaje_Cliente_Id) " +
                                            " VALUES(@kilometros,@vf,@vfi,@vff,@vchi,SQLGROUP.getAutoId(@vap),@vti,@vci)", conexion);
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

        public DataTable getViajes(DateTime fechaInicio, DateTime fechaFin, Cliente cliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Viaje_Id as 'Id', Viaje_Cant_Kilometros as 'Cantidad de kilometros', Viaje_Fecha_INIC as 'Fecha de inicio', Viaje_Fecha_Fin as 'Fecha de finalizacion', Viaje_Chofer_Id as 'Chofer id', SQLGROUP.getAutoPatente(Viaje_Auto_Id) as 'Auto Patente' , (Viaje_Cant_Kilometros*Turno_Valor_Kilometro)+Turno_Precio_Base as 'Precio del viaje'" +
                                              " FROM SQLGROUP.Viajes, SQLGROUP.Turno WHERE Viaje_Turno_Id = Turno_Id AND Viaje_Cliente_Id = @id AND SQLGROUP.entreFechasNoCuentaMinutosSegundo(@fechaInicio, @fechaFin,Viaje_Fecha_Fin) = 1", conexion);
            query.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            query.Parameters.AddWithValue("@fechaFin", fechaFin);
            query.Parameters.AddWithValue("@id", cliente.id);
            conexion.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public DataTable getViajes(DateTime fecha, Chofer chofer, Turno turno)
        {
            List<Viaje> viajes = new List<Viaje>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Viaje_Id as 'Id', Viaje_Cant_Kilometros as 'Cantidad de kilometros', Viaje_Fecha_INIC as 'Fecha de inicio', Viaje_Fecha_Fin as 'Fecha de finalizacion', Viaje_Cliente_Id as 'Cliente id', SQLGROUP.getAutoPatente(Viaje_Auto_Id) as 'Auto Patente' , (Viaje_Cant_Kilometros*Turno_Valor_Kilometro)+Turno_Precio_Base as 'Precio del viaje'" +
                                              " FROM SQLGROUP.Viajes, SQLGROUP.Turno WHERE Turno_Id = @turnoid AND Viaje_Chofer_Id = @id AND Viaje_Turno_Id = @turnoid AND DAY(@fecha)=DAY(Viaje_Fecha_INIC) AND MONTH(@fecha) = MONTH(Viaje_Fecha_INIC) AND YEAR(@fecha) = YEAR(Viaje_Fecha_INIC)", conexion);
            query.Parameters.AddWithValue("@fecha", fecha);
            query.Parameters.AddWithValue("@id", chofer.id);
            query.Parameters.AddWithValue("@turnoid", turno.id);
            conexion.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
                return dt;
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
