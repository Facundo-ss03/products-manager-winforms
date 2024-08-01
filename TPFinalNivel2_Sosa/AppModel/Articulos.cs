using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AppModel
{
    public class Articulos
    {
        public Articulos(string codigo, string nombre, string descripcion, string marca, string categoria, SqlMoney precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.categoria = categoria;
            this.precio = precio;
        }

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public string categoria { get; set; }
        public SqlMoney precio { get; set; }
        
        private void convertir()
        {
            SqlMoney a = (SqlMoney)precio;
        }
    }
}
