<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="http://www.microsoft.com/placeholderForXSLT" xmlns:uc1="http://www.microsoft.com/placeholderForUC1">
	<!--Controles tiene todos los templates de controles centralizados-->
	<xsl:include href="xslControlesASPX.xsl" />
	<xsl:output method="html" />
	<xsl:template match="/">
	<xsl:text disable-output-escaping="yes">
	<![CDATA[
	<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\" >
	<%@ Register TagPrefix="uc1" TagName="leftMenu" Src="modulos/leftMenu.ascx" %>
	<%@ Page language="c#" AutoEventWireup="false" ]]></xsl:text>CodeBehind="<xsl:value-of select="/formulario/archivo" />.cs" Inherits="<xsl:value-of select="/formulario/namespace" />.WebUI.frm<xsl:value-of select="/formulario/nombre" />"<xsl:text disable-output-escaping="yes"><![CDATA[ %>]]>
	</xsl:text>
		<HTML>
			<HEAD>
				<title>
					Distribuidoras Unidas - <xsl:value-of select="/formulario/titulo" />
				</title>
				<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
				<meta content="C#" name="CODE_LANGUAGE" />
				<meta content="JavaScript" name="vs_defaultClientScript" />
				<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
				<LINK href="css/admin.css" type="text/css" rel="stylesheet" />
				<LINK href="css/stylesmw.css" type="text/css" rel="stylesheet" />
			</HEAD>
			<BODY>
				<form id="editForm" method="post" runat="server">
					<!-- EJEMPLO CONTROL
					<xsl:element namespace="uc1" name="uc1:topbanner">
						<xsl:attribute name="id">Topbanner1</xsl:attribute>
						<xsl:attribute name="runat">server</xsl:attribute>
						<xsl:attribute name="EnableViewState">False</xsl:attribute>
					</xsl:element>
					-->
					<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD vAlign="top" width="168">
							<!--
								<xsl:element namespace="uc1" name="uc1:ormmenu">
									<xsl:attribute name="id">Ormmenu1</xsl:attribute>
									<xsl:attribute name="runat">server</xsl:attribute>
									<xsl:attribute name="EnableViewState">False</xsl:attribute>
								</xsl:element>
								-->
							</TD>
							<TD vAlign="top">
								<TABLE id="Table2" cellSpacing="0" cellPadding="4" width="100%" border="0">
									<TR>
										<TD vAlign="top">
											<table width="590" border="0">
												<tr>
													<td class="objectheader">
														<xsl:value-of select="/formulario/titulo" />
													</td>
												</tr>
											</table>
											<br />

											<xsl:apply-templates select="/formulario/registro/campos" />
											<hr />
											<br />
											<table width="590" border="0">
												<tr>
													<td class="actionname" align="center">
														<xsl:element namespace="asp" name="asp:HyperLink">
															<xsl:attribute name="id">lnkRegresar</xsl:attribute>
															<xsl:attribute name="Text">Listado</xsl:attribute>
															<xsl:attribute name="CssClass">actionname</xsl:attribute>
															<xsl:attribute name="NavigateUrl">
																<xsl:value-of select="/formulario/PaginaListado" />
															</xsl:attribute>
															<xsl:attribute name="runat">server</xsl:attribute>
														</xsl:element>
													</td>
												</tr>
											</table>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TABLE>
				</form>
			</BODY>
		</HTML>
	</xsl:template>
	<xsl:template match="accion">
		<td class="actionname" align="center">
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
	<xsl:template match="campos">
		<table border="0" width="590">
			<xsl:apply-templates />
		</table>
	</xsl:template>
	<xsl:template match="campo">
		<tr>
			<td class="fieldtitle">
				<xsl:if test="self::*[@mostrarformulario='True']">
					<xsl:value-of select="@descripcion" />:
				</xsl:if>
			</td>
			<td align="left">
				<xsl:call-template name="CrearControl">
					<xsl:with-param name="tipo" select="'label'" />
					<xsl:with-param name="nombre" select="@nombrecolumna" />
					<xsl:with-param name="titulo" select="@descripcion" />
					<xsl:with-param name="directorio" select="@directorioarchivos" />
					<xsl:with-param name="requerido" select="@esrequerido" />
					<xsl:with-param name="maxlen" select="@maxlen" />
					<xsl:with-param name="visible" select="@mostrarformulario" />
				</xsl:call-template>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="relacion">
		<xsl:element name="a">
			<xsl:attribute name="href">javascript:actionselected('<xsl:value-of select="@nombre" />')</xsl:attribute>
			<xsl:attribute name="class">actionname</xsl:attribute>
			<xsl:value-of select="@descripcion" />
		</xsl:element>
	</xsl:template>
</xsl:stylesheet>
