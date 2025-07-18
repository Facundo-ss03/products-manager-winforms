namespace presentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCriterioDeBusqueda = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.btnAñadirMarca = new System.Windows.Forms.Button();
            this.btnAñadirCategoría = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnEliminarMarca = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.cmbEliminarMarca = new System.Windows.Forms.ComboBox();
            this.cmbEliminarCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 96);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(923, 613);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbCriterioDeBusqueda);
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(13, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1239, 76);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(523, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar por:";
            // 
            // cmbCriterioDeBusqueda
            // 
            this.cmbCriterioDeBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterioDeBusqueda.FormattingEnabled = true;
            this.cmbCriterioDeBusqueda.Location = new System.Drawing.Point(111, 34);
            this.cmbCriterioDeBusqueda.Name = "cmbCriterioDeBusqueda";
            this.cmbCriterioDeBusqueda.Size = new System.Drawing.Size(180, 22);
            this.cmbCriterioDeBusqueda.TabIndex = 1;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(297, 34);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(220, 22);
            this.txtBusqueda.TabIndex = 2;
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(952, 96);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(300, 300);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 9;
            this.pbImagen.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(952, 429);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(148, 48);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1106, 429);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(148, 48);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(952, 490);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(148, 48);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Location = new System.Drawing.Point(1106, 490);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(148, 48);
            this.btnVerDetalles.TabIndex = 10;
            this.btnVerDetalles.Text = "Ver detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // btnAñadirMarca
            // 
            this.btnAñadirMarca.Location = new System.Drawing.Point(952, 551);
            this.btnAñadirMarca.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnAñadirMarca.Name = "btnAñadirMarca";
            this.btnAñadirMarca.Size = new System.Drawing.Size(148, 22);
            this.btnAñadirMarca.TabIndex = 11;
            this.btnAñadirMarca.Text = "Añadir marca";
            this.btnAñadirMarca.UseVisualStyleBackColor = true;
            this.btnAñadirMarca.Click += new System.EventHandler(this.btnAñadirMarca_Click);
            // 
            // btnAñadirCategoría
            // 
            this.btnAñadirCategoría.Location = new System.Drawing.Point(952, 628);
            this.btnAñadirCategoría.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnAñadirCategoría.Name = "btnAñadirCategoría";
            this.btnAñadirCategoría.Size = new System.Drawing.Size(148, 22);
            this.btnAñadirCategoría.TabIndex = 12;
            this.btnAñadirCategoría.Text = "Añadir categoría";
            this.btnAñadirCategoría.UseVisualStyleBackColor = true;
            this.btnAñadirCategoría.Click += new System.EventHandler(this.btnAñadirCategoría_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(952, 586);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(148, 22);
            this.txtMarca.TabIndex = 4;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(952, 663);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(148, 22);
            this.txtCategoria.TabIndex = 13;
            // 
            // btnEliminarMarca
            // 
            this.btnEliminarMarca.Location = new System.Drawing.Point(1106, 551);
            this.btnEliminarMarca.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnEliminarMarca.Name = "btnEliminarMarca";
            this.btnEliminarMarca.Size = new System.Drawing.Size(148, 22);
            this.btnEliminarMarca.TabIndex = 14;
            this.btnEliminarMarca.Text = "Eliminar marca";
            this.btnEliminarMarca.UseVisualStyleBackColor = true;
            this.btnEliminarMarca.Click += new System.EventHandler(this.btnEliminarMarca_Click);
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Location = new System.Drawing.Point(1106, 628);
            this.btnEliminarCategoria.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(148, 22);
            this.btnEliminarCategoria.TabIndex = 15;
            this.btnEliminarCategoria.Text = "Eliminar categoría";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            // 
            // cmbEliminarMarca
            // 
            this.cmbEliminarMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEliminarMarca.FormattingEnabled = true;
            this.cmbEliminarMarca.Location = new System.Drawing.Point(1106, 586);
            this.cmbEliminarMarca.Name = "cmbEliminarMarca";
            this.cmbEliminarMarca.Size = new System.Drawing.Size(146, 22);
            this.cmbEliminarMarca.TabIndex = 4;
            // 
            // cmbEliminarCategoria
            // 
            this.cmbEliminarCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEliminarCategoria.FormattingEnabled = true;
            this.cmbEliminarCategoria.Location = new System.Drawing.Point(1106, 663);
            this.cmbEliminarCategoria.Name = "cmbEliminarCategoria";
            this.cmbEliminarCategoria.Size = new System.Drawing.Size(146, 22);
            this.cmbEliminarCategoria.TabIndex = 16;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.cmbEliminarCategoria);
            this.Controls.Add(this.cmbEliminarMarca);
            this.Controls.Add(this.btnEliminarCategoria);
            this.Controls.Add(this.btnEliminarMarca);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.btnAñadirCategoría);
            this.Controls.Add(this.btnAñadirMarca);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCriterioDeBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnAñadirMarca;
        private System.Windows.Forms.Button btnAñadirCategoría;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Button btnEliminarMarca;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.ComboBox cmbEliminarMarca;
        private System.Windows.Forms.ComboBox cmbEliminarCategoria;
    }
}

