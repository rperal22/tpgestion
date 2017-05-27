using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                foreach(Turno tur in auto.turnos) {
                    insertTurnosAuto.CommandText = "INSERT INTO SQLGROUP.Auto_Turno (AT_Auto_Patente,AT_Turno_Id) " +
                                                   " VALUES(@au_patente,@tu_id)";
                    insertTurnosAuto.Parameters.AddWithValue("@au_patente", auto.patente);
                    insertTurnosAuto.Parameters.AddWithValue("@tu_id", tur.id);
                    insertTurnosAuto.ExecuteNonQuery();
                }

            }
            catch (Exception ex) {
                transaction.Rollback();
            }

        }
    }
}
