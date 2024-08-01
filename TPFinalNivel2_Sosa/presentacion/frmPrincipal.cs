using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppModel;

namespace presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            cmbCriterioDeBusqueda.Items.Add("Todos");

            this.controller = new ManejoDeConsultas();

            controller.obtenerColumnas(cmbCriterioDeBusqueda);
            controller.cargarSelector(cmbMarcas, "MARCAS");
            controller.cargarSelector(cmbCategorias, "CATEGORIAS");
        }

        ManejoDeConsultas controller;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            controller.agregar(txtCodigo.Text, txtTitulo.Text, txtDescripcion.Text, cmbMarcas.SelectedValue.ToString(), cmbCategorias.SelectedValue.ToString(), txtUrlImagen.Text, Convert.ToInt32(nudCantidad.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.cargarDataGrid(dataGridView1, cmbCriterioDeBusqueda.Text, txtBusqueda.Text.ToUpper());
        }
    }
}
