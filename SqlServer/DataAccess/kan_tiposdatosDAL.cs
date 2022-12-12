using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_tiposdatosDAL : IDisposable
    {


        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro tipo</summary>
        public static string TIPO_PARAM = "@tipo";
        /// <summary>Constante con el nombre del parametro dbplatform</summary>
        public static string DBPLATFORM_PARAM = "@dbplatform";
        /// <summary>Constante con el nombre del parametro typedatasql</summary>
        public static string TYPEDATASQL_PARAM = "@typedatasql";
        /// <summary>Constante con el nombre del parametro codigosql</summary>
        public static string CODIGOSQL_PARAM = "@codigosql";
        /// <summary>Constante con el nombre del parametro nombresql</summary>
        public static string NOMBRESQL_PARAM = "@nombresql";
        /// <summary>Constante con el nombre del parametro nombresql</summary>
        public static string NOMBRECOD_PARAM = "@nombrecod";
        /// <summary>Constante con el nombre del parametro nombresql</summary>
        public static string NOMBRETIPO_PARAM = "@nombretipo";
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_tiposdatos WHERE tipo = @tipo";
        private string sqlInsert = "INSERT INTO kan_tiposdatos (dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo) VALUES (@dbplatform, @typedatasql, @codigosql, @nombresql, @nombretipo)";
        private string sqlSelectALL = "SELECT tipo, dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo FROM kan_tiposdatos";
        private string sqlSelectID = "SELECT tipo, dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo FROM kan_tiposdatos WHERE tipo = @tipo";
        private string sqlSelectCod = "SELECT tipo, dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo FROM kan_tiposdatos WHERE ( codigosql = @codigosql ) AND ( dbplatform = @dbplatform )";
        private string sqlUpdate = "UPDATE kan_tiposdatos SET dbplatform = @dbplatform, typedatasql = @typedatasql, codigosql = @codigosql, nombresql = @nombresql, nombrecod = @nombrescod, nombretipo = @nombretipo WHERE tipo = @tipo";
        

        /// <summary>
        /// Clase de acceso a datos para el objeto kan_tiposdatos
        /// </summary>
        public kan_tiposdatosDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
        }
        // Metodo para el manejo del GC
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }
        // Free the instance variables of this object.
        public void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
        }

        /// <summary>
        /// Comando Delete para el objeto kan_tiposdatos
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(TIPO_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 tipo)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[TIPO_PARAM].Value = tipo;

            sqlDA.DeleteCommand = sqlCmd;
            sqlDA.DeleteCommand.Connection.Open();
            try
            {
                sqlDA.DeleteCommand.ExecuteNonQuery();

            }
            catch
            {
                sqlDA.DeleteCommand.Connection.Close();
            }
            sqlDA.DeleteCommand.Connection.Close();
        }

        /// <summary>
        /// Comando Insert para el objeto kan_tiposdatos
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(TIPO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPO_PARAM].SourceColumn = kan_tiposdatosDAO.TIPO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(DBPLATFORM_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[DBPLATFORM_PARAM].SourceColumn = kan_tiposdatosDAO.DBPLATFORM_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TYPEDATASQL_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[TYPEDATASQL_PARAM].SourceColumn = kan_tiposdatosDAO.TYPEDATASQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CODIGOSQL_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[CODIGOSQL_PARAM].SourceColumn = kan_tiposdatosDAO.CODIGOSQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRESQL_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[NOMBRESQL_PARAM].SourceColumn = kan_tiposdatosDAO.NOMBRESQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRECOD_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[NOMBRESQL_PARAM].SourceColumn = kan_tiposdatosDAO.NOMBRECOD_CAMPO;
            
            sqlCmd.Parameters.Add(new SqlParameter(NOMBRETIPO_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[NOMBRESQL_PARAM].SourceColumn = kan_tiposdatosDAO.NOMBRETIPO_CAMPO;
            
            return sqlCmd;
        }

        public void Insert(kan_tiposdatosDAO ds)
        {
            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_tiposdatos
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_tiposdatosDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_tiposdatosDAO data = new kan_tiposdatosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_tiposdatos
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(TIPO_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_tiposdatosDAO SelectID(System.Int32 tipo)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[TIPO_PARAM].Value = tipo;
            kan_tiposdatosDAO data = new kan_tiposdatosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectID para el objeto kan_tiposdatos
        /// </summary>
        private SqlCommand GetSelectCod()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectCod, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(CODIGOSQL_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters.Add(new SqlParameter(DBPLATFORM_PARAM, SqlDbType.VarChar, 60));

            return sqlCmd;
        }

        public kan_tiposdatosDAO SelectCod(System.Int32 codigosql, string dbplatform)
        {
            SqlCommand sqlCmd = GetSelectCod();

            sqlCmd.Parameters[CODIGOSQL_PARAM].Value = codigosql;
            sqlCmd.Parameters[DBPLATFORM_PARAM].Value = dbplatform;
            kan_tiposdatosDAO data = new kan_tiposdatosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_tiposdatos
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(TIPO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(DBPLATFORM_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(TYPEDATASQL_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(CODIGOSQL_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRESQL_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRECOD_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRETIPO_PARAM, SqlDbType.VarChar, 100));
            return sqlCmd;
        }

        public void Update(System.Int32 tipo, System.String dbplatform, System.String typedatasql, System.Int16 codigosql, System.String nombresql, System.String nombrecod, System.String nombretipo)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[TIPO_PARAM].Value = tipo;
            sqlCmd.Parameters[DBPLATFORM_PARAM].Value = dbplatform;
            sqlCmd.Parameters[TYPEDATASQL_PARAM].Value = typedatasql;
            sqlCmd.Parameters[CODIGOSQL_PARAM].Value = codigosql;
            sqlCmd.Parameters[NOMBRESQL_PARAM].Value = nombresql;
            sqlCmd.Parameters[NOMBRECOD_PARAM].Value = nombrecod;
            sqlCmd.Parameters[NOMBRETIPO_PARAM].Value = nombretipo;
            sqlDA.UpdateCommand = sqlCmd;
            sqlDA.UpdateCommand.Connection.Open();
            try
            {
                sqlDA.UpdateCommand.ExecuteNonQuery();

            }
            catch
            {
                sqlDA.UpdateCommand.Connection.Close();
            }
            sqlDA.UpdateCommand.Connection.Close();
        }
	
    }
}
