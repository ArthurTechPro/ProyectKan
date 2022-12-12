using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using ProjectKAN.DAO;
using ProjectKAN.BLL;


namespace ProjectKAN.WIN
{

    class GenerarXML
    {
        public VwKan_PropiedadesDAO DataSetBase;
        public Configuracion ConfigActual;
        public ConfiguracionMotor ConfigMotor;
        public String TipoArchivo;

        private string W_IDcomando;
        private string TipoParametro;

        public GenerarXML()
        { 
        
        }

        /// <summary>
        /// Transforma el Archivo en formato XML
        /// </summary>
        /// <param name="wl_NomPropiedad">Nombre de la Propiedad ( Tabla ) </param>
        /// <param name="arcPlantilla">Nomnre de Archivo Plantilla XSLT a tranformat</param>
        /// <param name="arcClaseSalida">Nombre de la Clase Salida</param>
        /// <param name="esASPX">Si el archivo es pagina ASPX</param>
        /// <param name="esXML">Si solo genera el archivo XML para Verificacion</param>
        /// <returns>Tetorna el archivo XML formateado.</returns>
        public string Transformar(string wl_NomPropiedad,string arcPlantilla, string arcClaseSalida, bool esASPX, bool esXML)
        {
            /// <summary>
            /// Hace llamada para Generar el Codigo XML.
            /// </summary>
            string strXML = GenerarCodeXML(wl_NomPropiedad,arcClaseSalida);
            
            if ((strXML !="") && (!esXML))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(strXML);
                XslCompiledTransform xslt = new XslCompiledTransform();
                //XslTransform xslt = new XslTransform();
                arcPlantilla = @arcPlantilla.Trim();
                xslt.Load(arcPlantilla);

                /// <summary>
                /// Create an XPathNavigator to use for the transform.
                /// </summary>
                XPathNavigator nav = doc.CreateNavigator();

                StringWriter sw = new StringWriter();
                //xslt.Transform(nav, null, sw, null);
                xslt.Transform(nav, null, sw);
                strXML = sw.ToString();
                if (esASPX)
                {
                    strXML = strXML.Replace("xmlns:asp=\"asp\"", "");
                    strXML = strXML.Replace("xmlns:uc1=\"uc1\"", "");
                    strXML = strXML.Replace("<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-16\">", "");
                    // Esto se reemplazo con CDATA
                    //					strXML = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\" >" + strXML;
                    //					strXML = "<%@ Page language=\"c#\" AutoEventWireup=\"false\" CodeBehind=\"" + arcSalida + ".cs\" Inherits=\"" + strNombreClasefrm + "\" %>" + strXML;
                    strXML = strXML.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
                    strXML = strXML.Replace("xmlns:asp=\"asp\"", "");
                }
                else
                {
                    strXML = strXML.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
                }
            }
            return strXML;
        }

