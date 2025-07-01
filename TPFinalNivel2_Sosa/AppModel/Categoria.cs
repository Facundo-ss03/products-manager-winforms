
namespace AppModel
{
    public class Categoria
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public override string ToString()
        {
            return descripcion;
        }
    }
}
