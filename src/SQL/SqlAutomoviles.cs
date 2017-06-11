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
                insertDatosAuto.CommandText = "INSERT INTO SQLGROUP.Automoviles (Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Licencia, Auto_Rodado, Auto_Chofer, Auto_Estado) " +
                                              " VALUES(@patente, @marca, @modelo, @licencia, @rodado, @chofer,@estado)";
                insertDatosAuto.Parameters.AddWithValue("@patente",auto.patente);
                insertDatosAuto.Parameters.AddWithValue("@marca",auto.marca);
                insertDatosAuto.Parameters.AddWithValue("@modelo",auto.modelo);
                insertDatosAuto.Parameters.AddWithValue("@licencia",auto.licencia);
                insertDatosAuto.Parameters.AddWithValue("@rodado",auto.rodado);
                insertDatosAuto.Parameters.AddWithValue("@chofer",auto.chofer);
                insertDatosAuto.Parameters.AddWithValue("@estado",auto.estado);
                insertDatosAuto.ExecuteNonQuery();
                int i = 0;
                foreach(Turno tur in auto.turnos) {
                    insertTurnosAuto.CommandText = "INSERT INTO SQLGROUP.Auto_Turno (AT_Auto_Id,AT_Turno_Id) " +
                                                   " VALUES(SQLGROUP.getAutoId(@au_patente"+i+"),@tu_id"+i+")";
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
            SqlCommand comando = new SqlCommand("SELECT TOP " +cantidad+ " Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Chofer, Auto_Licencia, Auto_Rodado, Auto_Estado, Auto_Id FROM SQLGROUP.automoviles", conexion);
            conexion.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while(resultado.Read()) {
                autos.Add(new Automovil(resultado.GetInt32(7),resultado.GetString(0),resultado.GetString(1),resultado.GetString(2),resultado.GetInt32(3),null,resultado.GetString(4),resultado.GetString(5),resultado.GetString(6)));
            }
            return autos;
        }

        public List<Automovil> getAutomoviles(String busqueda)
        {
            List<Automovil> autos = new List<Automovil>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand comando = new SqlCommand("SELECT Auto_Patente, Auto_Marca, Auto_Modelo, Auto_Chofer, Auto_Licencia, Auto_Rodado, Auto_Estado, Auto_Id FROM SQLGROUP.automoviles WHERE " + busqueda, conexion);
            conexion.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                autos.Add(new Automovil(resultado.GetInt32(7),resultado.GetString(0), resultado.GetString(1), resultado.GetString(2), resultado.GetInt32(3), null, resultado.GetString(4), resultado.GetString(5), resultado.GetString(6)));
            }
            return autos;
        }

        public List<Turno> getTurnosAuto(String patente, String turnoEstado)
        {
            List<Turno> turnos = new List<Turno>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand query = new SqlCommand("SELECT Turno_Id, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base " +
                                                  " FROM SQLGROUP.Turno, SQLGROUP.Auto_Turno  WHERE Turno_Estado='Habilitado' AND AT_Auto_Id = SQLGROUP.getAutoId(@patente) AND AT_Turno_Id = Turno_Id AND Turno_Estado = @estado",conexion);
            query.Parameters.AddWithValue("@patente",patente);
            query.Parameters.AddWithValue("@estado", turnoEstado);
            conexion.Open();
            SqlDataReader resultado = query.ExecuteReader();
            while (resultado.Read())
            {
                turnos.Add(new Turno(resultado.GetInt32(0),
                    (int)resultado.GetDecimal(1),
                    (int)resultado.GetDecimal(2),
                    resultado.GetString(3),
                    (float)resultado.GetDecimal(4),
                    (float)resultado.GetDecimal(5)));
            }
            conexion.Close();
            return turnos;
        }

        public void actualizarAutomovil(Automovil auto, int idAuto)
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

            SqlCommand borrarTurnosAuto = new SqlCommand("DELETE FROM SQLGROUP.Auto_Turno WHERE AT_Auto_Id = @patenteAnterior", conexion, transaction);

            try
            {
                borrarTurnosAuto.Parameters.AddWithValue("@patenteAnterior", idAuto);
                borrarTurnosAuto.ExecuteNonQuery();

                insertDatosAuto.CommandText = "UPDATE SQLGROUP.Automoviles SET Auto_Patente = @patente, Auto_Marca = @marca, Auto_Modelo = @modelo, Auto_Licencia = @licencia, Auto_Rodado = @rodado, Auto_Chofer =  @chofer, Auto_Estado = @estado WHERE Auto_Id = @id";
                insertDatosAuto.Parameters.AddWithValue("@patente", auto.patente);
                insertDatosAuto.Parameters.AddWithValue("@marca", auto.marca);
                insertDatosAuto.Parameters.AddWithValue("@modelo", auto.modelo);
                insertDatosAuto.Parameters.AddWithValue("@licencia", auto.licencia);
                insertDatosAuto.Parameters.AddWithValue("@rodado", auto.rodado);
                insertDatosAuto.Parameters.AddWithValue("@chofer", auto.chofer);
                insertDatosAuto.Parameters.AddWithValue("@estado", auto.estado);
                insertDatosAuto.Parameters.AddWithValue("@id", idAuto);
                insertDatosAuto.ExecuteNonQuery();
                int i = 0;
                foreach (Turno tur in auto.turnos)
                {
                    insertTurnosAuto.CommandText = "INSERT INTO SQLGROUP.Auto_Turno (AT_Auto_Id,AT_Turno_Id) " +
                                                   " VALUES(@au_id" + i + ",@tu_id" + i + ")";
                    insertTurnosAuto.Parameters.AddWithValue("@au_id" + i, idAuto);
                    insertTurnosAuto.Parameters.AddWithValue("@tu_id" + i, tur.id);
                    i++;
                    insertTurnosAuto.ExecuteNonQuery();
                }
                transaction.Commit();
                MessageBox.Show("Automovil actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            conexion.Close();
        }

        public List<String> getMarcas()
        {
            List<String> marcas = new List<String>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand comando = new SqlCommand("SELECT Auto_Marca FROM SQLGROUP.automoviles GROUP BY Auto_Marca", conexion);
            conexion.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                marcas.Add(resultado.GetString(0));
            }
            return marcas;
        }
    }
}