        /// <summary>
        /// Genera el Codigo XML 
        /// </summary>
        /// <param name="wl_NomPropiedad">Nombre de la Propiedad ( Tabla ) </param>
        /// <param name="arcPlantilla">Nomnre de Archivo Plantilla XSLT a tranformat</param>
        /// <returns>Retorna Archiv XML Texto Plano</returns>
        private string GenerarCodeXML(string wl_NomPropiedad, string arcClaseSalida)
        {
            XmlDocument docXml = new XmlDocument();
            XmlElement elemCampo;
            XmlAttribute elemAtrib;
            
            docXml.LoadXml("<Formulario></Formulario>");
            
            XmlNode root = docXml.DocumentElement;

            string strNomClase = arcClaseSalida;
            string strClaseDAO = wl_NomPropiedad.Trim() + ConfigActual.CONSTANTE_DAO.Trim();
            string strClaseDAL = wl_NomPropiedad.Trim() + ConfigActual.CONSTANTE_DAL.Trim();
            string strClaseBLL = wl_NomPropiedad.Trim() + ConfigActual.CONSTANTE_BLL.Trim();
            
            XmlElement elem = docXml.CreateElement("Titulo");
            elem.InnerText = wl_NomPropiedad.Trim();
            root.AppendChild(elem);
            
            elem = docXml.CreateElement("Archivo");
            
            elem.InnerText = arcClaseSalida.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("NombreClase");
            elem.InnerText = wl_NomPropiedad.Trim();
            root.AppendChild(elem);
            
            foreach (DataRow dr in DataSetBase.Tables[0].Rows)
            {
                elem = docXml.CreateElement("NameProject");
                elem.InnerText = dr[VwKan_PropiedadesDAO.NAMESPACEPROJECT_CAMPO].ToString().Trim();
                root.AppendChild(elem);

                elem = docXml.CreateElement("NameSpace");
                elem.InnerText = dr[VwKan_PropiedadesDAO.NAMEPROJECT_CAMPO].ToString().Trim();
                root.AppendChild(elem);
            }

            elem = docXml.CreateElement("NameSpaceProjet");
            elem.InnerText = TipoArchivo.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("ClaseDAO");
            elem.InnerText = strClaseDAO.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("ClaseDAL");
            elem.InnerText = strClaseDAL.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("ClaseBLL");
            elem.InnerText = strClaseBLL.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("DataProveedor");
            elem.InnerText = ConfigActual.DATAPROVEEDOR.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("SqlConn");
            elem.InnerText = ConfigActual.SQLCONN.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("SqlParam");
            elem.InnerText = ConfigActual.SQLPARAM.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("SqlDA");
            elem.InnerText = ConfigActual.SQLDA.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("SqlComm");
            elem.InnerText = ConfigActual.SQLCMM.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("SqlTrans");
            elem.InnerText = ConfigActual.SQLTRANSAC.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("DBPlataform");
            elem.InnerText = ConfigActual.DBPLATAFOR.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("ConfigSetings");
            elem.InnerText = ConfigActual.CONFIGSETING.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("StringConn");
            elem.InnerText = ConfigActual.STRINGCONNECTION.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("ConstanteTabla");
            elem.InnerText = wl_NomPropiedad.ToUpper().Trim() + ConfigActual.CONSTANTE_TABLA.Trim();
            root.AppendChild(elem);

            elem = docXml.CreateElement("PaginaListado");
            elem.InnerText = wl_NomPropiedad.Trim() + "Lista.aspx";
            root.AppendChild(elem);

            elem = docXml.CreateElement("PaginaEdicion");
            elem.InnerText = wl_NomPropiedad.Trim() + "Adm.aspx";
            root.AppendChild(elem);

            /// <summary>
            /// Genera el Codigo XML -  Para las Acciones ( Nuevo,Grabar,Eliminar)
            /// </summary>
            root.AppendChild(CargarAcciones(docXml));

            /// <summary>
            /// Genera el Codigo XML -  Para los Comandos
            /// </summary>
            elem = CargarComandos(DataSetBase, docXml);

            /// <summary>
            /// Genera el Codigo XML -  Para la Relaciones de la Tabla PADRE.
            /// </summary>
            CargarComandosRelPadres(DataSetBase, docXml, elem);

            root.AppendChild(elem);

            /// <summary>
            /// Genera el Codigo XML -  Para la Relaciones de la Tabla HIJOS.
            /// </summary>
            root.AppendChild(CargarRelHijos(DataSetBase, docXml));

            XmlElement elemRegistro = docXml.CreateElement("Registro");

            XmlElement elemCampos = docXml.CreateElement("Campos");

            kan_propcolumnasDAO Kan_ProColDAO = new kan_propcolumnasDAO();
            kan_propcolumnasBLL Kan_ProComBLL = new kan_propcolumnasBLL();

            Kan_ProColDAO = Kan_ProComBLL.SelectPro(DataSetBase.Tables[0].Rows[0][VwKan_PropiedadesDAO.IDPROPIEDAD_CAMPO].ToString());

            //foreach (DataColumn dc in Kan_ProColDAO.Tables[0].Columns)
            foreach (DataRow dr in Kan_ProColDAO.Tables[0].Rows)
            {
                string strNombreColumna = dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim();
                elemCampo = docXml.CreateElement("Campo");

                foreach (DataColumn dcRow in dr.Table.Columns)
                {
                    elemAtrib = docXml.CreateAttribute(dcRow.ColumnName.ToLower().Trim());
                    elemAtrib.InnerText = dr[dcRow.ColumnName].ToString().Trim();
                    elemCampo.Attributes.Append(elemAtrib);
                }

                elemAtrib = docXml.CreateAttribute("ConstanteCampo");
                elemAtrib.InnerText = strNombreColumna.ToUpper().Trim() + ConfigActual.CONSTANTE_CAMPO.ToString().Trim();
                elemCampo.Attributes.Append(elemAtrib);

                elemAtrib = docXml.CreateAttribute("ConstanteParametro");
                elemAtrib.InnerText = strNombreColumna.ToUpper().Trim() + ConfigActual.CONSTANTE_PARAMETRO.ToString().Trim();
                elemCampo.Attributes.Append(elemAtrib);
              

                elemCampos.AppendChild(elemCampo);
            }

            elemRegistro.AppendChild(elemCampos);
            root.AppendChild(elemRegistro);

            //root.AppendChild(CargarParamProp(docXml));
      
            return docXml.InnerXml;
        }


