namespace ProjectKAN.WIN
{
    partial class FrmPropiedades
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
            this.BTN_Actualizar = new System.Windows.Forms.Button();
            this.LstSelectPropiedad = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_TiposProp = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BTN_DelData = new System.Windows.Forms.Button();
            this.BTN_ActualizaData = new System.Windows.Forms.Button();
            this.DGV_Propiedades = new System.Windows.Forms.DataGridView();
            this.IDPropiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idprojectp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopropiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.padre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creaselect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.creainsert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.creadelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.creaupdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BTN_Seleccionar = new System.Windows.Forms.Button();
            this.BTN_MetaData = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBSubProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBProject = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Propiedades)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1125, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Propiedades Generales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTN_Actualizar);
            this.groupBox2.Controls.Add(this.LstSelectPropiedad);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CB_TiposProp);
            this.groupBox2.Location = new System.Drawing.Point(13, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 607);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccion";
            // 
            // BTN_Actualizar
            // 
            this.BTN_Actualizar.Location = new System.Drawing.Point(1, 559);
            this.BTN_Actualizar.Name = "BTN_Actualizar";
            this.BTN_Actualizar.Size = new System.Drawing.Size(242, 33);
            this.BTN_Actualizar.TabIndex = 3;
            this.BTN_Actualizar.Text = "Actualizar";
            this.BTN_Actualizar.UseVisualStyleBackColor = true;
            this.BTN_Actualizar.Click += new System.EventHandler(this.BTN_Actualizar_Click);
            // 
            // LstSelectPropiedad
            // 
            this.LstSelectPropiedad.FormattingEnabled = true;
            this.LstSelectPropiedad.Location = new System.Drawing.Point(6, 54);
            this.LstSelectPropiedad.Name = "LstSelectPropiedad";
            this.LstSelectPropiedad.Size = new System.Drawing.Size(242, 499);
            this.LstSelectPropiedad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Propiedad";
            // 
            // CB_TiposProp
            // 
            this.CB_TiposProp.FormattingEnabled = true;
            this.CB_TiposProp.Location = new System.Drawing.Point(94, 20);
            this.CB_TiposProp.Name = "CB_TiposProp";
            this.CB_TiposProp.Size = new System.Drawing.Size(154, 21);
            this.CB_TiposProp.TabIndex = 0;
            this.CB_TiposProp.SelectionChangeCommitted += new System.EventHandler(this.CB_TiposProp_SelectionChangeCommitted);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BTN_DelData);
            this.groupBox3.Controls.Add(this.BTN_ActualizaData);
            this.groupBox3.Controls.Add(this.DGV_Propiedades);
            this.groupBox3.Controls.Add(this.BTN_Seleccionar);
            this.groupBox3.Controls.Add(this.BTN_MetaData);
            this.groupBox3.Location = new System.Drawing.Point(273, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(865, 560);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Propiedades";
            // 
            // BTN_DelData
            // 
            this.BTN_DelData.Location = new System.Drawing.Point(487, 512);
            this.BTN_DelData.Name = "BTN_DelData";
            this.BTN_DelData.Size = new System.Drawing.Size(150, 33);
            this.BTN_DelData.TabIndex = 7;
            this.BTN_DelData.Text = "Borrar Data";
            this.BTN_DelData.UseVisualStyleBackColor = true;
            this.BTN_DelData.Click += new System.EventHandler(this.BTN_DelData_Click);
            // 
            // BTN_ActualizaData
            // 
            this.BTN_ActualizaData.Location = new System.Drawing.Point(165, 512);
            this.BTN_ActualizaData.Name = "BTN_ActualizaData";
            this.BTN_ActualizaData.Size = new System.Drawing.Size(150, 33);
            this.BTN_ActualizaData.TabIndex = 6;
            this.BTN_ActualizaData.Text = "Actualiza Data";
            this.BTN_ActualizaData.UseVisualStyleBackColor = true;
            this.BTN_ActualizaData.Click += new System.EventHandler(this.BTN_ActualizaData_Click);
            // 
            // DGV_Propiedades
            // 
            this.DGV_Propiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Propiedades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPropiedad,
            this.idprojectp,
            this.iddata,
            this.tipopropiedad,
            this.nombre,
            this.padre,
            this.creaselect,
            this.creainsert,
            this.creadelete,
            this.creaupdate});
            this.DGV_Propiedades.Location = new System.Drawing.Point(6, 19);
            this.DGV_Propiedades.Name = "DGV_Propiedades";
            this.DGV_Propiedades.Size = new System.Drawing.Size(853, 487);
            this.DGV_Propiedades.TabIndex = 5;
            // 
            // IDPropiedad
            // 
            this.IDPropiedad.DataPropertyName = "idpropiedad";
            this.IDPropiedad.HeaderText = "idpropiedad";
            this.IDPropiedad.Name = "IDPropiedad";
            this.IDPropiedad.ReadOnly = true;
            this.IDPropiedad.Visible = false;
            this.IDPropiedad.Width = 150;
            // 
            // idprojectp
            // 
            this.idprojectp.DataPropertyName = "idprojectp";
            this.idprojectp.HeaderText = "idprojectp";
            this.idprojectp.Name = "idprojectp";
            this.idprojectp.ReadOnly = true;
            this.idprojectp.Visible = false;
            // 
            // iddata
            // 
            this.iddata.DataPropertyName = "iddata";
            this.iddata.HeaderText = "ID";
            this.iddata.Name = "iddata";
            this.iddata.Visible = false;
            // 
            // tipopropiedad
            // 
            this.tipopropiedad.DataPropertyName = "tipopropiedad";
            this.tipopropiedad.HeaderText = "Tipo";
            this.tipopropiedad.Name = "tipopropiedad";
            this.tipopropiedad.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ToolTipText = "nombre";
            this.nombre.Width = 150;
            // 
            // padre
            // 
            this.padre.DataPropertyName = "padre";
            this.padre.HeaderText = "Padre";
            this.padre.Name = "padre";
            this.padre.Width = 150;
            // 
            // creaselect
            // 
            this.creaselect.DataPropertyName = "creaselect";
            this.creaselect.FalseValue = "0";
            this.creaselect.HeaderText = "Select";
            this.creaselect.Name = "creaselect";
            this.creaselect.TrueValue = "1";
            // 
            // creainsert
            // 
            this.creainsert.DataPropertyName = "creainsert";
            this.creainsert.FalseValue = "0";
            this.creainsert.HeaderText = "Insert";
            this.creainsert.Name = "creainsert";
            this.creainsert.TrueValue = "1";
            // 
            // creadelete
            // 
            this.creadelete.DataPropertyName = "creadelete";
            this.creadelete.FalseValue = "0";
            this.creadelete.HeaderText = "Delete";
            this.creadelete.Name = "creadelete";
            this.creadelete.TrueValue = "1";
            // 
            // creaupdate
            // 
            this.creaupdate.DataPropertyName = "creaupdate";
            this.creaupdate.FalseValue = "0";
            this.creaupdate.HeaderText = "Update";
            this.creaupdate.Name = "creaupdate";
            this.creaupdate.TrueValue = "1";
            // 
            // BTN_Seleccionar
            // 
            this.BTN_Seleccionar.Location = new System.Drawing.Point(7, 512);
            this.BTN_Seleccionar.Name = "BTN_Seleccionar";
            this.BTN_Seleccionar.Size = new System.Drawing.Size(150, 33);
            this.BTN_Seleccionar.TabIndex = 2;
            this.BTN_Seleccionar.Text = "Seleccionar";
            this.BTN_Seleccionar.UseVisualStyleBackColor = true;
            this.BTN_Seleccionar.Click += new System.EventHandler(this.BTN_Seleccionar_Click);
            // 
            // BTN_MetaData
            // 
            this.BTN_MetaData.Location = new System.Drawing.Point(326, 512);
            this.BTN_MetaData.Name = "BTN_MetaData";
            this.BTN_MetaData.Size = new System.Drawing.Size(150, 33);
            this.BTN_MetaData.TabIndex = 1;
            this.BTN_MetaData.Text = "Actializar MetaData";
            this.BTN_MetaData.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.CBSubProject);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.CBProject);
            this.groupBox4.Location = new System.Drawing.Point(273, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(865, 41);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Proyecto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(412, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name Space Proyecto";
            // 
            // CBSubProject
            // 
            this.CBSubProject.FormattingEnabled = true;
            this.CBSubProject.Location = new System.Drawing.Point(531, 13);
            this.CBSubProject.Name = "CBSubProject";
            this.CBSubProject.Size = new System.Drawing.Size(242, 21);
            this.CBSubProject.TabIndex = 3;
            this.CBSubProject.SelectionChangeCommitted += new System.EventHandler(this.CBSubProject_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(80, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proyecto";
            // 
            // CBProject
            // 
            this.CBProject.FormattingEnabled = true;
            this.CBProject.Location = new System.Drawing.Point(135, 14);
            this.CBProject.Name = "CBProject";
            this.CBProject.Size = new System.Drawing.Size(242, 21);
            this.CBProject.TabIndex = 0;
            this.CBProject.SelectionChangeCommitted += new System.EventHandler(this.CBProject_SelectionChangeCommitted);
            // 
            // FrmPropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1150, 694);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPropiedades";
            this.Text = "Selecciona Propoedades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPropiedades_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Propiedades)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_TiposProp;
        private System.Windows.Forms.CheckedListBox LstSelectPropiedad;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BTN_MetaData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBSubProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBProject;
        private System.Windows.Forms.Button BTN_Actualizar;
        private System.Windows.Forms.Button BTN_Seleccionar;
        private System.Windows.Forms.DataGridView DGV_Propiedades;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPropiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprojectp;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddata;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopropiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn padre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn creaselect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn creainsert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn creadelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn creaupdate;
        private System.Windows.Forms.Button BTN_DelData;
        private System.Windows.Forms.Button BTN_ActualizaData;
    }
}