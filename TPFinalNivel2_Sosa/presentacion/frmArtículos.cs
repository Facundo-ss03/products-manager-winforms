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

            this.dataGrid = dgv;
        }

        public frmArtículos(DataGridView dgv, Articulos seleccionado)
        {
            InitializeComponent();

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");

            this.articulo = seleccionado;
            this.dataGrid = dgv;

        }

        private DataGridView dataGrid;
        private Articulos articulo = null;
        private ManejoDeConsultas controller;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            {
                if (comprobarCampos())
                {
                    string codigo = txtCodigo.Text;
                    string nombre = txtNombre.Text;
                    string descripcion = txtDescripcion.Text;
                    string url = txtUrlImagen.Text;

                    Categoria categoria = (Categoria)cmbCategorias.SelectedItem;
                    Marca marca = (Marca)cmbMarcas.SelectedItem;
                    SqlMoney precio = SqlMoney.Parse(txtPrecio.Text);

                    if (articulo == null)
                    {
                        articulo = new Articulos();
                    }

                    articulo.codigo = codigo;
                    articulo.nombre = nombre;
                    articulo.descripcion = descripcion;
                    articulo.marca = new Marca();
                    articulo.marca.id = marca.id;
                    articulo.marca.descripcion = marca.descripcion;
                    articulo.categoria = new Categoria();
                    articulo.categoria.descripcion = categoria.descripcion;
                    articulo.categoria.id = categoria.id;
                    articulo.ImagenUrl = url;
                    articulo.precio = precio;

                    if(articulo.id == 0)
                    {
                        controller.agregar(articulo);
                        controller.actualizarDataGrid(dataGrid);
                    }
                    else
                    {
                        controller.modificar(articulo);
                        controller.actualizarDataGrid(dataGrid);
                    }
                }
                else
                {
                    MessageBox.Show("Hay campos con datos incorrectos");
                    return;
                }
            }
            this.Close();
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
            }

            controller.cargarImagen(pictureBox1, "");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtUrlImagen.Text = "";

            cmbMarcas.Text = "";
            cmbCategorias.Text = "";

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
