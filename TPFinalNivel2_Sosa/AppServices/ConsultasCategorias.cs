using System;
using System.Collections.Generic;
using AppModel;

namespace AppServices
{
    public class ConsultasCategorias
    {
        public List<Categoria> listarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, descripcion From CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.id = (int)datos.Reader["Id"];
                    categoria.descripcion = (string)datos.Reader["Descripcion"];

                    lista.Add(categoria);
                }

                return lista;

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
