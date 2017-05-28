using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UberFrba.SQL
{
    static class SqlGeneral
    {
        private static string stringConexion;

        public static void inicializar()
        {
            stringConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public static SqlConnection nuevaConexion() 
        {
            return new SqlConnection(stringConexion);
        }

    }
}
