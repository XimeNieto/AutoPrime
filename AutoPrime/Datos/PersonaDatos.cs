using System.Data.SqlClient;
using System.Data;
using AutoPrime.Models;

namespace AutoPrime.Datos
{
    public class PersonaDatos
    {
        public List<PersonaModelo> Listar()
        {

            var oLista = new List<PersonaModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new PersonaModelo()
                        {
                            IdPersona = Convert.ToInt32(dr["IdPersona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"])
                        });
                    }
                }
            }
            return oLista;
        }
        public PersonaModelo Obtener(int IdPersona)
        {
            var oPersona = new PersonaModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oPersona.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                        oPersona.Identificacion = dr["Identificacion"].ToString();
                        oPersona.Nombres = dr["Nombres"].ToString();
                        oPersona.Apellidos = dr["Apellidos"].ToString();
                        oPersona.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());

                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(PersonaModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oPersona.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oPersona.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oPersona.FechaNacimiento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BeginExecuteNonQuery();
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
        public bool Editar(PersonaModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdPersona", oPersona.IdPersona);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oPersona.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oPersona.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oPersona.FechaNacimiento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BeginExecuteNonQuery();
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
        public bool Eliminar(int IdPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BeginExecuteNonQuery();
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

