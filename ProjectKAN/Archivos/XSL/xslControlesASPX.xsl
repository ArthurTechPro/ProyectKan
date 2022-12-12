<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template name="CrearControl">
		<xsl:param name="tipo" />
		<xsl:param name="nombre" />
		<xsl:param name="titulo" />
		<xsl:param name="directorio" />
		<xsl:param name="requerido" />
		<xsl:param name="maxlen" />
		<xsl:param name="visible" />
		<xsl:choose>
			<xsl:when test="self::*[$tipo = 'label']">
				<xsl:element namespace="asp" name="asp:Label">
					<xsl:attribute name="id">lbl<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
				</xsl:element>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'textbox']">
				<xsl:element namespace="asp" name="asp:TextBox">
					<xsl:attribute name="id">txt<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
					<xsl:if test="$maxlen > 0">
						<xsl:attribute name="MaxLength">
							<xsl:value-of select="$maxlen" />
						</xsl:attribute>
					</xsl:if>
					<xsl:attribute name="visible"><xsl:value-of select="$visible" /></xsl:attribute>
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">txt<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>*</xsl:element>
				</xsl:if>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'dropdownlist']">
				<xsl:element namespace="asp" name="asp:DropDownList">
					<xsl:attribute name="id">cbo<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">cbo<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>
							*
						</xsl:element>
				</xsl:if>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'checkboxlist']">
				<xsl:element namespace="asp" name="asp:CheckBoxList">
					<xsl:attribute name="id">lst<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
				</xsl:element>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'textarea']">
				<xsl:element namespace="asp" name="asp:TextBox">
					<xsl:attribute name="id">txt<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="TextMode">MultiLine</xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">txt<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>
							*
						</xsl:element>
				</xsl:if>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'textedit']">
				<xsl:element namespace="asp" name="asp:TextBox">
					<xsl:attribute name="id">txt<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
					<xsl:attribute name="visible"><xsl:value-of select="$visible" /></xsl:attribute>
				</xsl:element>
				<xsl:element name="input">
					<xsl:attribute name="type">button</xsl:attribute>
					<xsl:attribute name="class">fieldcontent</xsl:attribute>
					<xsl:attribute name="name">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="value">Editor...</xsl:attribute>
				</xsl:element>
				<xsl:element name="script">
				<xsl:attribute name="for">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
				<xsl:attribute name="event">onclick</xsl:attribute>
				<xsl:attribute name="language">javascript</xsl:attribute>
					Editor('txt<xsl:value-of select="$nombre" />', '../imagenes');
					__doPostBack('lnkGrabar', '');	
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">txt<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>*
						</xsl:element>
				</xsl:if>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'textfecha']">
				<xsl:element namespace="asp" name="asp:TextBox">
					<xsl:attribute name="id">txt<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
					<xsl:attribute name="visible"><xsl:value-of select="$visible" /></xsl:attribute>
				</xsl:element>
				<xsl:element name="input">
					<xsl:attribute name="type">button</xsl:attribute>
					<xsl:attribute name="class">fieldcontent</xsl:attribute>
					<xsl:attribute name="name">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="value">Calendario...</xsl:attribute>
				</xsl:element>
				<xsl:element name="script">
				<xsl:attribute name="for">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
				<xsl:attribute name="event">onclick</xsl:attribute>
				<xsl:attribute name="language">javascript</xsl:attribute>
					SeleccionarFecha('txt<xsl:value-of select="$nombre" />');
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">txt<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>*
						</xsl:element>
				</xsl:if>
			</xsl:when>			
			<xsl:when test="self::*[$tipo = 'imagen']">
				<xsl:element namespace="asp" name="asp:TextBox">
					<xsl:attribute name="id">txt<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
				</xsl:element>
				<xsl:element name="input">
					<xsl:attribute name="type">button</xsl:attribute>
					<xsl:attribute name="class">fieldcontent</xsl:attribute>
					<xsl:attribute name="name">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="value">Seleccionar...</xsl:attribute>
				</xsl:element>
				<xsl:element name="script">
				<xsl:attribute name="for">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
				<xsl:attribute name="event">onclick</xsl:attribute>
				<xsl:attribute name="language">javascript</xsl:attribute>
					Imagen('txt<xsl:value-of select="$nombre" />', '<xsl:value-of select="$directorio" />');
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">txt<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>
							*
						</xsl:element>
				</xsl:if>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'button']">
				<xsl:element namespace="asp" name="asp:Button">
					<xsl:attribute name="id">cmd<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
					<xsl:attribute name="Text">
						<xsl:value-of select="@titulo" />
					</xsl:attribute>
				</xsl:element>
			</xsl:when>
			<xsl:when test="self::*[$tipo = 'checkbox']">
				<xsl:element namespace="asp" name="asp:CheckBox">
					<xsl:attribute name="id">chk<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
					<xsl:attribute name="Text">
						<xsl:value-of select="@titulo" />
					</xsl:attribute>
				</xsl:element>
			</xsl:when>
			<xsl:otherwise>
				<xsl:element namespace="asp" name="asp:TextBox">
					<xsl:attribute name="id">txt<xsl:value-of select="$nombre" /></xsl:attribute>
					<xsl:attribute name="runat">server</xsl:attribute>
					<xsl:attribute name="visible"><xsl:value-of select="$visible" /></xsl:attribute>
				</xsl:element>
				<xsl:if test="self::*[$requerido = 'True']">
					<xsl:element namespace="asp" name="asp:RequiredFieldValidator">
							<xsl:attribute name="id">rfv<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="ErrorMessage">Se requiere de <xsl:value-of select="$titulo" /></xsl:attribute>
							<xsl:attribute name="ControlToValidate">txt<xsl:value-of select="$nombre" /></xsl:attribute>
							<xsl:attribute name="runat">server</xsl:attribute>
							*
						</xsl:element>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>
