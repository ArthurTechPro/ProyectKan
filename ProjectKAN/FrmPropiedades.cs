using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ProjectKAN.Data;

using ProjectKAN.BLL;
using ProjectKAN.DAO;

namespace ProjectKAN.WIN
{
    public partial class FrmPropiedades : Form
    {
        private DataSet dsTablas;
        private string wTipoProp;
        private kan_propiedadesDAO DrPro;
        private kan_propcolumnasDAO Kan_PColumDAO;
        private int wIdentity;
        private string W_QUIERY;

        public Configuracion ConfigActual;
        public ConfiguracionMotor ConfigMotor;

        public FrmPropiedades()
        {
            InitializeComponent();
            dsTablas = new DataSet();
        }

        private void CargarPropiedadesGen(string wProp)
        {

            kan_propiedadesBLL Kan_PropBLL = new kan_propiedadesBLL();
            DrPro = Kan_PropBLL.SelectPro(wProp);
            DGV_Propiedades.DataSource = DrPro.Tables[0].DefaultView;
            //DG_Propiedades.SetDataBinding(DrPro, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            //            DrPro.Tables[0].RowChanged += new DataRowChangeEventHandler(FrmPropiedades_RowChanged);
        }
        /*
        private void DataBindControles()
        {
            DG_Propiedades.SetDataBinding(DrPro, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
        }
        */

        private void FrmPropiedades_Load(object sender, EventArgs e)
        {
            CargarPropiedadesGen("0");
            CargarTipoProp();
            CargaProyectos();
            //DataBindControles();
        }

        /// <summary>
        /// Proceso Para Cargar Las TABLAS asociadad a los proyectos de la aplicacion
        /// </summary>
        private void CargarTipoProp()
        {

            DataSet DsTipos = TiposAcciones();
            if (DsTipos.Tables[0].Rows.Count > 0)
            {
                CB_TiposProp.DataSource = DsTipos.Tables["Datos"].DefaultView;
                CB_TiposProp.ValueMember = DsTipos.Tables["Datos"].Columns["idtipop"].ToString();
                CB_TiposProp.DisplayMember = DsTipos.Tables["Datos"].Columns["descripcion"].ToString();
            }
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
        /// <summary>
        /// Genera las Acciones de la Propiedad.
        /// </summary>
        /// <returns>Retorna la DataTable con las Acciones ( Nuevo, Guardar, Eliminar ) </returns>
        private DataSet TiposAcciones()
        {
            DataSet DsTipos = new DataSet();
            DataTable tableAcciones;

            DataColumnCollection columns;
            tableAcciones = new DataTable("Datos");
            columns = tableAcciones.Columns;
            columns.Add("idtipop", typeof(System.String));
            columns.Add("descripcion", typeof(System.String));
            tableAcciones.Rows.Add(new object[] { "-1", "Seleccione Opcion" });
            tableAcciones.Rows.Add(new object[] { "0", "Tablas" });
            tableAcciones.Rows.Add(new object[] { "1", "Vistas" });
            tableAcciones.Rows.Add(new object[] { "2", "Procediminetos" });
            DsTipos.Tables.Add(tableAcciones);
            return DsTipos;

        }

        private void CargaPropiedades()
        {
            string OpTipo = CB_TiposProp.SelectedValue.ToString();
            switch (OpTipo)
            {

                case "-1":
                    dsTablas.Clear();
                    break;
                case "0":
                    CargarPropiedadesTB();
                    break;
                case "1":
                    CargarPropiedadesVW();
                    break;
                case "2":
                    CargarPropiedadesSP();
                    break;
                default:
                    break;
            }
        }

        private void CB_TiposProp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaPropiedades();
        }

