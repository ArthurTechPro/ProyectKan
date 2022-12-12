using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.BLL;
using ProjectKAN.DAO;

namespace ProjectKAN.WIN
{
    public class ComandosSQL
    {
        public Configuracion ConfigActual;
        public enum TipoParametros { Ninguno = 0, Dataset = 1, CamposLlave, CamposRegistro, CamposAdd }
        public enum ComandoTipo { Fill = 1, Execute, Update }
        public enum Comando { Insert = 1, Delete, Select, Update }
        public enum TipoImplementacion { Text = 1, StoredProcedure }
        public string Nombre;
        public string Propiedad;
        public string idPropiedad;
        public string SQL;
        public string TipoComando;
        public kan_parametrosDAO Kan_ParamDAO;
        public TipoParametros TipoParam;
        public ComandoTipo Tipo;
        public Comando Coman;
        public DataSet DataSetBase;
        public kan_propcolumnasDAO Kan_PropColDAO;
        public string Parametros;
        public string TipoSql;


        public ComandosSQL()
        {
            
            //TipoParametro = 0;
            Parametros = "";
        }

        public void Preparar()
        {
            CargaProColumas();

            string[] columnas = null;
            //Cargar parametros que son columnas del Dataset
            columnas = this.Parametros.Split(new Char[] { ',' });

            kan_parametrosBLL Kan_ParamBLL = new kan_parametrosBLL();
            Kan_ParamDAO = Kan_ParamBLL.SelectParamComando(TipoComando);

            foreach (string strCol in columnas)
            {
                if (strCol != "" )
                {
                    foreach (DataRow drc in DataSetBase.Tables[0].Rows)
                    {
                        string NCol = drc[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim();
                        if (NCol == (strCol.Trim()))
                        {
                            DataRow dr = Kan_ParamDAO.Tables[0].NewRow();
                            //  dr[kan_parametrosDAO.] = Propiedad.Trim();
                            dr[kan_parametrosDAO.NOMCOMANDO_CAMPO] = strCol;
                            dr[kan_parametrosDAO.NOMPARAMETRO_CAMPO] = drc[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim();
                            dr[kan_parametrosDAO.TIPODATO_CAMPO] = drc[kan_propcolumnasDAO.TIPODATO_CAMPO].ToString().Trim();
                            dr[kan_parametrosDAO.TIPODATOSQL_CAMPO] = drc[kan_propcolumnasDAO.TIPODATOSQL_CAMPO].ToString().Trim();
                            dr[kan_parametrosDAO.TAMANO_CAMPO] = drc[kan_propcolumnasDAO.TAMANO_CAMPO];
                            dr[kan_parametrosDAO.DIRECCION_CAMPO] = 1; //ParameterDirection.Input
                            Kan_ParamDAO.Tables[0].Rows.Add(dr);
                        }
                    }
                }
            }

            //Resolver SQL++
            ResolverSQL();
        }

        private void CargaProColumas()
        {
            kan_propcolumnasBLL Kan_PropColBLL = new kan_propcolumnasBLL();
            Kan_PropColDAO = Kan_PropColBLL.SelectPro(idPropiedad);
            DataSetBase = Kan_PropColDAO;
        }

        private void ResolverSQL()
        {
            
            SQL = string.Format(SQL,
                    Propiedad.ToString().Trim(), /// {0}  Nombre de la Propiedad Origen
                    ListaCampos(false, true),	///  {1} Relacion de todos los Campos
                    ListaCampos(true, true),	///  {2} Relacion de todos los Campos, agregar @PARM
                    ListaCampos(false, false),	///  {3} Relacion de todos los Campos, Sin Identity
                    ListaCampos(true, false),	///  {4} Relacion de todos los Campos, Sin Identity, agregar @PARM					
                    ListaAsignacionCampos(),	///  {5} Campos = Parametros, Sin Identity, agregar@PARM
                    ExpresionWhereKey(),		///  {6} Expresion where de la llave Promaria(Primarykey)
                    ExpresionWhere()			///  {7} Expresion where de los parametros del query.
                );
        }

        private string ListaCampos(bool esParametro, bool incluirAutoIncrement)
        {
            string str = "";
            foreach (DataRow Dr in Kan_PropColDAO.Tables[0].Rows)
            {
                //Determinar si se debe incluir el campo
                if (incluirAutoIncrement || !Convert.ToBoolean(Dr[kan_propcolumnasDAO.ESIDENTITY_CAMPO]))
                {
                    if (!esParametro)
                        str += Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + ", ";
                    else
                    {
                        if (ConfigActual.TYPEDATASQL.Trim() == "Npgsql")
                            str += "@" + Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + ", ";
                        else
                            str += "?, ";
                    }
                }
            }
            //Quitar la ultima ','
            if (str.Length > 0)
                return str.Substring(0, str.Length - 2);
            else
                return "";
        }

        private string ListaAsignacionCampos()
        {
            string str = "";
            foreach (DataRow Dr in Kan_PropColDAO.Tables[0].Rows)
            {
                //Excluir los campos identity
                if (!Convert.ToBoolean(Dr[kan_propcolumnasDAO.ESIDENTITY_CAMPO]))
                    if (ConfigActual.TYPEDATASQL.Trim() == "Npgsql")
                        str += Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + " = @" + Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + ", ";
                    else
                        str += Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + " = ?, ";
            }
            //Quitar la ultima ','
            if (str.Length > 0)
                return str.Substring(0, str.Length - 2);
            else
                return "";
        }


        private string ExpresionWhere()
        {
            
            string str = "";
            string strColumna;
            foreach (DataRow dr in Kan_ParamDAO.Tables[0].Rows)
            {
                strColumna = dr[kan_parametrosDAO.NOMPARAMETRO_CAMPO].ToString().Trim();
                str += strColumna.Trim() + " = ";
                if (ConfigActual.TYPEDATASQL.Trim() == "Npgsql")
                    str += "@" + strColumna.Trim() + " AND ";
                else
                    str += "? AND ";
            }
            //Quitar el ultimo AND
            if (str.Length > 0)
                return str.Substring(0, str.Length - " AND ".Length);
            else 
                return "";
        }

        private string ExpresionWhereKey()
        {
            string str = "";
            foreach (DataRow Dr in Kan_PropColDAO.Tables[0].Rows)
            {
                if (Convert.ToBoolean(Dr[kan_propcolumnasDAO.ESPRIMARYKEY_CAMPO]))
                {
                    str += Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + " = ";
                    if (ConfigActual.TYPEDATASQL.Trim() == "Npgsql")
                        str += "@" + Dr[kan_propcolumnasDAO.NOMCOLUMNA_CAMPO].ToString().Trim() + " AND ";
                    else
                        str += "? AND ";
                }
            }
            //Quitar el ultimo AND
            if (str.Length > 0)
                return str.Substring(0, str.Length - " AND ".Length);
            else
                return "";
        }

        public static string GenerarSqlDbType(DataColumn c)
        {
            switch (c.DataType.ToString())
            {
                case "String":
                    return "SqlDbType.VarChar," + c.MaxLength;
                case "Int32":
                    return "SqlDbType.Int, 4";
                case "Int16":
                    return "SqlDbType.SmallInt, 2";
                case "DateTime":
                    return "SqlDbType.DateTime, 8";
                case "Boolean":
                    return "SqlDbType.Bit, 1";
                case "Decimal":
                    return "SqlDbType.Money, 8";
                case "Byte[]":
                    return "SqlDbType.Image, 16";
                case "Byte":
                    return "SqlDbType.TinyInt, 1";
                case "Double":
                    return "SqlDbType.Float, 8";
                default:
                    return "//No encontró " + c.DataType.ToString();
            }
        }

        public static string GenerarSqlProcType(DataColumn c)
        {
            switch (c.DataType.ToString())
            {
                case "String":
                    return "varchar(" + c.MaxLength + ")";
                case "Int32":
                    return "int";
                case "Int16":
                    return "smallint";
                case "DateTime":
                    return "dateTime";
                case "Boolean":
                    return "bit";
                case "Decimal":
                    return "money";
                case "Byte[]":
                    return "image";
                case "Byte":
                    return "tinyInt";
                case "Double":
                    return "float";
                default:
                    return "//No encontró " + c.DataType.ToString();
            }
        }

        public static string GenerarSqlDbType(string strTipo)
        {
            switch (strTipo)
            {
                case "String":
                    return "SqlDbType.VarChar";
                case "Int32":
                    return "SqlDbType.Int, 4";
                case "Int16":
                    return "SqlDbType.SmallInt, 2";
                case "DateTime":
                    return "SqlDbType.DateTime, 8";
                case "Boolean":
                    return "SqlDbType.Bit, 1";
                case "Decimal":
                    return "SqlDbType.Money, 8";
                case "Byte[]":
                    return "SqlDbType.Image, 16";
                case "Byte":
                    return "SqlDbType.TinyInt, 1";
                case "Double":
                    return "SqlDbType.Float, 8";
                default:
                    return "//No encontró " + strTipo;
            }
        }

        private SqlDbType SystemToSqlDbType(Type t)
        {
            switch (t.ToString())
            {
                case "String":
                    return SqlDbType.VarChar;
                case "Int32":
                    return SqlDbType.Int;
                case "Int16":
                    return SqlDbType.SmallInt;
                case "DateTime":
                    return SqlDbType.DateTime;
                case "Boolean":
                    return SqlDbType.Bit;
                case "Decimal":
                    return SqlDbType.Money;
                case "Byte[]":
                    return SqlDbType.Image;
                case "Byte":
                    return SqlDbType.TinyInt;
                case "Double":
                    return SqlDbType.Float;
                default:
                    return SqlDbType.VarChar;
            }
        }
    }
}
