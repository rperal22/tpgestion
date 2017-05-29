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
    class SqlTurnos
    {
        public List<Turno> getAllTurnos()
        {
            List<Turno> turnos = new List<Turno>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand comando = new SqlCommand("SELECT Turno_Id, Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Descripcion, Turno_Valor_Kilometro, Turno_Precio_Base " +
                                                  " FROM SQLGROUP.Turno WHERE Turno_Estado='Habilitado'",conexion);
            conexion.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while(resultado.Read()){
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

        public void guardarTurno(Turno turno)
        {

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("SQLGROUP.crearTurno", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@t_hi", turno.hi));
            cmd.Parameters.Add(new SqlParameter("@t_hf", turno.hf));
            cmd.Parameters.Add(new SqlParameter("@t_desc", turno.desc));
            cmd.Parameters.Add(new SqlParameter("@t_vk", turno.valor_kilometro));
            cmd.Parameters.Add(new SqlParameter("@t_pb", turno.precio_base));
            cmd.Parameters.Add(new SqlParameter("@t_estado", turno.estado));

            conexion.Open();
            try
            {
                cmd.ExecuteNonQuery(); 
                conexion.Close();
            }
            catch(Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
    }
}