        /// <summary>
        /// Listado de Tablas.
        /// </summary>
        private void CargarPropiedadesTB()
        {
            dsTablas.Clear();
            wTipoProp = "T";
            ObjetDataConn ODComm = new ObjetDataConn();
            /// SQLSERVER
            /// ODComm.SQLQuery = "SELECT sysobjects.id,sysobjects.name FROM sys.sysobjects WHERE xtype = 'U' AND name <> 'dtproperties' ORDER BY name ;";
            /// ODComm.SQLTabla = "sysobjects";
            /// ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["MSSQLConnectionString"].ToString();
            /// INFORMIX
            /// ODComm.SQLQuery = "SELECT TB.partnum AS id , TB.tabname AS name  FROM systables AS TB  WHERE ( TB.tabid >= 100 ) AND ( TB.Tabtype = 'T' ) ORDER BY 2   ;";
            /// ODComm.SQLTabla = "systables";
            /// ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["IFXSQLConnectionString"].ToString();
            /// POSTGRES
            ODComm.SQLQuery = "select t.reltype AS id,t.relname as name FROM pg_class t join pg_namespace n on (n.oid = t.relnamespace) WHERE t.relkind = 'r' and n.nspname = 'public'  ORDER BY 2";
            ODComm.SQLTabla = "pg_class";
            ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["PGSQLConnectionString"].ToString();


            dsTablas = ODComm.SqlEjecut();
            LstSelectPropiedad.DataSource = dsTablas.Tables[0].DefaultView;
            LstSelectPropiedad.ValueMember = "id";
            LstSelectPropiedad.DisplayMember = "name";

        }

        /// <summary>
        /// Listado de Vistas
        /// </summary>
        private void CargarPropiedadesVW()
        {
            dsTablas.Clear();
            wTipoProp = "V";
            ObjetDataConn ODComm = new ObjetDataConn();
            /// SQL SERVER
            /// ODComm.SQLQuery = "SELECT v.object_id, v.name FROM sys.views v ;";
            /// ODComm.SQLTabla = "views";
            /// ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["MSSQLConnectionString"].ToString();

            /// INFORMIX
            /// ODComm.SQLQuery = "SELECT TB.partnum AS id , TB.tabname AS name  FROM systables AS TB  WHERE ( TB.tabid >= 100 ) AND ( TB.Tabtype = 'V' ) ORDER BY 2   ;";
            /// ODComm.SQLTabla = "systables";
            /// ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["IFXSQLConnectionString"].ToString();

            /// POSTGES 
            ODComm.SQLQuery = "select t.reltype AS id,t.relname as name from pg_class t join pg_namespace n on (n.oid = t.relnamespace) where t.relkind = 'r' n.nspname = 'public' order by 1, 2";
            ODComm.SQLTabla = "pg_class";
            ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["PGSQLConnectionString"].ToString();

            dsTablas = ODComm.SqlEjecut();
            LstSelectPropiedad.DataSource = dsTablas.Tables[0].DefaultView;
            LstSelectPropiedad.ValueMember = "id";
            LstSelectPropiedad.DisplayMember = "name";

        }

        /// <summary>
        /// Listado de Procedimientos.
        /// </summary>
        private void CargarPropiedadesSP()
        {
            dsTablas.Clear();
            wTipoProp = "P";
            ObjetDataConn ODComm = new ObjetDataConn();

            /// SQL SERVER
            /// ODComm.SQLQuery = "SELECT p.id,p.name FROM sys.sysobjects p WHERE p.type in ('IF', 'FN', 'TF', 'P') ORDER BY 2 ;";
            /// ODComm.SQLTabla = "sysobjects";
            /// ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["MSSQLConnectionString"].ToString();

            ///  INFORMIX
            ODComm.SQLQuery = "SELECT SP.procid AS id, SP.procname AS name FROM sysprocedures AS SP  WHERE  mode = 'O'  ORDER BY 2;";
            ODComm.SQLTabla = "sysprocedures";
            ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["PGSQLConnectionString"].ToString();

            dsTablas = ODComm.SqlEjecut();
            LstSelectPropiedad.DataSource = dsTablas.Tables[0].DefaultView;
            LstSelectPropiedad.ValueMember = "id";
            LstSelectPropiedad.DisplayMember = "name";

        }

        private void BTN_Actualizar_Click(object sender, EventArgs e)
        {
            CargaPropiedades();
        }

        private void CBProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaSubProyectos();
        }

        private void BTN_Seleccionar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable tbMain = DrPro.Tables[0];
            kan_propiedadesBLL Kan_PropBLL = new kan_propiedadesBLL();

