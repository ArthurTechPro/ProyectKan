<?xml version="1.0" encoding="UTF-8" ?>
<!-- DWXMLSource="adm_configDAO.cs.xml" -->
<!-- 

-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" />
<xsl:template match="/">

/// <summary>
/// DATA OBJET Class for: <xsl:value-of select="/Formulario/Titulo" />
/// CODEGEN  Proyecto  KAN ( semilla )
/// Derechos Reservados ( CARLOS ARTURO HERNANDEZ )
/// </summary>

using System;
using System.Data;
using System.Runtime.Serialization;

namespace <xsl:value-of select="Formulario/NameProject" />.<xsl:value-of select="Formulario/NameSpace" />.<xsl:value-of select="Formulario/NameSpaceProjet" />
{

	[Serializable()]
	public class <xsl:value-of select="Formulario/NombreClase" /><xsl:value-of select="Formulario/NameSpaceProjet" /> : DataSet
    {
    
		//Constantes para la tabla 
		<xsl:call-template name="DeclararConstantesDAO" />
        // Constructor 
        public <xsl:value-of select="Formulario/NombreClase" /><xsl:value-of select="Formulario/NameSpaceProjet" />()
        {
            BuildDataTables();
        }
		<xsl:call-template name="BuildDataTables" />		
	}
}

</xsl:template>
	<xsl:template name="DeclararConstantesDAO">
		/// <summary>Constante con el nombre de la tabla <xsl:value-of select="Formulario/NombreClase" /></summary>
		public const string <xsl:value-of select="Formulario/ConstanteTabla" /> = "<xsl:value-of select="Formulario/NombreClase" />";
		<xsl:for-each select="Formulario/Registro/Campos/Campo">
		/// <summary>Constante con el nombre del campo <xsl:value-of select="@nomcolumna" /></summary>
		public const string <xsl:value-of select="@ConstanteCampo" /> = "<xsl:value-of select="@nomcolumna" />";
         </xsl:for-each>
</xsl:template>

<xsl:template name="BuildDataTables">
		private void BuildDataTables()
		{
	    	DataTable DTable;
        	DataColumnCollection DColumns;
        	DTable = new DataTable(<xsl:value-of select="Formulario/NombreClase" /><xsl:value-of select="Formulario/NameSpaceProjet" />.<xsl:value-of select="Formulario/ConstanteTabla" />);
        	DColumns = DTable.Columns;
			<xsl:for-each select="Formulario/Registro/Campos/Campo">
            DColumns.Add( <xsl:value-of select="@ConstanteCampo" />, typeof(<xsl:value-of select="@tipodato" />));</xsl:for-each>
			this.Tables.Add( DTable );
		}
</xsl:template>

</xsl:stylesheet>