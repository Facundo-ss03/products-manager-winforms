
using System;
using System.Data.SqlTypes;
using System.Text;

namespace AppModel
{
    public class Articulo
    {
        public Articulo()
        {

        }

        public Articulo(int id, string codigo, string nombre, string descripcion, Marca marca, Categoria categoria, string URLimagen, SqlMoney precio)
        {

            validarArgumentos(id, codigo, nombre, descripcion, marca, categoria, URLimagen, precio);

            this.id = id;
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.categoria = categoria;
            this.ImagenUrl = URLimagen;
            this.precio = precio;
        }

        public static bool validarArgumentos(int id, string codigo, string nombre, string descripcion, Marca marca,
                                        Categoria categoria, string URLimagen, SqlMoney precio)
        {
            if (id < 0)
                throw new ArgumentException("El ID es negativo.");
            if (codigo.Length == 0)
                throw new ArgumentException("El codigo está vacío.");
            if (nombre.Length == 0)
                throw new ArgumentException("El nombre está vacío.");
            if (descripcion.Length == 0)
                throw new ArgumentException("La descripción está vacía.");
            if (marca == null)
                throw new ArgumentException("La marca es null.");
            if (categoria == null)
                throw new ArgumentException("La categoría es null.");
            if (URLimagen.Length == 0)
                throw new ArgumentException("La URL de la imagen está vacía.");
            if (precio < 0 || precio.IsNull)
                throw new ArgumentException("El precio es null o negativo.");

            return true;

        }
        public static bool validarArgumentos(string codigo, string nombre, string descripcion, int marca,
                                        int categoria, string URLimagen, double precio)
        {
            if (codigo.Length == 0)
                throw new ArgumentException("El codigo está vacío.");
            if (nombre.Length == 0)
                throw new ArgumentException("El nombre está vacío.");
            if (descripcion.Length == 0)
                throw new ArgumentException("La descripción está vacía.");
            if (marca <= 0)
                throw new ArgumentException("La marca es null.");
            if (categoria <= 0)
                throw new ArgumentException("La categoría es null.");
            if (URLimagen.Length == 0)
                throw new ArgumentException("La URL de la imagen está vacía.");
            if (precio < 0)
                throw new ArgumentException("El precio es null o negativo.");

            return true;

        }

        public int id { get; }
        public string codigo { get; }
        public string nombre { get; }
        public string descripcion { get; }
        public Marca marca { get; }
        public Categoria categoria { get; }
        public string ImagenUrl { get; }
        public SqlMoney precio { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Codigo: " + codigo);
            sb.Append(" Nombre: " + nombre);
            sb.Append(" Descripción: " + descripcion);
            sb.Append(" Marca: " + marca.ToString());
            sb.Append(" Categoria: " + categoria.ToString());
            sb.Append(" URL de imagen: " + ImagenUrl);
            sb.Append(" Precio: " + precio.ToString());
            return sb.ToString();
        }

    }
}
