using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Entidades;

namespace UberFrba.SQL
{
    class SqlAutomoviles
    {
        public void guardarAutomovil(Automovil auto)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();    
            SqlTransaction transaction = conexion.BeginTransaction();

            SqlCommand insertDatosAuto = new SqlCommand();
            insertDatosAuto.Connection = conexion;
            insertDatosAuto.Transaction = transaction;

            SqlCommand insertTurnosAuto = new SqlCommand();
            insertTurnosAuto.Connection = conexion;
            insertTurnosAuto.Transaction = transaction;

            try
            {
                insertDatosAuto.CommandText = "INSERT INTO SQLGROUP.Automoviles (Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Licencia, Auto_Rodado, Auto_Chofer)" +
                                              " VALUES(@patente, @marca, @modelo, @licencia, @rodado, @chofer)";
                insertDatosAuto.Parameters.AddWithValue("@patente",auto.patente);
                insertDatosAuto.Parameters.AddWithValue("@marca",auto.marca);
                insertDatosAuto.Parameters.AddWithValue("@modelo",auto.modelo);
                insertDatosAuto.Parameters.AddWithValue("@licencia",auto.licencia);
                insertDatosAuto.Parameters.AddWithValue("@rodado",auto.rodado);
                insertDatosAuto.Parameters.AddWithValue("@chofer",auto.chofer);
                insertDatosAuto.ExecuteNonQuery();
                int i = 0;
                foreach(Turno tur in auto.turnos) {
                    insertTurnosAuto.CommandText = "INSERT INTO SQLGROUP.Auto_Turno (AT_Auto_Patente,AT_Turno_Id) " +
                                                   " VALUES(@au_patente"+ i + ",@tu_id"+i+")";
                    insertTurnosAuto.Parameters.AddWithValue("@au_patente"+i, auto.patente);
                    insertTurnosAuto.Parameters.AddWithValue("@tu_id"+i, tur.id);
                    i++;
                    insertTurnosAuto.ExecuteNonQuery();
                }
                transaction.Commit();
                MessageBox.Show("Automovil guardado correctamente.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            conexion.Close();
        }

        public List<Automovil> getAutomoviles(int cantidad)
        {
            List<Automovil> autos = new List<Automovil>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand comando = new SqlCommand("SELECT TOP " +cantidad+ " Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Chofer, Auto_Licencia, Auto_Rodado, Auto_Estado FROM SQLGROUP.automoviles", conexion);
            conexion.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while(resultado.Read()) {
                autos.Add(new Automovil(resultado.GetString(0),resultado.GetString(1),resultado.GetString(2),resultado.GetInt32(3),null,resultado.GetString(4),resultado.GetString(5),resultado.GetString(6)));
            }
            return autos;
        }

        public List<Automovil> getAutomoviles(String busqueda)
        {
            List<Automovil> autos = new List<Automovil>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand comando = new SqlCommand("SELECT Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Chofer, Auto_Licencia, Auto_Rodado, Auto_Estado FROM SQLGROUP.automoviles WHERE " + busqueda, conexion);
            conexion.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                autos.Add(new Automovil(resultado.GetString(0), resultado.GetString(1), resultado.GetString(2), resultado.GetInt32(3), null, resultado.GetString(4), resultado.GetString(5), resultado.GetString(6)));
            }
            return autos;
        }
    }
}
