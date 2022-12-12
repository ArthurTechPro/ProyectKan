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

	public class frm<xsl:value-of select="/formulario/nombre" /> : System.Web.UI.Page
    {
		<xsl:call-template name="DeclararControles" />

		protected System.Web.UI.WebControls.LinkButton lnkNuevo;
		protected System.Web.UI.WebControls.LinkButton lnkGrabar;
		protected System.Web.UI.WebControls.LinkButton lnkEliminar;
		protected System.Web.UI.WebControls.LinkButton lnkEliminarOk;
		protected System.Web.UI.WebControls.HyperLink lnkRegresar;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;		
        private bool indNuevo;
        private const string MENSAJE_ELIMINAR = "Esta a punto de eliminar este registro presione eliminar para confirmar o presione cancelar para regresar";
        private enum EdicionTipo {Nuevo, Editar, Eliminar};
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {                
				CargarDropDown();
                if (Request.QueryString["accion"] == null)
                {
					<xsl:call-template name="LeerQueryString" />
                    CargarControles(<xsl:call-template name="ListarCamposLlave" />);
                    ViewState["indNuevo"] = indNuevo = false;
                    EstadoBotonesEdicion(EdicionTipo.Editar);
				}
                else
                {
					if (Request.QueryString["accion"] == "n") 
						lnkNuevoClick(null, null);
					if (Request.QueryString["accion"] == "e")
					{
						<xsl:call-template name="LeerQueryString" />
						CargarControles(<xsl:call-template name="ListarCamposLlave" />);
						CargarRelaciones(<xsl:call-template name="ListarCamposLlave" />);
						ViewState["indNuevo"] = indNuevo = false;					
						lnkEliminar_Click(null, null);
					}
				}
            }
            else
            {
                indNuevo = (bool) ViewState["indNuevo"];
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
            this.lnkNuevo.Click += new System.EventHandler(this.lnkNuevoClick);
            this.lnkGrabar.Click += new System.EventHandler(this.lnkGrabar_Click);
            this.lnkEliminar.Click += new System.EventHandler(this.lnkEliminar_Click);
            this.lnkEliminarOk.Click += new System.EventHandler(this.lnkEliminarOk_Click);
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
        private void lnkNuevoClick(object sender, System.EventArgs e)
        {
			<xsl:call-template name="LimpiarControles" />
            ViewState["indNuevo"] = true;
            EstadoBotonesEdicion(EdicionTipo.Nuevo);
        }
        private void lnkGrabar_Click(object sender, System.EventArgs e)
        {
			<xsl:value-of select="/formulario/ClaseBLL" /> data = new <xsl:value-of select="/formulario/ClaseBLL" />();
            if (indNuevo)
            {
	            data.Insert(<xsl:call-template name="ListarControlesInsert" />);
                ViewState["indNuevo"] = indNuevo = false;
				Response.Redirect("<xsl:value-of select="/formulario/PaginaListado" />");
			}
            else
            {
                data.Update(<xsl:call-template name="ListarControlesUpdate" />);
				EstadoBotonesEdicion(EdicionTipo.Editar);
            }
        }
        private void lnkEliminar_Click(object sender, System.EventArgs e)
        {
			lblMensaje.Text = MENSAJE_ELIMINAR;
			EstadoBotonesEdicion(EdicionTipo.Eliminar);
        }

        private void lnkEliminarOk_Click(object sender, System.EventArgs e)
        {
			<xsl:value-of select="/formulario/ClaseBLL" /> data = new <xsl:value-of select="/formulario/ClaseBLL" />();
			data.Delete(<xsl:call-template name="ListarControlesDelete" />);
			Response.Redirect("<xsl:value-of select="/formulario/PaginaListado" />");
        }

		private void EstadoBotonesEdicion(EdicionTipo t)
		{
			switch(t)
			{
				case EdicionTipo.Nuevo:
					lnkEliminar.Visible = false;
					lnkNuevo.Visible = false;
					lnkGrabar.Visible = true;
					break;
				case EdicionTipo.Eliminar:
					lnkNuevo.Visible = false;
					lnkEliminar.Visible = false;
					lnkEliminarOk.Visible = true;
					lnkGrabar.Visible = false;
					break;
				case EdicionTipo.Editar:
					lnkNuevo.Visible = true;
					lnkEliminar.Visible = true;
					lnkEliminarOk.Visible = false;
					lnkGrabar.Visible = true;
					break;					
			}
		}
		
		private void CargarDropDown()
		{
			<xsl:call-template name="CargarDropDown" />
		}
		
		private void CargarRelaciones(<xsl:call-template name="DeclaracionCamposLlave" />)
		{
			<xsl:call-template name="CargarRelaciones" />
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
				<xsl:when test="self::*[@control = 'label']">
					<xsl:choose>
						<xsl:when test="@formato">lbl<xsl:value-of select="@nombrecolumna" />.Text = string.Format("{0:<xsl:value-of select="@formato" />}", dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />]);</xsl:when>
						<xsl:otherwise>lbl<xsl:value-of select="@nombrecolumna" />.Text = dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />].ToString();</xsl:otherwise>
					</xsl:choose>
				</xsl:when>
				<xsl:when test="self::*[@control = 'dropdownlist']">
				cbo<xsl:value-of select="@nombrecolumna" />.Items.FindByValue(dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />].ToString()).Selected = true;</xsl:when>
				<xsl:when test="self::*[@control = 'checkbox']">
				chk<xsl:value-of select="@nombrecolumna" />.Checked = Boolean.Parse(dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />].ToString());</xsl:when>
				<xsl:otherwise>
					<xsl:choose>
						<xsl:when test="@formato">txt<xsl:value-of select="@nombrecolumna" />.Text = string.Format("{0:<xsl:value-of select="@formato" />}", dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />]);
					</xsl:when>
						<xsl:otherwise>
				txt<xsl:value-of select="@nombrecolumna" />.Text = dr[<xsl:value-of select="/formulario/ClaseDAO" />.<xsl:value-of select="@constanteCampo" />].ToString();</xsl:otherwise>
					</xsl:choose>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="LimpiarControles">
		<xsl:for-each select="/formulario/registro/campos/campo">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'label']">
		lbl<xsl:value-of select="@nombrecolumna" />.Text = "";</xsl:when>
				<xsl:when test="self::*[@control = 'dropdownlist']">
		cbo<xsl:value-of select="@nombrecolumna" />.SelectedIndex = 0;</xsl:when>
				<xsl:when test="self::*[@control = 'checkbox']">
		chk<xsl:value-of select="@nombrecolumna" />.Checked = false;</xsl:when>
				<xsl:otherwise>
		txt<xsl:value-of select="@nombrecolumna" />.Text = "";</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="DeclararControles">
		<xsl:for-each select="/formulario/registro/campos/campo">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'label']">protected System.Web.UI.WebControls.Label lbl<xsl:value-of select="@nombrecolumna" />;
		</xsl:when>
				<xsl:when test="self::*[@control = 'dropdownlist']">protected System.Web.UI.WebControls.DropDownList cbo<xsl:value-of select="@nombrecolumna" />;
		</xsl:when>
				<xsl:when test="self::*[@control = 'checkbox']">protected System.Web.UI.WebControls.CheckBox chk<xsl:value-of select="@nombrecolumna" />;
		</xsl:when>
				<xsl:when test="self::*[@control = 'checkboxlist']">protected System.Web.UI.WebControls.CheckBoxList lst<xsl:value-of select="@nombrecolumna" />;
		</xsl:when>
				<xsl:otherwise>protected System.Web.UI.WebControls.TextBox txt<xsl:value-of select="@nombrecolumna" />;
		</xsl:otherwise>
			</xsl:choose>
			<xsl:if test="self::*[@esrequerido = 'True']">
				<xsl:if test="self::*[@visible = 'True']">
				protected System.Web.UI.WebControls.RequiredFieldValidator rfv<xsl:value-of select="@nombrecolumna" />;
				</xsl:if>
			</xsl:if>
		</xsl:for-each>
		<xsl:for-each select="/formulario/relaciones/relacion">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'checkboxlist']">protected System.Web.UI.WebControls.CheckBoxList lst<xsl:value-of select="@nombre" />;
		</xsl:when>
				<xsl:otherwise>protected System.Web.UI.WebControls.DataGrid grd<xsl:value-of select="@nombre" />;
		</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="ListarControlesInsert">
		<xsl:for-each select="/formulario/registro/campos/campo[@esidentity='False']">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'label']">lbl<xsl:value-of select="@nombrecolumna" />.Text</xsl:when>
				<xsl:when test="self::*[@control = 'dropdownlist']">cbo<xsl:value-of select="@nombrecolumna" />.SelectedItem.Value</xsl:when>
				<xsl:when test="self::*[@control = 'checkbox']">chk<xsl:value-of select="@nombrecolumna" />.Checked.ToString()</xsl:when>
				<xsl:otherwise>txt<xsl:value-of select="@nombrecolumna" />.Text</xsl:otherwise>
			</xsl:choose>
			<xsl:if test="position()!=last()">,<xsl:text> </xsl:text></xsl:if>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="ListarControlesUpdate">
		<xsl:for-each select="/formulario/registro/campos/campo">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'label']">lbl<xsl:value-of select="@nombrecolumna" />.Text</xsl:when>
				<xsl:when test="self::*[@control = 'dropdownlist']">cbo<xsl:value-of select="@nombrecolumna" />.SelectedItem.Value</xsl:when>
				<xsl:when test="self::*[@control = 'checkbox']">chk<xsl:value-of select="@nombrecolumna" />.Checked.ToString()</xsl:when>
				<xsl:otherwise>txt<xsl:value-of select="@nombrecolumna" />.Text</xsl:otherwise>
			</xsl:choose>
			<xsl:if test="position()!=last()">,<xsl:text> </xsl:text></xsl:if>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="ListarControlesDelete">
		<xsl:for-each select="/formulario/registro/campos/campo[@esprimarykey='True']">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'label']">lbl<xsl:value-of select="@nombrecolumna" />.Text</xsl:when>
				<xsl:when test="self::*[@control = 'dropdownlist']">cbo<xsl:value-of select="@nombrecolumna" />.SelectedItem.Value</xsl:when>
				<xsl:when test="self::*[@control = 'checkbox']">chk<xsl:value-of select="@nombrecolumna" />.Checked</xsl:when>
				<xsl:otherwise>txt<xsl:value-of select="@nombrecolumna" />.Text</xsl:otherwise>
			</xsl:choose>
			<xsl:if test="position()!=last()">, </xsl:if>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="CargarDropDown">
		<xsl:for-each select="/formulario/registro/campos/campo[@nombretablallf]">
			<xsl:value-of select="@nombretablallf" />BLL data<xsl:value-of select="@nombretablallf" /> = new <xsl:value-of select="@nombretablallf" />BLL();
			cbo<xsl:value-of select="@nombrecolumna" />.DataTextField = "<xsl:value-of select="@nombrecolumnadescripcionllf" />";
			cbo<xsl:value-of select="@nombrecolumna" />.DataValueField = "<xsl:value-of select="@nombrecolumnaidllf" />";
			<xsl:if test="@formato">
			cbo<xsl:value-of select="@nombrecolumna" />.DataTextFormatString = "<xsl:value-of select="@formato" />";
			</xsl:if>			
			cbo<xsl:value-of select="@nombrecolumna" />.DataSource = data<xsl:value-of select="@nombretablallf" />.SelectALL();
			cbo<xsl:value-of select="@nombrecolumna" />.DataBind();
			cbo<xsl:value-of select="@nombrecolumna" />.Items.Insert(0, new ListItem("-- Seleccione --", ""));
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="CargarRelaciones">	
		<xsl:for-each select="/formulario/relaciones/relacion">
			<xsl:choose>
				<xsl:when test="self::*[@control = 'checkboxlist']">
				<xsl:value-of select="/formulario/ClaseBLL" /> data<xsl:value-of select="@nombre" /> = new <xsl:value-of select="/formulario/ClaseBLL" />();
				lst<xsl:value-of select="@nombre" />.DataSource = data<xsl:value-of select="@nombretablarelacion" />.<xsl:value-of select="@nombrecomando" />(<xsl:call-template name="ListarCamposLlave" />);
				lst<xsl:value-of select="@nombre" />.DataBind();				
			</xsl:when>
				<xsl:otherwise>//Falta relacion para <xsl:value-of select="@control" />
			</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
