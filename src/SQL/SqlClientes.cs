using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Entidades;

namespace UberFrba.SQL
{
    class SqlClientes
    {
        public List<Cliente> getClientes(int limit)
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT TOP " + limit + " Cliente_Id, Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Dni, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Estado FROM SQLGROUP.Clientes", conexion);
            conexion.Open();
            try
            {
                SqlDataReader resultado = query.ExecuteReader();
                while (resultado.Read())
                {
                    Cliente cf = new Cliente(resultado.GetString(1), resultado.GetString(2), (int)resultado.GetDecimal(4), resultado.GetString(3), (int)resultado.GetDecimal(5), resultado.GetString(6), resultado.GetDateTime(7), resultado.GetString(8));
                    cf.id = resultado.GetInt32(0);
                    clientes.Add(cf);
                }
                return clientes;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public List<Cliente> getClientes(String condicion)
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Cliente_Id, Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Dni, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Estado FROM SQLGROUP.Clientes WHERE " + condicion, conexion);
            conexion.Open();
            try
            {
                SqlDataReader resultado = query.ExecuteReader();
                while (resultado.Read())
                {
                    Cliente cf = new Cliente(resultado.GetString(1), resultado.GetString(2), (int)resultado.GetDecimal(4), resultado.GetString(3), (int)resultado.GetDecimal(5), resultado.GetString(6), resultado.GetDateTime(7), resultado.GetString(8));
                    cf.id = resultado.GetInt32(0);
                    clientes.Add(cf);
                }
                return clientes;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
    }
}
