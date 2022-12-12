<?xml version="1.0" encoding="UTF-8" ?>
<!-- DWXMLSource="../XML/adm_configBLL.cs.xml" -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" />
  <xsl:template match="/" >
    /// <summary>
      /// DATA ACCESS Class for: <xsl:value-of select="/Formulario/Titulo" />
      /// CODEGEN  Proyecto  KAN ( semilla )
      /// Derechos Reservados ( CARLOS ARTURO HERNANDEZ - CACERES )
      ///
    </summary>

    using System;
    using System.Text;
    using System.Data;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.Data.Common;
    using <xsl:value-of select="Formulario/DataProveedor" />;
    using System.IO;
    using System.Linq;
    using <xsl:value-of select="Formulario/NameProject" />.<xsl:value-of select="Formulario/NameSpace" />.DAO;

    namespace <xsl:value-of select="Formulario/NameProject" />.<xsl:value-of select="Formulario/NameSpace" />.<xsl:value-of select="Formulario/NameSpaceProjet" />
    {

    [Serializable()]
    public class <xsl:value-of select="Formulario/ClaseDAL" />
    {
    <!-- Parametros para el llamado de comandos  -->
    <xsl:call-template name="DeclararParametrosModulo" />
    <!-- Declara Comando SQL  -->
    <xsl:call-template name="DeclararSQL" />

    /// <summary> /// Parametro de Conneccition	/// </summary>
    private <xsl:value-of select="Formulario/SqlConn" /> SqlConn;
    private <xsl:value-of select="Formulario/SqlDA" /> SqlDA;

    public <xsl:value-of select="Formulario/ClaseDAL" />()
    {
    SqlConn = new <xsl:value-of select="Formulario/SqlConn" />(GetConnectionString()) ;
    SqlDA = new IfxDataAdapter();
    }
    /// <summary> /// Plataforma Base de Datos Usada /// </summary>
    public static string DBPlatform()
    {
    return "<xsl:value-of select="Formulario/DBPlataform" />";
    }
    <!-- Generacion de Comandos  -->
    <xsl:call-template name="GenerarComandos" />
    private static string GetConnectionString()
    {
    return ConfigurationManager.AppSettings["<xsl:value-of select="Formulario/ConfigSetings" />"];
    }
    }
    }
  </xsl:template>

  <!-- Parametros del la Tabla -->
  <xsl:template name="DeclararParametrosModulo" >
    /// <summary> /// Parametros para el llamado de Comandos /// </summary>
    <xsl:for-each select="Formulario/Registro/Campos/Campo">
      /// <summary>
        /// Constante con el Nombre del Parametro <xsl:value-of select="@nomcolumna" />  ///
      </summary>
      public static string <xsl:value-of select="@ConstanteParametro" /> = "@<xsl:value-of select="@nomcolumna" />";
    </xsl:for-each>
    <!-- Parametros adicionales -->
    <xsl:for-each select="Formulario/Parametros/Parametro">
      /// <summary>
        /// Constante con el Nombre del Parametro <xsl:value-of select="@Nombre" /> ///
      </summary>
      private string <xsl:value-of select="@ConstanteParametro" /> = "@<xsl:value-of select="@Nombre" />";
    </xsl:for-each>
  </xsl:template>

  <!-- Declarar SQL  -->
  <xsl:template name="DeclararSQL" >
    /// <summary> /// Sentencias SQL o Procedimientos almacenados  /// </summary>
    <xsl:for-each select="Formulario/Comandos/Comando">
      private string Sql<xsl:value-of select="Nombre" /> = "<xsl:value-of select="Sql" />";
    </xsl:for-each>
  </xsl:template>

  <!-- Generar Comandos -->
  <xsl:template name="GenerarComandos">
    <xsl:for-each select="Formulario/Comandos/Comando">
      /// <summary>
        /// Comando <xsl:value-of select="Nombre" /> Para el Objeto <xsl:value-of select="Formulario/Titulo" /> ///
      </summary>
      <xsl:variable name="W_COMANDO" select="Nombre" />
      <xsl:choose>
        <xsl:when test="self::*[TipoComando = 'Fill']">
          <xsl:call-template name="GenerarComandoFill" />
        </xsl:when>
        <xsl:when test="self::*[TipoComando = 'Execute']">
          <xsl:call-template name="GenerarComandoExecute" />
        </xsl:when>
        <xsl:when test="self::*[TipoComando = 'Update']">
          <xsl:call-template name="GenerarComandoUpdate" />
        </xsl:when>
      </xsl:choose>
    </xsl:for-each>
  </xsl:template>
  <!-- Generar Comando Fill  -->
  <xsl:template name="GenerarComandoFill">
      public <xsl:value-of select="/Formulario/ClaseDAO" /><xsl:text> </xsl:text><xsl:value-of select="Nombre" />(<xsl:call-template name="DeclararParametrosComando" />)
      {
      <xsl:value-of select="/Formulario/SqlComm" /> SqlCmd = new <xsl:value-of select="/Formulario/SqlComm" />(Sql<xsl:value-of select="Nombre" />, SqlConn );
    <xsl:if test="tiposql">
      SqlCmd.CommandType = CommandType.<xsl:value-of select="tiposql" />;
    </xsl:if>
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros='Dataset']">
        /// <summary>
          /// Parametros 1 - <xsl:value-of select="TipoComando" /> ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />(<xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        /// <summary>
          /// Parametros 2 - <xsl:value-of select="TipoParametros" /> ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />(<xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        /// <summary>
          /// Parametros 4 - <xsl:value-of select="TipoParametros" />  ///
        </summary>
        <xsl:for-each select="Parametros/Parametro">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />(<xsl:value-of select="ConstanteParam" />, <xsl:value-of select="TipoDatoSql" />, <xsl:value-of select="Tamano" />));
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
    <xsl:for-each select="/Parametros/Parametro">
      SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />(<xsl:value-of select="ConstanteParam" />, <xsl:value-of select="tipodatosql" />, <xsl:value-of select="@tamano" />));<xsl:if test="direccion">
        SqlCmd.Parameters[<xsl:value-of select="ConstanteParam" />].Direction = <xsl:value-of select="direccion" />;
      </xsl:if>
    </xsl:for-each>

    <xsl:call-template name="AsignarParametrosComando" />
    <xsl:text> 
        </xsl:text>
    <xsl:value-of select="/Formulario/ClaseDAO" /> Data = new <xsl:value-of select="/Formulario/ClaseDAO" />();
    SqlDA = new <xsl:value-of select="/Formulario/SqlDA" />(SqlCmd);
    SqlDA.SelectCommand = SqlCmd;
    SqlDA.Fill(Data, <xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />);
    return Data;
    }
  </xsl:template>

  <!-- Asignar Parametros Comando  -->
  <xsl:template name="AsignarParametrosComando">
    <!-- Dataset no tiene asignación de parametros -->
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value = <xsl:value-of select="@nomcolumna" />;
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        <xsl:for-each select="Parametros/Parametro">
          SqlCmd.Parameters[<xsl:value-of select="ConstanteParam" />].Value = <xsl:value-of select="NombreParam" />;
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>

    <!-- Parametros adicionales -->
    <xsl:for-each select="/Parametros/Parametro" >
      SqlCmd.Parameters[<xsl:value-of select="constanteParam" />].Value = <xsl:value-of select="NombreParam" />;
    </xsl:for-each>
  </xsl:template>

  <!-- Generar Comando Execute  -->
  <xsl:template name="GenerarComandoExecute">
    public void <xsl:value-of select="Nombre" />(<xsl:call-template name="DeclararParametrosComando" />)
    {
    <xsl:value-of select="/Formulario/SqlComm" /> SqlCmd = new <xsl:value-of select="/Formulario/SqlComm" />(Sql<xsl:value-of select="Nombre" />, SqlConn );
    <xsl:if test="tiposql">
      SqlCmd.CommandType = CommandType.<xsl:value-of select="tiposql" />;
    </xsl:if>
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros='Dataset']">
        /// <summary>
          //Parametros 1 - <xsl:value-of select="TipoParametros" /> ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esidentity = '0']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        /// <summary>
          /// Parametros 2- <xsl:value-of select="TipoParametros" /> ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />,<xsl:value-of select="@tamano" /> ));
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposRegistro']">
        /// <summary>
          /// Parametros 3 - <xsl:value-of select="TipoParametros" />  ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        /// <summary>
          /// Parametros 4 - <xsl:value-of select="TipoParametros" /> ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
    <xsl:for-each select="Parametros/Parametro">
      /// <summary> /// Parameroes Add  /// </summary>
      SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="ConstanteParame" />, <xsl:value-of select="TipoDatoSql" />));
      <xsl:if test="direccion">
        SqlCmd.Parameters[<xsl:value-of select="ConstanteParam" />].Direction = <xsl:value-of select="Direccion" />;
      </xsl:if>
    </xsl:for-each>

    <!--AsignarParametrosComando -->
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros ='Dataset']">
        DataRow Dr = Ds.Tables[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />].Rows[0];
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esidentity = '0']">
          <xsl:choose>
            <xsl:when test="self::*[@tipodato ='System.String']">
              SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value = dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />].ToString();
            </xsl:when>
            <xsl:otherwise>
              SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value = Convert.To<xsl:value-of select="@tipodato" />(Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />].ToString());
            </xsl:otherwise>
          </xsl:choose>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value = <xsl:value-of select="@nomcolumna" />;
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros = 'CamposRegistro']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value = <xsl:value-of select="@nomcolumna" />;
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        <xsl:for-each select="/Formulario/Comandos/Comando/Parametros/Parametro">
          SqlCmd.Parameters[<xsl:value-of select="ConstanteParam" />].Value = <xsl:value-of select="NombreParam" />;
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
    <!-- Parametros adicionales -->
    <xsl:for-each select="/Parametros/Parametro">
      SqlCmd.Parameters[<xsl:value-of select="constanteParam" />].Value = <xsl:value-of select="Nombre" />;
    </xsl:for-each>
    SqlDA.<xsl:value-of select="ComandoDataAdapter" /> = SqlCmd;
    SqlDA.<xsl:value-of select="ComandoDataAdapter" />.Connection.Open();
    try
    {
    SqlDA.<xsl:value-of select="ComandoDataAdapter" />.ExecuteNonQuery();
    <xsl:call-template name="AsignarParametrosRetorno" />
    }
    catch
    {
    SqlDA.<xsl:value-of select="ComandoDataAdapter" />.Connection.Close();
    }
    SqlDA.<xsl:value-of select="ComandoDataAdapter" />.Connection.Close();
    }
  </xsl:template>

  <!-- Declarar ParametrosComando -->
  <xsl:template name="DeclararParametrosComando">
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros ='Dataset']">
        <xsl:value-of select="/Formulario/ClaseDAO" /><xsl:text>  </xsl:text>Ds</xsl:when>
     
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          <xsl:value-of select="@tipodato" />
          <xsl:text> </xsl:text>
          <xsl:value-of select="@nomcolumna" />
          <xsl:if test="position()!=last()">
            ,<xsl:text> </xsl:text>
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
      
      <xsl:when test="self::*[TipoParametros ='CamposRegistro']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          <xsl:value-of select="@tipodato" />
          <xsl:text> </xsl:text>
          <xsl:value-of select="@nomcolumna" />
          <xsl:if test="position()!=last()">
            ,<xsl:text> </xsl:text>
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
      
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        <xsl:for-each select="Parametros/Parametro">
          <xsl:value-of select="Tipodato" />
          <xsl:text> </xsl:text>
          <xsl:value-of select="NombreParam" />
          <xsl:if test="position()!=last()">
            ,<xsl:text> </xsl:text>
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
    
    </xsl:choose>
    <!-- Parametros adicionales -->
    <xsl:for-each select="/Parametros/Parametro">
      <xsl:value-of select="Tipodato" />
      <xsl:text> </xsl:text>
      <xsl:value-of select="NombreParam" />
      <xsl:if test="position()!=last()">
        ,<xsl:text></xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <!-- Generar Comando Update -->
  <xsl:template name="GenerarComandoUpdate">
    public void <xsl:value-of select="Nombre" /> (<xsl:call-template name="DeclararParametrosComando" />)
    {
    SqlConn.Open();
    // <xsl:value-of select="/Formulario/SqlTrans" /> Transac = SqlConn.BeginTransaction();
    <xsl:value-of select="/Formulario/SqlComm" /> SqlCmd = new <xsl:value-of select="/Formulario/SqlComm" />(Sql<xsl:value-of select="Nombre" />, SqlConn );
    <xsl:if test="tiposql">
      SqlCmd.CommandType = CommandType.<xsl:value-of select="tiposql" />;
    </xsl:if>
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros='Dataset']">
        /// <summary>
          /// Parametros DOS <xsl:value-of select="TipoParametros" />  ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '0']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].SourceColumn = <xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />;
        </xsl:for-each>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].SourceColumn = <xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />;
        </xsl:for-each>
      </xsl:when>

      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        /// <summary>
          /// Parametros DOS <xsl:value-of select="TipoParametros" /> ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>

      <xsl:when test="self::*[TipoParametros ='CamposRegistro']">
        /// <summary>
          /// Parametros DOS <xsl:value-of select="TipoParametros" />  ///
        </summary>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '0']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value =  <xsl:value-of select="@nomcolumna" />;
        </xsl:for-each>
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="@ConstanteParametro" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
          SqlCmd.Parameters[<xsl:value-of select="@ConstanteParametro" />].Value =  <xsl:value-of select="@nomcolumna" />;
        </xsl:for-each>
      </xsl:when>

      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        /// <summary>
          /// Parametros DOS <xsl:value-of select="TipoParametros" />  ///
        </summary>
        <xsl:for-each select="/Formulario/Comandos/Comando/Parametros/Parametro">
          SqlCmd.Parameters.Add(new <xsl:value-of select="Formulario/SqlParam" />( <xsl:value-of select="ConstanteParam" />, <xsl:value-of select="@tipodatosql" />, <xsl:value-of select="@tamano" />));
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>

    <xsl:for-each select="/Parametros/Parametro">
      /// <summary>
        OTROS PARAMETROS <xsl:value-of select="TipoParametros" />  ///
      </summary>
      SqlCmd.Parameters.Add(new <xsl:value-of select="/Formulario/SqlParam" />( <xsl:value-of select="ConstanteParam" />, <xsl:value-of select="tipodatosql" />, <xsl:value-of select="@tamano" />));
      <xsl:if test="direccion">
        SqlCmd.Parameters[<xsl:value-of select="ConstanteParam" />].Direction = <xsl:value-of select="direccion" />;
      </xsl:if>
    </xsl:for-each>
    <xsl:if test="self::*[TipoParametros != 'CamposRegistro']">
      ///SqlDA.<xsl:value-of select="ComandoDataAdapter" /> = SqlCmd;
      SqlDA.InsertCommand = SqlCmd;
      SqlDA.Update(Ds, <xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />);
      ///Transac.Commit();
      SqlConn.Close();
      <xsl:call-template name="AsignarParametrosRetorno" />
    </xsl:if>
    <xsl:if test="self::*[TipoParametros = 'CamposRegistro']">
      SqlDA.<xsl:value-of select="ComandoDataAdapter" /> = SqlCmd;
      SqlDA.<xsl:value-of select="ComandoDataAdapter" />.Connection.Open();
      try
      {
      SqlDA.<xsl:value-of select="ComandoDataAdapter" />.ExecuteNonQuery();
      }
      catch
      {
      SqlDA.<xsl:value-of select="ComandoDataAdapter" />.Connection.Close();
      }
      SqlDA.<xsl:value-of select="ComandoDataAdapter" />.Connection.Close();
    </xsl:if>
    }
  </xsl:template>


  <!-- Asignar Parametros Retorno -->
  <xsl:template name="AsignarParametrosRetorno">
    <!-- Parametros con valores de retorno -->
    <xsl:for-each select="/Parametros/Parametro">
      <xsl:if test="direccion">
        <xsl:value-of select="nombre" /> = SqlDA.InsertCommand.Parameters[<xsl:value-of select="constanteParam" />].Value;
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>