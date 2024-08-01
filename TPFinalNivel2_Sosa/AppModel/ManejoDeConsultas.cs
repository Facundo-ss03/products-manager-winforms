using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppServices;


namespace AppModel
{
    public class ManejoDeConsultas
    {
        public ManejoDeConsultas()
        {
            this.consulta = new Consultas();
        }

        Consultas consulta;

        public void cargarDataGrid(DataGridView dgv, string criterio, string busqueda)
        {
            List<Articulos> articulos = crearListaArticulos();

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
                dgv.DataSource = articulos.FindAll(x => x.marca.ToUpper().Contains(busqueda));
            }
            if (criterio == "Categoria")
            {
                dgv.DataSource = articulos.FindAll(x => x.categoria.ToUpper().Contains(busqueda));
            }
            if (criterio == "Precio")
            {
                dgv.DataSource = articulos.FindAll(x => x.precio.ToString().Contains(busqueda));
            }
        }


        public List<Articulos> crearListaArticulos()
        {
            List<Articulos> articulos = new List<Articulos>();
            DataTable dt = consulta.consultarTablaArticulos();

            foreach (DataRow columna in dt.Rows)
            {
                articulos.Add(new Articulos(columna["Codigo"].ToString(), columna["Nombre"].ToString(), 
                    
                    columna["Descripcion"].ToString(), columna["Marca"].ToString(), 
                    
                    columna["Categoria"].ToString(), SqlMoney.Parse(columna["Precio"].ToString())));
            }

            return articulos;
        }

        public void cargarSelector(ComboBox cmb, string comando)
        {

            if (comando == "MARCAS")
            {
                comando = "select * from MARCAS";
            }
            else
            {
                comando = "select* from CATEGORIAS";
            }

            DataTable tabla = consulta.consultarTablas(comando);

            foreach (DataRow categoria in tabla.Rows)
            {
                string item = Convert.ToString(categoria["Descripcion"]);
                cmb.Items.Add(item);
               
            }
        }

        public void obtenerColumnas(ComboBox cmb)
        {
            DataTable tabla = consulta.consultarTablaArticulos();

            foreach (DataColumn item in tabla.Columns)
            {
                cmb.Items.Add(item.ColumnName);
            }
        }

        public void agregar(string codigo, string Nombre, string descripcion, string marca, string categoria, string url, int precio)
        {
            consulta.agregarArticulo(codigo, Nombre, descripcion, marca, categoria, url, precio);
        }
    }
}