        /// <summary>
        /// Genera las Acciones del Elemento
        /// </summary>
        /// <param name="docXml">Docuemnto XML </param>
        /// <returns>Retorna Elemento XML </returns>
        private XmlElement CargarAcciones(XmlDocument docXml)
        {
            XmlElement elemAccion;
            XmlAttribute elemAtrib;

            XmlElement elemAcciones = docXml.CreateElement("Acciones");

            DataTable table = PropiedadesAcciones();
            foreach (DataRow dr in table.Rows)
            {
                elemAccion = docXml.CreateElement("Accion");
                foreach (DataColumn dcRow in dr.Table.Columns)
                {
                    elemAtrib = docXml.CreateAttribute(dcRow.ColumnName.ToLower());
                    elemAtrib.InnerText = dr[dcRow.ColumnName].ToString();
                    elemAccion.Attributes.Append(elemAtrib);
                }
                elemAcciones.AppendChild(elemAccion);
            }

            return elemAcciones;
        }


        /// <summary>
        /// Genera las Acciones de la Propiedad.
        /// </summary>
        /// <returns>Retorna la DataTable con las Acciones ( Nuevo, Guardar, Eliminar ) </returns>
        private DataTable PropiedadesAcciones()
        {
            DataTable tableAcciones;

            DataColumnCollection columns;
            tableAcciones = new DataTable("Datos");
            columns = tableAcciones.Columns;
            columns.Add("nombre", typeof(System.String));
            columns.Add("descripcion", typeof(System.String));
            tableAcciones.Rows.Add(new object[] { "Nuevo", "Nuevo" });
            tableAcciones.Rows.Add(new object[] { "Grabar", "Grabar" });
            tableAcciones.Rows.Add(new object[] { "Eliminar", "Eliminar" });
            tableAcciones.Rows.Add(new object[] { "EliminarOk", "Eliminar" });

            return tableAcciones;
        }

