
using System;
using System.Text;

namespace AppModel
{
    public class Marca
    {

        public Marca(int id, string descripcion)
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
