using AppModel;
using System;
using System.Drawing;
using System.Windows.Forms;
using AppController;

namespace presentacion
{
    public partial class frmArtículos : Form
    {
        public frmArtículos()
        {
            InitializeComponent();

            this.Text = "Crear Artículo";
            this.Icon = new System.Drawing.Icon("F:/repositorios/Nivel2Final/resources/nuevoArticulo.ico");

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");
            articulo = null;
        }

        public frmArtículos(Object articuloSeleccionado)
        {
            if (!(articuloSeleccionado is Articulo))
                throw new ArgumentException("El objeto no es de tipo Articulo.");

            InitializeComponent();
            this.Text = "Modificar Artículo";
            this.Icon = new System.Drawing.Icon("F:/repositorios/Nivel2Final/resources/nuevoArticulo.ico");

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");

            this.articulo = controller.ObtenerArticuloDTO(articuloSeleccionado);
        }

        private ArticuloDTO articulo;
        private ManejoDeConsultas controller;

        private void btnAceptar_Click(object sender, EventArgs e) {

            DialogResult respuesta;
            bool operacionExitosa = false;

            try {

                operacionExitosa = AgregarOModificarArticulo();

            }
            catch (Exception ex) {

                Console.WriteLine(ex.ToString());

                respuesta = MessageBox.Show("Los datos ingresados son inválidos. ¿Desea seguir editando?", "¡Advertencia!",
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta.Equals(DialogResult.No))
                    Close();
            }
            if (operacionExitosa) Close();
        }

        private bool AgregarOModificarArticulo()
        {
            Categoria categoria = (Categoria)cmbCategorias.SelectedItem;
            Marca marca = (Marca)cmbMarcas.SelectedItem;
            double precio = ConvertirPrecioADouble(txtPrecio.Text);

            bool resultado;

            if (articulo == null)
                resultado = AgregarArticulo(categoria, marca, precio);
            else resultado = ModificarArticulo(articulo.categoria, articulo.marca, precio);

            return resultado;
        }

        private bool AgregarArticulo(Categoria categoria, Marca marca, double precio)
        {
            return controller.agregar(txtCodigo.Text,
                                      txtNombre.Text,
                                      txtDescripcion.Text,
                                      marca.id,
                                      categoria.id,
                                      txtUrlImagen.Text,
                                      precio);
        }

        private bool ModificarArticulo(Categoria categoria, Marca marca, double precio)
        {
            return controller.modificar(articulo.id,
                                        txtCodigo.Text,
                                        txtNombre.Text,
                                        txtDescripcion.Text,
                                        marca.id,
                                        categoria.id,
                                        txtUrlImagen.Text,
                                        precio);
        }

        private double ConvertirPrecioADouble(string precio)
        {
            return Double.Parse(precio);
        }

        private void frmArtículos_Load(object sender, EventArgs e)
        {
            if(articulo != null)
            {
                txtCodigo.Text = articulo.codigo;
                txtNombre.Text = articulo.nombre;
                txtDescripcion.Text = articulo.descripcion;
                txtPrecio.Text = articulo.precio.ToString();

                if (articulo.ImagenUrl != "")
                {
                    txtUrlImagen.Text = articulo.ImagenUrl;
                }

                cmbMarcas.Text = articulo.marca.descripcion;
                cmbCategorias.Text = articulo.categoria.descripcion;
                controller.cargarImagen(pictureBox1, articulo.ImagenUrl);
            } else
            {
                controller.cargarImagen(pictureBox1, null);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtUrlImagen.Clear();
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            controller.cargarImagen(pictureBox1, txtUrlImagen.Text);
        }

        private void frmArtículos_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.desecharImagen(pictureBox1);
            Dispose();
        }
        
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = InputsNumericos.esCaracterNumerico(e.KeyChar);

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = InputsAlfabeticos.esCaracterAlfabetico(e.KeyChar);

        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = InputsAlfabeticos.esCaracterAlfabetico(e.KeyChar);

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = InputsNumericos.esCaracterNumerico(e.KeyChar);

        }

        private void txtUrlImagen_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = InputsAlfabeticos.esCaracterAlfabetico(e.KeyChar);

        }
    }
}
