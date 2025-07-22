using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppController;

namespace presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.Text = "Principal";
            this.Icon = new System.Drawing.Icon("F:/repositorios/Nivel2Final/resources/icono-principal.ico");

            cmbCriterioDeBusqueda.Items.Add("Todos");

            this.controller = new ManejoDeConsultas();

            controller.cargarSelector(cmbCriterioDeBusqueda, "CRITERIOS");
            controller.cargarSelector(cmbEliminarMarca, "MARCAS");
            controller.cargarSelector(cmbEliminarCategoria, "CATEGORIAS");
        }

        ManejoDeConsultas controller;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.filtrar(cmbCriterioDeBusqueda.Text, txtBusqueda.Text.ToUpper());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmArtículos());
            actualizarGrilla();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
            {
                abrirFormulario(new frmArtículos(dataGridView1.CurrentRow.DataBoundItem));
                actualizarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este artículo?", "Eliminado con éxito.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (dataGridView1.SelectedRows.Count == 1)
                        {
                            controller.eliminar(dataGridView1.CurrentRow.DataBoundItem);
                        }
                        else
                        {
                            controller.eliminar(dataGridView1.SelectedRows);
                        }

                        actualizarGrilla();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay ningún elemento seleccionado. " + ex.ToString());
            }
            finally
            {
                controller.Dispose();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            actualizarGrilla();
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
            try
            {

                abrirFormulario(new frmDetalles(dataGridView1.CurrentRow.DataBoundItem));

            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay ningún elemento seleccionado." + ex.ToString());
            }

        }

        private void btnAñadirMarca_Click(object sender, EventArgs e)
        {
            try
            {
                controller.agregarMarca(txtMarca.Text);
                controller.cargarSelector(cmbEliminarMarca, "MARCAS");
                txtMarca.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al agregar la marca. " + ex.ToString()); ;
            }
        }

        private void btnAñadirCategoría_Click(object sender, EventArgs e)
        {
            try
            {
                controller.agregarCategoria(txtCategoria.Text);
                controller.cargarSelector(cmbEliminarCategoria, "CATEGORIAS");
                txtCategoria.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al agregar la categoría. " + ex.ToString());
            }
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar esta marca? " +
                                                        "Se eliminarán todos los artículos relacionados a ella.",
                                                        "Eliminar categoría", MessageBoxButtons.YesNo);
                
                if(respuesta == DialogResult.Yes)
                {
                    controller.eliminarMarca(cmbEliminarMarca.Text);
                    controller.cargarSelector(cmbEliminarMarca, "MARCAS");
                    actualizarGrilla();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la marca. " + ex.ToString());
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar esta categoría? " +
                                                        "Se eliminarán todos los artículos relacionados a ella.",
                                                        "Eliminar categoría", MessageBoxButtons.YesNo);

                if(respuesta == DialogResult.Yes)
                {
                    controller.eliminarCategoria(cmbEliminarCategoria.Text);
                    controller.cargarSelector(cmbEliminarCategoria, "CATEGORIAS");
                    actualizarGrilla();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la categoría. " + ex.ToString());
            }

        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = InputsAlfabeticos.esCaracterAlfabetico(e.KeyChar);
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = InputsAlfabeticos.esCaracterAlfabetico(e.KeyChar);
        }

        private void abrirFormulario(Form formulario)
        {
            using(var form = formulario)
            {
                formulario.ShowDialog();
            }
        }

        private void actualizarGrilla()
        { 
            dataGridView1.DataSource = controller.actualizarDataGrid();
        }
    }
}
