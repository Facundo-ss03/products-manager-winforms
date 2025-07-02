using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AppServices;
using AppModel;

namespace AppController
{
    public class ManejoDeConsultas
    {

        private List<Articulo> articulos;
        private DataGridView DataGrid;

        public void filtrar(DataGridView dgv, string criterio, string busqueda)
        {
            if(criterio == "Todos")
            {
                dgv.DataSource = articulos;
            }
            if (criterio == "Codigo")
            {
                dgv.DataSource = articulos.FindAll(x => x.codigo.ToUpper().Contains(busqueda));
            }
            if (criterio == "Nombre")
            {
                dgv.DataSource = articulos.FindAll(x => x.nombre.ToUpper().Contains(busqueda));
            }
            if (criterio == "Descripcion")
            {
                dgv.DataSource = articulos.FindAll(x => x.descripcion.ToUpper().Contains(busqueda));
            }
            if (criterio == "Marca")
            {
                dgv.DataSource = articulos.FindAll(x => x.marca.descripcion.ToUpper().Contains(busqueda));
            }
            if (criterio == "Categoria")
            {
                dgv.DataSource = articulos.FindAll(x => x.categoria.descripcion.ToUpper().Contains(busqueda));
            }
            if (criterio == "Precio")
            {
                dgv.DataSource = articulos.FindAll(x => x.precio.ToString().Contains(busqueda));
            }
        }

        public void actualizarDataGrid(DataGridView dgv)
        {
            ConsultasArticulos consultasArticulos = new ConsultasArticulos();

            articulos = consultasArticulos.consultarTablaArticulos();

            dgv.DataSource = articulos;
        }

        public void cargarSelector(ComboBox cmb, string comando)
        {
            cmb.ValueMember = "id";
            cmb.DisplayMember = "descripcion";

            if (comando == "CRITERIOS")
            {
                obtenerColumnas(cmb);
                return;
            }
            if (comando == "MARCAS")
            {
                ConsultasMarcas consulta = new ConsultasMarcas();
                List<Marca> lista;
                lista = consulta.listarMarcas();

                cmb.DataSource = lista;
            }
            if (comando == "CATEGORIAS")
            {
                ConsultasCategorias consulta = new ConsultasCategorias();
                List<Categoria> lista;
                lista = consulta.listarCategorias();

                cmb.DataSource = lista;
            }
        }

        public void obtenerColumnas(ComboBox cmb)
        {
            ConsultasArticulos consulta = new ConsultasArticulos();
            DataTable tabla = consulta.consultarColumnas();

            foreach (DataColumn item in tabla.Columns)
            {
                if(item.ColumnName != "ImagenUrl")
                {
                    cmb.Items.Add(item.ColumnName);
                }
            }
        }

        public void agregar(string codigo, string nombre, string descripcion, int idMarca, int idCategoria, string URLImagen, double precio)
        {
            ConsultasArticulos consulta = new ConsultasArticulos();
            consulta.agregarArticulo(codigo, nombre, descripcion, idMarca, idCategoria, URLImagen, precio);
        }

        public void modificar(int id, string codigo, string nombre, string descripcion, int idMarca, int idCategoria, string UrlImagen, double precio)
        {
            ConsultasArticulos consulta = new ConsultasArticulos();
            consulta.modificarArticulo(id, codigo, nombre, descripcion, idMarca, idCategoria, UrlImagen, precio);
        }

        public void eliminar(Object seleccion)
        {
            if (!(seleccion is Articulo))
                throw new ArgumentException("El objeto no es de tipo Artículo");

            ConsultasArticulos consulta = new ConsultasArticulos();
            Articulo articulo = (Articulo)seleccion;
            consulta.eliminarArticulo(articulo.id);
        }

        public bool comprobarCampoNumerico(string cadena)
        {
            bool salida = true;
            try
            {
                if(cadena != "")
                {
                    foreach (char item in cadena)
                    {
                        if (char.IsLetter(item))
                        {
                            salida = false;
                        }
                    }

                    if (double.Parse(cadena) < 0)
                    {
                        salida = false;
                    }
                }
                else
                {
                    salida = false;
                }

                return salida;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool comprobarCampoDeCaracteres(string cadena)
        {
            bool salida = true;
            try
            {
                if (cadena != "")
                {
                    foreach (char item in cadena)
                    {
                        if (char.IsNumber(item) && item != ' ')
                        {
                            salida = false;
                        }
                    }

                    if (ContieneSimbolos(cadena))
                    {
                        salida = false;
                    }
                }

                return salida;
            }
            catch(Exception)
            {
                return false; 
            }
        }

        public bool ContieneSimbolos(string cadena)
        {
            bool salida = false;
            foreach (char item in cadena)
            {
                if (char.IsSymbol(item))
                {
                    salida = true;
                }
            }
            return salida;
        }

        public void cargarImagen(PictureBox box, Object seleccion)
        {
            string imagenNotFound = "https://previews.123rf.com/images/yoginta/yoginta2301/yoginta230100567/196853824-imagen-no-encontrada-ilustraci%C3%B3n-vectorial.jpg";

            try
            {
                Articulo articulo = (Articulo)seleccion;
                box.Load(articulo.ImagenUrl);
            }
            catch (Exception ex)
            {
                box.Load(imagenNotFound);
            }
        }

        public void setearDataGrid(DataGridView grid)
        {
            this.DataGrid = grid;
        }
    }
}
