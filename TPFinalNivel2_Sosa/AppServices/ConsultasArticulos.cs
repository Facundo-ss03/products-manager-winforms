using AppModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

namespace AppServices
{
    public class ConsultasArticulos
    {
        private List<Articulo> listaArticulos;
        public DataTable consultarColumnas()
        {
            DataTable tabla = new DataTable();

            AccesoDatos datos = new AccesoDatos();
            datos.setearConsultaEnAdapter("select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = IdMarca AND C.Id = IdCategoria");
            
            datos.Adapter.Fill(tabla);

            return tabla;
        }

        public List<Articulo> consultarTablaArticulos()
        {
            AccesoDatos datos = new AccesoDatos();
            //listaArticulos = new List<Articulos>();
            listaArticulos = new List<Articulo>();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = IdMarca AND C.Id = IdCategoria");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    int id = (int)datos.Reader["Id"];
                    string codigo = (string)datos.Reader["Codigo"];
                    string nombre = (string)datos.Reader["Nombre"];
                    string descripcion = (string)datos.Reader["Descripcion"];

                    int idMarca = (int)datos.Reader["IdMarca"];
                    string descripcionMarca = (string)datos.Reader["Marca"];
                    Marca marca = new Marca(idMarca, descripcionMarca);

                    int idCategoria = (int)datos.Reader["IdCategoria"];
                    string descripcionCategoria = (string)datos.Reader["Categoria"];
                    Categoria categoria = new Categoria(idCategoria, descripcionCategoria);

                    SqlMoney precio = SqlMoney.Parse(datos.Reader["Precio"].ToString());
                    string ImagenUrl = (string)datos.Reader["ImagenUrl"];

                    Articulo articulo = new Articulo(id, codigo, nombre, descripcion, marca, categoria, ImagenUrl, precio);
                    /*
                    articulo.id = (int)datos.Reader["Id"];
                    articulo.codigo = (string)datos.Reader["Codigo"];
                    articulo.nombre = (string)datos.Reader["Nombre"];
                    articulo.descripcion = (string)datos.Reader["Descripcion"];
                    articulo.marca = new Marca();
                    articulo.marca.descripcion = (string)datos.Reader["Marca"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.descripcion = (string)datos.Reader["Categoria"];
                    articulo.precio = SqlMoney.Parse(datos.Reader["Precio"].ToString());
                    articulo.ImagenUrl = (string)datos.Reader["ImagenUrl"];
                    */
                    listaArticulos.Add(articulo);
                }

                return listaArticulos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarArticulo(string codigo, string nombre, string descripcion, int idMarca, int idCategoria, string url, double precio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.Cmd.Parameters.AddWithValue("@Codigo", codigo);
                datos.Cmd.Parameters.AddWithValue("@Nombre", nombre);
                datos.Cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                datos.Cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                datos.Cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                datos.Cmd.Parameters.AddWithValue("@ImagenUrl", url);
                datos.Cmd.Parameters.AddWithValue("@Precio", new SqlMoney(precio));

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Delete From ARTICULOS Where Id = @Id");
                datos.Cmd.Parameters.AddWithValue("@Id", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarArticulo(int id, string codigo, string nombre, string descripcion, int idMarca, int idCategoria, string url, double precio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio WHERE Id = @Id");
                datos.Cmd.Parameters.AddWithValue("@Id", id);
                datos.Cmd.Parameters.AddWithValue("@Codigo", codigo);
                datos.Cmd.Parameters.AddWithValue("@Nombre", nombre);
                datos.Cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                datos.Cmd.Parameters.AddWithValue("@IdMarca", idMarca);
                datos.Cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                datos.Cmd.Parameters.AddWithValue("@ImagenUrl", url);
                datos.Cmd.Parameters.AddWithValue("@Precio", new SqlMoney(precio));

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
