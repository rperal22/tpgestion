using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Entidades;

namespace UberFrba.SQL
{
    class SqlChoferes
    {

        public void updateChofer(Chofer choferNuevo, int id)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand updateAuto = new SqlCommand("UPDATE SQLGROUP.Choferes SET Chofer_Nombre = @nombre, Chofer_Apellido = @apellido, Chofer_Direccion = @direccion, Chofer_Dni = @dni, Chofer_Telefono = @telefono, Chofer_Mail = @mail, Chofer_Fecha_Nac = @nacimiento, Chofer_Estado = @estado WHERE Chofer_Id = @id",conexion);
            updateAuto.Parameters.AddWithValue("@nombre", choferNuevo.nombre);
            updateAuto.Parameters.AddWithValue("@apellido", choferNuevo.apellido);
            updateAuto.Parameters.AddWithValue("@direccion", choferNuevo.direccion);
            updateAuto.Parameters.AddWithValue("@dni", choferNuevo.dni);
            updateAuto.Parameters.AddWithValue("@telefono", choferNuevo.telefono);
            updateAuto.Parameters.AddWithValue("@mail", choferNuevo.mail);
            updateAuto.Parameters.AddWithValue("@nacimiento", choferNuevo.fechaNacimiento);
            updateAuto.Parameters.AddWithValue("@estado", choferNuevo.estado);
            updateAuto.Parameters.AddWithValue("@id", id);
            conexion.Open();
            try
            {
                updateAuto.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public void guardarChofer(Chofer chofer)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand ponerAuto = new SqlCommand("INSERT INTO SQLGROUP.Choferes (Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Dni, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac, Chofer_Estado)" +
                                                  " VALUES (@nombre,@apellido,@direccion,@dni, @telefono,@mail,@nacimiento,@estado)", conexion);
            ponerAuto.Parameters.AddWithValue("@nombre", chofer.nombre);
            ponerAuto.Parameters.AddWithValue("@apellido", chofer.apellido);
            ponerAuto.Parameters.AddWithValue("@direccion", chofer.direccion);
            ponerAuto.Parameters.AddWithValue("@dni", chofer.dni);
            ponerAuto.Parameters.AddWithValue("@telefono", chofer.telefono);
            ponerAuto.Parameters.AddWithValue("@mail", chofer.mail);
            ponerAuto.Parameters.AddWithValue("@nacimiento", chofer.fechaNacimiento);
            ponerAuto.Parameters.AddWithValue("@estado", chofer.estado);
            conexion.Open();
            try
            {
                ponerAuto.ExecuteNonQuery();
                conexion.Close();
            }
            catch(Exception ex) {
                conexion.Close();
                throw ex;
            }
        }

        public List<Chofer> getChoferes(int limit)
        {
            List<Chofer> choferes = new List<Chofer>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT TOP "+ limit +" Chofer_Id, Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Dni, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac, Chofer_Estado FROM SQLGROUP.Choferes",conexion);
            conexion.Open();
            try
            {
                SqlDataReader resultado = query.ExecuteReader();
                while(resultado.Read()) {
                    Chofer cf = new Chofer(resultado.GetString(1), resultado.GetString(2), (int)resultado.GetDecimal(4), resultado.GetString(3), (int)resultado.GetDecimal(5), resultado.GetString(6), resultado.GetDateTime(7), resultado.GetString(8));
                    cf.id = resultado.GetInt32(0);
                    choferes.Add(cf);
                }
                return choferes;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public List<Chofer> getChoferes(String condicion)
        {
            List<Chofer> choferes = new List<Chofer>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Chofer_Id, Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Dni, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac, Chofer_Estado FROM SQLGROUP.Choferes WHERE " + condicion, conexion);
            conexion.Open();
            try
            {
                SqlDataReader resultado = query.ExecuteReader();
                while (resultado.Read())
                {
                    Chofer cf = new Chofer(resultado.GetString(1), resultado.GetString(2), (int)resultado.GetDecimal(4), resultado.GetString(3), (int)resultado.GetDecimal(5), resultado.GetString(6), resultado.GetDateTime(7),resultado.GetString(8));
                    cf.id = resultado.GetInt32(0);
                    choferes.Add(cf);
                }
                return choferes;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public Automovil getAutoHabilitado(Chofer chofer)
        {
            Automovil auto;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Chofer, Auto_Licencia, Auto_Rodado, Auto_Estado, Auto_Id FROM SQLGROUP.automoviles WHERE Auto_Estado='Habilitado' AND Auto_Chofer=@id",conexion);
            query.Parameters.AddWithValue("@id",chofer.id);
            conexion.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            auto = new Automovil(reader.GetInt32(7),reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), new SqlAutomoviles().getTurnosAuto(reader.GetString(0),"Habilitado"), reader.GetString(4), reader.GetString(5), reader.GetString(6));
            conexion.Close();
            return auto;
        }

    }
}
