using System;
using System.Collections.Generic;
using AppModel;

namespace AppServices
{
    public class ConsultasCategorias
    {
        public List<Categoria> listarCategorias()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Categoria> listaCategorias = new List<Categoria>();

            try
            {
                datos.setearConsulta("Select id, descripcion From CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    
                    int id = (int)datos.Reader["Id"];
                    string descripcion = (string)datos.Reader["Descripcion"];

                    Categoria categoria = new Categoria(id, descripcion);

                    listaCategorias.Add(categoria);
                }

                return listaCategorias;

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
