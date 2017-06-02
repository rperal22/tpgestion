using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace UberFrba.SQL
{
    class SqlCargaViajes
    {
        public int cargarViaje(String chofer, Decimal kilometros, String turno, DateTime fechaInicio, DateTime fechaFin, String auto, Int32 turnoID, Int32 clienteID)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SQLGROUP.cargarViaje", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // instancio parametro de salida
            SqlParameter VariableRetorno = new SqlParameter("@resultado", SqlDbType.Int);
            VariableRetorno.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@nombreChofer", chofer));
            cmd.Parameters.Add(new SqlParameter("@kilometros", kilometros));
            cmd.Parameters.Add(new SqlParameter("@turno", turno));
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@auto", auto));
            cmd.Parameters.Add(new SqlParameter("@turnoID", turnoID));
            cmd.Parameters.Add(new SqlParameter("@clienteID", clienteID));
            cmd.Parameters.Add(VariableRetorno);

            conexion.Open();
            cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login
            int resultado = (int)cmd.Parameters["@resultado"].Value;
            conexion.Close();
            return resultado;
            

        }
    }
}
