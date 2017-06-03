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
        public void guardarChofer(Chofer chofer)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand ponerAuto = new SqlCommand("INSERT INTO SQLGROUP.Choferes (Chofer_Nombre, Chofer_Apellido, Chofer_Direccion, Chofer_Dni, Chofer_Telefono, Chofer_Mail, Chofer_Fecha_Nac)" +
                                                  " VALUES (@nombre,@apellido,@direccion,@dni, @telefono,@mail,@nacimiento)", conexion);
            ponerAuto.Parameters.AddWithValue("@nombre", chofer.nombre);
            ponerAuto.Parameters.AddWithValue("@apellido", chofer.apellido);
            ponerAuto.Parameters.AddWithValue("@direccion", chofer.direccion);
            ponerAuto.Parameters.AddWithValue("@dni", chofer.dni);
            ponerAuto.Parameters.AddWithValue("@telefono", chofer.telefono);
            ponerAuto.Parameters.AddWithValue("@mail", chofer.mail);
            ponerAuto.Parameters.AddWithValue("@nacimiento", chofer.fechaNacimiento);

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
    }
}
