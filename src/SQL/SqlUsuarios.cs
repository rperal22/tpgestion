using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Entidades;

namespace UberFrba.SQL
{
    class SqlUsuarios
    {

        public int loguear(String username, String password)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SQLGROUP.login", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // instancio parametro de salida
            SqlParameter VariableRetorno = new SqlParameter("@resultado", SqlDbType.Int);
            VariableRetorno.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@usuario", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(VariableRetorno);

            conexion.Open();
            cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login
            int resultado = (int)cmd.Parameters["@resultado"].Value;
            conexion.Close();
            return resultado;
        }

        public List<String> getRolesUsuario(String username)
        {
            List<String> roles = new List<string>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT UR_Rol_Nombre FROM SQLGROUP.Usuarios_Rol WHERE UR_Usuario_Id = @username",conexion);
            query.Parameters.AddWithValue("@username", username);
            conexion.Open();
            SqlDataReader resultados = query.ExecuteReader();
            while(resultados.Read()) {
                roles.Add(resultados.GetString(0));
            }
            conexion.Close();
            return roles;
        }

    }
}
