namespace P1_LENGUAJES_FP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtIngresoCodigo = new System.Windows.Forms.RichTextBox();
            this.btnGuardarError = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuOpciones = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGuardarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProyecto = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrearNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCompilar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSalidaError = new System.Windows.Forms.RichTextBox();
            this.labeOutput = new System.Windows.Forms.Label();
            this.labelFila = new System.Windows.Forms.Label();
            this.labelColumna = new System.Windows.Forms.Label();
            this.lboxArchivosProyecto = new System.Windows.Forms.ListBox();
            this.lblLogoProyecto = new System.Windows.Forms.Label();
            this.lblProyecto = new System.Windows.Forms.Label();
            this.btnLimpiarSalida = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIngresoCodigo
            // 
            this.txtIngresoCodigo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIngresoCodigo.Location = new System.Drawing.Point(26, 40);
            this.txtIngresoCodigo.Name = "txtIngresoCodigo";
            this.txtIngresoCodigo.Size = new System.Drawing.Size(890, 376);
            this.txtIngresoCodigo.TabIndex = 0;
            this.txtIngresoCodigo.Text = "";
            this.txtIngresoCodigo.Click += new System.EventHandler(this.txtIngresoCodigo_Click);
            // 
            // btnGuardarError
            // 
            this.btnGuardarError.Location = new System.Drawing.Point(26, 613);
            this.btnGuardarError.Name = "btnGuardarError";
            this.btnGuardarError.Size = new System.Drawing.Size(126, 23);
            this.btnGuardarError.TabIndex = 1;
            this.btnGuardarError.Text = "Guardar Errores";
            this.btnGuardarError.UseVisualStyleBackColor = true;
            this.btnGuardarError.Click += new System.EventHandler(this.btnGuardarError_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpciones,
            this.menuGuardar,
            this.menuCrearNuevo,
            this.menuCerrar,
            this.itemCompilar,
            this.menuAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1174, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuOpciones
            // 
            this.menuOpciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbrir,
            this.itemGuardarComo,
            this.itemProyecto,
            this.itemSalir});
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Size = new System.Drawing.Size(60, 20);
            this.menuOpciones.Text = "Archivo";
            // 
            // itemAbrir
            // 
            this.itemAbrir.Image = ((System.Drawing.Image)(resources.GetObject("itemAbrir.Image")));
            this.itemAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itemAbrir.Name = "itemAbrir";
            this.itemAbrir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.itemAbrir.Size = new System.Drawing.Size(192, 22);
            this.itemAbrir.Text = "Abrir";
            this.itemAbrir.Click += new System.EventHandler(this.itemAbrir_Click);
            // 
            // itemGuardarComo
            // 
            this.itemGuardarComo.Image = ((System.Drawing.Image)(resources.GetObject("itemGuardarComo.Image")));
            this.itemGuardarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itemGuardarComo.Name = "itemGuardarComo";
            this.itemGuardarComo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.itemGuardarComo.Size = new System.Drawing.Size(192, 22);
            this.itemGuardarComo.Text = "Guardar como";
            this.itemGuardarComo.Click += new System.EventHandler(this.itemGuardarComo_Click);
            // 
            // itemProyecto
            // 
            this.itemProyecto.Name = "itemProyecto";
            this.itemProyecto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.itemProyecto.Size = new System.Drawing.Size(192, 22);
            this.itemProyecto.Text = "Abrir Proyecto";
            this.itemProyecto.Click += new System.EventHandler(this.itemProyecto_Click);
            // 
            // itemSalir
            // 
            this.itemSalir.Name = "itemSalir";
            this.itemSalir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.itemSalir.Size = new System.Drawing.Size(192, 22);
            this.itemSalir.Text = "Salir";
            this.itemSalir.Click += new System.EventHandler(this.itemSalir_Click);
            // 
            // menuGuardar
            // 
            this.menuGuardar.Name = "menuGuardar";
            this.menuGuardar.Size = new System.Drawing.Size(61, 20);
            this.menuGuardar.Text = "Guardar";
            this.menuGuardar.Click += new System.EventHandler(this.menuGuardar_Click);
            // 
            // menuCrearNuevo
            // 
            this.menuCrearNuevo.Name = "menuCrearNuevo";
            this.menuCrearNuevo.Size = new System.Drawing.Size(151, 20);
            this.menuCrearNuevo.Text = "Crear Nuevo Documento";
            this.menuCrearNuevo.Click += new System.EventHandler(this.menuCrearNuevo_Click);
            // 
            // menuCerrar
            // 
            this.menuCerrar.Name = "menuCerrar";
            this.menuCerrar.Size = new System.Drawing.Size(51, 20);
            this.menuCerrar.Text = "Cerrar";
            this.menuCerrar.Click += new System.EventHandler(this.menuCerrar_Click);
            // 
            // itemCompilar
            // 
            this.itemCompilar.Name = "itemCompilar";
            this.itemCompilar.Size = new System.Drawing.Size(68, 20);
            this.itemCompilar.Text = "Compilar";
            this.itemCompilar.Click += new System.EventHandler(this.itemCompilar_Click);
            // 
            // menuAyuda
            // 
            this.menuAyuda.Name = "menuAyuda";
            this.menuAyuda.Size = new System.Drawing.Size(53, 20);
            this.menuAyuda.Text = "Ayuda";
            // 
            // txtSalidaError
            // 
            this.txtSalidaError.Location = new System.Drawing.Point(26, 470);
            this.txtSalidaError.Name = "txtSalidaError";
            this.txtSalidaError.ReadOnly = true;
            this.txtSalidaError.Size = new System.Drawing.Size(890, 137);
            this.txtSalidaError.TabIndex = 3;
            this.txtSalidaError.Text = "";
            // 
            // labeOutput
            // 
            this.labeOutput.AutoSize = true;
            this.labeOutput.Location = new System.Drawing.Point(26, 452);
            this.labeOutput.Name = "labeOutput";
            this.labeOutput.Size = new System.Drawing.Size(41, 15);
            this.labeOutput.TabIndex = 4;
            this.labeOutput.Text = "Salida:";
            // 
            // labelFila
            // 
            this.labelFila.AutoSize = true;
            this.labelFila.Location = new System.Drawing.Point(739, 419);
            this.labelFila.Name = "labelFila";
            this.labelFila.Size = new System.Drawing.Size(40, 15);
            this.labelFila.TabIndex = 5;
            this.labelFila.Text = "Fila:  1";
            // 
            // labelColumna
            // 
            this.labelColumna.AutoSize = true;
            this.labelColumna.Location = new System.Drawing.Point(537, 419);
            this.labelColumna.Name = "labelColumna";
            this.labelColumna.Size = new System.Drawing.Size(71, 15);
            this.labelColumna.TabIndex = 6;
            this.labelColumna.Text = "Columna:  1";
            // 
            // lboxArchivosProyecto
            // 
            this.lboxArchivosProyecto.FormattingEnabled = true;
            this.lboxArchivosProyecto.ItemHeight = 15;
            this.lboxArchivosProyecto.Location = new System.Drawing.Point(971, 68);
            this.lboxArchivosProyecto.Name = "lboxArchivosProyecto";
            this.lboxArchivosProyecto.Size = new System.Drawing.Size(171, 334);
            this.lboxArchivosProyecto.TabIndex = 7;
            this.lboxArchivosProyecto.SelectedIndexChanged += new System.EventHandler(this.lboxArchivosProyecto_SelectedIndexChanged);
            // 
            // lblLogoProyecto
            // 
            this.lblLogoProyecto.AutoSize = true;
            this.lblLogoProyecto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblLogoProyecto.Location = new System.Drawing.Point(971, 24);
            this.lblLogoProyecto.Name = "lblLogoProyecto";
            this.lblLogoProyecto.Size = new System.Drawing.Size(181, 17);
            this.lblLogoProyecto.TabIndex = 8;
            this.lblLogoProyecto.Text = "EXPLORADOR DE ARCHIVOS";
            this.lblLogoProyecto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProyecto
            // 
            this.lblProyecto.AutoSize = true;
            this.lblProyecto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProyecto.Location = new System.Drawing.Point(980, 40);
            this.lblProyecto.Name = "lblProyecto";
            this.lblProyecto.Size = new System.Drawing.Size(0, 17);
            this.lblProyecto.TabIndex = 9;
            this.lblProyecto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLimpiarSalida
            // 
            this.btnLimpiarSalida.Location = new System.Drawing.Point(182, 613);
            this.btnLimpiarSalida.Name = "btnLimpiarSalida";
            this.btnLimpiarSalida.Size = new System.Drawing.Size(105, 23);
            this.btnLimpiarSalida.TabIndex = 10;
            this.btnLimpiarSalida.Text = "Limpiar Salida";
            this.btnLimpiarSalida.UseVisualStyleBackColor = true;
            this.btnLimpiarSalida.Click += new System.EventHandler(this.btnLimpiarSalida_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 657);
            this.Controls.Add(this.btnLimpiarSalida);
            this.Controls.Add(this.lblProyecto);
            this.Controls.Add(this.lblLogoProyecto);
            this.Controls.Add(this.lboxArchivosProyecto);
            this.Controls.Add(this.labelColumna);
            this.Controls.Add(this.labelFila);
            this.Controls.Add(this.labeOutput);
            this.Controls.Add(this.txtSalidaError);
            this.Controls.Add(this.btnGuardarError);
            this.Controls.Add(this.txtIngresoCodigo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LENGUAJE FORMAL Y DE PROGRAMACION 2020";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtIngresoCodigo;
        private System.Windows.Forms.Button btnGuardarError;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem itemAbrir;
        private System.Windows.Forms.ToolStripMenuItem itemGuardarComo;
        private System.Windows.Forms.ToolStripMenuItem itemSalir;
        private System.Windows.Forms.ToolStripMenuItem menuGuardar;
        private System.Windows.Forms.ToolStripMenuItem menuCrearNuevo;
        private System.Windows.Forms.ToolStripMenuItem menuCerrar;
        private System.Windows.Forms.ToolStripMenuItem menuAyuda;
        private System.Windows.Forms.RichTextBox txtSalidaError;
        private System.Windows.Forms.Label labeOutput;
        private System.Windows.Forms.Label labelFila;
        private System.Windows.Forms.Label labelColumna;
        private System.Windows.Forms.ToolStripMenuItem itemProyecto;
        private System.Windows.Forms.ListBox lboxArchivosProyecto;
        private System.Windows.Forms.Label lblLogoProyecto;
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.ToolStripMenuItem itemCompilar;
        private System.Windows.Forms.Button btnLimpiarSalida;
    }
}

