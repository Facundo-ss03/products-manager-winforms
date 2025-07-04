using System;
using System.Windows.Forms;
using AppController;

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
                frmArtículos modificar = new frmArtículos(dataGridView1, dataGridView1.CurrentRow.DataBoundItem);

                modificar.ShowDialog();
                GC.Collect();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ManejoDeConsultas consultas = new ManejoDeConsultas();
            ToolTip tool = new ToolTip();
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este artículo?", "Eliminado con éxito.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        consultas.eliminar(dataGridView1.CurrentRow.DataBoundItem);
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
                controller.cargarImagen(pbImagen, dataGridView1.Rows[0].DataBoundItem);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            controller.cargarImagen(pbImagen, dataGridView1.CurrentRow.DataBoundItem);
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            frmDetalles detalles;

            try
            {
                detalles = new frmDetalles(dataGridView1.CurrentRow.DataBoundItem);
                detalles.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay ningún elemento seleccionado." + ex.ToString());
            }

        }
    }
}
