using System.Data;
using System.Data.SqlClient;

namespace POOII_CL2_QUISPE_EDSON.Models
{
    public class BDProducto
    {
        // CONEXION CON LA BASE DE DATOS
        string cadenaConexion = "Data Source=MINAMI-EED;" +
            "Initial Catalog=POOCL2;" +
            "Integrated Security=True;";

        // LISTAR
        public List<Producto> ObtenerTodos()
        {
            List<Producto> listaProductos = new List<Producto>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT id, nombre, tipo, precio, fecha FROM Producto", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto producto = new Producto();
                producto.Id = dr.GetInt32(0);
                producto.Nombre = dr.GetString(1);
                producto.IdTipo = dr.GetInt32(2);
                producto.Precio = dr.GetDecimal(3);
                producto.Fecha = dr.GetDateTime(4).Date;

                listaProductos.Add(producto);
            }
            con.Close();

            return listaProductos;
        }

        // BUSCAR POR AÑO
        public List<Producto> ProductosPorAño(int año)
        {
            List<Producto> listaProducto = new List<Producto>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_productos_por_año", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@año", año);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto producto = new Producto();
                producto.Id = dr.GetInt32(0);
                producto.Nombre = dr.GetString(1);
                producto.IdTipo = dr.GetInt32(2);
                producto.Precio = dr.GetDecimal(3);
                producto.Fecha = dr.GetDateTime(4).Date;
                listaProducto.Add(producto);
            }
            con.Close();

            return listaProducto;
        }

        // CREAR
        public int Crear(string nombre, int tipo, decimal precio, DateTime fecha)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@fecha", fecha.Date);

            con.Open();
            int filasAfectadas = cmd.ExecuteNonQuery();
            con.Close();
            return filasAfectadas;
        }
        // OBETENER DATOS POR ID
        public Producto ObtenerProductoPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener_producto_por_id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = dr.GetInt32(0);
                    producto.Nombre = dr.GetString(1);
                    producto.IdTipo = dr.GetInt32(2);
                    producto.Precio = dr.GetDecimal(3);
                    producto.Fecha = dr.GetDateTime(4).Date;

                    return producto;
                }
            }

            return null;
        }

        // ACTUALIZAR
        public void Actualizar(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Producto SET nombre = @nombre, tipo = @idTipo, precio = @precio, fecha = @fecha WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@idTipo", producto.IdTipo);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@fecha", producto.Fecha);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
