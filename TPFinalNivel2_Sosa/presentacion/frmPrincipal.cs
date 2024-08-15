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
using AppController;
using System.Net;

namespace presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            cmbCriterioDeBusqueda.Items.Add("Todos");

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbCriterioDeBusqueda, "CRITERIOS");
        }

        ManejoDeConsultas controller;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            controller.filtrar(dataGridView1, cmbCriterioDeBusqueda.Text, txtBusqueda.Text.ToUpper());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmArtículos articulos = new frmArtículos(dataGridView1);

            articulos.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
            {
                Articulos seleccionado = (Articulos)dataGridView1.CurrentRow.DataBoundItem;
                frmArtículos modificar = new frmArtículos(dataGridView1, seleccionado);

                modificar.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ManejoDeConsultas consultas = new ManejoDeConsultas();
            Articulos seleccionado;
            ToolTip tool = new ToolTip();
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    seleccionado = (Articulos)dataGridView1.CurrentRow.DataBoundItem;
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este artículo?", "Eliminado con éxito.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        consultas.eliminar(seleccionado.id);
                        controller.actualizarDataGrid(dataGridView1);
                        tool.RemoveAll();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No hay ningún elemento seleccionado.");
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            controller.actualizarDataGrid(dataGridView1);
            dataGridView1.Columns["ImagenUrl"].Visible = false;

            if(dataGridView1.Rows.Count > 0)
            {
                Articulos articulo = (Articulos)dataGridView1.Rows[0].DataBoundItem;
                controller.cargarImagen(pbImagen, articulo.ImagenUrl);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Articulos articulo = (Articulos)dataGridView1.CurrentRow.DataBoundItem;
            controller.cargarImagen(pbImagen, articulo.ImagenUrl);
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            frmDetalles detalles;
            Articulos seleccionado;

            try
            {
                seleccionado = (Articulos)dataGridView1.CurrentRow.DataBoundItem;
                detalles = new frmDetalles(seleccionado);
                detalles.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay ningún elemento seleccionado.");
            }

        }
    }
}
