using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.SQL
{
    class SqlRendicion
    {

        public int calcularRendicion(DateTime fecha, String chofer, String turno)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SQLGROUP.calcularRendicion", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // instancio parametro de salida
            SqlParameter VariableRetorno = new SqlParameter("@resultado", SqlDbType.Int);
            VariableRetorno.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@nombreChofer", chofer));
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            cmd.Parameters.Add(new SqlParameter("@turno", turno));
            cmd.Parameters.Add(VariableRetorno);

            conexion.Open();
            cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login
            int resultado = (int)cmd.Parameters["@resultado"].Value;
            conexion.Close();
            return resultado;


        }
            


    }
}
