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

            controller.cargarSelector(cmbCriterioDeBusqueda, "CRITERIOS");
        }

        ManejoDeConsultas controller;

        private void button2_Click(object sender, EventArgs e)
        {
            controller.cargarDataGrid(dataGridView1, cmbCriterioDeBusqueda.Text, txtBusqueda.Text.ToUpper());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmArtículos articulos = new frmArtículos();
            articulos.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
        }
    }
}
