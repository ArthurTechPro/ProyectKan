namespace ProjectKAN.WIN
{
    partial class FrmComandos
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComandos));
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this.CBSubProject = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.CBProject = new System.Windows.Forms.ComboBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.TV_Comandos = new System.Windows.Forms.TreeView();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.cboComando = new System.Windows.Forms.ComboBox();
         this.label15 = new System.Windows.Forms.Label();
         this.textIDProp = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this.Parametros = new System.Windows.Forms.GroupBox();
         this.grdParametros = new System.Windows.Forms.DataGrid();
         this.BTN_Adicionar = new System.Windows.Forms.Button();
         this.cboDireccion = new System.Windows.Forms.ComboBox();
         this.label13 = new System.Windows.Forms.Label();
         this.cboTipoDato = new System.Windows.Forms.ComboBox();
         this.label12 = new System.Windows.Forms.Label();
         this.txtNombreParametro = new System.Windows.Forms.TextBox();
         this.label11 = new System.Windows.Forms.Label();
         this.txtAyuda = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.lstCampos = new System.Windows.Forms.ListBox();
         this.cboTipoImplementacion = new System.Windows.Forms.ComboBox();
         this.label9 = new System.Windows.Forms.Label();
         this.txtParametros = new System.Windows.Forms.TextBox();
         this.label8 = new System.Windows.Forms.Label();
         this.cboTipoParametros = new System.Windows.Forms.ComboBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.txtSQL = new System.Windows.Forms.TextBox();
         this.cboTipoComando = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.txtNombreComando = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.groupBox5 = new System.Windows.Forms.GroupBox();
         this.BTN_Elliminar = new System.Windows.Forms.Button();
         this.BTN_Guardar = new System.Windows.Forms.Button();
         this.BTN_Nuevo = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.Parametros.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdParametros)).BeginInit();
         this.groupBox5.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label1.Location = new System.Drawing.Point(7, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(205, 24);
         this.label1.TabIndex = 0;
         this.label1.Text = "Comandos Adicionales";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(13, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(1125, 44);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.label4);
         this.groupBox4.Controls.Add(this.CBSubProject);
         this.groupBox4.Controls.Add(this.label3);
         this.groupBox4.Controls.Add(this.CBProject);
         this.groupBox4.Location = new System.Drawing.Point(12, 47);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(1126, 41);
         this.groupBox4.TabIndex = 4;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Proyecto";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label4.Location = new System.Drawing.Point(345, 16);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(114, 13);
         this.label4.TabIndex = 4;
         this.label4.Text = "Name Space Proyecto";
         // 
         // CBSubProject
         // 
         this.CBSubProject.FormattingEnabled = true;
         this.CBSubProject.Location = new System.Drawing.Point(464, 13);
         this.CBSubProject.Name = "CBSubProject";
         this.CBSubProject.Size = new System.Drawing.Size(242, 21);
         this.CBSubProject.TabIndex = 3;
         this.CBSubProject.SelectionChangeCommitted += new System.EventHandler(this.CBSubProject_SelectionChangeCommitted);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label3.Location = new System.Drawing.Point(13, 18);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(49, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Proyecto";
         // 
         // CBProject
         // 
         this.CBProject.FormattingEnabled = true;
         this.CBProject.Location = new System.Drawing.Point(68, 14);
         this.CBProject.Name = "CBProject";
         this.CBProject.Size = new System.Drawing.Size(242, 21);
         this.CBProject.TabIndex = 0;
         this.CBProject.SelectionChangeCommitted += new System.EventHandler(this.CBProject_SelectionChangeCommitted);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.TV_Comandos);
         this.groupBox2.Location = new System.Drawing.Point(12, 91);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(247, 572);
         this.groupBox2.TabIndex = 5;
         this.groupBox2.TabStop = false;
         // 
         // TV_Comandos
         // 
         this.TV_Comandos.ImageIndex = 0;
         this.TV_Comandos.ImageList = this.imageList1;
         this.TV_Comandos.Location = new System.Drawing.Point(7, 11);
         this.TV_Comandos.Name = "TV_Comandos";
         this.TV_Comandos.SelectedImageIndex = 0;
         this.TV_Comandos.Size = new System.Drawing.Size(234, 555);
         this.TV_Comandos.TabIndex = 0;
         this.TV_Comandos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Comandos_AfterSelect);
         // 
         // imageList1
         // 
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList1.Images.SetKeyName(0, "NODE.BMP");
         this.imageList1.Images.SetKeyName(1, "NODECOLUMNA.BMP");
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.cboComando);
         this.groupBox3.Controls.Add(this.label15);
         this.groupBox3.Controls.Add(this.textIDProp);
         this.groupBox3.Controls.Add(this.label14);
         this.groupBox3.Controls.Add(this.Parametros);
         this.groupBox3.Controls.Add(this.txtAyuda);
         this.groupBox3.Controls.Add(this.label10);
         this.groupBox3.Controls.Add(this.lstCampos);
         this.groupBox3.Controls.Add(this.cboTipoImplementacion);
         this.groupBox3.Controls.Add(this.label9);
         this.groupBox3.Controls.Add(this.txtParametros);
         this.groupBox3.Controls.Add(this.label8);
         this.groupBox3.Controls.Add(this.cboTipoParametros);
         this.groupBox3.Controls.Add(this.label7);
         this.groupBox3.Controls.Add(this.label6);
         this.groupBox3.Controls.Add(this.txtSQL);
         this.groupBox3.Controls.Add(this.cboTipoComando);
         this.groupBox3.Controls.Add(this.label5);
         this.groupBox3.Controls.Add(this.txtNombreComando);
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Location = new System.Drawing.Point(265, 91);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(873, 527);
         this.groupBox3.TabIndex = 6;
         this.groupBox3.TabStop = false;
         // 
         // cboComando
         // 
         this.cboComando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboComando.Location = new System.Drawing.Point(139, 69);
         this.cboComando.Name = "cboComando";
         this.cboComando.Size = new System.Drawing.Size(359, 21);
         this.cboComando.TabIndex = 123;
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label15.Location = new System.Drawing.Point(28, 70);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(52, 13);
         this.label15.TabIndex = 124;
         this.label15.Text = "Comando";
         // 
         // textIDProp
         // 
         this.textIDProp.Enabled = false;
         this.textIDProp.Location = new System.Drawing.Point(139, 15);
         this.textIDProp.Name = "textIDProp";
         this.textIDProp.Size = new System.Drawing.Size(87, 20);
         this.textIDProp.TabIndex = 122;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label14.Location = new System.Drawing.Point(26, 18);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(69, 13);
         this.label14.TabIndex = 121;
         this.label14.Text = "ID Propiedad";
         // 
         // Parametros
         // 
         this.Parametros.Controls.Add(this.grdParametros);
         this.Parametros.Controls.Add(this.BTN_Adicionar);
         this.Parametros.Controls.Add(this.cboDireccion);
         this.Parametros.Controls.Add(this.label13);
         this.Parametros.Controls.Add(this.cboTipoDato);
         this.Parametros.Controls.Add(this.label12);
         this.Parametros.Controls.Add(this.txtNombreParametro);
         this.Parametros.Controls.Add(this.label11);
         this.Parametros.Location = new System.Drawing.Point(8, 338);
         this.Parametros.Name = "Parametros";
         this.Parametros.Size = new System.Drawing.Size(858, 183);
         this.Parametros.TabIndex = 120;
         this.Parametros.TabStop = false;
         this.Parametros.Text = "Parametros";
         // 
         // grdParametros
         // 
         this.grdParametros.DataMember = "Kan_Comandos";
         this.grdParametros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.grdParametros.Location = new System.Drawing.Point(12, 37);
         this.grdParametros.Name = "grdParametros";
         this.grdParametros.Size = new System.Drawing.Size(840, 141);
         this.grdParametros.TabIndex = 20;
         // 
         // BTN_Adicionar
         // 
         this.BTN_Adicionar.Location = new System.Drawing.Point(749, 10);
         this.BTN_Adicionar.Name = "BTN_Adicionar";
         this.BTN_Adicionar.Size = new System.Drawing.Size(92, 23);
         this.BTN_Adicionar.TabIndex = 19;
         this.BTN_Adicionar.Text = "Adicionar";
         this.BTN_Adicionar.UseVisualStyleBackColor = true;
         this.BTN_Adicionar.Click += new System.EventHandler(this.BTN_Adicionar_Click);
         // 
         // cboDireccion
         // 
         this.cboDireccion.FormattingEnabled = true;
         this.cboDireccion.Items.AddRange(new object[] {
            "Input",
            "InputOutput",
            "Output",
            "ReturnValue"});
         this.cboDireccion.Location = new System.Drawing.Point(540, 12);
         this.cboDireccion.Name = "cboDireccion";
         this.cboDireccion.Size = new System.Drawing.Size(193, 21);
         this.cboDireccion.TabIndex = 18;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label13.Location = new System.Drawing.Point(482, 16);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(52, 13);
         this.label13.TabIndex = 17;
         this.label13.Text = "Direccion";
         // 
         // cboTipoDato
         // 
         this.cboTipoDato.FormattingEnabled = true;
         this.cboTipoDato.Items.AddRange(new object[] {
            "System.Boolean",
            "System.DateTime",
            "System.Decimal",
            "System.Int16",
            "System.Int32",
            "System.String"});
         this.cboTipoDato.Location = new System.Drawing.Point(274, 13);
         this.cboTipoDato.Name = "cboTipoDato";
         this.cboTipoDato.Size = new System.Drawing.Size(193, 21);
         this.cboTipoDato.TabIndex = 16;
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label12.Location = new System.Drawing.Point(240, 16);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(28, 13);
         this.label12.TabIndex = 15;
         this.label12.Text = "Tipo";
         // 
         // txtNombreParametro
         // 
         this.txtNombreParametro.Location = new System.Drawing.Point(62, 13);
         this.txtNombreParametro.Name = "txtNombreParametro";
         this.txtNombreParametro.Size = new System.Drawing.Size(156, 20);
         this.txtNombreParametro.TabIndex = 6;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label11.Location = new System.Drawing.Point(9, 16);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(47, 13);
         this.label11.TabIndex = 5;
         this.label11.Text = "Nombre ";
         // 
         // txtAyuda
         // 
         this.txtAyuda.Location = new System.Drawing.Point(514, 199);
         this.txtAyuda.Multiline = true;
         this.txtAyuda.Name = "txtAyuda";
         this.txtAyuda.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.txtAyuda.Size = new System.Drawing.Size(353, 140);
         this.txtAyuda.TabIndex = 118;
         this.txtAyuda.WordWrap = false;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label10.Location = new System.Drawing.Point(514, 15);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(109, 13);
         this.label10.TabIndex = 16;
         this.label10.Text = "Propidades Columnas";
         // 
         // lstCampos
         // 
         this.lstCampos.DisplayMember = "NomColumna";
         this.lstCampos.FormattingEnabled = true;
         this.lstCampos.Location = new System.Drawing.Point(514, 32);
         this.lstCampos.Name = "lstCampos";
         this.lstCampos.Size = new System.Drawing.Size(352, 147);
         this.lstCampos.TabIndex = 15;
         this.lstCampos.ValueMember = "NomColumna";
         // 
         // cboTipoImplementacion
         // 
         this.cboTipoImplementacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboTipoImplementacion.FormattingEnabled = true;
         this.cboTipoImplementacion.Location = new System.Drawing.Point(139, 315);
         this.cboTipoImplementacion.Name = "cboTipoImplementacion";
         this.cboTipoImplementacion.Size = new System.Drawing.Size(359, 21);
         this.cboTipoImplementacion.TabIndex = 117;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label9.Location = new System.Drawing.Point(26, 318);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(81, 13);
         this.label9.TabIndex = 13;
         this.label9.Text = "Implementacion";
         // 
         // txtParametros
         // 
         this.txtParametros.Location = new System.Drawing.Point(139, 289);
         this.txtParametros.Name = "txtParametros";
         this.txtParametros.Size = new System.Drawing.Size(359, 20);
         this.txtParametros.TabIndex = 4;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label8.Location = new System.Drawing.Point(26, 292);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(109, 13);
         this.label8.TabIndex = 11;
         this.label8.Text = "Columnas Parametros";
         // 
         // cboTipoParametros
         // 
         this.cboTipoParametros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboTipoParametros.FormattingEnabled = true;
         this.cboTipoParametros.Location = new System.Drawing.Point(139, 262);
         this.cboTipoParametros.Name = "cboTipoParametros";
         this.cboTipoParametros.Size = new System.Drawing.Size(359, 21);
         this.cboTipoParametros.TabIndex = 3;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label7.Location = new System.Drawing.Point(26, 265);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(79, 13);
         this.label7.TabIndex = 9;
         this.label7.Text = "Tipo Parametro";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label6.Location = new System.Drawing.Point(26, 126);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(76, 13);
         this.label6.TabIndex = 8;
         this.label6.Text = "Comando SQL";
         // 
         // txtSQL
         // 
         this.txtSQL.Location = new System.Drawing.Point(139, 124);
         this.txtSQL.Multiline = true;
         this.txtSQL.Name = "txtSQL";
         this.txtSQL.Size = new System.Drawing.Size(359, 129);
         this.txtSQL.TabIndex = 2;
         // 
         // cboTipoComando
         // 
         this.cboTipoComando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboTipoComando.Location = new System.Drawing.Point(139, 97);
         this.cboTipoComando.Name = "cboTipoComando";
         this.cboTipoComando.Size = new System.Drawing.Size(359, 21);
         this.cboTipoComando.TabIndex = 1;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label5.Location = new System.Drawing.Point(28, 98);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(28, 13);
         this.label5.TabIndex = 5;
         this.label5.Text = "Tipo";
         // 
         // txtNombreComando
         // 
         this.txtNombreComando.Location = new System.Drawing.Point(139, 41);
         this.txtNombreComando.Name = "txtNombreComando";
         this.txtNombreComando.Size = new System.Drawing.Size(359, 20);
         this.txtNombreComando.TabIndex = 0;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
         this.label2.Location = new System.Drawing.Point(26, 45);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(47, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Nombre ";
         // 
         // groupBox5
         // 
         this.groupBox5.Controls.Add(this.BTN_Elliminar);
         this.groupBox5.Controls.Add(this.BTN_Guardar);
         this.groupBox5.Controls.Add(this.BTN_Nuevo);
         this.groupBox5.Location = new System.Drawing.Point(265, 612);
         this.groupBox5.Name = "groupBox5";
         this.groupBox5.Size = new System.Drawing.Size(873, 51);
         this.groupBox5.TabIndex = 119;
         this.groupBox5.TabStop = false;
         // 
         // BTN_Elliminar
         // 
         this.BTN_Elliminar.Location = new System.Drawing.Point(319, 14);
         this.BTN_Elliminar.Name = "BTN_Elliminar";
         this.BTN_Elliminar.Size = new System.Drawing.Size(142, 33);
         this.BTN_Elliminar.TabIndex = 2;
         this.BTN_Elliminar.Text = "Eliminar";
         this.BTN_Elliminar.UseVisualStyleBackColor = true;
         this.BTN_Elliminar.Click += new System.EventHandler(this.BTN_Elliminar_Click);
         // 
         // BTN_Guardar
         // 
         this.BTN_Guardar.Location = new System.Drawing.Point(167, 14);
         this.BTN_Guardar.Name = "BTN_Guardar";
         this.BTN_Guardar.Size = new System.Drawing.Size(142, 33);
         this.BTN_Guardar.TabIndex = 1;
         this.BTN_Guardar.Text = "Guardar";
         this.BTN_Guardar.UseVisualStyleBackColor = true;
         this.BTN_Guardar.Click += new System.EventHandler(this.BTN_Guardar_Click);
         // 
         // BTN_Nuevo
         // 
         this.BTN_Nuevo.Location = new System.Drawing.Point(12, 14);
         this.BTN_Nuevo.Name = "BTN_Nuevo";
         this.BTN_Nuevo.Size = new System.Drawing.Size(142, 33);
         this.BTN_Nuevo.TabIndex = 0;
         this.BTN_Nuevo.Text = "Nuevo";
         this.BTN_Nuevo.UseVisualStyleBackColor = true;
         this.BTN_Nuevo.Click += new System.EventHandler(this.BTN_Nuevo_Click);
         // 
         // FrmComandos
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
         this.ClientSize = new System.Drawing.Size(1150, 694);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox5);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox4);
         this.Controls.Add(this.groupBox1);
         this.Name = "FrmComandos";
         this.Text = "FrmComandos";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.FrmComandos_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.Parametros.ResumeLayout(false);
         this.Parametros.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdParametros)).EndInit();
         this.groupBox5.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBSubProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBProject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView TV_Comandos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAyuda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstCampos;
        private System.Windows.Forms.ComboBox cboTipoImplementacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtParametros;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoParametros;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.ComboBox cboTipoComando;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreComando;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BTN_Elliminar;
        private System.Windows.Forms.Button BTN_Guardar;
        private System.Windows.Forms.Button BTN_Nuevo;
        private System.Windows.Forms.GroupBox Parametros;
        private System.Windows.Forms.ComboBox cboDireccion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTipoDato;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNombreParametro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BTN_Adicionar;
        private System.Windows.Forms.DataGrid grdParametros;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textIDProp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboComando;
        private System.Windows.Forms.Label label15;
    }
}