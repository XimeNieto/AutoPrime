using AutoPrime.Models;
using System.Data.SqlClient;
using System.Data;

namespace AutoPrime.Datos
{
    public class SeguroDatos
    {
        public List<SeguroModelo> Listar()
        {

            var oLista = new List<SeguroModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSeguro", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new SeguroModelo()
                        {
                            IdSeguro = Convert.ToInt32(dr["IdSeguro"]),
                            FkDueno = Convert.ToInt32(dr["FkDueno"]),
                            FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                            FechaFinal = Convert.ToDateTime(dr["FechaFinal"]),
                            PolizaNumero = dr["Numero"].ToString(),
                            Tipo = dr["Tipo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public SeguroModelo Obtener(int IdSeguro)
        {
            var oSeguro = new SeguroModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerSeguro", conexion);
                cmd.Parameters.AddWithValue("IdSeguro", IdSeguro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oSeguro.IdSeguro = Convert.ToInt32(dr["IdSeguro"]);
                        oSeguro.FkDueno = Convert.ToInt32(dr["FkDueno"]);
                        oSeguro.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                        oSeguro.FechaFinal = Convert.ToDateTime(dr["FechaFinal"]);
                        oSeguro.PolizaNumero = dr["Numero"].ToString();
                        oSeguro.Tipo = dr["Tipo"].ToString();

                    }
                }
            }
            return oSeguro;
        }
        public bool Guardar(SeguroModelo oSeguro)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarSeguro", conexion);
                    cmd.Parameters.AddWithValue("FechaInicio", oSeguro.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFinal", oSeguro.FechaFinal);
                    cmd.Parameters.AddWithValue("PolizaNumero", oSeguro.PolizaNumero);
                    cmd.Parameters.AddWithValue("Tipo", oSeguro.Tipo);
                    cmd.Parameters.AddWithValue("FkDueno", oSeguro.FkDueno);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(SeguroModelo oSeguro)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarSeguro", conexion);
                    cmd.Parameters.AddWithValue("IdSeguro", oSeguro.IdSeguro);
                    cmd.Parameters.AddWithValue("FkDueno", oSeguro.FkDueno);
                    cmd.Parameters.AddWithValue("FechaInicio", oSeguro.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFinal", oSeguro.FechaFinal);
                    cmd.Parameters.AddWithValue("PolizaNumero", oSeguro.PolizaNumero);
                    cmd.Parameters.AddWithValue("Tipo", oSeguro.Tipo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int IdSeguro)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarSeguro", conexion);
                    cmd.Parameters.AddWithValue("IdSeguro", IdSeguro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}