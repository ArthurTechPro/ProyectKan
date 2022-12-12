using System;
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
    public partial class MainForm : Form
    {
        public Configuracion ConfigActual;
        public ConfiguracionMotor ConfigMotor;
        public MainForm()
        {
            InitializeComponent();
            ConfigActual = new Configuracion();
            ConfigMotor = new ConfiguracionMotor();
        }

        private void salirMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Project KAN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void plantillasMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlantillas frm = new FrmPlantillas();
            frm.MdiParent = this;
            frm.Show();

        }

        private void codigoMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenerar frm = new FrmGenerar();
            frm.MdiParent = this;
            frm.ConfigActual = ConfigActual;
            frm.ConfigMotor = ConfigMotor;
            frm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CaragaConfigActual();
            CarfgaConfigMotor();

        }

        private void CaragaConfigActual()
        {
            kan_configgenDAO Kan_ConfGenDAO = new kan_configgenDAO();
            kan_configgenBLL Kan_ConfGenBLL = new kan_configgenBLL();

            Kan_ConfGenDAO = Kan_ConfGenBLL.SelectALL();

            if (Kan_ConfGenDAO.Tables[0].Rows.Count > 0 )
            {
                foreach (DataRow dr in Kan_ConfGenDAO.Tables[0].Rows)
                {
                    switch (dr[kan_configgenDAO.CONTANTE_CAMPO].ToString().Trim())
                    {
                        case "SQLCONN":
                            ConfigActual.SQLCONN = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "SQLDA":
                            ConfigActual.SQLDA = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "SQLCMM":
                            ConfigActual.SQLCMM = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "SQLTRANSAC":
                            ConfigActual.SQLTRANSAC = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONFIGSETING":
                            ConfigActual.CONFIGSETING = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "STRINGCONNECTION":
                            ConfigActual.STRINGCONNECTION = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "DATAPROVEEDOR":
                            ConfigActual.DATAPROVEEDOR = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_DATATABLE":
                            ConfigActual.CONSTANTE_DATATABLE = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_TABLA":
                            ConfigActual.CONSTANTE_TABLA = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_DAO":
                            ConfigActual.CONSTANTE_DAO = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_BLL":
                            ConfigActual.CONSTANTE_BLL = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_DAL":
                            ConfigActual.CONSTANTE_DAL = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_CAMPO":
                            ConfigActual.CONSTANTE_CAMPO = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "CONSTANTE_PARAMETRO":
                            ConfigActual.CONSTANTE_PARAMETRO = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "DEFAULT_STRINGCONNECTION":
                            ConfigActual.DEFAULT_STRINGCONNECTION = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "DBPLATAFOR":
                            ConfigActual.DBPLATAFOR = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "SQLPARAM":
                            ConfigActual.SQLPARAM = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "DIR_PLANTILLAS":
                            ConfigActual.DIR_PLANTILLAS = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        case "TYPEDATASQL":
                            ConfigActual.TYPEDATASQL = dr[kan_configgenDAO.VARIABLE_CAMPO].ToString();
                            break;
                        default:
                            ConfigActual.IntSinInstanciar++;
                            break;
                    }
                }
            }
        }

        private void CarfgaConfigMotor()
        {

            kan_configmotorDAO Kan_CMotorDAO = new kan_configmotorDAO();
            kan_configmotorBLL kan_CMotorBLL = new kan_configmotorBLL();

            Kan_CMotorDAO = kan_CMotorBLL.SelectALL();

            if (Kan_CMotorDAO.Tables[0].Rows.Count > 0 )
            {
                foreach (DataRow dr in Kan_CMotorDAO.Tables[0].Rows)
                {
                    switch (dr[kan_configmotorDAO.NOMCOMANDO_CAMPO].ToString().Trim())
                    {
                        case "SelectTables":
                            ConfigMotor.StrSelectTables = dr[kan_configmotorDAO.SQL_CAMPO].ToString().Trim();
                            break;
                        case "SelectColumns":
                            ConfigMotor.StrSelectColumns = dr[kan_configmotorDAO.SQL_CAMPO].ToString().Trim();
                            break;
                        case "SelectSP":
                            ConfigMotor.StrSelectSP = dr[kan_configmotorDAO.SQL_CAMPO].ToString().Trim();
                            break;
                        case "SelectIDX":
                            ConfigMotor.StrSelectIDX = dr[kan_configmotorDAO.SQL_CAMPO].ToString().Trim();
                            break;
                        default:
                            ConfigMotor.IntSinInstanciar++;
                            break;
                    }
                }
            }
        
        }

        private void tablasMenuItem_Click(object sender, EventArgs e)
        {
            FrmPropiedades frm = new FrmPropiedades();
            frm.ConfigActual = ConfigActual;
            frm.ConfigMotor = ConfigMotor;
            frm.MdiParent = this;
            frm.Show();
        }

        private void proyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfigProject frm = new FrmConfigProject();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comandosMenuItem1_Click(object sender, EventArgs e)
        {
            FrmComandos frm = new FrmComandos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MenuPpal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
