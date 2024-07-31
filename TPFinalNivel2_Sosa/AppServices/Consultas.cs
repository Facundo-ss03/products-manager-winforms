using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;

namespace AppServices
{
    public class Consultas
    {
        public Consultas() 
        {

            this.conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            
        }

        SqlConnection conexion;

        public DataTable consultarListaArticulos()
        {
            try
            {

                conexion.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria \r\nfrom ARTICULOS A, MARCAS M, CATEGORIAS C\r\nwhere M.Id = IdMarca And C.Id = A.IdCategoria", conexion);
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

        public void agregarArticulo(string codigo, string Nombre, string descripcion, string marca, string categoria, string url, int precio)
        {
            try
            {

                conexion.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (" + codigo + ", " + Nombre + ", " + descripcion + ", " + marca + ", " + categoria + ", " + url + ", " + precio.ToString(), conexion);
                
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
