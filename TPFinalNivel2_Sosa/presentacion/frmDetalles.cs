using AppController;
using AppModel;
using System;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmDetalles : Form
    {
        public frmDetalles(Object seleccion)
        {
            InitializeComponent();

            this.controller = new ManejoDeConsultas();

            if (seleccion == null)
                throw new ArgumentException("El objeto pasado por parámetro es nulo.");

            if (!(seleccion is Articulo))
                throw new InvalidCastException("El objeto pasado por parámetro no es de tipo Artículo.");

            this.articulo = (Articulo)seleccion;
            cargarDatos();                               
        }

        Articulo articulo;
        ManejoDeConsultas controller;

        private void cargarDatos()
        {
            lblCodigo.Text += articulo.codigo;
            lblNombre.Text += articulo.nombre;
            lblDescripcion.Text += articulo.descripcion;
            lblPrecio.Text += articulo.precio.ToString();
            lblUrlImagen.Text += articulo.ImagenUrl;
            lblMarca.Text += articulo.marca.descripcion;
            lblCategorias.Text += articulo.categoria.descripcion;

            controller.cargarImagen(pictureBox1, articulo);
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Limpiar(bool disposing)
        {
            if (disposing)
            {
                // Liberar recursos manuales
                if (controller != null)
                {
                    if (controller is IDisposable disposableController)
                        disposableController.Dispose();

                    controller = null;
                }

                // Liberar imagen si es necesario
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }

            base.Dispose(disposing);
        }

    }
}
