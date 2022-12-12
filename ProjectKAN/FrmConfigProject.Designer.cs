namespace ProjectKAN.WIN
{
    partial class FrmConfigProject
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.BTNBorrarPro = new System.Windows.Forms.Button();
         this.textProyect = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.listProyectos = new System.Windows.Forms.ListBox();
         this.BTNAddPro = new System.Windows.Forms.Button();
         this.textName = new System.Windows.Forms.TextBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.BTNBorrarSubP = new System.Windows.Forms.Button();
         this.listSubProyectos = new System.Windows.Forms.ListBox();
         this.BTNAddSubPro = new System.Windows.Forms.Button();
         this.textSubProyect = new System.Windows.Forms.TextBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.DGDirSalida = new System.Windows.Forms.DataGrid();
         this.TSDirSalida = new System.Windows.Forms.DataGridTableStyle();
         this.gtxttipoarchivo = new System.Windows.Forms.DataGridTextBoxColumn();
         this.gtxtdescrip = new System.Windows.Forms.DataGridTextBoxColumn();
         this.gtxtdirectoriosalida = new System.Windows.Forms.DataGridTextBoxColumn();
         this.gtxtplantilla = new System.Windows.Forms.DataGridTextBoxColumn();
         this.label3 = new System.Windows.Forms.Label();
         this.CB_Plantillas = new System.Windows.Forms.ComboBox();
         this.BTNBorrarDir = new System.Windows.Forms.Button();
         this.BTNAddDir = new System.Windows.Forms.Button();
         this.BTN_SelectDir = new System.Windows.Forms.Button();
         this.textDirSalida = new System.Windows.Forms.TextBox();
         this.tatxtidproject = new System.Windows.Forms.DataGridTextBoxColumn();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox4.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGDirSalida)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 13);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(1126, 57);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label1.Location = new System.Drawing.Point(17, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(129, 29);
         this.label1.TabIndex = 0;
         this.label1.Text = "Proyectos";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.BTNBorrarPro);
         this.groupBox2.Controls.Add(this.textProyect);
         this.groupBox2.Controls.Add(this.label2);
         this.groupBox2.Controls.Add(this.listProyectos);
         this.groupBox2.Controls.Add(this.BTNAddPro);
         this.groupBox2.Controls.Add(this.textName);
         this.groupBox2.Location = new System.Drawing.Point(12, 86);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(264, 288);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Poyectos";
         // 
         // BTNBorrarPro
         // 
         this.BTNBorrarPro.Location = new System.Drawing.Point(132, 76);
         this.BTNBorrarPro.Name = "BTNBorrarPro";
         this.BTNBorrarPro.Size = new System.Drawing.Size(119, 23);
         this.BTNBorrarPro.TabIndex = 5;
         this.BTNBorrarPro.Text = "Borrar";
         this.BTNBorrarPro.UseVisualStyleBackColor = true;
         // 
         // textProyect
         // 
         this.textProyect.Location = new System.Drawing.Point(7, 17);
         this.textProyect.Name = "textProyect";
         this.textProyect.Size = new System.Drawing.Size(250, 20);
         this.textProyect.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label2.Location = new System.Drawing.Point(19, 51);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(66, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "NameSpace";
         // 
         // listProyectos
         // 
         this.listProyectos.FormattingEnabled = true;
         this.listProyectos.Location = new System.Drawing.Point(6, 115);
         this.listProyectos.Name = "listProyectos";
         this.listProyectos.Size = new System.Drawing.Size(251, 160);
         this.listProyectos.TabIndex = 2;
         this.listProyectos.Click += new System.EventHandler(this.listProyectos_Click);
         // 
         // BTNAddPro
         // 
         this.BTNAddPro.Location = new System.Drawing.Point(6, 76);
         this.BTNAddPro.Name = "BTNAddPro";
         this.BTNAddPro.Size = new System.Drawing.Size(119, 23);
         this.BTNAddPro.TabIndex = 1;
         this.BTNAddPro.Text = "Adicionar";
         this.BTNAddPro.UseVisualStyleBackColor = true;
         this.BTNAddPro.Click += new System.EventHandler(this.BTNAddPro_Click);
         // 
         // textName
         // 
         this.textName.Location = new System.Drawing.Point(117, 48);
         this.textName.Name = "textName";
         this.textName.Size = new System.Drawing.Size(140, 20);
         this.textName.TabIndex = 0;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.BTNBorrarSubP);
         this.groupBox3.Controls.Add(this.listSubProyectos);
         this.groupBox3.Controls.Add(this.BTNAddSubPro);
         this.groupBox3.Controls.Add(this.textSubProyect);
         this.groupBox3.Location = new System.Drawing.Point(12, 381);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(264, 288);
         this.groupBox3.TabIndex = 2;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Sub Proyectos";
         // 
         // BTNBorrarSubP
         // 
         this.BTNBorrarSubP.Location = new System.Drawing.Point(133, 45);
         this.BTNBorrarSubP.Name = "BTNBorrarSubP";
         this.BTNBorrarSubP.Size = new System.Drawing.Size(119, 23);
         this.BTNBorrarSubP.TabIndex = 3;
         this.BTNBorrarSubP.Text = "Borrar";
         this.BTNBorrarSubP.UseVisualStyleBackColor = true;
         // 
         // listSubProyectos
         // 
         this.listSubProyectos.FormattingEnabled = true;
         this.listSubProyectos.Location = new System.Drawing.Point(7, 76);
         this.listSubProyectos.Name = "listSubProyectos";
         this.listSubProyectos.Size = new System.Drawing.Size(251, 199);
         this.listSubProyectos.TabIndex = 2;
         this.listSubProyectos.Click += new System.EventHandler(this.listSubProyectos_Click);
         this.listSubProyectos.SelectedIndexChanged += new System.EventHandler(this.listSubProyectos_SelectedIndexChanged);
         // 
         // BTNAddSubPro
         // 
         this.BTNAddSubPro.Location = new System.Drawing.Point(7, 46);
         this.BTNAddSubPro.Name = "BTNAddSubPro";
         this.BTNAddSubPro.Size = new System.Drawing.Size(119, 23);
         this.BTNAddSubPro.TabIndex = 1;
         this.BTNAddSubPro.Text = "Adicionar";
         this.BTNAddSubPro.UseVisualStyleBackColor = true;
         this.BTNAddSubPro.Click += new System.EventHandler(this.BTNAddSubPro_Click);
         // 
         // textSubProyect
         // 
         this.textSubProyect.Location = new System.Drawing.Point(7, 18);
         this.textSubProyect.Name = "textSubProyect";
         this.textSubProyect.Size = new System.Drawing.Size(251, 20);
         this.textSubProyect.TabIndex = 0;
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.DGDirSalida);
         this.groupBox4.Controls.Add(this.label3);
         this.groupBox4.Controls.Add(this.CB_Plantillas);
         this.groupBox4.Controls.Add(this.BTNBorrarDir);
         this.groupBox4.Controls.Add(this.BTNAddDir);
         this.groupBox4.Controls.Add(this.BTN_SelectDir);
         this.groupBox4.Controls.Add(this.textDirSalida);
         this.groupBox4.Location = new System.Drawing.Point(282, 86);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(856, 583);
         this.groupBox4.TabIndex = 3;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Directorios Salida";
         // 
         // DGDirSalida
         // 
         this.DGDirSalida.DataMember = "";
         this.DGDirSalida.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.DGDirSalida.Location = new System.Drawing.Point(7, 107);
         this.DGDirSalida.Name = "DGDirSalida";
         this.DGDirSalida.Size = new System.Drawing.Size(834, 463);
         this.DGDirSalida.TabIndex = 7;
         this.DGDirSalida.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.TSDirSalida});
         // 
         // TSDirSalida
         // 
         this.TSDirSalida.DataGrid = this.DGDirSalida;
         this.TSDirSalida.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.gtxttipoarchivo,
            this.tatxtidproject,
            this.gtxtplantilla,
            this.gtxtdescrip,
            this.gtxtdirectoriosalida});
         this.TSDirSalida.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.TSDirSalida.MappingName = "DirectorioSalida";
         this.TSDirSalida.ReadOnly = true;
         // 
         // gtxttipoarchivo
         // 
         this.gtxttipoarchivo.Format = "";
         this.gtxttipoarchivo.FormatInfo = null;
         this.gtxttipoarchivo.HeaderText = "Tipo Archivo";
         this.gtxttipoarchivo.MappingName = "tipoarchivo";
         this.gtxttipoarchivo.Width = 75;
         // 
         // gtxtdescrip
         // 
         this.gtxtdescrip.Format = "";
         this.gtxtdescrip.FormatInfo = null;
         this.gtxtdescrip.HeaderText = "Descripcion";
         this.gtxtdescrip.MappingName = "descrip";
         this.gtxtdescrip.Width = 75;
         // 
         // gtxtdirectoriosalida
         // 
         this.gtxtdirectoriosalida.Format = "";
         this.gtxtdirectoriosalida.FormatInfo = null;
         this.gtxtdirectoriosalida.HeaderText = "Directorio Salida";
         this.gtxtdirectoriosalida.MappingName = "directoriosalida";
         this.gtxtdirectoriosalida.Width = 75;
         // 
         // gtxtplantilla
         // 
         this.gtxtplantilla.Format = "";
         this.gtxtplantilla.FormatInfo = null;
         this.gtxtplantilla.HeaderText = "Plantilla";
         this.gtxtplantilla.MappingName = "plantilla";
         this.gtxtplantilla.Width = 75;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label3.Location = new System.Drawing.Point(18, 21);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(48, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Plantillas";
         // 
         // CB_Plantillas
         // 
         this.CB_Plantillas.FormattingEnabled = true;
         this.CB_Plantillas.Location = new System.Drawing.Point(72, 17);
         this.CB_Plantillas.Name = "CB_Plantillas";
         this.CB_Plantillas.Size = new System.Drawing.Size(571, 21);
         this.CB_Plantillas.TabIndex = 5;
         // 
         // BTNBorrarDir
         // 
         this.BTNBorrarDir.Location = new System.Drawing.Point(134, 76);
         this.BTNBorrarDir.Name = "BTNBorrarDir";
         this.BTNBorrarDir.Size = new System.Drawing.Size(119, 23);
         this.BTNBorrarDir.TabIndex = 4;
         this.BTNBorrarDir.Text = "Borrar";
         this.BTNBorrarDir.UseVisualStyleBackColor = true;
         // 
         // BTNAddDir
         // 
         this.BTNAddDir.Location = new System.Drawing.Point(9, 77);
         this.BTNAddDir.Name = "BTNAddDir";
         this.BTNAddDir.Size = new System.Drawing.Size(119, 23);
         this.BTNAddDir.TabIndex = 2;
         this.BTNAddDir.Text = "Adicionar";
         this.BTNAddDir.UseVisualStyleBackColor = true;
         this.BTNAddDir.Click += new System.EventHandler(this.BTNAddDir_Click);
         // 
         // BTN_SelectDir
         // 
         this.BTN_SelectDir.Location = new System.Drawing.Point(827, 45);
         this.BTN_SelectDir.Name = "BTN_SelectDir";
         this.BTN_SelectDir.Size = new System.Drawing.Size(23, 23);
         this.BTN_SelectDir.TabIndex = 1;
         this.BTN_SelectDir.Text = "...";
         this.BTN_SelectDir.UseVisualStyleBackColor = true;
         this.BTN_SelectDir.Click += new System.EventHandler(this.BTN_SelectDir_Click);
         // 
         // textDirSalida
         // 
         this.textDirSalida.Location = new System.Drawing.Point(6, 47);
         this.textDirSalida.Name = "textDirSalida";
         this.textDirSalida.Size = new System.Drawing.Size(815, 20);
         this.textDirSalida.TabIndex = 0;
         // 
         // tatxtidproject
         // 
         this.tatxtidproject.Format = "";
         this.tatxtidproject.FormatInfo = null;
         this.tatxtidproject.HeaderText = "Proyecto";
         this.tatxtidproject.MappingName = "idproject";
         this.tatxtidproject.Width = 75;
         // 
         // FrmConfigProject
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
         this.ClientSize = new System.Drawing.Size(1150, 694);
         this.Controls.Add(this.groupBox4);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Name = "FrmConfigProject";
         this.Text = "FrmConfigProject";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.FrmConfigProject_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGDirSalida)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listProyectos;
        private System.Windows.Forms.Button BTNAddPro;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.ListBox listSubProyectos;
        private System.Windows.Forms.Button BTNAddSubPro;
        private System.Windows.Forms.TextBox textSubProyect;
        private System.Windows.Forms.Button BTNAddDir;
        private System.Windows.Forms.Button BTN_SelectDir;
        private System.Windows.Forms.TextBox textDirSalida;
        private System.Windows.Forms.TextBox textProyect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNBorrarPro;
        private System.Windows.Forms.Button BTNBorrarSubP;
        private System.Windows.Forms.Button BTNBorrarDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Plantillas;
        private System.Windows.Forms.DataGrid DGDirSalida;
        private System.Windows.Forms.DataGridTableStyle TSDirSalida;
        private System.Windows.Forms.DataGridTextBoxColumn gtxttipoarchivo;
        private System.Windows.Forms.DataGridTextBoxColumn gtxtdescrip;
        private System.Windows.Forms.DataGridTextBoxColumn gtxtdirectoriosalida;
        private System.Windows.Forms.DataGridTextBoxColumn gtxtplantilla;
        private System.Windows.Forms.DataGridTextBoxColumn tatxtidproject;
    }
}