using System;
using System.IO;
using System.Reflection; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectKAN.DAO;
using ProjectKAN.BLL;

namespace ProjectKAN.WIN
{
    public partial class FrmConfigProject : Form
    {
       
        private kan_projectDAO Kan_ProDAO;
        private kan_projectBLL Kan_ProBLL;
        private kan_configprojectDAO Kan_CProDAO;
        private kan_configprojectBLL Kan_CProBLL;
        private kan_dirsalidaBLL Kan_DirBLL;
        private kan_plantillasDAO Kan_PlantDAO;
        private kan_plantillasBLL Kan_PlantBLL;
        private VwKan_DirPlantillaDAO Kan_DirPlantDAO;
        private VwKan_DirPlantillaBLL Kan_DirPlantBLL;

        public FrmConfigProject()
        {
            InitializeComponent();
        }

        private void BTNAddPro_Click(object sender, EventArgs e)
        {
            Kan_ProBLL = new kan_projectBLL();
            Kan_ProBLL.Insert(textProyect.Text,textName.Text);
            CargaProyectos();
            textProyect.Text = "" ;
            textName.Text = "";
        }

        private void FrmConfigProject_Load(object sender, EventArgs e)
        {
            CargaProyectos();
            CargaPlantillas();
        }

        private void CargaProyectos()
        {

            Kan_ProDAO = new kan_projectDAO();
            Kan_ProBLL = new kan_projectBLL();
            Kan_ProDAO = Kan_ProBLL.SelectALL();
            listProyectos.DisplayMember = kan_projectDAO.NOMPROJECT_CAMPO;
            listProyectos.ValueMember = kan_projectDAO.IDPROJECT_CAMPO;
            listProyectos.DataSource = Kan_ProDAO.Tables[0].DefaultView;
        }

        private void CargaPlantillas()
        {
            Kan_PlantDAO = new kan_plantillasDAO();
            Kan_PlantBLL = new kan_plantillasBLL();
            Kan_PlantDAO = Kan_PlantBLL.SelectALL();
            CB_Plantillas.DisplayMember = kan_plantillasDAO.DESCRIP_CAMPO;
            CB_Plantillas.ValueMember = kan_plantillasDAO.IDPLANTILLA_CAMPO;
            if ( Kan_PlantDAO.Tables[0].Rows.Count > 0)
                CB_Plantillas.DataSource = Kan_PlantDAO.Tables[0].DefaultView;

        }

        private void listProyectos_Click(object sender, EventArgs e)
        {

            Kan_PlantDAO = new kan_plantillasDAO();
            DGDirSalida.DataSource = Kan_PlantDAO.Tables[0].DefaultView;
            CargaSubProyectos();
            

        }

        private void BTNAddSubPro_Click(object sender, EventArgs e)
        {
            Kan_CProBLL = new kan_configprojectBLL();
            Kan_CProBLL.Insert(listProyectos.SelectedValue.ToString(), textSubProyect.Text);
            CargaSubProyectos();
            textSubProyect.Text = "";
        }

        private void CargaSubProyectos()
        {
            /*
            DataRowView dr = (DataRowView)listProyectos.SelectedItem;
            textProyect.Text = (string)dr[kan_projectDAO.NOMPROJECT_CAMPO].ToString();
            textName.Text = (string)dr[kan_projectDAO.NAMESPACEPROJECT_CAMPO].ToString();
            */
            Kan_CProDAO = new kan_configprojectDAO();
            Kan_CProBLL = new kan_configprojectBLL();
            Kan_CProDAO = Kan_CProBLL.SelectPro(listProyectos.SelectedValue.ToString());
            listSubProyectos.DisplayMember = kan_configprojectDAO.NAMEPROJECT_CAMPO;
            listSubProyectos.ValueMember = kan_configprojectDAO.IDCONFIGP_CAMPO;
            listSubProyectos.DataSource = Kan_CProDAO.Tables[0].DefaultView;
        }

        private void listSubProyectos_Click(object sender, EventArgs e)
        {
            CargaDirSalida();
        }

        private void CargaDirSalida()
        {
            Kan_DirPlantDAO = new VwKan_DirPlantillaDAO();
            Kan_DirPlantBLL = new VwKan_DirPlantillaBLL();
            Kan_DirPlantDAO = Kan_DirPlantBLL.SelectProp(listSubProyectos.SelectedValue.ToString());
            DGDirSalida.DataSource = Kan_DirPlantDAO.Tables[0].DefaultView;
      
        }

        private void CargaDirSalida_OLD()
        {
            Kan_PlantDAO = new kan_plantillasDAO();
            Kan_PlantBLL = new kan_plantillasBLL();
            Kan_PlantDAO = Kan_PlantBLL.SelectID(listSubProyectos.SelectedValue.ToString());
            DGDirSalida.DataSource = Kan_PlantDAO.Tables[0].DefaultView;

        }

        private void BTN_SelectDir_Click(object sender, EventArgs e)
        {
            //textDirSalida.Text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            string DirProyec = @"D:\Documentos Personales\Mis Desarrollos\Visual Studio 2010\Projects";
            string DirSelect = "";

            FolderBrowserDialog dialogoRuta = new FolderBrowserDialog();
            dialogoRuta.SelectedPath = DirProyec.ToString();

            
            if (dialogoRuta.ShowDialog() == DialogResult.OK)
            {
                DirSelect = dialogoRuta.SelectedPath;
                textDirSalida.Text = DirSelect.Replace(DirProyec,"..\\..");
            }

            /*
            //string Xd = (string)Directory.SetCurrentDirectory();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Help";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.CheckFileExists = false;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textDirSalida.Text = Path.GetDirectoryName(fdlg.FileName);
                //System.IO.Path.GetDirectoryName(fdlg.FileName);
                //string drive =
                //dirName.Split(System.IO.Path.VolumeSeparatorChar)[0];
                //MessageBox.Show(drive);
            }
        */

        }

        private void BTNAddDir_Click(object sender, EventArgs e)
        {
            Kan_DirBLL = new kan_dirsalidaBLL();
            if (textDirSalida.Text != "")
            {
                Kan_DirBLL.Insert(listSubProyectos.SelectedValue.ToString(),
                                  CB_Plantillas.SelectedValue.ToString(),
                                  textDirSalida.Text);
            }

            textDirSalida.Text = "";
            CargaDirSalida();
        }

        private void listSubProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDirSalida();
        }

    }
}
