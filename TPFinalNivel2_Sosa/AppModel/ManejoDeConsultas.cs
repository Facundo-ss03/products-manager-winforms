using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public void cargarDataGrid(DataGridView dgv)
        {
            dgv.DataSource = consulta.consultarListaArticulos();
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
            DataTable tabla = consulta.consultarListaArticulos();

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