            for (int i = 0; i < LstSelectPropiedad.CheckedIndices.Count; i++)
            {
                DataRowView dr = (DataRowView)LstSelectPropiedad.CheckedItems[i];
                string wPropiedad = (string)dr["name"].ToString();
                int wIdProp = (int)dr["id"];

                DataRow drMain = tbMain.NewRow();
                drMain[kan_propiedadesDAO.IDPROJECTP_CAMPO] = CBSubProject.SelectedValue;
                drMain[kan_propiedadesDAO.IDDATA_CAMPO] = wIdProp;
                drMain[kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO] = wTipoProp.Trim();
                drMain[kan_propiedadesDAO.NOMBRE_CAMPO] = wPropiedad.Trim();
                drMain[kan_propiedadesDAO.PADRE_CAMPO] = wPropiedad.Trim();
                drMain[kan_propiedadesDAO.CREASELECT_CAMPO] = true;
                drMain[kan_propiedadesDAO.CREAINSERT_CAMPO] = true;
                drMain[kan_propiedadesDAO.CREADELETE_CAMPO] = true;
                drMain[kan_propiedadesDAO.CREAUPDATE_CAMPO] = true;
                tbMain.Rows.Add(drMain);
                Kan_PropBLL.Insert(DrPro);
                wIdentity = Kan_PropBLL.SelectIdTity();
                ActualizaColumnas(wIdProp, wPropiedad);
            }
            this.Cursor = Cursors.Default;
            CargarPropiedadesGen(CBSubProject.SelectedValue.ToString());
        }

        private void ActualizaColumnas(int wIdProp, string wtabla)
        {
            DataRow drMain;
            ObjetDataConn ODComm = new ObjetDataConn();

            ///  SQL SERVER
            /// W_QUIERY = "SELECT C.id AS Id,O.name AS NumPropiedad,C.colid AS NumColumn,C.name AS ColumnName,C.isnullable AS EsRequerido,C.colstat as EsIdentity,"
            ///         + "C.xtype AS DataType, C.length AS Length,C.typestat AS TypeStat FROM sys.syscolumns C join sys.objects O on (O.object_id = C.id) "
            ///         + "join sys.sysobjects B on (B.id = C.id ) WHERE O.type in ('P','U','IF','FN','TF','P') AND O.name = '{0}' ";

            /// ODComm.SQLQuery = String.Format(W_QUIERY, wtabla);

            /// ODComm.SQLTabla = "syscolumns";

            ///  INFORMIX

            // W_QUIERY = "SELECT t.tabid as id ,t.tabname as NomPropiedad, c.colno as  NumColumn, c.colname as ColumnName, case(trunc(c.coltype / 256)) 	when 0 then 1 else 0 end as EsRequerido, "
            //          + "case(c.coltype)  when 262 then 1 else 0 end as EsIdentity,  c.coltype as DataType, c.collength as Length, c.colno as  TypeStat  FROM syscolumns as c, systables as t  "
            //          + " WHERE c.tabid = t.tabid  AND t.tabname = '{0}' ";

            // ODComm.SQLQuery = String.Format(W_QUIERY, wtabla);

            // ODComm.SQLTabla = "syscolumns";

            // ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["IFXSQLConnectionString"].ToString();
            // dsTablas = ODComm.SqlEjecut();


            ///  POSTGRES

            W_QUIERY = " SELECT t.reltype as id, t.relname As NomPropiedad, c.attnum as NumColumn, c.attname as ColumnName,  "
                     + " CASE c.attnotnull WHEN 't' THEN 0 ELSE 1 END  EsRequerido, c.attinhcount as EsIdentity,  c.atttypid as DataType, "
                     + " CASE(c.atttypmod >> 16) WHEN 0 THEN (c.atttypmod - ((c.atttypmod >> 16)<<16) - 4) else (c.atttypmod >> 16) END as Length, c.attnum as  TypeStat , "
                     + " CASE (c.attndims) WHEN 0 THEN d.typname ELSE (SELECT x.typname FROM pg_type x WHERE x.oid = d.typelem) || '[]' END as NomDataType "
                     + " FROM pg_class t join pg_namespace n on (n.oid = t.relnamespace) join pg_attribute c on (c.attrelid = t.oid and c.attnum > 0 and c.attisdropped is false) join "
                     + " pg_type d on (d.oid = c.atttypid) WHERE t.relkind = 'r' AND n.nspname = 'public' AND t.relname = '{0}' ORDER BY c.attnum ";

            ODComm.SQLQuery = String.Format(W_QUIERY, wtabla);

            ODComm.SQLTabla = "pg_attribute";

            ODComm.ConnectionDataBase = ConfigurationManager.AppSettings["PGSQLConnectionString"].ToString();
            dsTablas = ODComm.SqlEjecut();



            Kan_PColumDAO = new kan_propcolumnasDAO();
            kan_propcolumnasBLL Kan_PColumBLL = new kan_propcolumnasBLL();
            DataTable tb = Kan_PColumDAO.Tables[kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA];

            foreach (DataRow Dr in dsTablas.Tables[0].Rows)
            {
                string[] wTipos;
                wTipos = new string[4];
                drMain = tb.NewRow();
                drMain[kan_propcolumnasDAO.IDPROPIEDAD_CAMPO] = wIdentity;
                drMain[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO] = Dr["ColumnName"];
                drMain[kan_propcolumnasDAO.CONTROL_CAMPO] = "textbox";
                drMain[kan_propcolumnasDAO.DESCRIPCION_CAMPO] = Dr["ColumnName"];
                drMain[kan_propcolumnasDAO.BLOQUEDADO_CAMPO] = Dr["EsRequerido"];
                drMain[kan_propcolumnasDAO.ORDEN_CAMPO] = Dr["NumColumn"];
                drMain[kan_propcolumnasDAO.OCULTO_CAMPO] = Dr["EsRequerido"];
                drMain[kan_propcolumnasDAO.FORMULARIO_CAMPO] = 0;
                drMain[kan_propcolumnasDAO.LISTADO_CAMPO] = 0;
                //GenerarSqlDbType
                wTipos = TraerDataType(Convert.ToInt32(Dr["DataType"]), ConfigActual.DBPLATAFOR.Trim());
                drMain[kan_propcolumnasDAO.TIPODATO_CAMPO] = wTipos[1];
                drMain[kan_propcolumnasDAO.TIPODATOSQL_CAMPO] = wTipos[2];
                //if ( (Convert.ToInt32(wTipos[3]) == 5) & (ConfigActual.DBPLATAFOR.Trim() == "IFXSQL") )
                //{ drMain[kan_propcolumnasDAO.TAMANO_CAMPO] = ( Convert.ToInt32(Dr["Length"]) / 256 ); }
                //else
                //{ drMain[kan_propcolumnasDAO.TAMANO_CAMPO] = Dr["Length"]; }
                drMain[kan_propcolumnasDAO.TAMANO_CAMPO] = Dr["Length"];
                if (Convert.ToDecimal(drMain[kan_propcolumnasDAO.TAMANO_CAMPO]) == -1)
                { drMain[kan_propcolumnasDAO.TAMANO_CAMPO] = 4; }

                drMain[kan_propcolumnasDAO.REQUERIDO_CAMPO] = Dr["EsRequerido"];
                drMain[kan_propcolumnasDAO.ESIDENTITY_CAMPO] = Dr["EsIdentity"];
                drMain[kan_propcolumnasDAO.ESPRIMARYKEY_CAMPO] = false;
                drMain[kan_propcolumnasDAO.GRUPO_CAMPO] = wTipos[3];
                //drMain[kan_propcolumnasDAO.ESADICIONAL_CAMPO] = false;


                ///  SQL SERVER
                /// W_QUIERY = "SELECT COUNT(k.xtype) AS LlavePK  "
                ///         + "FROM sys.sysobjects k join sys.sysobjects   o on (o.type = 'U' and o.id = k.parent_obj)"
                ///          + "  join sys.schemas u on (u.schema_id = o.uid) join sys.sysindexkeys x on (x.id = o.id )"
                ///          + "  join sys.syscolumns   c on (c.id=x.id and c.colid=x.colid)"
                ///         + " WHERE k.type = 'K' and o.name='{0}' and c.name='{1}'";

                /// ODComm.SQLQuery = String.Format(W_QUIERY, wtabla.ToString(), Dr["ColumnName"].ToString());

                /// ODComm.SQLTabla = "schemas";

                ///  INFORMIX  9.0
                ///W_QUIERY = "SELECT  count(c.colno) AS LlavePK"
                ///        + " FROM  sysconstraints k,sysindexes x, syscolumns c, systables t "
                ///         + "WHERE  k.constrtype in ('P')  AND x.idxname=k.idxname AND t.tabid=k.tabid AND c.tabid=k.tabid "
                ///         + "AND c.colno = ikeyextractcolno(x.indexkeys ,(  c.colno - 1 )) "
                ///        + " AND t.tabname = '{0}' AND c.colname = '{1}' ;";

                ///  INFORMIX 7.3
                // W_QUIERY = "SELECT c.colno AS LlavePK "
                //        + "FROM systables t, sysconstraints p, syscolumns c, sysindexes x "
                //         + " WHERE ( t.tabid = p.tabid ) AND ( x.tabid = t.tabid ) AND ( t.tabid = c.tabid ) AND   "
                //         + " ( c.colno = x.part1 ) AND ( t.tabname = '{0}' ) AND ( c.colname = '{1}' ) AND "
                //        + " ( p.constrtype = 'P' ) AND ( x.idxtype = 'U') ;";


                //            ODComm.SQLQuery = String.Format(W_QUIERY, wtabla.ToString(), Dr["ColumnName"].ToString());

                //            ODComm.SQLTabla = "schemas";

                // POSTGRES

                W_QUIERY = "SELECT a.attname as LlavePK  FROM pg_index x "
                         + "JOIN pg_class     t ON (t.oid = x.indrelid AND t.relkind = 'r') "
                         + "JOIN pg_namespace n ON (n.oid = t.relnamespace)  "
                         + " JOIN pg_class     i ON (i.oid = x.indexrelid) "
                         + " JOIN pg_attribute a ON (a.attrelid = i.oid) "
                         + " WHERE x.indisprimary IS TRUE AND n.nspname = 'public' AND t.relname = '{0}' AND a.attname = '{1}' ";

                ODComm.SQLQuery = String.Format(W_QUIERY, wtabla.ToString(), Dr["ColumnName"].ToString());

                ODComm.SQLTabla = "indisprimary";



                DataSet DS = ODComm.SqlEjecut();

                foreach (DataRow DR in DS.Tables[0].Rows)
                {
                    // if ( DR["LlavePK"].ToString() == "PK" )
                    // drMain[kan_propcolumnasDAO.ESPRIMARYKEY_CAMPO] = DR["LlavePK"] ;
                    drMain[kan_propcolumnasDAO.ESPRIMARYKEY_CAMPO] = 1;
                }


                tb.Rows.Add(drMain);
                Kan_PColumBLL.Insert(Kan_PColumDAO);
            }


        }

        private string[] TraerDataType(int WDataType, string WPlataform)
        {
            String[] wTipoDato;
            wTipoDato = new String[4];

            wTipoDato[0] = "";
            wTipoDato[1] = "";
            wTipoDato[2] = "";
            wTipoDato[3] = "";


            if ((WDataType > 20) & (WDataType < 256) & (WPlataform == "IFXSQL"))
            {
                WDataType = (WDataType & 256);
            }
            
            kan_tiposdatosDAO kan_DTypeDAO = new kan_tiposdatosDAO();
            kan_tiposdatosBLL kan_DTypeBLL = new kan_tiposdatosBLL();

            //kan_DTypeDAO = kan_DTypeBLL.SelectCod(WDataType, WPlataform, WDType);
            kan_DTypeDAO = kan_DTypeBLL.SelectCod(WDataType, WPlataform);

            foreach (DataRow Dr in kan_DTypeDAO.Tables[0].Rows)
            {
                wTipoDato[0] = Dr[kan_tiposdatosDAO.NOMBRESQL_CAMPO].ToString().Trim();
                wTipoDato[1] = Dr[kan_tiposdatosDAO.NOMBRECOD_CAMPO].ToString().Trim();
                wTipoDato[2] = Dr[kan_tiposdatosDAO.NOMBRETIPO_CAMPO].ToString().Trim();
                wTipoDato[3] = WDataType.ToString();

            }

            return wTipoDato;
        }


        private void CBSubProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarPropiedadesGen(CBSubProject.SelectedValue.ToString());
            //DataBindControles();
        }


        private void BTN_ActualizaData_Click(object sender, EventArgs e)
        {
            kan_propiedadesBLL KanPropBLL = new kan_propiedadesBLL();
            DataTable Dt = DrPro.Tables[kan_propiedadesDAO.KAN_PROPIEDADES_TABLA];

            int WRows = DGV_Propiedades.Rows.Count - 1;
            for (int i = 0; i < WRows; i++)
            {

                DataGridViewRow item = DGV_Propiedades.Rows[i];
                DataRow Dr = Dt.NewRow();
                Dr[kan_propiedadesDAO.IDPROPIEDAD_CAMPO] = item.Cells[0].Value;
                Dr[kan_propiedadesDAO.IDPROJECTP_CAMPO] = item.Cells[1].Value;
                Dr[kan_propiedadesDAO.IDDATA_CAMPO] = item.Cells[2].Value;
                Dr[kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO] = item.Cells[3].Value;
                Dr[kan_propiedadesDAO.NOMBRE_CAMPO] = item.Cells[4].Value;
                Dr[kan_propiedadesDAO.PADRE_CAMPO] = item.Cells[5].Value;
                Dr[kan_propiedadesDAO.CREASELECT_CAMPO] = item.Cells[6].Value;
                Dr[kan_propiedadesDAO.CREAINSERT_CAMPO] = item.Cells[7].Value;
                Dr[kan_propiedadesDAO.CREADELETE_CAMPO] = item.Cells[8].Value;
                Dr[kan_propiedadesDAO.CREAUPDATE_CAMPO] = item.Cells[9].Value;
                Dt.Rows.Add(Dr);
                KanPropBLL.Update(DrPro);
            }

            CargarPropiedadesGen(CBSubProject.SelectedValue.ToString());
        }

        private void BTN_DelData_Click(object sender, EventArgs e)
        {
            kan_propiedadesBLL KanPropBLL = new kan_propiedadesBLL();
            DataGridViewSelectedRowCollection Seleccionados = DGV_Propiedades.SelectedRows;

            foreach (DataGridViewRow item in Seleccionados)
            {
                KanPropBLL.Delete(item.Cells[0].Value.ToString());
            }

            CargarPropiedadesGen(CBSubProject.SelectedValue.ToString());
        }
        /*
        private void FrmPropiedades_RowChanged(object sender, DataRowChangeEventArgs e)
        {
         * 
         * kan_propiedadesDAO DrUpdate = new kan_propiedadesDAO();
            DataTable tb = DrUpdate.Tables[kan_propiedadesDAO.KAN_PROPIEDADES_TABLA];
            //string w_act = e.Action.ToString();
            DrUpdate.Tables[0].Rows.Add(DGV_Propiedades.Rows[e.RowIndex]);
            //tb.Rows.Add(e.Row.ItemArray);
            kan_propiedadesBLL KanPropBLL = new kan_propiedadesBLL();
            KanPropBLL.Update(DrUpdate);
         * 
         * 
            kan_propiedadesDAO DrUp = new kan_propiedadesDAO();
            DataTable tb = DrUp.Tables[kan_propiedadesDAO.KAN_PROPIEDADES_TABLA];
            string w_act = e.Action.ToString();
            DrUp.Tables[0].Rows.Add(e.Row.ItemArray);
            //tb.Rows.Add(e.Row.ItemArray);
            kan_propiedadesBLL KanPropBLL = new kan_propiedadesBLL();
            KanPropBLL.Update(DrUp);
        }
        */
        /*
             SELECT  syscolumns.id AS id,
                  syscolumns.colid AS NumColumn, 
                  sysobjects.name AS TableName,
                  syscolumns.name AS ColumnName,
                  syscolumns.isnullable AS EsRequerido,
                  syscolumns.colstat AS EsIdentity,
                  syscolumns.xtype AS DataType, 
                  syscolumns.length AS Length,
                  syscolumns.typestat AS TypeStat
              FROM sysobjects INNER JOIN syscolumns ON sysobjects.id = syscolumns.id 
          WHERE	( sysobjects.name = 'VwReg_Clientes' ) AND 
                  ( sysobjects.xtype = 'V' ) AND 
                  ( sysobjects.name <> N'dtproperties' ) 
          ORDER BY sysobjects.name, syscolumns.colid 
       */
    }
}
