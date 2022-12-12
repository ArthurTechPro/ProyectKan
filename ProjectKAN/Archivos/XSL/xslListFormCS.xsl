<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" />
	<xsl:template match="/">
namespace <xsl:value-of select="/formulario/namespace" />.WebUI
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.SessionState;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using <xsl:value-of select="/formulario/namespace" />.DAO;
    using <xsl:value-of select="/formulario/namespace" />.BLL;

	public class frmLista<xsl:value-of select="/formulario/nombre" /> : System.Web.UI.Page
    {
		protected System.Web.UI.WebControls.LinkButton lnkNuevo;
		protected System.Web.UI.WebControls.DataGrid grdTabla;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblStats;		
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;		
        private const string MENSAJE_ELIMINAR = "Esta a punto de eliminar este registro presione eliminar para confirmar o presione cancelar para regresar";
        private enum EdicionTipo {Nuevo, Editar, Eliminar};
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {                
				CargarDatos();
            }
        }
	#region Web Form Designer generated code
		protected override void OnInit(System.EventArgs e)
        {
            /// 
            ///  CODEGEN: This call is required by the ASP.NET Web Form Designer.
            /// 
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            this.grdTabla.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grdTabla_ItemCommand);
            this.lnkNuevo.Click += new System.EventHandler(this.lnkNuevoClick);
            this.Load += new System.EventHandler(this.Page_Load);
        }
	#endregion
	
	private void CargarDatos()
        {
            <xsl:value-of select="/formulario/ClaseBLL" /> dataBLL = new <xsl:value-of select="/formulario/ClaseBLL" />();
            <xsl:value-of select="/formulario/ClaseDAO" /> data = dataBLL.SelectALL();
            grdTabla.DataSource = data.Tables[0].DefaultView;
            grdTabla.DataBind();
            ShowStats(data.Tables[0].Rows.Count);
        }

        private void grdTabla_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
			switch (e.CommandName)
			{
				case "Select":
	                Response.Redirect("<xsl:value-of select="/formulario/PaginaEdicion" />?<xsl:call-template name="ArmarQueryStringLlave" />);
					break;
				case "Delete":
	                Response.Redirect("<xsl:value-of select="/formulario/PaginaEdicion" />?accion=e<xsl:text disable-output-escaping="yes"><![CDATA[&]]></xsl:text><xsl:call-template name="ArmarQueryStringLlave" />);
					break;
			}
        }
        
		private void ShowStats(int totalRecords) 
		{
			if (totalRecords == 0) 
			{
				grdTabla.Visible = false; 
				lblStats.Text = "No se encontró información";
			}
			else 
			{
				grdTabla.Visible = true; 
				int startOffset = (totalRecords &gt; 0) ? (grdTabla.CurrentPageIndex*grdTabla.PageSize+1) : 0;
				int pageEndOffset = (grdTabla.CurrentPageIndex+1)*(grdTabla.PageSize);
				int endOffset = (pageEndOffset &gt; totalRecords) ? totalRecords : pageEndOffset;
				lblStats.Text = String.Format("{0}-{1} de {2}",	startOffset,endOffset,totalRecords);
				if (totalRecords &gt; grdTabla.PageSize)
					grdTabla.PagerStyle.Visible = true;
				else
					grdTabla.PagerStyle.Visible = false;
			}
		} 
        
     private void lnkNuevoClick(object sender, System.EventArgs e)
        {
			Response.Redirect("<xsl:value-of select="/formulario/PaginaEdicion" />?accion=n");
        }		
    }
}
	</xsl:template>
	<xsl:template name="ListarCamposLlave">
		<xsl:for-each select="/formulario/registro/campos/campo[@esprimarykey='True']">
			<xsl:value-of select="@nombrecolumna" /><xsl:if test="position()!=last()">,</xsl:if>
		</xsl:for-each>
	</xsl:template>	
	<xsl:template name="ArmarQueryStringLlave">
		<xsl:for-each select="/formulario/registro/campos/campo[@esprimarykey='True']">
		<xsl:value-of select="@nombrecolumna" />=" + e.Item.Cells[0].Text<xsl:if test="position()!=last()">+ "<xsl:text disable-output-escaping="yes"><![CDATA[&]]></xsl:text></xsl:if></xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
