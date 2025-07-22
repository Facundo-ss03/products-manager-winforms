using AppController;
using System;
using System.Windows.Forms;
using System.Text;

namespace presentacion
{
    public partial class frmDetalles : Form
    {
        public frmDetalles(Object seleccion)
        {
            InitializeComponent();
            this.Text = "Detalles";
            this.Icon = new System.Drawing.Icon("F:/repositorios/Nivel2Final/resources/detalles.ico");

            this.controller = new ManejoDeConsultas();

            if (seleccion == null)
                throw new ArgumentException("El objeto pasado por parámetro es nulo.");

            cargarDatos(seleccion);                               
        }

        ManejoDeConsultas controller;

        private void cargarDatos(Object articulo)
        {
            lblPrueba.Text = controller.ObtenerDetallesDeArticulo(articulo);
            controller.cargarImagen(pictureBox1, articulo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalles_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
