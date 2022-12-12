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

	public class frm<xsl:value-of select="/formulario/nombre" /> : PageBase
    {
		<xsl:call-template name="DeclararControles" />

		protected System.Web.UI.WebControls.HyperLink lnkRegresar;
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {                
				<xsl:call-template name="LeerQueryString" />
                CargarControles(<xsl:call-template name="ListarCamposLlave" />);
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
            this.Load += new System.EventHandler(this.Page_Load);
        }
	#endregion
	
	private void CargarControles(<xsl:call-template name="DeclaracionCamposLlave" />)
        {
            <xsl:value-of select="/formulario/ClaseBLL" /> dataBLL = new <xsl:value-of select="/formulario/ClaseBLL" />();
            <xsl:value-of select="/formulario/ClaseDAO" /> dataDAO = dataBLL.SelectID(<xsl:call-template name="ListarCamposLlave" />);
            DataRow dr = dataDAO.Tables[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="/formulario/ConstanteTabla" />].Rows[0];
            <xsl:call-template name="CargarControles" />
        }
    }
}
	</xsl:template>
	<xsl:template name="LeerQueryString">
		<xsl:for-each select="/formulario/registro/campos/campo[@esprimarykey='True']">
			string<xsl:text> </xsl:text><xsl:value-of select="@nombrecolumna" /> = Request.QueryString["<xsl:value-of select="@nombrecolumna" />"].ToString();
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="ListarCamposLlave">
		<xsl:for-each select="/formulario/registro/campos/campo[@esprimarykey='True']">
			<xsl:value-of select="@nombrecolumna" />
			<xsl:if test="position()!=last()">,</xsl:if>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="DeclaracionCamposLlave">
		<xsl:for-each select="/formulario/registro/campos/campo[@esprimarykey='True']">string<xsl:text> </xsl:text><xsl:value-of select="@nombrecolumna" /><xsl:if test="position()!=last()">,</xsl:if>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="CargarControles">
		<xsl:for-each select="/formulario/registro/campos/campo">
			<xsl:choose>
				<xsl:when test="@formato">lbl<xsl:value-of select="@nombrecolumna" />.Text = string.Format("{0:<xsl:value-of select="@formato" />}", dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />]);</xsl:when>
				<xsl:otherwise>lbl<xsl:value-of select="@nombrecolumna" />.Text = dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />].ToString();
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="DeclararControles">
		<xsl:for-each select="/formulario/registro/campos/campo">
			protected System.Web.UI.WebControls.Label lbl<xsl:value-of select="@nombrecolumna" />;</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
