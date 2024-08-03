using AppServices;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace AppModel
{
    public class Articulos
    {
        public Articulos(string codigo, string nombre, string descripcion, string marca, string categoria, string url, SqlMoney precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.marca = marca;
            this.categoria = categoria;
            this.ImagenUrl = url;
            this.precio = precio;

            Consultas consulta = new Consultas();

            DataTable marcas = consulta.consultarTablas("Select * From MARCAS");
            DataTable categorias = consulta.consultarTablas("Select * From CATEGORIAS");

            this.IdMarca = obtenerId(marcas, marca);
            this.IdCategoria = obtenerId(categorias, categoria);
        }

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public string categoria { get; set; }
        private string ImagenUrl { get; set; }
        public SqlMoney precio { get; set; }

        private int IdMarca ;
        private int IdCategoria;

        public int obtenerId(DataTable tabla, string descripcion)
        {
            int id = 0;

            foreach (DataRow row in tabla.Rows)
            {
                if (descripcion == (string)row["Descripcion"])
                {
                    id = (int)row["Id"];
                }
            }

            return id;
        }

        public int getIdMarca()
        {
            MessageBox.Show(IdMarca.ToString());
            return IdMarca;
        }
        public int getIdCategoria()
        {
            MessageBox.Show(IdCategoria.ToString());
            return IdCategoria;
        }
        public string getImagenUrl()
        {
            return ImagenUrl;
        }

    }
}
