
using AppModel;
using System.Data.SqlTypes;

namespace AppController
{
    public class ArticuloDTO
    {
        public ArticuloDTO(int id, string codigo, string nombre, string descripcion, Marca marca, Categoria categoria, string URLimagen, SqlMoney precio)
        {
            this.id = id;
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.categoria = categoria;
            this.ImagenUrl = URLimagen;
            this.precio = precio;
        }

        public int id { get; }
        public string codigo { get; }
        public string nombre { get; }
        public string descripcion { get; }
        public Marca marca { get; }
        public Categoria categoria { get; }
        public string ImagenUrl { get; }
        public SqlMoney precio { get; }

    }
}
