namespace presentacion
{
    partial class frmArtículos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbMarcas = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(37, 143);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 21;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(40, 160);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(13, 3, 13, 22);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(180, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(37, 265);
            this.lblUrlImagen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(84, 13);
            this.lblUrlImagen.TabIndex = 19;
            this.lblUrlImagen.Text = "URL de imagen:";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(40, 282);
            this.txtUrlImagen.Margin = new System.Windows.Forms.Padding(13, 3, 13, 22);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(180, 20);
            this.txtUrlImagen.TabIndex = 5;
            this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(37, 21);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(40, 38);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(13, 3, 13, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(180, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCategorias
            // 
            this.lblCategorias.AutoSize = true;
            this.lblCategorias.Location = new System.Drawing.Point(37, 385);
            this.lblCategorias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(59, 13);
            this.lblCategorias.TabIndex = 13;
            this.lblCategorias.Text = "Categoriía:";
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(40, 404);
            this.cmbCategorias.Margin = new System.Windows.Forms.Padding(10, 5, 10, 20);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(180, 21);
            this.cmbCategorias.TabIndex = 7;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(37, 324);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 11;
            this.lblMarca.Text = "Marca:";
            // 
            // cmbMarcas
            // 
            this.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarcas.FormattingEnabled = true;
            this.cmbMarcas.Location = new System.Drawing.Point(40, 343);
            this.cmbMarcas.Margin = new System.Windows.Forms.Padding(10, 5, 10, 20);
            this.cmbMarcas.Name = "cmbMarcas";
            this.cmbMarcas.Size = new System.Drawing.Size(180, 21);
            this.cmbMarcas.TabIndex = 6;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(37, 204);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(37, 82);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(240, 448);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(180, 37);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(40, 99);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(13, 3, 13, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(40, 448);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 37);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(40, 220);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(13, 3, 13, 22);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(180, 20);
            this.txtPrecio.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(440, 448);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(180, 37);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(318, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // frmArtículos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 505);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCategorias);
            this.Controls.Add(this.cmbCategorias);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cmbMarcas);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblPrecio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmArtículos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmArtículos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCategorias;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarcas;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}