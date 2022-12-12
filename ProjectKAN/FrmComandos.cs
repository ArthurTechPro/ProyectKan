using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProjectKAN.BLL;
using ProjectKAN.DAO;

namespace ProjectKAN.WIN
{
    public partial class FrmComandos : Form
    {
        private kan_propiedadesDAO dsMain;
        private kan_comandosDAO dsComando;
        private kan_parametrosDAO dsParametros;
        private kan_propcolumnasDAO dsColumnas;
        private string strTablaActual;
        private string strComandoActual;
        private bool ComInsert = false;
        private string IPro = "0";
        private string ICom = "0";
        
        public FrmComandos()
        {
            InitializeComponent();

            dsComando = new kan_comandosDAO();
            dsParametros = new kan_parametrosDAO();
            dsColumnas = new kan_propcolumnasDAO();
        }

        private void FrmComandos_Load(object sender, EventArgs e)
        {
            CargarDropDown();
            CargaProyectos();
            ControlDataBind();
            CargaAyuda();
       }

        private void CargaAyuda()
        {
            txtAyuda.Text = "{0} Nombre de la Propiedad Origen";
			txtAyuda.Text += Environment.NewLine + "{1} Relacion de todos los Campos";
			txtAyuda.Text += Environment.NewLine + "{2} Relacion de todos los Campos, agregar @PARM";
			txtAyuda.Text += Environment.NewLine + "{3} Relacion de todos los Campos, Sin Identity";
			txtAyuda.Text += Environment.NewLine + "{4} Relacion de todos los Campos, Sin Identity, agregar @PARM";				
			txtAyuda.Text += Environment.NewLine + "{5} Todos los Campos = Parametros, Sin Identity, agregar @PARM";
			txtAyuda.Text += Environment.NewLine + "{6} Expresion WHERE de la llave Primaria(Primarykey)";
			txtAyuda.Text += Environment.NewLine + "{7} Expresion WHERE de los parametros del Comado.";
        }

        private void CargarDatos()
        {
            string LisProp="";
            kan_propiedadesBLL Kan_PropBLL = new kan_propiedadesBLL();
            dsMain = Kan_PropBLL.SelectTablasBD(CBSubProject.SelectedValue.ToString());
                       
            dsMain.EnforceConstraints = false;
            
            kan_comandosBLL Kan_ComBLL = new kan_comandosBLL();

            foreach (DataRow dr in dsMain.Tables[0].Rows)
            {
                LisProp = LisProp.Trim() + dr[kan_propiedadesDAO.IDPROPIEDAD_CAMPO].ToString().Trim() + ",";
            }

            dsMain.Tables.Add(((DataSet)Kan_ComBLL.SelectComandosBD((LisProp+"0"))).Tables[0].Copy());

            DataColumn[] parentCol = dsMain.Tables[kan_propiedadesDAO.KAN_PROPIEDADES_TABLA].PrimaryKey;

            DataColumn[] childCol = new DataColumn[1];

            childCol[0] = dsMain.Tables[kan_comandosDAO.KAN_COMANDOS_TABLA].Columns[kan_comandosDAO.IDPROPIEDAD_CAMPO];
        
            // Create DataRelation.
            DataRelation rel = new DataRelation("ComandosTabla", parentCol, childCol, true);

            // Add the relation to the DataSet.
            dsMain.Relations.Add(rel);
        }

        
        private void CargarDropDown()
        {

            kan_comandoBLL cmd = new kan_comandoBLL();

            cboComando.DisplayMember = kan_comandoDAO.COMANDO_CAMPO;
            cboComando.ValueMember = kan_comandoDAO.IDCOMAN_CAMPO;
            cboComando.DataSource = cmd.SelectALL().Tables[0].DefaultView;

            kan_tiposcomandoBLL tcmd = new kan_tiposcomandoBLL();

            cboTipoComando.DisplayMember = kan_tiposcomandoDAO.COMANDO_CAMPO;
            cboTipoComando.ValueMember = kan_tiposcomandoDAO.TIPOCOMANDO_CAMPO;
            cboTipoComando.DataSource = tcmd.SelectALL().Tables[0].DefaultView;

            kan_tiposparametroBLL prm = new kan_tiposparametroBLL();

            cboTipoParametros.DisplayMember = kan_tiposparametroDAO.PARAMETRO_CAMPO;
            cboTipoParametros.ValueMember = kan_tiposparametroDAO.TIPOPARAMETRO_CAMPO;
            cboTipoParametros.DataSource = prm.SelectALL().Tables[0].DefaultView;

            cboTipoImplementacion.DataSource = DataTableTipoImplementacion();
            cboTipoImplementacion.DisplayMember = "Tipo";
            cboTipoImplementacion.ValueMember = "Id";

            cboDireccion.SelectedIndex = 0;
            cboTipoDato.SelectedIndex = 0;
        }

