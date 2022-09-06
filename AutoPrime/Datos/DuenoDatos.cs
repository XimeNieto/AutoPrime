using System.Data.SqlClient;
using System.Data;
using AutoPrime.Models;

namespace AutoPrime.Datos
{
    public class DuenoDatos
    {
        public List<DuenoModelo> Listar()
        {

            var oLista = new List<DuenoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarDueno", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new DuenoModelo()
                        {
                            IdDueno = Convert.ToInt32(dr["IdDueno"]),
                            FkPersona = Convert.ToInt32(dr["FkPersona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            Ciudad = dr["Ciudad"].ToString(),
                            Email = dr["Email"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public DuenoModelo Obtener(int IdDueno)
        {
            var oDueno = new DuenoModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerDueno", conexion);
                cmd.Parameters.AddWithValue("IdDueno", IdDueno);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oDueno.IdDueno = Convert.ToInt32(dr["IdDueno"]);
                        oDueno.FkPersona = Convert.ToInt32(dr["FkPersona"]);
                        oDueno.Identificacion = dr["Identificacion"].ToString();
                        oDueno.Nombres = dr["Nombres"].ToString();
                        oDueno.Apellidos = dr["Apellidos"].ToString();
                        oDueno.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                        oDueno.Ciudad = dr["Ciudad"].ToString();
                        oDueno.Email = dr["Email"].ToString();

                    }
                }
            }
            return oDueno;
        }
        public bool Guardar(DuenoModelo oDueno)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarDueno", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oDueno.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oDueno.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oDueno.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oDueno.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", oDueno.Ciudad);
                    cmd.Parameters.AddWithValue("Email", oDueno.Email);
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
        public bool Editar(DuenoModelo oDueno)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarDueno", conexion);
                    cmd.Parameters.AddWithValue("IdDueno", oDueno.IdDueno);
                    cmd.Parameters.AddWithValue("Identificacion", oDueno.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oDueno.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oDueno.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oDueno.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", oDueno.Ciudad);
                    cmd.Parameters.AddWithValue("Email", oDueno.Email);
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
        public bool Eliminar(int IdDueno)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarDueno", conexion);
                    cmd.Parameters.AddWithValue("IdDueno", IdDueno);
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
    

