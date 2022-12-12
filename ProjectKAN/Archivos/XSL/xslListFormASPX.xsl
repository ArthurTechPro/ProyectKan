<?xml version="1.0" encoding="UTF-8" ?><!-- DWXMLSource="../XML/ge_ramoBLL.cs.xml" -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
	<xsl:template match="/">
	<xsl:text disable-output-escaping="yes" >
	<![CDATA[
	<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\" >
	<%@ Register TagPrefix="uc1" TagName="leftMenu" Src="modulos/leftMenu.ascx" %>
	<%@ Page language="c#" AutoEventWireup="false" ]]></xsl:text>CodeBehind="<xsl:value-of select="/Formulario/Archivo" />.cs" Inherits="<xsl:value-of select="/Formulario/NameSpace" />.WebUI.frmLista<xsl:value-of select="/Formulario/Nombre" />"<xsl:text disable-output-escaping="yes" ><![CDATA[ %>]]>
    </xsl:text>
		<HTML>
			<HEAD>
				<title>
					<xsl:value-of select="/Formulario/Titulo" />
				</title>
				<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0" />
				<meta name="CODE_LANGUAGE" Content="C#" />
				<meta name="vs_defaultClientScript" content="JavaScript" />
				<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
				<LINK href="css/admin.css" type="text/css" rel="stylesheet" />
				<LINK href="css/stylesmw.css" type="text/css" rel="stylesheet" />
			</HEAD>
			<BODY>
				<form id="gridForm" method="post" runat="server">
					<table width="590" border="0">
						<tr>
							<td class="objectheader">
								<xsl:value-of select="/Formulario/Titulo" />
							</td>
						</tr>
						<tr>
							<td>
								<xsl:element namespace="asp" name="asp:Label">
									<xsl:attribute name="id">lblMensaje</xsl:attribute>
									<xsl:attribute name="CssClass">mensaje</xsl:attribute>
									<xsl:attribute name="Runat">server</xsl:attribute>
								</xsl:element>
							</td>
						</tr>
					</table>
					<table width="590" border="0">
						<tr>
							<xsl:apply-templates select="/Formulario/Acciones" />
							<td class="actionname" align="center"></td>
							<td class="actionname" align="center"></td>
							<td class="actionname" align="center"></td>
						</tr>
					</table>
					<xsl:apply-templates select="/Formulario/Registro"/>
					<xsl:element namespace="asp" name="asp:Label">
						<xsl:attribute name="id">lblStats</xsl:attribute>
						<xsl:attribute name="runat">server</xsl:attribute>
						<xsl:attribute name="CssClass">fieldtitle</xsl:attribute>
					</xsl:element>
				</form>
			</BODY>
		</HTML>
	</xsl:template>
	<xsl:template match="Accion">
		<td class="actionname" align="center" width="94">
			<xsl:element namespace="asp" name="asp:LinkButton">
				<xsl:attribute name="id">lnk<xsl:value-of select="@nombre" /></xsl:attribute>
				<xsl:attribute name="runat">server</xsl:attribute>
				<xsl:attribute name="Text">
					<xsl:value-of select="@descripcion" />
				</xsl:attribute>
				<xsl:attribute name="CssClass">actionname</xsl:attribute>
			</xsl:element>
		</td>
	</xsl:template>
	<xsl:template match="Campos">
		<xsl:element namespace="asp" name="asp:DataGrid">
			<xsl:attribute name="id">grdTabla</xsl:attribute>
			<xsl:attribute name="CssClass">tablagrid</xsl:attribute>
			<xsl:attribute name="ShowHeader">True</xsl:attribute>
			<xsl:attribute name="AutoGenerateColumns">False</xsl:attribute>
			<xsl:attribute name="Runat">server</xsl:attribute>
			<xsl:attribute name="BorderWidth">0px</xsl:attribute>
			<xsl:attribute name="cellSpacing">1</xsl:attribute>
			<xsl:attribute name="cellPadding">1</xsl:attribute>
			<xsl:attribute name="Width">590</xsl:attribute>
			<alternatingItemStyle>
				<xsl:attribute name="CssClass">tablagridalterno</xsl:attribute>
			</alternatingItemStyle>
			<columns>
				<xsl:apply-templates select="Campo"/>
				<xsl:element namespace="asp" name="asp:ButtonColumn">
                    <xsl:attribute name="Text">Editar</xsl:attribute>
                    <xsl:attribute name="CommandName">Select</xsl:attribute>
                </xsl:element>
                <xsl:element namespace="asp" name="asp:ButtonColumn">
                    <xsl:attribute name="Text">Eliminar</xsl:attribute>
                    <xsl:attribute name="CommandName">Delete</xsl:attribute>
                </xsl:element>
 			</columns>
		</xsl:element>
	</xsl:template>
	<xsl:template match="Campo">
		<xsl:element namespace="asp" name="asp:BoundColumn">
			<xsl:attribute name="DataField">
				<xsl:value-of select="@nomcolumna"/>
			</xsl:attribute>
			<xsl:attribute name="HeaderText">
				<xsl:value-of select="@descripcion"/>
			</xsl:attribute>
         </xsl:element>
	</xsl:template>
</xsl:stylesheet>
