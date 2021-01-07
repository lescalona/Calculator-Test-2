using Calculator.WindowsUi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Calculator.WindowsUi
{
    public class HistoricoDB
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase\DataBaseHistorico.mdf;Integrated Security = True";

        public void GuardarHistorico(string Operacion, float Operador1, float Operador2, float Resultado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GuardarHistoricos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Operacion", Operacion);
                    cmd.Parameters.AddWithValue("@Operador1", Operador1);
                    cmd.Parameters.AddWithValue("@Operador2", Operador2);
                    cmd.Parameters.AddWithValue("@Resultado", Resultado);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public List<DetallesHistorialViewModel> TraerHistorico()
        {
            var historico = new List<DetallesHistorialViewModel>();
            try
            {

                SqlDataReader rdr = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("ConsultarHistoricos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        historico.Add(new DetallesHistorialViewModel
                        {
                            Fecha = DateTime.Parse(rdr["Fecha"].ToString()),
                            Operacion = rdr.GetString(1),
                            PrimerOperador = decimal.Parse(rdr.GetString(2)),
                            SegundoOperador = decimal.Parse(rdr.GetString(3)),
                            Resultado = decimal.Parse(rdr.GetString(4))
                        });
                    }
                    if (rdr != null)
                        rdr.Close();

                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return historico;
        }
    }
}
