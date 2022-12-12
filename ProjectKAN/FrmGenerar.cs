using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectKAN.DAO;
using ProjectKAN.BLL;
using ProjectKAN.WIN;

using System.Xml;
using System.Xml.Xsl;

namespace ProjectKAN.WIN
{
    public partial class FrmGenerar : Form
    {
        private DataTable DTablelog;
        public Configuracion ConfigActual;
        public ConfiguracionMotor ConfigMotor;

        public FrmGenerar()
        {
            InitializeComponent();
            BuildDataTable();
            DG_Archivos.SetDataBinding(DTablelog, "");
        }

        private void BuildDataTable()
        {
            DataColumnCollection columns;
            DTablelog = new DataTable("Datos");
            columns = DTablelog.Columns;
            columns.Add("Tabla", typeof(System.String));
            columns.Add("Archivo", typeof(System.String));
            columns["Archivo"].MaxLength = 400;
            columns.Add("esASPX", typeof(System.Boolean));
        }


        /// <summary>
        /// Boton generar codigo de las clases segun pplantillas seleccionadas.
        /// </summary>
        /// <param name="sender"></param>
        /// 
        /// 
        /// <param name="e"></param>
        private void BTNGenerar_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            DTablelog.Rows.Clear();
            for (int i = 0; i < LstPropiedades.CheckedIndices.Count; i++)
            {
                DataRowView dr = (DataRowView)LstPropiedades.CheckedItems[i];
                string NomPropiedad = dr[kan_propiedadesDAO.NOMBRE_CAMPO].ToString();
                GenerePropiedad(NomPropiedad);
            }
           // this.Cursor = Cursors.Default;
        }
        
        /// <summary>
        /// Genera Propieded 
        /// </summary>
        /// <param name="wl_NomPropiedad">Nombre de la Propiedad</param>
        private void GenerePropiedad(string wl_NomPropiedad)
        {
            string archivo = "";
            GeneraObjeto GenObjeto = new GeneraObjeto();
            GenObjeto.ConfigMotor = ConfigMotor;
            GenObjeto.ConfigActual = ConfigActual;

            for (int i = 0; i < LstPlantillas.CheckedIndices.Count ; i++)
            {
                DataRowView dr = (DataRowView) LstPlantillas.CheckedItems[i];
                string idPlantilla = dr[kan_plantillasDAO.IDPLANTILLA_CAMPO].ToString();
                string idProjectp = CB_Proyectos.SelectedValue.ToString();
                string idProJect = ListProject.SelectedValue.ToString();
                bool esASPX = (bool)Convert.ToBoolean(dr[kan_plantillasDAO.LIMPIAASPX_CAMPO]);
                /// <summary>
                ///  GENERE LA PLANTILLA
                /// </summary>
                archivo = GenObjeto.Planilla(idPlantilla, wl_NomPropiedad,idProJect, idProjectp, CheckXML.Checked);
                DTablelog.Rows.Add(new object[] { wl_NomPropiedad, archivo, esASPX });
            }
        }

        /// <summary>
        /// Genenra Load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGenerar_Load(object sender, EventArgs e)
        {
            CargarProyectos();
            CargarPlantillas();
        }

        /// <summary>
        /// Proceso para cargar Proyectos de la Aplicación
        /// </summary>
        private void CargarProyectos()
        {
            kan_projectDAO Kan_ProjDAO = new kan_projectDAO();
            kan_projectBLL Kan_projBLL = new kan_projectBLL();

            Kan_ProjDAO = Kan_projBLL.SelectALL();
            if (Kan_ProjDAO.Tables[0].Rows.Count > 0)
            {
                CB_Proyectos.DataSource = Kan_ProjDAO.Tables[0].DefaultView;
                CB_Proyectos.ValueMember = kan_projectDAO.IDPROJECT_CAMPO;
                CB_Proyectos.DisplayMember = kan_projectDAO.NOMPROJECT_CAMPO;
            }
        }
        /// <summary>
        /// Carga la configuraciones de los proyectos.
        /// </summary>
        private void CaragaCongigProject()
        {
            kan_configprojectDAO Kan_ConfigProjDAO = new kan_configprojectDAO();
            kan_configprojectBLL Kan_ConfigProjBLL = new kan_configprojectBLL();

            Kan_ConfigProjDAO = Kan_ConfigProjBLL.SelectPro(CB_Proyectos.SelectedValue.ToString());
            ListProject.DataSource = Kan_ConfigProjDAO.Tables[0].DefaultView;
            ListProject.ValueMember = kan_configprojectDAO.IDCONFIGP_CAMPO;
            ListProject.DisplayMember = kan_configprojectDAO.NAMEPROJECT_CAMPO;
            
          
        }

        /// <summary>
        /// Proceso Para Cargar Las TABLAS asociadad a los proyectos de la aplicacion
        /// </summary>
        private void CargarPropiedades()
        {
            kan_propiedadesDAO Kan_PropDAO = new kan_propiedadesDAO();
            kan_propiedadesBLL Kan_PropBLL = new kan_propiedadesBLL();

            Kan_PropDAO = Kan_PropBLL.SelectPro(ListProject.SelectedValue.ToString());
            LstPropiedades.DataSource = Kan_PropDAO.Tables[0].DefaultView;
            LstPropiedades.ValueMember = kan_propiedadesDAO.IDPROPIEDAD_CAMPO;
            LstPropiedades.DisplayMember = kan_propiedadesDAO.NOMBRE_CAMPO;
    
        }

        /// <summary>
        /// Proceso para cargar las plavtillas disponibles. 
        /// </summary>
        private void CargarPlantillas()
        {
            kan_plantillasDAO Kan_PlantDAO = new kan_plantillasDAO();
            kan_plantillasBLL Kan_PlantBLL = new kan_plantillasBLL();

            Kan_PlantDAO = Kan_PlantBLL.SelectALL();
            LstPlantillas.DataSource = Kan_PlantDAO.Tables[0].DefaultView;
            LstPlantillas.ValueMember = kan_plantillasDAO.IDPLANTILLA_CAMPO;
            LstPlantillas.DisplayMember = kan_plantillasDAO.DESCRIP_CAMPO;
        }
        /// <summary>
        /// Carga los Proyectos subproyectos dependiendo el proyecto solucion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_Proyectos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CaragaCongigProject();
        }

        private void BTNEdit_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "C:\\Archivos de programa\\EditPlus 3\\editplus.exe";  //  "Notepad";
            myProcess.StartInfo.Arguments = DG_Archivos[DG_Archivos.CurrentRowIndex, 1].ToString();
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            myProcess.Start();
        }
        /// <summary>
        /// Carga las propiedades del proyecto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listProject_Click(object sender, EventArgs e)
        {
            CargarPropiedades();
        }

    }
}
