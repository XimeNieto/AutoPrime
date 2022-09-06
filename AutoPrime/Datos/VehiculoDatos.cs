using AutoPrime.Models;
using System.Data.SqlClient;
using System.Data;

namespace AutoPrime.Datos
{
	public class VehiculoDatos
	{
        public List<VehiculoModelo> Listar()
        {

            var oLista = new List<VehiculoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new VehiculoModelo()
                        {
                            IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]),
                            FkDueno = Convert.ToInt32(dr["FkDueno"]),
                            FkSeguro = Convert.ToInt32(dr["FKSeguro"]),
                            Placa = dr["Placa"].ToString(),
                            Tipo = dr["Tipo"].ToString(),
                            Marca = dr["Marca"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Capacidad = dr["Capacidad"].ToString(),
                            Cilindraje = dr["Cilindraje"].ToString(),
                            CiudadOrigen = dr["CiudadOrigen"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public VehiculoModelo Obtener(int IdVehiculo)
        {
            var oVehiculo = new VehiculoModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVehiculo", conexion);
                cmd.Parameters.AddWithValue("IdVehiculo", IdVehiculo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oVehiculo.IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]);
                        oVehiculo.FkDueno = Convert.ToInt32(dr["FkDueno"]);
                        oVehiculo.FkSeguro = Convert.ToInt32(dr["FkSeguro"]);
                        oVehiculo.Placa = dr["Placa"].ToString();
                        oVehiculo.Tipo = dr["Tipo"].ToString();
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Capacidad = dr["Capacidad"].ToString();
                        oVehiculo.Cilindraje = dr["Cilindraje"].ToString();
                        oVehiculo.CiudadOrigen = dr["CiudadOrigen"].ToString();
                        oVehiculo.Descripcion = dr["Descripcion"].ToString();
                    }
                }
            }
            return oVehiculo;
        }

        public VehiculoModelo Buscar(string Placa)
        {
            var oVehiculo = new VehiculoModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarVehiculo", conexion);
                cmd.Parameters.AddWithValue("Placa", Placa);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oVehiculo.IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]);
                        oVehiculo.FkDueno = Convert.ToInt32(dr["FkDueno"]);
                        oVehiculo.FkSeguro = Convert.ToInt32(dr["FkSeguro"]);
                        oVehiculo.Placa = dr["Placa"].ToString();
                        oVehiculo.Tipo = dr["Tipo"].ToString();
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Capacidad = dr["Capacidad"].ToString();
                        oVehiculo.Cilindraje = dr["Cilindraje"].ToString();
                        oVehiculo.CiudadOrigen = dr["CiudadOrigen"].ToString();
                        oVehiculo.Descripcion = dr["Descripcion"].ToString();
                    }
                }
            }
            return oVehiculo;
        }
        public bool Guardar(VehiculoModelo oVehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("Placa", oVehiculo.Placa);
                    cmd.Parameters.AddWithValue("Tipo", oVehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", oVehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", oVehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("CiudadOrigen", oVehiculo.CiudadOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", oVehiculo.Descripcion);
                    cmd.Parameters.AddWithValue("FkDueno", oVehiculo.FkDueno);
                    cmd.Parameters.AddWithValue("FkSeguro", oVehiculo.FkSeguro);
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
        public bool Editar(VehiculoModelo oVehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", oVehiculo.IdVehiculo);
                    cmd.Parameters.AddWithValue("FkDueno", oVehiculo.FkDueno);
                    cmd.Parameters.AddWithValue("FkSeguro", oVehiculo.FkSeguro);
                    cmd.Parameters.AddWithValue("Placa", oVehiculo.Placa);
                    cmd.Parameters.AddWithValue("Tipo", oVehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", oVehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", oVehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("CiudadOrigen", oVehiculo.CiudadOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", oVehiculo.Descripcion);
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
        public bool Eliminar(int IdVehiculo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("IdVehiculo", IdVehiculo);
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
