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
            frmArtículos agregar = new frmArtículos();

            agregar.ShowDialog();
            agregar.Limpiar(true);
            dataGridView1.DataSource = controller.actualizarDataGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
            {
                frmArtículos modificar = new frmArtículos(/*dataGridView1, */dataGridView1.CurrentRow.DataBoundItem);

                modificar.ShowDialog();
                modificar.Limpiar(true);
                dataGridView1.DataSource = controller.actualizarDataGrid();
                GC.Collect();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ToolTip tool = new ToolTip();
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

                        dataGridView1.DataSource = controller.actualizarDataGrid();
                        tool.RemoveAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay ningún elemento seleccionado. " + ex.ToString());
            }
            finally
            {
                tool.Dispose();
                controller.Dispose();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.actualizarDataGrid();
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
                using (var detalles = new frmDetalles(dataGridView1.CurrentRow.DataBoundItem))
                {
                    detalles.ShowDialog();
                    detalles.Limpiar(true);
                }
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
                    dataGridView1.DataSource = controller.actualizarDataGrid();
                
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
                    dataGridView1.DataSource = controller.actualizarDataGrid();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la categoría. " + ex.ToString());
            }

        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = esLetra(e.KeyChar);
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = esLetra(e.KeyChar);
        }

        private bool esLetra(char caracter)
        {
            if (!char.IsControl(caracter) && !char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                return true;
            else return false;
        }
    }
}
