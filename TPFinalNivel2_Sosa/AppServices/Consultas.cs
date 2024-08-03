using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System.Data.SqlTypes;

namespace AppServices
{
    public class Consultas
    {
        public Consultas() 
        {

            this.conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            
        }

        SqlConnection conexion;

        public DataTable consultarTablaArticulos()
        {
            try
            {
                conexion.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter("select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = IdMarca AND C.Id = IdCategoria", conexion);
                DataTable dt = new DataTable();
                
                adapter.Fill(dt);
                
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataTable consultarTablas(string comando)
        {
            try
            {
                conexion.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(comando, conexion);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataTable consultarBusqueda(string comando)
        {
            try
            {
                conexion.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select " + comando + " from ARTICULOS", conexion);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void agregarArticulo(string codigo, string nombre, string descripcion, int marca, int categoria, string url, SqlMoney precio)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)";
            cmd.Parameters.AddWithValue("@Codigo", codigo);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Descripcion", descripcion);
            cmd.Parameters.AddWithValue("@IdMarca", marca);
            cmd.Parameters.AddWithValue("@IdCategoria", categoria);
            cmd.Parameters.AddWithValue("@ImagenUrl", url);
            cmd.Parameters.AddWithValue("@Precio", precio);
            cmd.Connection = conexion;

            try
            {

                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        /*
        public void consultarColumnas()
        {
            try
            {
                conexion.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
    }
}
