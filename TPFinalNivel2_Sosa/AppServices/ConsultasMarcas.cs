﻿using System;
using System.Collections.Generic;
using AppModel;

namespace AppServices
{
    public class ConsultasMarcas
    {
        public List<Marca> listarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    
                    int id = (int)datos.Reader["Id"];
                    string descripcion = (string)datos.Reader["Descripcion"];

                    Marca marca = new Marca(id, descripcion);

                    listaMarcas.Add(marca);
                }

                return listaMarcas;

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
