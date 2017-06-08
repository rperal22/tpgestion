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
    class SqlRendicion
    {

        public float calcularRendicion(DateTime fecha, Chofer chofer, Turno turno)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT ISNULL(SUM(Turno_Precio_Base + Turno_Valor_Kilometro*Viaje_Cant_Kilometros),0) FROM SQLGROUP.Viajes,SQLGROUP.Turno WHERE Viaje_Chofer_Id = @choferid AND Viaje_Turno_Id=@turnoid AND Turno_id = @turnoid AND DAY(@fecha)=DAY(Viaje_Fecha_INIC) AND MONTH(@fecha) = MONTH(Viaje_Fecha_INIC) AND YEAR(@fecha) = YEAR(Viaje_Fecha_INIC)", conexion);
            query.Parameters.AddWithValue("@choferid", chofer.id);
            query.Parameters.AddWithValue("@turnoid", turno.id);
            query.Parameters.AddWithValue("@fecha", fecha);
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
