
using System;

namespace AppModel
{
    public class Categoria
    {

        public Categoria(int id, string descripcion)
        {
            if (id < 0)
                throw new ArgumentException("La id es null.");
            if (descripcion.Length == 0)
                throw new ArgumentException("La descripcion está vacía.");

            this.id = id;
            this.descripcion = descripcion;

        }

        public int id { get; }
        public string descripcion { get; }
        public override string ToString()
        {
            return descripcion;
        }
    }
}
