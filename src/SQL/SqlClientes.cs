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
        public void guardarCliente(Cliente cliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("INSERT INTO SQLGROUP.Clientes (Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Dni, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Estado,Cliente_Codigo_Postal) " +
                                                " VALUES(@nombre,@apellido,@direccion,@dni,@telefono,@mail,@nacimiento,@estado,@codigopostal)", conexion);
            query.Parameters.AddWithValue("@nombre",cliente.nombre);
            query.Parameters.AddWithValue("@apellido", cliente.apellido);
            query.Parameters.AddWithValue("@direccion", cliente.direccion);
            query.Parameters.AddWithValue("@dni",cliente.dni);
            query.Parameters.AddWithValue("@telefono", cliente.telefono);
            query.Parameters.AddWithValue("@mail", cliente.mail);
            query.Parameters.AddWithValue("@nacimiento", cliente.fechaNacimiento);
            query.Parameters.AddWithValue("@estado",cliente.estado);
            query.Parameters.AddWithValue("@codigopostal",cliente.codigoPostal);
            try
            {
                conexion.Open();
                query.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }


        public void actualizarCliente(Cliente clienteNuevo, int clienteId)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("UPDATE SQLGROUP.Clientes SET Cliente_Nombre = @nombre, Cliente_Apellido = @apellido, Cliente_Direccion = @direccion, Cliente_Dni = @dni, Cliente_Telefono = @telefono, Cliente_Mail = @mail, Cliente_Fecha_Nac = @nacimiento, Cliente_Estado = @estado, Cliente_Codigo_Postal = @codigopostal WHERE Cliente_Id = @id", conexion);
            query.Parameters.AddWithValue("@nombre", clienteNuevo.nombre);
            query.Parameters.AddWithValue("@apellido", clienteNuevo.apellido);
            query.Parameters.AddWithValue("@direccion", clienteNuevo.direccion);
            query.Parameters.AddWithValue("@dni", clienteNuevo.dni);
            query.Parameters.AddWithValue("@telefono", clienteNuevo.telefono);
            query.Parameters.AddWithValue("@mail", clienteNuevo.mail);
            query.Parameters.AddWithValue("@nacimiento", clienteNuevo.fechaNacimiento);
            query.Parameters.AddWithValue("@estado", clienteNuevo.estado);
            query.Parameters.AddWithValue("@id", clienteId);
            query.Parameters.AddWithValue("@codigopostal", clienteNuevo.codigoPostal);
            try
            {
                conexion.Open();
                query.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        public List<Cliente> getClientes(int limit)
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT TOP " + limit + " Cliente_Id, Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Dni, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Estado, Cliente_Codigo_Postal FROM SQLGROUP.Clientes", conexion);
            conexion.Open();
            try
            {
                SqlDataReader resultado = query.ExecuteReader();
                while (resultado.Read())
                {
                    Cliente cf = new Cliente(resultado.GetString(1), resultado.GetString(2), (int)resultado.GetDecimal(4), resultado.GetString(3), (int)resultado.GetDecimal(5), resultado.GetString(6), resultado.GetDateTime(7), resultado.GetString(8), resultado.GetString(9));
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
            SqlCommand query = new SqlCommand("SELECT Cliente_Id, Cliente_Nombre, Cliente_Apellido, Cliente_Direccion, Cliente_Dni, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nac, Cliente_Estado, Cliente_Codigo_Postal FROM SQLGROUP.Clientes WHERE " + condicion, conexion);
            conexion.Open();
            try
            {
                SqlDataReader resultado = query.ExecuteReader();
                while (resultado.Read())
                {
                    Cliente cf = new Cliente(resultado.GetString(1), resultado.GetString(2), (int)resultado.GetDecimal(4), resultado.GetString(3), (int)resultado.GetDecimal(5), resultado.GetString(6), resultado.GetDateTime(7), resultado.GetString(8), resultado.GetString(9));
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
