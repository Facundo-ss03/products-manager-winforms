using AppController;
using AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmDetalles : Form
    {
        public frmDetalles(Articulos articulo)
        {
            InitializeComponent();

            this.controller = new ManejoDeConsultas();
            cargarDatos(articulo);
        }

        ManejoDeConsultas controller;

        private void cargarDatos(Articulos articulo)
        {
            lblCodigo.Text += articulo.codigo;
            lblNombre.Text += articulo.nombre;
            lblDescripcion.Text += articulo.descripcion;
            lblPrecio.Text += articulo.precio.ToString();
            lblUrlImagen.Text += articulo.ImagenUrl;
            lblMarca.Text += articulo.marca.descripcion;
            lblCategorias.Text += articulo.categoria.descripcion;

            controller.cargarImagen(pictureBox1, articulo.ImagenUrl);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
