using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Entidades;

namespace UberFrba.SQL
{
    class SqlRoles
    {

        public Rol getRol(String nombre)
        {
            Rol rol = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT Rol_Nombre, Rol_Estado, Rol_Descripcion  FROM SQLGROUP.Roles WHERE Rol_Nombre = @nombre", conexion);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                conexion.Open();
                SqlDataReader rolesResultados = consulta.ExecuteReader();
                while (rolesResultados.Read())
                {
                    rol = new Rol(rolesResultados.GetString(0), rolesResultados.GetString(1), rolesResultados.GetString(2), this.getFuncionesRol(rolesResultados.GetString(0)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return rol;
        }

        public List<Rol> getRoles()
        {
            List<Rol> roles = new List<Rol>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT Rol_Nombre, Rol_Estado, Rol_Descripcion,  FROM SQLGROUP.Roles", conexion);
                conexion.Open();
                SqlDataReader rolesResultados = consulta.ExecuteReader();
                while (rolesResultados.Read())
                {
                    roles.Add(new Rol(rolesResultados.GetString(0), rolesResultados.GetString(1), rolesResultados.GetString(2), this.getFuncionesRol(rolesResultados.GetString(0))));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return roles;
        }

        public Boolean rolHabilitado(String rol)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            Boolean aDevlover;
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT CASE WHEN Rol_Estado = 'Habilitado' THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END FROM dbo.rol WHERE Rol_Tipo = @rol", conexion);
                consulta.Parameters.Add("rol", SqlDbType.VarChar).Value = rol;
                conexion.Open();
                SqlDataReader rolEstado = consulta.ExecuteReader();
                if (rolEstado.Read())
                    aDevlover = rolEstado.GetBoolean(0);
                else
                    aDevlover = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return aDevlover;
        }

        public List<Funcionalidad> getFuncionesRol(String nombreRol)
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT Func_Nombre, Func_Descripcion FROM SQLGROUP.Rol_Funcionalidad, SQLGROUP.Funcionalidades WHERE RF_Rol_Nombre = @rolNombre AND Func_Nombre = RF_Func_Nombre", conexion);
                consulta.Parameters.AddWithValue("@rolnombre", nombreRol);
                conexion.Open();
                SqlDataReader funcResultados = consulta.ExecuteReader();
                while (funcResultados.Read())
                {
                    funcionalidades.Add(new Funcionalidad(funcResultados.GetString(0), funcResultados.GetString(1)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return funcionalidades;
        }

        public List<Funcionalidad> getFuncionesTotales()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT Func_Nombre, Func_Descripcion FROM SQLGROUP.Funcionalidades", conexion);
                conexion.Open();
                SqlDataReader funcResultados = consulta.ExecuteReader();
                while (funcResultados.Read())
                {
                    funcionalidades.Add(new Funcionalidad(funcResultados.GetString(0),funcResultados.GetString(1)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return funcionalidades;
        }

        public Boolean actualizarFuncionesRoles(String rolViejo, String rolNuevo, List<String> funcionesNuevas, String habilitado)
        {
            Boolean ok = true;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction actualizacionRol = conexion.BeginTransaction("Actualizar Funciones De Un Rol");
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.Transaction = actualizacionRol;
            int i = 0;
            command.Parameters.Add("@rolViejo", SqlDbType.VarChar).Value = rolViejo;
            command.Parameters.Add("@rolNuevo", SqlDbType.VarChar).Value = rolNuevo;
            command.Parameters.Add("@habilitado", SqlDbType.VarChar).Value = habilitado;
            try
            {
                command.CommandText = "DELETE FROM rolxfuncionalidad WHERE RF_Rol_Tipo = @rolViejo";
                command.ExecuteNonQuery();

                command.CommandText = "UPDATE rol SET Rol_Tipo = @rolNuevo WHERE Rol_Tipo = @rolViejo";
                command.ExecuteNonQuery();
                /*Primero los borra si no esta habilitado, asi no actualiza y luego borra al pedo*/
                if (!habilitado.Equals("Habilitado"))
                {
                    command.CommandText = "DELETE FROM rolxusuario WHERE RU_Rol_Tipo = @rolNuevo";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "UPDATE rol SET Rol_Estado = @habilitado WHERE Rol_Tipo = @rolNuevo";
                command.ExecuteNonQuery();

                foreach (String funcion in funcionesNuevas)
                {
                    command.CommandText = "INSERT INTO rolxfuncionalidad VALUES (@rolNuevo,(SELECT Func_Codigo FROM funcionalidad WHERE Func_Nombre = @funcion" + i + "))";
                    command.Parameters.Add("@funcion" + i, SqlDbType.VarChar).Value = funcion;
                    command.ExecuteNonQuery();
                    i++;
                }
                actualizacionRol.Commit();
            }
            catch (Exception ex)
            {
                ok = false;
                System.Console.Write(ex.ToString());
                actualizacionRol.Rollback();
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public void insertarNuevoRol(Rol rolNuevo)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            SqlCommand comando2 = new SqlCommand("", conexion, transaction);
            try
            {
                SqlCommand comando = new SqlCommand("INSERT INTO SQLGROUP.Roles (Rol_Nombre,Rol_Descripcion,Rol_Estado) VALUES (@nombre,@desc,@estado)", conexion, transaction);
                comando.Parameters.AddWithValue("@nombre", rolNuevo.nombre);
                comando.Parameters.AddWithValue("@desc", rolNuevo.desc);
                comando.Parameters.AddWithValue("@estado", rolNuevo.estado);
                comando.ExecuteNonQuery();
                int i = 0;
                foreach (Funcionalidad func in rolNuevo.funcionalidades)
                {
                    comando2.CommandText = "INSERT INTO SQLGROUP.Rol_Funcionalidad (RF_Rol_Nombre, RF_Func_Nombre) VALUES (@nombreRol" + i + ",@nombreFunc" + i + ")";
                    comando2.Parameters.AddWithValue("@nombreRol" + i, rolNuevo.nombre);
                    comando2.Parameters.AddWithValue("@nombreFunc" + i, func.nombreFuncion);
                    comando2.ExecuteNonQuery();
                    i++;
                }
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                conexion.Close();
                throw ex;
            }
        }
    }
}
