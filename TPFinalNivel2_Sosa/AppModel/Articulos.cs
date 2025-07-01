
using System.Data.SqlTypes;

namespace AppModel
{
    public class Articulos
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public string ImagenUrl { get; set; }
        public SqlMoney precio { get; set; }

    }
}
