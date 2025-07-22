using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AppServices;
using AppModel;
using System.Linq;
using System.IO;
using System.Drawing;

namespace AppController
{
    public class ManejoDeConsultas : IDisposable
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
        private Image imagenTemporal;


        public List<Articulo> filtrar(string criterio, string busqueda)
        {
            if (criterio.Equals("Codigo"))
            {
                return articulos.FindAll(x => x.codigo.ToUpper().Contains(busqueda));
            }
            if (criterio.Equals("Nombre"))
            {
                return articulos.FindAll(x => x.nombre.ToUpper().Contains(busqueda));
            }
            if (criterio.Equals("Descripcion"))
            {
                return articulos.FindAll(x => x.descripcion.ToUpper().Contains(busqueda));
            }
            if (criterio.Equals("Marca"))
            {
                return articulos.FindAll(x => x.marca.descripcion.ToUpper().Contains(busqueda));
            }
            if (criterio.Equals("Categoria"))
            {
                return articulos.FindAll(x => x.categoria.descripcion.ToUpper().Contains(busqueda));
            }
            if (criterio.Equals("Precio"))
            {
                return articulos.FindAll(x => x.precio.ToString().Contains(busqueda));
            }

            return articulos;
        }

        public List<Articulo> actualizarDataGrid()
        {
            ConsultasArticulos consultasArticulos = new ConsultasArticulos();

            articulos = consultasArticulos.consultarTablaArticulos();

            return articulos;
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
                Console.WriteLine(URLImagen.Length);
                ConsultasArticulos consulta = new ConsultasArticulos();
                return consulta.agregarArticulo(codigo, nombre, descripcion, idMarca, idCategoria, URLImagen, precio);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al agregar un artículo. " + ex.ToString());
            }

        }

        public bool modificar(int id, string codigo, string nombre, string descripcion, int idMarca, int idCategoria, string UrlImagen, double precio)
        {
            ConsultasArticulos consulta = new ConsultasArticulos();
            return consulta.modificarArticulo(id, codigo, nombre, descripcion, idMarca, idCategoria, UrlImagen, precio);
        }

        public void eliminar(Object seleccion)
        {
            if (!(seleccion is Articulo) && !(seleccion is DataGridViewSelectedRowCollection))
                throw new ArgumentException("El objeto no es de tipo Artículo ni una colección.");

            if(seleccion is Articulo)
            {
                ConsultasArticulos consulta = new ConsultasArticulos();
                Articulo articulo = (Articulo)seleccion;
                consulta.eliminarArticulo(articulo.id);

                consulta = null;
                articulo = null;
                return;
            }

            if (seleccion is DataGridViewSelectedRowCollection)
            {
                ConsultasArticulos consulta = new ConsultasArticulos();
                DataGridViewSelectedRowCollection coleccion = (DataGridViewSelectedRowCollection) seleccion;

                foreach (DataGridViewRow fila in coleccion)
                {
                    Articulo articulo = (Articulo)fila.DataBoundItem;
                    consulta.eliminarArticulo(articulo.id);
                }
            }

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

        public void cargarImagen(PictureBox box, string url)
        {
            // Lógica similar a la que ya usás, pero liberando la imagen previa
            if (box.Image != null)
            {
                box.Image.Dispose();
                box.Image = null;
            }

            // Cargar imagen nueva y guardarla por si luego hay que liberarla manualmente
            string imagenNotFound = "F:/repositorios/Nivel2Final/resources/imagen-no-encontrada.jpg";

            try
            {

                box.Load(url);
                imagenTemporal = box.Image; // Enlazás la imagen temporalmente
            }
            catch
            {
                box.Load(imagenNotFound);
                imagenTemporal = box.Image;
            }
        }

        public void cargarImagen(PictureBox box, object seleccion)
        {
            if (box.Image != null)
            {
                box.Image.Dispose();
                box.Image = null;
            }

            string imagenNotFound = "F:/repositorios/Nivel2Final/resources/imagen-no-encontrada.jpg";

            try
            {
                if (!(seleccion is Articulo articulo))
                    throw new ArgumentException("El objeto no es de tipo Artículo.");

                box.Load(articulo.ImagenUrl);
                imagenTemporal = box.Image;

            }
            catch
            {
                box.Load(imagenNotFound);
                imagenTemporal = box.Image;
            }
        }

        public void agregarMarca(string marca)
        {
            if (marca.Trim().Length == 0)
                throw new Exception("La marca que se intenta agregar está vacía.");

            bool existeMarca = false;

            foreach (var item in marcas)
            {
                if(item.descripcion.Equals(marca)) existeMarca = true;
            }

            if (!existeMarca)
            {

                ConsultasMarcas consulta = new ConsultasMarcas();
                consulta.Agregar(marca);
                marcas = consulta.listarMarcas();
            }
            
        }

        public void agregarCategoria(string categoria)
        {
            if (categoria.Trim().Length == 0)
                throw new Exception("La categoría que se intenta agregar está vacía.");

            bool existeCategoria = false;

            foreach (var item in categorias)
            {
                if (item.descripcion.Equals(categoria)) existeCategoria = true;
            }
            Console.WriteLine(existeCategoria);

            if (!existeCategoria)
            {

                ConsultasCategorias consulta = new ConsultasCategorias();
                consulta.Agregar(categoria);
                categorias = consulta.listarCategorias();
            }
        }

        public void eliminarCategoria(string categoria)
        {
            if(!categoria.Equals("Ninguna"))
            {
                ConsultasCategorias consulta = new ConsultasCategorias();
                consulta.Eliminar(categoria);

                categorias = consulta.listarCategorias();
            }
        }

        public void eliminarMarca(string marca)
        {
            if (!marca.Equals("Ninguna")){

                ConsultasMarcas consulta = new ConsultasMarcas();
                consulta.Eliminar(marca);

                marcas = consulta.listarMarcas();
            }
        }

        public void Dispose()
        {
            articulos = null;
            categorias = null;
            marcas = null;
            columnas = null;
        }
    }
}
