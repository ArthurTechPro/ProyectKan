<?xml version="1.0" encoding="UTF-8" ?>
<!-- DWXMLSource="../XML/adm_configBLL.cs.xml" -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" />
  <xsl:template match="/">

    /// <summary>
    ///  Class for: <xsl:value-of select="/Formulario/Titulo" />
    /// CODEGEN  Proyecto  KAN ( semilla )
    /// Derechos Reservados ( CARLOS ARTURO HERNANDEZ )
    /// </summary>


    using System;
    using System.Data;
    using <xsl:value-of select="/Formulario/NameProject" />.<xsl:value-of select="/Formulario/NameSpace" />.DAO;
    using <xsl:value-of select="/Formulario/NameProject" />.<xsl:value-of select="/Formulario/NameSpace" />.DAL;


    namespace <xsl:value-of select="/Formulario/NameProject" />.<xsl:value-of select="/Formulario/NameSpace" />.BLL
    {

    public class <xsl:value-of select="/Formulario/ClaseBLL" />
    {
    <xsl:call-template name="GenerarComandos" />
    }
    }
  </xsl:template>

  <xsl:template name="GenerarComandos">
    <xsl:for-each select="/Formulario/Comandos/Comando">
      <xsl:choose>
        <xsl:when test="self::*[TipoComando = 'Fill']">
          <xsl:call-template name="GenerarComandoFill" />
        </xsl:when>
        <xsl:when test="self::*[TipoComando = 'Update']">
          <xsl:call-template name="GenerarComandoUpdate" />
        </xsl:when>
        <xsl:when test="self::*[TipoComando = 'Execute']">
          <xsl:call-template name="GenerarComandoExecute" />
        </xsl:when>
      </xsl:choose>
    </xsl:for-each>
    <!--		<xsl:call-template name="GenerarComandoSaveChanges" />-->
  </xsl:template>

  <xsl:template name="GenerarComandoFill">
    public <xsl:value-of select="/Formulario/ClaseDAO" /><xsl:text> </xsl:text><xsl:value-of select="Nombre" />(<xsl:call-template name="DeclararParametrosComando" />)
    {
    <xsl:value-of select="/Formulario/ClaseDAL" /> DataDAL = new <xsl:value-of select="/Formulario/ClaseDAL" />();
    <xsl:value-of select="/Formulario/ClaseDAO" /> DataDAO = new <xsl:value-of select="/Formulario/ClaseDAO" />();
    DataDAO = DataDAL.<xsl:value-of select="Nombre" />(<xsl:call-template name="ConvertirParametrosComando" />);
    return DataDAO;
    }
  </xsl:template>

  <xsl:template name="GenerarComandoUpdate">
    public void <xsl:value-of select="Nombre" /> (<xsl:call-template name="DeclararParametrosComando" />)
    {
    <xsl:value-of select="/Formulario/ClaseDAL" /> DataDAL = new <xsl:value-of select="/Formulario/ClaseDAL" />();
    <xsl:value-of select="/Formulario/ClaseDAO" /> DataDAO = new <xsl:value-of select="/Formulario/ClaseDAO" />();
    <xsl:if test="self::*[TipoParametros != 'CamposRegistro']" >
      DataRow Dr = DataDAO.Tables[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />].NewRow();
      <xsl:if test="self::*[ComandoDataAdapter ='UpdateCommand']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          <xsl:choose>
            <xsl:when test="self::*[@tipodato ='String']">
              Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />] = <xsl:value-of select="@nomcolumna" />;
            </xsl:when>
            <xsl:otherwise>
              if (<xsl:value-of select="@nomcolumna" /> != "")
              Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />] = Convert.To<xsl:value-of select="@tipodato" />(<xsl:value-of select="@nomcolumna" />);
              else
              Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />] = DBNull.Value;
            </xsl:otherwise>
          </xsl:choose>
        </xsl:for-each>
        DataDAO.Tables[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />].Rows.Add(Dr);
        DataDAL.<xsl:value-of select="Nombre" />(DataDAO);
      </xsl:if>
    </xsl:if>
    <xsl:if test="self::*[TipoParametros = 'CamposRegistro']" >
      DataDAL.<xsl:value-of select="Nombre" />(<xsl:call-template name="ConvertirParametrosComando" />);
    </xsl:if>
    }
  </xsl:template>
  <xsl:template name="GenerarComandoExecute">
    public void <xsl:value-of select="Nombre" />(<xsl:call-template name="DeclararParametrosComando" />)
    {
    <xsl:value-of select="/Formulario/ClaseDAL" /> DataDAL = new <xsl:value-of select="/Formulario/ClaseDAL" />();
    <xsl:value-of select="/Formulario/ClaseDAO" /> DataDAO = new <xsl:value-of select="/Formulario/ClaseDAO" />();
    <xsl:choose>
      <xsl:when test="self::*[ComandoDataAdapter ='InsertCommand']">
        DataRow Dr = DataDAO.Tables[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />].NewRow();
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esidentity = '0']">
          <xsl:choose>
            <xsl:when test="self::*[@tipodato ='String']">
              Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />] = <xsl:value-of select="@nomcolumna" />;
            </xsl:when>
            <xsl:otherwise>
              if (<xsl:value-of select="@nomcolumna" /> != "")
              Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />] =  Convert.To<xsl:value-of select="@tipodato" />(<xsl:value-of select="@nomcolumna" />);
              else
              Dr[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="@ConstanteCampo" />] = DBNull.Value;;
            </xsl:otherwise>
          </xsl:choose>
        </xsl:for-each>
        DataDAO.Tables[<xsl:value-of select="/Formulario/ClaseDAO" />.<xsl:value-of select="/Formulario/ConstanteTabla" />].Rows.Add(Dr);
        DataDAL.<xsl:value-of select="Nombre" />(DataDAO);
      </xsl:when>
      <xsl:otherwise>
        DataDAL.<xsl:value-of select="Nombre" />(<xsl:call-template name="ConvertirParametrosComando" />);
      </xsl:otherwise>
    </xsl:choose>
    }
  </xsl:template>

  <xsl:template name="DeclararParametrosComando">
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros ='Dataset' ]">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">String<xsl:text> </xsl:text><xsl:value-of select="@nomcolumna" /><xsl:if test="position()!=last()">,<xsl:text> </xsl:text> </xsl:if> </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">String<xsl:text> </xsl:text><xsl:value-of select="@nomcolumna" /><xsl:if test="position()!=last()">,<xsl:text> </xsl:text> </xsl:if> 
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposRegistro']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">String<xsl:text> </xsl:text><xsl:value-of select="@nomcolumna" /><xsl:if test="position()!=last()"> ,<xsl:text> </xsl:text> </xsl:if> 
        </xsl:for-each>
      </xsl:when>
      <!-- Parametros adicionales -->
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        <xsl:for-each select="Parametros/Parametro" > String<xsl:text> </xsl:text><xsl:value-of select="NombreParam" /><xsl:if test="position()!=last()">,<xsl:text> </xsl:text> </xsl:if> 
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
  </xsl:template>

  <xsl:template name="ConvertirParametrosComando">
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros ='Dataset']">Ds</xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposLlave']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          <xsl:choose>
            <xsl:when test="self::*[@tipodato ='String']">
              <xsl:value-of select="@nomcolumna" />
            </xsl:when>
            <xsl:otherwise>
              Convert.To<xsl:value-of select="@tipodato" />(<xsl:value-of select="@nomcolumna"/>)
            </xsl:otherwise>
          </xsl:choose>
          <xsl:if test="position()!=last()">
            ,<xsl:text> </xsl:text>
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros = 'CamposRegistro']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo">
          <xsl:choose>
            <xsl:when test="self::*[@tipodato ='String']">
              <xsl:value-of select="@nomcolumna" />
            </xsl:when>
            <xsl:otherwise>
              Convert.To<xsl:value-of select="@tipodato" />(<xsl:value-of select="@nomcolumna"/>)
            </xsl:otherwise>
          </xsl:choose>
          <xsl:if test="position()!=last()">
            ,<xsl:text> </xsl:text>
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="self::*[TipoParametros ='CamposAdd']">
        <xsl:for-each select="Parametros/Parametro">
          <xsl:choose>
            <xsl:when test="self::*[Tipodato ='String']">
              <xsl:value-of select="NombreParam" />
            </xsl:when>
            <xsl:otherwise>
              Convert.To<xsl:value-of select="Tipodato" />(<xsl:value-of select="NombreParam"/>)
            </xsl:otherwise>
          </xsl:choose>
          <xsl:if test="position()!=last()">
            ,<xsl:text> </xsl:text>
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
    <!-- Parametros adicionales -->
    <xsl:for-each select="/Parametros/Parametro">
      <xsl:choose>
        <xsl:when test="self::*[tipodato ='String']">
          <xsl:value-of select="@nomcolumna" />
        </xsl:when>
        <xsl:otherwise>
          Convert.To<xsl:value-of select="Tipodato" />(<xsl:value-of select="@nomcolumna" />)
        </xsl:otherwise>
      </xsl:choose>
      <xsl:if test="position()!=last()">
        ,<xsl:text> </xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="AsignarParametrosComando">
    <!-- Dataset no tiene asignación de parametros -->
    <xsl:choose>
      <xsl:when test="self::*[TipoParametros ='2']">
        <xsl:for-each select="/Formulario/Registro/Campos/Campo[@esprimarykey = '1']">
          SqlCmd.Parameters[<xsl:value-of select="/Formulario/ClaseDAL" />.<xsl:value-of select="@constanteParametro" />].Value = <xsl:value-of select="@nombrecolumna" />;
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>

    <!-- Parametros adicionales -->
    <xsl:for-each select="/Formulario/Parametros/Parametro">
      SqlCmd.Parameters[<xsl:value-of select="constanteParametro" />].Value = <xsl:value-of select="@nomcolumna" />;
    </xsl:for-each>

  </xsl:template>

  <xsl:template name="AsignarParametrosRetorno">
    <!-- Parametros con valores de retorno -->
    <xsl:for-each select="/Formulario/Parametros/Parametro">
      <xsl:if test="direccion">
        <xsl:value-of select="Nombre" /> = SqlDA.UpdateCommand.Parameters[<xsl:value-of select="constanteParametro" />].Value;
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>