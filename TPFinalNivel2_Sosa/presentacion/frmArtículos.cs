using AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmArtículos : Form
    {
        public frmArtículos()
        {
            InitializeComponent();

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");
        }

        ManejoDeConsultas controller;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string url = txtUrlImagen.Text;
            string marca = cmbMarcas.Text;
            string categoria = cmbCategorias.Text;
            SqlMoney precio = SqlMoney.Parse(txtPrecio.Text);

            Articulos nuevo = new Articulos(codigo, nombre, descripcion, marca, categoria, url, precio);

            controller.agregar(nuevo);
            Close();
        }
    }
}
