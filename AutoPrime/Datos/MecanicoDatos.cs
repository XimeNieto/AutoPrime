using System.Data.SqlClient;
using System.Data;
using AutoPrime.Models;

namespace AutoPrime.Datos
{
    public class MecanicoDatos
    {
        public List<MecanicoModelo> Listar()
        {

            var oLista = new List<MecanicoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarMecanico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new MecanicoModelo()
                        {
                            IdMecanico = Convert.ToInt32(dr["IdMecanico"]),
                            FkEmpleado = Convert.ToInt32(dr["FkEmpleado"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            Telefono = dr["Telefono"].ToString(),
                            NivelEstudio = dr["Email"].ToString(),
                            Email = dr["Email"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public MecanicoModelo Obtener(int IdMecanico)
        {
            var oMecanico = new MecanicoModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerMecanico", conexion);
                cmd.Parameters.AddWithValue("IdMecanico", IdMecanico);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oMecanico.IdMecanico = Convert.ToInt32(dr["IdMecanico"]);
                        oMecanico.FkEmpleado = Convert.ToInt32(dr["FkEmpleado"]);
                        oMecanico.Identificacion = dr["Identificacion"].ToString();
                        oMecanico.Nombres = dr["Nombres"].ToString();
                        oMecanico.Apellidos = dr["Apellidos"].ToString();
                        oMecanico.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                        oMecanico.Telefono = dr["Telefono"].ToString();
                        oMecanico.NivelEstudio = dr["Email"].ToString();
                        oMecanico.Email = dr["Email"].ToString();
                        oMecanico.Direccion = dr["Direccion"].ToString();
                    }
                }
            }
            return oMecanico;
        }
        public bool Guardar(MecanicoModelo oMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarMecanico", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oMecanico.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oMecanico.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oMecanico.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oMecanico.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Telefono", oMecanico.Telefono);
                    cmd.Parameters.AddWithValue("NivelEstudio", oMecanico.NivelEstudio);
                    cmd.Parameters.AddWithValue("Email", oMecanico.Email);
                    cmd.Parameters.AddWithValue("Direccion", oMecanico.Direccion);
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
        public bool Editar(MecanicoModelo oMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarMecanico", conexion);
                    cmd.Parameters.AddWithValue("IdMecanico", oMecanico.IdMecanico);
                    cmd.Parameters.AddWithValue("Identificacion", oMecanico.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oMecanico.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oMecanico.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oMecanico.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Telefono", oMecanico.Telefono);
                    cmd.Parameters.AddWithValue("NivelEstudio", oMecanico.NivelEstudio);
                    cmd.Parameters.AddWithValue("Email", oMecanico.Email);
                    cmd.Parameters.AddWithValue("Direccion", oMecanico.Direccion);
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
        public bool Eliminar(int IdMecanico)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarMecanico", conexion);
                    cmd.Parameters.AddWithValue("IdMecanico", IdMecanico);
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
    