        /// <summary>
        /// Genera loa Comandos corespondientes a las Propiedades 
        /// </summary>
        /// <param name="VwKanPropDAO">Propiedades ( Tabla ) </param>
        /// <param name="docXml">Documento XML</param>
        /// <returns>Retorna Elemnto XML</returns>
        private XmlElement CargarComandos(VwKan_PropiedadesDAO VwKanPropDAO,XmlDocument docXml)
        {
            XmlElement elemComando;
            XmlElement elem;

            XmlElement elemComandos = docXml.CreateElement("Comandos");

            /// <summary>
            /// Genera loa Comandos MODELO 
            /// </summary>
            kan_comandosmDAO Kan_ComandoM_DAO = new kan_comandosmDAO();
            kan_comandosmBLL Kan_ComandoM_BLL = new kan_comandosmBLL();

            Kan_ComandoM_DAO = Kan_ComandoM_BLL.SelectALL();
            
            foreach (DataRow drComM in Kan_ComandoM_DAO.Tables[0].Rows)
            {
                if (GenerarComando(VwKanPropDAO, drComM))
                {
                    ComandosSQL.ComandoTipo ComSQLTipo = (ComandosSQL.ComandoTipo)Int32.Parse(drComM[kan_comandosmDAO.TIPOCOMANDO_CAMPO].ToString());
                    ComandosSQL.Comando ComSQLCom = (ComandosSQL.Comando)Int32.Parse(drComM[kan_comandosDAO.IDCOMAN_CAMPO].ToString());
                    ComandosSQL.TipoParametros TipParam = (ComandosSQL.TipoParametros)Int32.Parse(drComM[kan_comandosDAO.TIPOPARAMETRO_CAMPO].ToString());
                    elemComando = docXml.CreateElement("Comando");

                    ComandosSQL ComSQL = new ComandosSQL();

                    ComSQL.ConfigActual = ConfigActual;
                    ComSQL.Propiedad = VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.NOMBRE_CAMPO].ToString();
                    ComSQL.idPropiedad = VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.IDPROPIEDAD_CAMPO].ToString();
                    //ComSQL.DataSetBase = Kan_ComandoM_DAO;
                    ComSQL.Nombre = drComM[kan_comandosmDAO.NOMBRECOM_CAMPO].ToString();
                    ComSQL.SQL = drComM[kan_comandosmDAO.SQL_CAMPO].ToString();
                    ComSQL.TipoComando = drComM[kan_comandosmDAO.TIPOCOMANDO_CAMPO].ToString();
                    ComSQL.TipoSql = "";

                    ComSQL.Preparar();

                    elem = docXml.CreateElement("Nombre");
                    elem.InnerText = ComSQL.Nombre.ToString().Trim();
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("TipoComando");
                    elem.InnerText = ComSQLTipo.ToString().Trim();
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("ComandoDataAdapter");
                    elem.InnerText = ComSQLCom.ToString().Trim() +"Command";
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("TipoParametros");
                    elem.InnerText = TipParam.ToString().Trim();
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("Sql");
                    elem.InnerText = ComSQL.SQL.ToString().Trim();
                    elemComando.AppendChild(elem);

                    elemComandos.AppendChild(elemComando);

                }
            
            }

            /// <summary>
            /// Genera loa Comandos PERSONALIZADOS 
            /// </summary>
            kan_comandosDAO Kan_ComDAO = new kan_comandosDAO();
            kan_comandosBLL Kan_ComBLL = new kan_comandosBLL();

            foreach( DataRow DrProp in DataSetBase.Tables[0].Rows )
            {
                Kan_ComDAO = Kan_ComBLL.SelectProp(DrProp[VwKan_PropiedadesDAO.IDPROPIEDAD_CAMPO].ToString());

                foreach( DataRow DrCom in Kan_ComDAO.Tables[0].Rows )
                {
                    W_IDcomando = DrCom[kan_comandosDAO.IDCOMANDO_CAMPO].ToString();

                    if (GenerarComando(VwKanPropDAO, DrCom))
                    {
                        ComandosSQL.ComandoTipo ComSQLTipo = (ComandosSQL.ComandoTipo)Int32.Parse(DrCom[kan_comandosDAO.TIPOCOMANDO_CAMPO].ToString());
                        ComandosSQL.Comando ComSQLCom = (ComandosSQL.Comando)Int32.Parse(DrCom[kan_comandosDAO.IDCOMAN_CAMPO].ToString());
                        ComandosSQL.TipoParametros TipParam = (ComandosSQL.TipoParametros)Int32.Parse(DrCom[kan_comandosDAO.TIPOPARAMETRO_CAMPO].ToString());
                        elemComando = docXml.CreateElement("Comando");

                        ComandosSQL ComSQL = new ComandosSQL();
                        
                        ComSQL.ConfigActual = ConfigActual;
                        ComSQL.Propiedad = VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.NOMBRE_CAMPO].ToString();
                        ComSQL.idPropiedad = VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.IDPROPIEDAD_CAMPO].ToString();
                        //ComSQL.DataSetBase = Kan_ComDAO;
                        ComSQL.Parametros = DrCom[kan_comandosDAO.PARAMETROS_CAMPO].ToString();
                        ComSQL.Nombre = DrCom[kan_comandosDAO.NOMBRECOM_CAMPO].ToString();
                        ComSQL.SQL = DrCom[kan_comandosDAO.SQL_CAMPO].ToString();
                        ComSQL.TipoComando = DrCom[kan_comandosDAO.TIPOCOMANDO_CAMPO].ToString();

                        ComSQL.TipoSql = "";

                        ComSQL.Preparar();
                        elemComando = docXml.CreateElement("Comando");

                        elem = docXml.CreateElement("Nombre");
                        elem.InnerText = DrCom[kan_comandosDAO.NOMBRECOM_CAMPO].ToString().Trim();
                        elemComando.AppendChild(elem);

                        elem = docXml.CreateElement("TipoComando");
                        elem.InnerText = ComSQLTipo.ToString().Trim();
                        elemComando.AppendChild(elem);

                        elem = docXml.CreateElement("ComandoDataAdapter");
                        elem.InnerText = ComSQLCom.ToString().Trim() + "Command";
                        elemComando.AppendChild(elem);

                        elem = docXml.CreateElement("TipoParametros");
                        elem.InnerText = TipParam.ToString().Trim();
                        elemComando.AppendChild(elem);

                        elem = docXml.CreateElement("Sql");
                        elem.InnerText = ComSQL.SQL.ToString().Trim();
                        elemComando.AppendChild(elem);

                        if (ComSQL.TipoSql != "")
                        {
                            elem = docXml.CreateElement("TipoSql");
                            elem.InnerText = ComSQL.TipoSql;
                            elemComando.AppendChild(elem);
                        }

                        XmlElement elemParametros = docXml.CreateElement("Parametros");

                        foreach (DataRow drParm in ComSQL.Kan_ParamDAO.Tables[0].Rows)
                        {
                           
                            XmlElement elemParametro = docXml.CreateElement("Parametro");

                            elem = docXml.CreateElement("NombreParam");
                            elem.InnerText = drParm[kan_parametrosDAO.NOMPARAMETRO_CAMPO].ToString();
                            elemParametro.AppendChild(elem);

                            elem = docXml.CreateElement("Tipodato");
                            elem.InnerText = drParm[kan_parametrosDAO.TIPODATO_CAMPO].ToString();
                            elemParametro.AppendChild(elem);

                            elem = docXml.CreateElement("Tamano");
                            elem.InnerText = drParm[kan_parametrosDAO.TAMANO_CAMPO].ToString();
                            elemParametro.AppendChild(elem);

                            elem = docXml.CreateElement("TipoDatoSql");

                            elem.InnerText = drParm[kan_parametrosDAO.TIPODATOSQL_CAMPO].ToString().Trim();
                            elemParametro.AppendChild(elem);

                            elem = docXml.CreateElement("ConstanteParam");
                            elem.InnerText = drParm[DAO.kan_parametrosDAO.NOMPARAMETRO_CAMPO].ToString().ToUpper().Trim() + ConfigActual.CONSTANTE_PARAMETRO.ToString().Trim();
                            elemParametro.AppendChild(elem);

                            elem = docXml.CreateElement("Direccion");
                            elem.InnerText = DireccionParametro(Int16.Parse(drParm[kan_parametrosDAO.DIRECCION_CAMPO].ToString()));
                            elemParametro.AppendChild(elem);

                            elemParametros.AppendChild(elemParametro);
                        }
                        elemComando.AppendChild(elemParametros);

                        elemComandos.AppendChild(elemComando);
                    }
                }
            }
            
            return elemComandos;
        }

        /// <summary>
        /// Genera los Comandos para la relacion de Padre Hijo
        /// </summary>
        /// <param name="VwKanPropDAO">Propiedades ( Tabla ) </param>
        /// <param name="docXml">Documento XML</param>
        /// <param name="elemComandos">Elementos XML</param>
        private void CargarComandosRelPadres(VwKan_PropiedadesDAO VwKanPropDAO, XmlDocument docXml, XmlElement elemComandos)
        {
            try
            {
                XmlElement elemComando;
                XmlElement elem;

                string tablaPadre = VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.PADRE_CAMPO].ToString();

                kan_relacionesDAO Kan_RelDAO = new kan_relacionesDAO();
                kan_relacionesBLL Kan_RelBLL = new kan_relacionesBLL();

                Kan_RelDAO = Kan_RelBLL.SelectRelPadre(VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.IDPROPIEDAD_CAMPO].ToString());

                foreach (DataRow drRPad in Kan_RelDAO.Tables[0].Rows)
                {
                    //Comandos
                    elemComando = docXml.CreateElement("Comando");

                    elem = docXml.CreateElement("Nombre");
                    elem.InnerText = "Load" + drRPad[kan_relacionesDAO.NOMRELACION_CAMPO].ToString() + "Data";
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("TipoParametros");
                    elem.InnerText = TipoParametro.ToString().Trim();
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("ComandoDataAdapter");
                    elem.InnerText = "SelectCommand";
                    elemComando.AppendChild(elem);

                    elem = docXml.CreateElement("TipoComando");
                    elem.InnerText = ComandosSQL.ComandoTipo.Fill.ToString();
                    elemComando.AppendChild(elem);

                    string sql = "SELECT * FROM " + DataSetBase.Tables[0].TableName + " WHERE " + drRPad[kan_relacionesDAO.NOMHIJO_CAMPO].ToString() + " = @" + drRPad[kan_relacionesDAO.NOMHIJO_CAMPO].ToString();

                    elem = docXml.CreateElement("Sql");
                    elem.InnerText = sql;
                    elemComando.AppendChild(elem);

                    XmlElement elemParametros = docXml.CreateElement("Parametros");

                    XmlElement elemParametro = docXml.CreateElement("Parametro");

                    elem = docXml.CreateElement("Nombre");
                    elem.InnerText = drRPad[kan_relacionesDAO.NOMHIJO_CAMPO].ToString().Trim();
                    elemParametro.AppendChild(elem);

                    elem = docXml.CreateElement("TipoDato");
                    elem.InnerText = "System.Int32";
                    elemParametro.AppendChild(elem);

                    elem = docXml.CreateElement("TipoDatoSql");
                    elem.InnerText = ComandosSQL.GenerarSqlDbType("System.Int32");
                    elemParametro.AppendChild(elem);

                    elem = docXml.CreateElement("ConstanteParametro");
                    elem.InnerText = drRPad[kan_relacionesDAO.RELPADRE_CAMPO].ToString().ToUpper().Trim() + ConfigActual.CONSTANTE_PARAMETRO.ToString().Trim();
                    elemParametro.AppendChild(elem);

                    elem = docXml.CreateElement("Direccion");
                    elem.InnerText = "ParameterDirection.Input";
                    elemParametro.AppendChild(elem);

                    elemParametros.AppendChild(elemParametro);
                    elemComando.AppendChild(elemParametros);

                    elemComandos.AppendChild(elemComando);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + "\n" + e.Source);
            }
        }

        /// <summary>
        /// Genera relaciones Hijo Padre
        /// </summary>
        /// <param name="VwKanPropDAO">Propiedades ( Tabla ) </param>
        /// <param name="docXml">Docuemtnos XML</param>
        /// <returns>Elemento XML</returns>
        private XmlElement CargarRelHijos(VwKan_PropiedadesDAO VwKanPropDAO, XmlDocument docXml)
        {

            try
            {
                XmlElement elemRelacion;
                XmlAttribute elemAtrib;

                XmlElement elemRelaciones = docXml.CreateElement("RelacionesHijos");

                kan_relacionesDAO Kan_RelDAO = new kan_relacionesDAO();
                kan_relacionesBLL Kan_RelBLL = new kan_relacionesBLL();

                Kan_RelDAO = Kan_RelBLL.SelectRelHijo(VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.IDPROPIEDAD_CAMPO].ToString());

                foreach (DataRow dr in Kan_RelDAO.Tables[0].Rows)
                {
                    elemRelacion = docXml.CreateElement("Relacion");
                    elemAtrib = docXml.CreateAttribute("Nombre");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.NOMRELACION_CAMPO].ToString().Trim();
                    elemRelacion.Attributes.Append(elemAtrib);
                    elemAtrib = docXml.CreateAttribute("NombreTablaRelacion");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.NOMRELACION_CAMPO].ToString().Trim();
                    elemRelacion.Attributes.Append(elemAtrib);
                    elemAtrib = docXml.CreateAttribute("ConstanteTablaRelacion");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.NOMRELACION_CAMPO].ToString().ToUpper().Trim() + ConfigActual.CONSTANTE_TABLA;
                    elemRelacion.Attributes.Append(elemAtrib);
                    elemAtrib = docXml.CreateAttribute("ColumnaPadre");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.RELPADRE_CAMPO].ToString().Trim();
                    elemRelacion.Attributes.Append(elemAtrib);
                    elemAtrib = docXml.CreateAttribute("ConstanteColumnaPadre");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.RELPADRE_CAMPO].ToString().ToUpper().Trim() + ConfigActual.CONSTANTE_CAMPO;
                    elemRelacion.Attributes.Append(elemAtrib);

                    elemAtrib = docXml.CreateAttribute("ColumnaHijo");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.RELHIJO_CAMPO].ToString().Trim();
                    elemRelacion.Attributes.Append(elemAtrib);
                    elemRelaciones.AppendChild(elemRelacion);

                    elemAtrib = docXml.CreateAttribute("ConstanteColumnaHijo");
                    elemAtrib.InnerText = dr[kan_relacionesDAO.RELHIJO_CAMPO].ToString().ToUpper().Trim() + ConfigActual.CONSTANTE_CAMPO;
                    elemRelacion.Attributes.Append(elemAtrib);
                    elemRelaciones.AppendChild(elemRelacion);
                }
                return elemRelaciones;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + "\n" + e.Source);
                return null;
            }
        }

        /// <summary>
        /// Genera Loa parametros de la Propiedad 
        /// </summary>
        /// <param name="docXml">Docuemto XML</param>
        /// <returns>Retorna Elemento XML</returns>
        private XmlElement CargarParamProp(XmlDocument docXml)
        {
            try
            {
                XmlElement elemParametro;
                XmlAttribute elemAtrib;

                XmlElement elemParametros = docXml.CreateElement("Parametros");

                kan_parametrosDAO Kan_ParamDAO = new kan_parametrosDAO();
                kan_parametrosBLL Kan_ParamBLL = new kan_parametrosBLL();

                Kan_ParamDAO = Kan_ParamBLL.SelectParamComando(W_IDcomando);

                foreach (DataRow dr in Kan_ParamDAO.Tables[0].Rows)
                {
                    elemParametro = docXml.CreateElement("Parametro");

                    elemAtrib = docXml.CreateAttribute("ConsParametre");
                    elemAtrib.InnerText = dr[kan_parametrosDAO.NOMPARAMETRO_CAMPO].ToString().ToUpper().Trim() + ConfigActual.CONSTANTE_PARAMETRO.ToString().Trim();
                    elemParametro.Attributes.Append(elemAtrib);

                    elemAtrib = docXml.CreateAttribute("Nombre");
                    elemAtrib.InnerText = dr[kan_parametrosDAO.NOMPARAMETRO_CAMPO].ToString().Trim();
                    elemParametro.Attributes.Append(elemAtrib);

                    elemAtrib = docXml.CreateAttribute("Tamamo");
                    elemAtrib.InnerText = dr[kan_parametrosDAO.TAMANO_CAMPO].ToString();
                    elemParametro.Attributes.Append(elemAtrib);

                    elemParametros.AppendChild(elemParametro);
                }
                return elemParametros;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Genera los Comandos Modelo para la Propiedad 
        /// </summary>
        /// <param name="VwKanPropDAO">Propiedades ( Tabla ) </param>
        /// <param name="dr">DataRow  Comandos</param>
        /// <returns></returns>
        private bool GenerarComando(VwKan_PropiedadesDAO VwKanPropDAO, DataRow dr)
        {
            //switch (dr[kan_comandosmDAO.NOMBRECOM_CAMPO].ToString().ToLower())
            switch (dr[1].ToString().Trim())
            {
                case "SelectALL":
                case "SelectID":
                    return (bool)Convert.ToBoolean(VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.CREASELECT_CAMPO]);
                case "Delete":
                    return (bool)Convert.ToBoolean(VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.CREADELETE_CAMPO]);
                case "Update":
                    return (bool)Convert.ToBoolean(VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.CREAUPDATE_CAMPO]);
                case "Insert":
                    return (bool)Convert.ToBoolean(VwKanPropDAO.Tables[0].Rows[0][VwKan_PropiedadesDAO.CREAINSERT_CAMPO]);
                default:
                    return true;
            }
        }

        /// <summary>
        /// Direccion del Parametro. 
        /// </summary>
        /// <param name="c">Tipo Direccion </param>
        /// <returns>Retornna Direccion (Input,InputOutput,Output,ReturnValue)</returns>
        private string DireccionParametro(int c)
        {
            switch (c)
            {
                case 1:
                    return "ParameterDirection.Input";
                case 2:
                    return "ParameterDirection.InputOutput";
                case 3:
                    return "ParameterDirection.Output";
                case 4:
                    return "ParameterDirection.ReturnValue";
                default:
                    return "ParameterDirection.Input";
            }
        }
    
    }
}
