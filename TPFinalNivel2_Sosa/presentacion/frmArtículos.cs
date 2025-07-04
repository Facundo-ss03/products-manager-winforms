using AppModel;
using System;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using AppController;

namespace presentacion
{
    public partial class frmArtículos : Form
    {
        public frmArtículos(DataGridView dgv)
        {
            InitializeComponent();

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");
            articulo = null;
            this.dataGrid = dgv;
        }

        public frmArtículos(DataGridView dgv, Object seleccionado)
        {
            if (!(seleccionado is Articulo))
                throw new ArgumentException("El objeto no es de tipo Articulo.");

            InitializeComponent();

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");

            this.articulo = (Articulo)seleccionado;
            this.dataGrid = dgv;

        }

        private DataGridView dataGrid;
        private Articulo articulo;
        private ManejoDeConsultas controller;

        private void btnAceptar_Click(object sender, EventArgs e){

            DialogResult respuesta = DialogResult.Yes;
            bool agregadoExitoso = false;
                try {

                    string codigo = txtCodigo.Text;
                    string nombre = txtNombre.Text;
                    string descripcion = txtDescripcion.Text;
                    string url = txtUrlImagen.Text;

                    Categoria categoria = (Categoria)cmbCategorias.SelectedItem;
                    Marca marca = (Marca)cmbMarcas.SelectedItem;

                    double precio = Double.Parse(txtPrecio.Text);

                    if (articulo == null) {

                        agregadoExitoso = controller.agregar(txtCodigo.Text, txtNombre.Text, txtDescripcion.Text, marca.id, categoria.id, txtUrlImagen.Text, precio);
                        controller.actualizarDataGrid(dataGrid);

                    } else {

                        controller.modificar(articulo.id, txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                                                    marca.id, categoria.id, txtUrlImagen.Text, precio);
                        controller.actualizarDataGrid(dataGrid);

                        }
                    }
                catch (Exception ex){

                    Console.WriteLine(ex.ToString());

                    respuesta = MessageBox.Show("Los datos ingresados son inválidos. ¿Desea seguir editando?", "¡Advertencia!",
                                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta.Equals(DialogResult.No))
                        Close();
                }
            if (agregadoExitoso) Close();
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
                controller.cargarImagen(pictureBox1, articulo);
            }

            controller.cargarImagen(pictureBox1, null);

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

        private bool comprobarCampos()
        {
            bool salida = true;

            if (!controller.comprobarCampoDeCaracteres(txtDescripcion.Text))
            {
                salida = false;
                lblDescripcion.ForeColor = Color.Red;
            }
            else
            {
                lblDescripcion.ForeColor = Color.Black;
            }

            if (!controller.comprobarCampoDeCaracteres(txtNombre.Text))
            {
                salida = false;
                lblNombre.ForeColor = Color.Red;
            }
            else
            {
                lblNombre.ForeColor = Color.Black;
            }

            if (!controller.comprobarCampoNumerico(txtPrecio.Text))
            {
                lblPrecio.ForeColor = Color.Red;
                salida = false;
            }
            else
            {
                lblPrecio.ForeColor = Color.Black;
            }

            if (controller.ContieneSimbolos(txtCodigo.Text))
            {
                lblCodigo.ForeColor = Color.Red;
                salida = false;
            }
            else
            {
                lblCodigo.ForeColor = Color.Black;
            }

            return salida;
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            controller.cargarImagen(pictureBox1, txtUrlImagen.Text);
        }

        private void frmArtículos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }
    }
}
