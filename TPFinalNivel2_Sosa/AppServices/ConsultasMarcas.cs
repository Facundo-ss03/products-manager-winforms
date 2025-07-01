using System;
using System.Collections.Generic;
using AppModel;

namespace AppServices
{
    public class ConsultasMarcas
    {
        public List<Marca> listarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Marca marca = new Marca();

                    marca.id = (int)datos.Reader["Id"];
                    marca.descripcion = (string)datos.Reader["Descripcion"];

                    lista.Add(marca);
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