        private DataTable DataTableTipoImplementacion()
        {
            DataColumnCollection columns;
            DataTable table = new DataTable("TipoImplementacion");
            columns = table.Columns;
            table.Columns.Add("Id", typeof(System.Int16));
            table.Columns.Add("Tipo", typeof(System.String));
            table.Rows.Add(new object[] { 1, "SQL" });
            table.Rows.Add(new object[] { 2, "StoredProcedure" });

            return table;
        }

         private void CargaProyectos()
        {
            kan_projectDAO Kan_ProDAO = new kan_projectDAO();
            kan_projectBLL Kan_ProBLL = new kan_projectBLL();

            Kan_ProDAO = Kan_ProBLL.SelectALL();
            CBProject.ValueMember = kan_projectDAO.IDPROJECT_CAMPO;
            CBProject.DisplayMember = kan_projectDAO.NOMPROJECT_CAMPO;
            CBProject.DataSource = Kan_ProDAO.Tables[0].DefaultView;

        }

        private void CargaSubProyectos()
        {
            string wProject = CBProject.SelectedValue.ToString();

            kan_configprojectDAO Kan_CProDAO = new kan_configprojectDAO();
            kan_configprojectBLL Kan_CProBLL = new kan_configprojectBLL();

            Kan_CProDAO = Kan_CProBLL.SelectPro(wProject);

            CBSubProject.ValueMember = kan_configprojectDAO.IDCONFIGP_CAMPO;
            CBSubProject.DisplayMember = kan_configprojectDAO.NAMEPROJECT_CAMPO;
            CBSubProject.DataSource = Kan_CProDAO.Tables[0].DefaultView;

        }

        private void CBProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaSubProyectos();
        }

        private void CargarTreeView()
        {
            TV_Comandos.Nodes.Clear();
            DataRowView drW = (DataRowView)CBSubProject.Items[CBSubProject.SelectedIndex];
            //TreeNode root = new TreeNode(CBSubProject.Items[CBSubProject.SelectedIndex].ToString());
            TreeNode root = new TreeNode(drW[kan_configprojectDAO.NAMEPROJECT_CAMPO].ToString().Trim());
            root.Tag = "";
            TV_Comandos.Nodes.Add(root);

            foreach (DataRow dr in dsMain.Tables[0].Rows)
            {
                TreeNode nodeTabla = new TreeNode(dr[kan_propiedadesDAO.NOMBRE_CAMPO].ToString().Trim());
                nodeTabla.Tag = "Tabla";
                nodeTabla.ImageKey = dr[kan_propiedadesDAO.IDPROPIEDAD_CAMPO].ToString();
                nodeTabla.SelectedImageIndex = 0;
                //nodeTabla.ImageIndex = dr[kan_propiedadesDAO.IDPROPIEDAD_CAMPO] ;

                root.Nodes.Add(nodeTabla);
                nodeTabla.EnsureVisible();
                foreach (DataRow drChild in dr.GetChildRows("ComandosTabla"))
                {
                    TreeNode nodeComando = new TreeNode(drChild[kan_comandosDAO.NOMBRECOM_CAMPO].ToString().Trim());
                    nodeComando.Tag = "Comando";
                    nodeComando.ImageKey = drChild[kan_comandosDAO.IDCOMANDO_CAMPO].ToString();
                    //nodeComando.ImageIndex = drChild[kan_comandosDAO.IDCOMANDO_CAMPO]; 
                    nodeComando.SelectedImageIndex = 1;
                    nodeTabla.Nodes.Add(nodeComando);
                    nodeComando.EnsureVisible();
                }
            }
            root.EnsureVisible();
        }

        private void NuevoComando()
        {
            ComInsert = true;
            txtNombreComando.Text = "<Nuevo Comando>";
            TreeNode n = new TreeNode(txtNombreComando.Text, 1, 1);

            if (TV_Comandos.SelectedNode.SelectedImageIndex == 0) //Tabla
                TV_Comandos.SelectedNode.Nodes.Add(n);
            else
                TV_Comandos.SelectedNode.Parent.Nodes.Add(n);

            n.EnsureVisible();
            TV_Comandos.SelectedNode = n;

            BindingContext[dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA].EndCurrentEdit();
            BindingContext[dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA].AddNew();

            if (BindingContext[dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA].Current.GetType()
                != typeof(DataRowView)) return;

            // Otherwise, print the value of the column named "CustName".
            DataRowView drv = (DataRowView)BindingContext[dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA].Current;

            //drv[ComandosTablaDAO.NOMBREBD_CAMPO] = ConfiguracionActual.NombreBaseDatos;
            drv[kan_comandosDAO.NOMBRECOM_CAMPO] = strTablaActual;

            cboTipoParametros.SelectedIndex = 0;
            cboTipoImplementacion.SelectedIndex = 0;
            textIDProp.Text = IPro.ToString();
            txtNombreComando.Text = "<Nuevo Comando>";
            

            txtNombreComando.Focus();
            txtNombreComando.SelectAll();
        }

