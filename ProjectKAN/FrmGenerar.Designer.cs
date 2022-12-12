namespace ProjectKAN.WIN
{
    partial class FrmGenerar
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
            this.ListProject = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Proyectos = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LstPropiedades = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LstPlantillas = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DG_Archivos = new System.Windows.Forms.DataGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BTNEdit = new System.Windows.Forms.Button();
            this.CheckXML = new System.Windows.Forms.CheckBox();
            this.BTNGenerar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Archivos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListProject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CB_Proyectos);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proyectos";
            // 
            // ListProject
            // 
            this.ListProject.FormattingEnabled = true;
            this.ListProject.Location = new System.Drawing.Point(6, 48);
            this.ListProject.Name = "ListProject";
            this.ListProject.Size = new System.Drawing.Size(290, 186);
            this.ListProject.TabIndex = 3;
            this.ListProject.Click += new System.EventHandler(this.listProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proyecto";
            // 
            // CB_Proyectos
            // 
            this.CB_Proyectos.BackColor = System.Drawing.SystemColors.Info;
            this.CB_Proyectos.FormattingEnabled = true;
            this.CB_Proyectos.Location = new System.Drawing.Point(68, 20);
            this.CB_Proyectos.Name = "CB_Proyectos";
            this.CB_Proyectos.Size = new System.Drawing.Size(228, 21);
            this.CB_Proyectos.TabIndex = 1;
            this.CB_Proyectos.SelectionChangeCommitted += new System.EventHandler(this.CB_Proyectos_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LstPropiedades);
            this.groupBox2.Location = new System.Drawing.Point(12, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 423);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Propiedades";
            // 
            // LstPropiedades
            // 
            this.LstPropiedades.CheckOnClick = true;
            this.LstPropiedades.FormattingEnabled = true;
            this.LstPropiedades.Location = new System.Drawing.Point(7, 21);
            this.LstPropiedades.Name = "LstPropiedades";
            this.LstPropiedades.Size = new System.Drawing.Size(289, 394);
            this.LstPropiedades.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LstPlantillas);
            this.groupBox3.Location = new System.Drawing.Point(322, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(805, 246);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plantillas";
            // 
            // LstPlantillas
            // 
            this.LstPlantillas.BackColor = System.Drawing.SystemColors.GrayText;
            this.LstPlantillas.CheckOnClick = true;
            this.LstPlantillas.FormattingEnabled = true;
            this.LstPlantillas.Location = new System.Drawing.Point(6, 20);
            this.LstPlantillas.Name = "LstPlantillas";
            this.LstPlantillas.Size = new System.Drawing.Size(793, 214);
            this.LstPlantillas.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DG_Archivos);
            this.groupBox4.Location = new System.Drawing.Point(322, 307);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(805, 369);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Archivos Generados";
            // 
            // DG_Archivos
            // 
            this.DG_Archivos.DataMember = "";
            this.DG_Archivos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DG_Archivos.Location = new System.Drawing.Point(6, 19);
            this.DG_Archivos.Name = "DG_Archivos";
            this.DG_Archivos.Size = new System.Drawing.Size(793, 342);
            this.DG_Archivos.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BTNEdit);
            this.groupBox5.Controls.Add(this.CheckXML);
            this.groupBox5.Controls.Add(this.BTNGenerar);
            this.groupBox5.Location = new System.Drawing.Point(322, 253);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(805, 53);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // BTNEdit
            // 
            this.BTNEdit.Location = new System.Drawing.Point(163, 13);
            this.BTNEdit.Name = "BTNEdit";
            this.BTNEdit.Size = new System.Drawing.Size(143, 32);
            this.BTNEdit.TabIndex = 2;
            this.BTNEdit.Text = "Edit Plus";
            this.BTNEdit.UseVisualStyleBackColor = true;
            this.BTNEdit.Click += new System.EventHandler(this.BTNEdit_Click);
            // 
            // CheckXML
            // 
            this.CheckXML.AutoSize = true;
            this.CheckXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckXML.ForeColor = System.Drawing.SystemColors.Desktop;
            this.CheckXML.Location = new System.Drawing.Point(742, 21);
            this.CheckXML.Name = "CheckXML";
            this.CheckXML.Size = new System.Drawing.Size(51, 17);
            this.CheckXML.TabIndex = 1;
            this.CheckXML.Text = "XML";
            this.CheckXML.UseVisualStyleBackColor = true;
            // 
            // BTNGenerar
            // 
            this.BTNGenerar.Location = new System.Drawing.Point(13, 13);
            this.BTNGenerar.Name = "BTNGenerar";
            this.BTNGenerar.Size = new System.Drawing.Size(143, 32);
            this.BTNGenerar.TabIndex = 0;
            this.BTNGenerar.Text = "Generar";
            this.BTNGenerar.UseVisualStyleBackColor = true;
            this.BTNGenerar.Click += new System.EventHandler(this.BTNGenerar_Click);
            // 
            // FrmGenerar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1139, 694);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGenerar";
            this.Text = "Generar Archivos ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGenerar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Archivos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGrid DG_Archivos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BTNGenerar;
        private System.Windows.Forms.CheckedListBox LstPropiedades;
        private System.Windows.Forms.CheckedListBox LstPlantillas;
        private System.Windows.Forms.CheckBox CheckXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Proyectos;
        private System.Windows.Forms.ListBox ListProject;
        private System.Windows.Forms.Button BTNEdit;
    }
}