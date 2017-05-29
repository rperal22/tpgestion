using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace UberFrba.SQL
{
    class SqlAltaUsuario
    {

        public int crearUsuario(String username, String password, Int32 dni, Int32 flagRolChofer, Int32 flagRolCliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SQLGROUP.crearUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;


            // instancio parametro de salida
            SqlParameter VariableRetorno = new SqlParameter("@resultado", SqlDbType.Int);
            VariableRetorno.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@dni", dni));
            cmd.Parameters.Add(new SqlParameter("@flagChofer", flagRolChofer ));
            cmd.Parameters.Add(new SqlParameter("@flagCliente", flagRolCliente));
            cmd.Parameters.Add(VariableRetorno);

            conexion.Open();
            cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login
            int resultado = (int)cmd.Parameters["@resultado"].Value;
            conexion.Close();
            return resultado;
        }



    }
}
