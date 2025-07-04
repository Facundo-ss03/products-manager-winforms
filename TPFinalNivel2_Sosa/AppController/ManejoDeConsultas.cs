using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AppServices;
using AppModel;
using System.Linq;
using System.IO;

namespace AppController
{
    public class ManejoDeConsultas
    {
        public ManejoDeConsultas()
        {
            ConsultasMarcas consultaMarcas = new ConsultasMarcas();
            ConsultasCategorias consultaCategorias = new ConsultasCategorias();
            ConsultasArticulos consultaArticulos = new ConsultasArticulos();

            this.categorias = consultaCategorias.listarCategorias();
            this.marcas = consultaMarcas.listarMarcas();
            this.columnas = consultaArticulos.consultarColumnas();
        }

        private List<Articulo> articulos;
        private List<Categoria> categorias;
        private List<Marca> marcas;
        private DataTable columnas;
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
                cmb.DataSource = marcas;
            }
            if (comando == "CATEGORIAS")
            {
                cmb.DataSource = categorias;
            }
        }

        public void obtenerColumnas(ComboBox cmb)
        {
            foreach (DataColumn item in columnas.Columns)
            {
                if(item.ColumnName != "ImagenUrl")
                {
                    cmb.Items.Add(item.ColumnName);
                }
            }
        }

        public bool agregar(string codigo, string nombre, string descripcion, int idMarca, int idCategoria, string URLImagen, double precio)
        {
            try
            {
                ConsultasArticulos consulta = new ConsultasArticulos();
                return consulta.agregarArticulo(codigo, nombre, descripcion, idMarca, idCategoria, URLImagen, precio);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al agregar un artículo. " + ex.ToString());
            }

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
            bool cadenaEsVálida = cadena.Length > 0 && !cadena.Any(char.IsLetter);
            Console.WriteLine(cadenaEsVálida);
            return cadenaEsVálida;
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
            Articulo articulo;

            try
            {
                if (seleccion == null || seleccion is Articulo)
                    throw new ArgumentException("El objeto no es de tipo Artículo o es nulo.");

                articulo = (Articulo)seleccion;
                box.Load(articulo.ImagenUrl);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontró la URL de la imagen. " + ex.ToString());
                box.Load(imagenNotFound);
            }
        }

        public void setearDataGrid(DataGridView grid)
        {
            this.DataGrid = grid;
        }
    }
}
