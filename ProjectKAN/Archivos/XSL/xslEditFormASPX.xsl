<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<!--Controles tiene todos los templates de controles centralizados-->
	<xsl:include href="xslControlesASPX.xsl" />
	<xsl:output method="html" />
	<xsl:template match="/">
		<xsl:text disable-output-escaping="yes">
	<![CDATA[
	<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\" >
	<%@ Page language="c#" AutoEventWireup="false" validateRequest="false" ]]></xsl:text>CodeBehind="<xsl:value-of select="/formulario/archivo" />.cs" Inherits="<xsl:value-of select="/formulario/namespace" />.WebUI.frm<xsl:value-of select="/formulario/nombre" />"<xsl:text disable-output-escaping="yes"><![CDATA[ %>]]>
	</xsl:text>
		<HTML>
			<HEAD>
				<title>
					Wilton New Comers Club
				</title>
				<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
				<meta content="C#" name="CODE_LANGUAGE" />
				<meta content="JavaScript" name="vs_defaultClientScript" />
				<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
				<LINK href="css/styles.css" type="text/css" rel="stylesheet" />
			</HEAD>
			<BODY>
				<form id="editForm" method="post" runat="server">
					<div align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="590" border="0">
							<TR>
								<TD vAlign="top">
									<TABLE id="Table2" cellSpacing="0" cellPadding="4" width="590" border="0">
										<TR>
											<TD vAlign="top">
												<table width="590" border="0">
													<tr>
														<td class="objectheader">
															<xsl:value-of select="/formulario/titulo" />
														</td>
													</tr>
												</table>
												<table width="590" border="0">
													<tr>
														<td>
															<xsl:element namespace="asp" name="asp:Label">
																<xsl:attribute name="id">lblMensaje</xsl:attribute>
																<xsl:attribute name="runat">server</xsl:attribute>
																<xsl:attribute name="CssClass">mensaje</xsl:attribute>
															</xsl:element>
														</td>
													</tr>
													<tr>
														<td>
															<xsl:element namespace="asp" name="asp:ValidationSummary">
																<xsl:attribute name="id">ValidationSummary1</xsl:attribute>
																<xsl:attribute name="runat">server</xsl:attribute>
															</xsl:element>
														</td>
													</tr>
												</table>
												<hr />
												<!--
											<table width="590">
												<tr>
													<td class="groupheader">Datos Básicos</td>
												</tr>
											</table>
											-->
												<xsl:apply-templates select="/formulario/registro/campos" />
												<hr />
												<table width="590" border="0">
													<xsl:apply-templates select="/formulario/relaciones" />
												</table>
												<br />
												<table width="590" border="0">
													<tr>
														<xsl:apply-templates select="/formulario/acciones" />
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
					</div>
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
					<xsl:with-param name="tipo" select="@control" />
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
		<tr><td>
			<xsl:call-template name="CrearControl">
				<xsl:with-param name="tipo" select="@control" />
				<xsl:with-param name="nombre" select="@nombre" />
				<xsl:with-param name="titulo" select="@nombre" />
			</xsl:call-template>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