        private void EstadoEdicionComando(bool st)
        {
            groupBox3.Enabled = st;
            BTN_Nuevo.Enabled = true;
            BTN_Guardar.Enabled = st;
            BTN_Elliminar.Enabled = st;
        }


        private void CBSubProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarDatos();
            CargarTreeView();
        }

        private void BTN_Nuevo_Click(object sender, EventArgs e)
        {
            NuevoComando();
            EstadoEdicionComando(true);
        }

        private void TV_Comandos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.SelectedImageIndex)
            {
                case 0: //Tabla
                    IPro = e.Node.ImageKey.ToString();
                    strTablaActual = e.Node.Text;
                    EstadoEdicionComando(false);
                    break;
                case 1: //Comando
                    IPro = e.Node.Parent.ImageKey.ToString();
                    ICom = e.Node.ImageKey.ToString();
                    //ICom = e.Node.Parent.ImageKey.ToString();
                    strTablaActual = e.Node.Parent.Text;
                    CargarDatosComando(IPro, ICom);
                    EstadoEdicionComando(true);
                    break;
                default:
                    break;
            }
        }


        private void CargarDatosComando(string strPro, string strCom)
        {
        
            if (strPro == "") strPro = "0";
            if (strCom == "") strCom = "0";

            dsComando.Clear();
            kan_comandosBLL Kan_ComdsBLL = new kan_comandosBLL();
            dsComando.Merge(Kan_ComdsBLL.SelectID(strCom));
           
            dsParametros.Clear();
            kan_parametrosBLL Kan_paramBLL = new kan_parametrosBLL();
            dsParametros.Merge(Kan_paramBLL.SelectParamComando(strCom));
        
            dsColumnas.Clear();
            kan_propcolumnasBLL Kan_PcolBLL = new kan_propcolumnasBLL();
            dsColumnas.Merge(Kan_PcolBLL.SelectPro(strPro));
        
        }

        private void BTN_Guardar_Click(object sender, EventArgs e)
        {
            BindingContext[dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA].EndCurrentEdit();

            if (dsComando.HasChanges())
            {
                if (dsComando.HasErrors)
                    System.Diagnostics.Debug.WriteLine(dsComando.Tables[0].GetErrors()[0].ToString());
                else
                {
                    //					ParametrosComandoDAL parDAL = new ParametrosComandoDAL();
                    //					parDAL.Update(dsMain.Tables[ParametrosComandoDAO.PARAMETROSCOMANDO_TABLA]);

                    kan_comandosBLL Kan_ComBLL = new kan_comandosBLL();
                    if (ComInsert)
                        Kan_ComBLL.Insert(dsComando);
                    else
                        Kan_ComBLL.Update(dsComando);
                  
                }
                if (dsMain.HasErrors)
                    System.Diagnostics.Debug.WriteLine("Errores: " + dsComando.Tables[0].GetErrors()[0].ToString());

                //Falta hacer merge para traer cambios de otros usuarios
            }
            ComInsert = false;
            CargarDatos();
            CargarTreeView();
        }

        private void ControlDataBind()
        {
            textIDProp.DataBindings.Add("Text", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.IDPROPIEDAD_CAMPO);
            txtNombreComando.DataBindings.Add("Text", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.NOMBRECOM_CAMPO);
            txtSQL.DataBindings.Add("Text", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.SQL_CAMPO);
            cboComando.DataBindings.Add("SelectedValue", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.IDCOMAN_CAMPO);
            cboTipoComando.DataBindings.Add("SelectedValue", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.TIPOCOMANDO_CAMPO);
            cboTipoParametros.DataBindings.Add("SelectedValue", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.TIPOPARAMETRO_CAMPO);
            cboTipoImplementacion.DataBindings.Add("SelectedValue", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.TIPOIMPLEMENTA_CAMPO);
            txtParametros.DataBindings.Add("Text", dsComando, kan_comandosDAO.KAN_COMANDOS_TABLA + "." + kan_comandosDAO.PARAMETROS_CAMPO);
            grdParametros.SetDataBinding(dsParametros, kan_parametrosDAO.KAN_PARAMETROS_TABLA);
            lstCampos.DataSource = dsColumnas.Tables[0].DefaultView;
        }

        private void BTN_Elliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea eliminar este registro","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
                kan_comandosBLL comandosBLL = new kan_comandosBLL();
                comandosBLL.Delete(ICom.ToString());
				TV_Comandos.Nodes.Remove(TV_Comandos.SelectedNode);
			}
        }

        private void BTN_Adicionar_Click(object sender, EventArgs e)
        {

        }

    }
}
