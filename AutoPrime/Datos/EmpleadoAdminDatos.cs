using AutoPrime.Models;
using System.Data.SqlClient;
using System.Data;

namespace AutoPrime.Datos
{
    public class EmpleadoAdminDatos
    {

        public List<EmpleadoAdminModelo> Listar()
        {

            var oLista = new List<EmpleadoAdminModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEmpleadoAdmin", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoAdminModelo()
                        {
                            IdAdministrativo = Convert.ToInt32(dr["IdAdministrativo"]),
                            FkEmpleado = Convert.ToInt32(dr["FkEmpleado"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            Telefono = dr["Telefono"].ToString(),
                            NivelEstudio = dr["Email"].ToString(),
                            Email = dr["Email"].ToString(),
                            Cargo = dr["Cargo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public EmpleadoAdminModelo Obtener(int IdAdministrativo)
        {
            var oEmpleadoAdmin = new EmpleadoAdminModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAdmin", conexion);
                cmd.Parameters.AddWithValue("IdAdministrativo", IdAdministrativo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEmpleadoAdmin.IdAdministrativo = Convert.ToInt32(dr["IdAdministrativo"]);
                        oEmpleadoAdmin.FkEmpleado = Convert.ToInt32(dr["FkEmpleado"]);
                        oEmpleadoAdmin.Identificacion = dr["Identificacion"].ToString();
                        oEmpleadoAdmin.Nombres = dr["Nombres"].ToString();
                        oEmpleadoAdmin.Apellidos = dr["Apellidos"].ToString();
                        oEmpleadoAdmin.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                        oEmpleadoAdmin.Telefono = dr["Telefono"].ToString();
                        oEmpleadoAdmin.NivelEstudio = dr["Email"].ToString();
                        oEmpleadoAdmin.Email = dr["Email"].ToString();
                        oEmpleadoAdmin.Cargo = dr["Cargo"].ToString();
                    }
                }
            }
            return oEmpleadoAdmin;
        }
        public bool Guardar(EmpleadoAdminModelo oEmpleadoAdmin)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarEmpleadoAdmin", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oEmpleadoAdmin.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oEmpleadoAdmin.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oEmpleadoAdmin.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oEmpleadoAdmin.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Telefono", oEmpleadoAdmin.Telefono);
                    cmd.Parameters.AddWithValue("NivelEstudio", oEmpleadoAdmin.NivelEstudio);
                    cmd.Parameters.AddWithValue("Email", oEmpleadoAdmin.Email);
                    cmd.Parameters.AddWithValue("Cargo", oEmpleadoAdmin.Cargo);
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
        public bool Editar(EmpleadoAdminModelo oEmpleadoAdmin)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarEmpleadoAdmin", conexion);
                    cmd.Parameters.AddWithValue("IdAdministrativo", oEmpleadoAdmin.IdAdministrativo);
                    cmd.Parameters.AddWithValue("Identificacion", oEmpleadoAdmin.Identificacion);
                    cmd.Parameters.AddWithValue("Nombres", oEmpleadoAdmin.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", oEmpleadoAdmin.Apellidos);
                    cmd.Parameters.AddWithValue("FechaNacimiento", oEmpleadoAdmin.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Telefono", oEmpleadoAdmin.Telefono);
                    cmd.Parameters.AddWithValue("NivelEstudio", oEmpleadoAdmin.NivelEstudio);
                    cmd.Parameters.AddWithValue("Email", oEmpleadoAdmin.Email);
                    cmd.Parameters.AddWithValue("Cargo", oEmpleadoAdmin.Cargo);
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
        public bool Eliminar(int IdAdministrativo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarEmpleadoAdmin", conexion);
                    cmd.Parameters.AddWithValue("IdAdministrativo", IdAdministrativo);
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