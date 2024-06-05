using ParcialCesanelli.Models;
using System.Data.SqlClient;
using System.Data;

namespace ParcialCesanelli.Datos
{
    public class SucursalDatos
    {
        public List<SucursalModel> Listar()
        {
            var oLista = new List<SucursalModel>();
            var cn = new ConexionDB();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new SucursalModel()
                        {
                            IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                            Nombre = dr["Nombre"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Provincia = dr["Provincia"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public SucursalModel Obtener(int IdSucursal)
        {
            var oSucursal = new SucursalModel();
            var cn = new ConexionDB();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("@IdSucursal", IdSucursal);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oSucursal.IdSucursal = Convert.ToInt32(dr["IdSucursal"]);
                        oSucursal.Nombre = dr["Nombre"].ToString();
                        oSucursal.Direccion = dr["Direccion"].ToString();
                        oSucursal.Ciudad = dr["Ciudad"].ToString();
                        oSucursal.Provincia = dr["Provincia"].ToString();
                        oSucursal.Telefono = dr["Telefono"].ToString();
                        oSucursal.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return oSucursal;
        }

        public bool Guardar(SucursalModel osucursal)
        {
            bool rpta;
            try
            {
                var cn = new ConexionDB();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", osucursal.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", osucursal.Direccion);
                    cmd.Parameters.AddWithValue("@Ciudad", osucursal.Ciudad);
                    cmd.Parameters.AddWithValue("@Provincia", osucursal.Provincia);
                    cmd.Parameters.AddWithValue("@Telefono", osucursal.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", osucursal.Correo);
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

        public bool Editar(SucursalModel osucursal)
        {
            bool rpta;
            try
            {
                var cn = new ConexionDB();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSucursal", osucursal.IdSucursal);
                    cmd.Parameters.AddWithValue("@Nombre", osucursal.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", osucursal.Direccion);
                    cmd.Parameters.AddWithValue("@Ciudad", osucursal.Ciudad);
                    cmd.Parameters.AddWithValue("@Provincia", osucursal.Provincia);
                    cmd.Parameters.AddWithValue("@Telefono", osucursal.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", osucursal.Correo);
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

        public bool Eliminar(int IdSucursal)
        {
            bool rpta;
            try
            {
                var cn = new ConexionDB();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSucursal", IdSucursal);
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
