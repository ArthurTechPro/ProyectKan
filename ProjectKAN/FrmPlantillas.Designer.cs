namespace ProjectKAN
{
    partial class FrmPlantillas
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BotonCancelar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnNueva = new System.Windows.Forms.Button();
            this.DataGred_Plantillas = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGred_Plantillas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1115, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Definicion de Plantillas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLANTILLAS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DataGred_Plantillas);
            this.groupBox2.Location = new System.Drawing.Point(176, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(951, 557);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Plantillas";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnNueva);
            this.groupBox3.Controls.Add(this.BtnActualizar);
            this.groupBox3.Controls.Add(this.BotonCancelar);
            this.groupBox3.Location = new System.Drawing.Point(12, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 198);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // BotonCancelar
            // 
            this.BotonCancelar.Location = new System.Drawing.Point(7, 20);
            this.BotonCancelar.Name = "BotonCancelar";
            this.BotonCancelar.Size = new System.Drawing.Size(139, 34);
            this.BotonCancelar.TabIndex = 0;
            this.BotonCancelar.Text = "Consultar";
            this.BotonCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(7, 96);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(139, 33);
            this.BtnActualizar.TabIndex = 1;
            this.BtnActualizar.Text = "Actulizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            // 
            // BtnNueva
            // 
            this.BtnNueva.Location = new System.Drawing.Point(7, 60);
            this.BtnNueva.Name = "BtnNueva";
            this.BtnNueva.Size = new System.Drawing.Size(139, 33);
            this.BtnNueva.TabIndex = 2;
            this.BtnNueva.Text = "Nueva";
            this.BtnNueva.UseVisualStyleBackColor = true;
            // 
            // DataGred_Plantillas
            // 
            this.DataGred_Plantillas.CaptionText = "Plantillas";
            this.DataGred_Plantillas.DataMember = "";
            this.DataGred_Plantillas.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGred_Plantillas.Location = new System.Drawing.Point(20, 20);
            this.DataGred_Plantillas.Name = "DataGred_Plantillas";
            this.DataGred_Plantillas.RowHeadersVisible = false;
            this.DataGred_Plantillas.Size = new System.Drawing.Size(914, 519);
            this.DataGred_Plantillas.TabIndex = 0;
            // 
            // FrmPlantillas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1150, 668);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPlantillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPlantillas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGred_Plantillas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnNueva;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BotonCancelar;
        private System.Windows.Forms.DataGrid DataGred_Plantillas;
    }
}