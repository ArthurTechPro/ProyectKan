namespace ProjectKAN.WIN
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuPpal = new System.Windows.Forms.MenuStrip();
            this.archivoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandosMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codigoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantillasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propiedadesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MenuPpal.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPpal
            // 
            this.MenuPpal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoMenuItem,
            this.generarMenuItem,
            this.configurarMenuItem,
            this.salirMenuItem});
            this.MenuPpal.Location = new System.Drawing.Point(0, 0);
            this.MenuPpal.Name = "MenuPpal";
            this.MenuPpal.Size = new System.Drawing.Size(1144, 24);
            this.MenuPpal.TabIndex = 1;
            this.MenuPpal.Text = "menuStrip1";
            this.MenuPpal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuPpal_ItemClicked);
            // 
            // archivoMenuItem
            // 
            this.archivoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablasMenuItem,
            this.columnasMenuItem,
            this.comandosMenuItem1});
            this.archivoMenuItem.Name = "archivoMenuItem";
            this.archivoMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoMenuItem.Text = "Archivo";
            // 
            // tablasMenuItem
            // 
            this.tablasMenuItem.Name = "tablasMenuItem";
            this.tablasMenuItem.Size = new System.Drawing.Size(139, 22);
            this.tablasMenuItem.Text = "Propiedades";
            this.tablasMenuItem.Click += new System.EventHandler(this.tablasMenuItem_Click);
            // 
            // columnasMenuItem
            // 
            this.columnasMenuItem.Name = "columnasMenuItem";
            this.columnasMenuItem.Size = new System.Drawing.Size(139, 22);
            this.columnasMenuItem.Text = "Columnas";
            // 
            // comandosMenuItem1
            // 
            this.comandosMenuItem1.Name = "comandosMenuItem1";
            this.comandosMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.comandosMenuItem1.Text = "Comandos";
            this.comandosMenuItem1.Click += new System.EventHandler(this.comandosMenuItem1_Click);
            // 
            // generarMenuItem
            // 
            this.generarMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectosMenuItem,
            this.comandosMenuItem,
            this.codigoMenuItem});
            this.generarMenuItem.Name = "generarMenuItem";
            this.generarMenuItem.Size = new System.Drawing.Size(60, 20);
            this.generarMenuItem.Text = "Generar";
            // 
            // proyectosMenuItem
            // 
            this.proyectosMenuItem.Name = "proyectosMenuItem";
            this.proyectosMenuItem.Size = new System.Drawing.Size(132, 22);
            this.proyectosMenuItem.Text = "Proyectos";
            // 
            // comandosMenuItem
            // 
            this.comandosMenuItem.Name = "comandosMenuItem";
            this.comandosMenuItem.Size = new System.Drawing.Size(132, 22);
            this.comandosMenuItem.Text = "Comandos";
            // 
            // codigoMenuItem
            // 
            this.codigoMenuItem.Name = "codigoMenuItem";
            this.codigoMenuItem.Size = new System.Drawing.Size(132, 22);
            this.codigoMenuItem.Text = "Codigo";
            this.codigoMenuItem.Click += new System.EventHandler(this.codigoMenuItem_Click);
            // 
            // configurarMenuItem
            // 
            this.configurarMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem,
            this.plantillasMenuItem,
            this.propiedadesMenuItem,
            this.parametrosMenuItem,
            this.globalesMenuItem});
            this.configurarMenuItem.Name = "configurarMenuItem";
            this.configurarMenuItem.Size = new System.Drawing.Size(76, 20);
            this.configurarMenuItem.Text = "Configurar";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            this.proyectoToolStripMenuItem.Click += new System.EventHandler(this.proyectoToolStripMenuItem_Click);
            // 
            // plantillasMenuItem
            // 
            this.plantillasMenuItem.Name = "plantillasMenuItem";
            this.plantillasMenuItem.Size = new System.Drawing.Size(139, 22);
            this.plantillasMenuItem.Text = "Plantillas";
            this.plantillasMenuItem.Click += new System.EventHandler(this.plantillasMenuItem_Click);
            // 
            // propiedadesMenuItem
            // 
            this.propiedadesMenuItem.Name = "propiedadesMenuItem";
            this.propiedadesMenuItem.Size = new System.Drawing.Size(139, 22);
            this.propiedadesMenuItem.Text = "Propiedades";
            // 
            // parametrosMenuItem
            // 
            this.parametrosMenuItem.Name = "parametrosMenuItem";
            this.parametrosMenuItem.Size = new System.Drawing.Size(139, 22);
            this.parametrosMenuItem.Text = "Parametros";
            // 
            // globalesMenuItem
            // 
            this.globalesMenuItem.Name = "globalesMenuItem";
            this.globalesMenuItem.Size = new System.Drawing.Size(139, 22);
            this.globalesMenuItem.Text = "Globales";
            // 
            // salirMenuItem
            // 
            this.salirMenuItem.Name = "salirMenuItem";
            this.salirMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirMenuItem.Text = "Salir";
            this.salirMenuItem.Click += new System.EventHandler(this.salirMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 700);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1144, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1144, 722);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuPpal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuPpal;
            this.Name = "MainForm";
            this.Text = "Project KAN - Semilla";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuPpal.ResumeLayout(false);
            this.MenuPpal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPpal;
        private System.Windows.Forms.ToolStripMenuItem archivoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plantillasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propiedadesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandosMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proyectosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codigoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalesMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
    }
}

