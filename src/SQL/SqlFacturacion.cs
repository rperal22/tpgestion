using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using UberFrba.SQL;
using UberFrba.Entidades;

namespace UberFrba.SQL
{
    class SqlFacturacion
    {
        public void facturar(DateTime fechaInicio, DateTime fechaFin, Cliente cliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand newFactura = new SqlCommand("SQLGROUP.facturar",conexion);
            newFactura.CommandType = CommandType.StoredProcedure;

            newFactura.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            newFactura.Parameters.AddWithValue("@fechaFin", fechaFin);
            newFactura.Parameters.AddWithValue("@clienteId", cliente.id);
            newFactura.Parameters.AddWithValue("@fechaFacturar", fechaInicio);
            try
            {
                conexion.Open();
                newFactura.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
    }
}
