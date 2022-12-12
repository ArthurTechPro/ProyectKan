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
    public class kan_comandosDAL : IDisposable
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idcomando</summary>
        public static string IDCOMANDO_PARAM = "@idcomando";
        /// <summary>Constante con el nombre del parametro idpropiedad</summary>
        public static string IDPROPIEDAD_PARAM = "@idpropiedad";
        /// <summary>Constante con el nombre del parametro nombrecom</summary>
        public static string NOMBRECOM_PARAM = "@nombrecom";
        /// <summary>Constante con el nombre del parametro sql</summary>
        public static string SQL_PARAM = "@sql";
        /// <summary>Constante con el nombre del parametro tipocomando</summary>
        public static string TIPOCOMANDO_PARAM = "@tipocomando";
        /// <summary>Constante con el nombre del parametro tipoparametro</summary>
        public static string TIPOPARAMETRO_PARAM = "@tipoparametro";
        /// <summary>Constante con el nombre del parametro idcoman</summary>
        public static string IDCOMAN_PARAM = "@idcoman";
        /// <summary>Constante con el nombre del parametro parametros</summary>
        public static string PARAMETROS_PARAM = "@parametros";
        /// <summary>Constante con el nombre del parametro tipoimplementa</summary>
        public static string TIPOIMPLEMENTA_PARAM = "@tipoimplementa";
        /// <summary>Constante con el nombre del parametro nombrecom</summary>
        public static string SPROPIEDAD_PARAM = "@spropiedad";


        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_comandos WHERE idcomando = @idcomando";
        private string sqlInsert = "INSERT INTO kan_comandos (idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa) VALUES (@idpropiedad, @nombrecom, @sql, @tipocomando, @tipoparametro, @idcoman, @parametros, @tipoimplementa)";
        private string sqlSelectALL = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos";
        private string sqlSelectID = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos WHERE idcomando = @idcomando";
        private string sqlSelectProp = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos WHERE idpropiedad = @idpropiedad";
        private string sqlUpdate = "UPDATE kan_comandos SET idpropiedad = @idpropiedad, nombrecom = @nombrecom, sql = @sql, tipocomando = @tipocomando, tipoparametro = @tipoparametro, idcoman = @idcoman, parametros = @parametros, tipoimplementa = @tipoimplementa WHERE idcomando = @idcomando";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_comandos
        /// </summary>
        public kan_comandosDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_comandosDAO.KAN_COMANDOS_TABLA, kan_comandosDAO.KAN_COMANDOS_TABLA);
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
        /// Comando Delete para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idcomando)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDCOMANDO_PARAM].Value = idcomando;

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
        /// Comando Insert para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMANDO_PARAM].SourceColumn = kan_comandosDAO.IDCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_comandosDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRECOM_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMBRECOM_PARAM].SourceColumn = kan_comandosDAO.NOMBRECOM_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(SQL_PARAM, SqlDbType.VarChar, 2000));
            sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_comandosDAO.SQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOCOMANDO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_comandosDAO.TIPOCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOPARAMETRO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_comandosDAO.TIPOPARAMETRO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDCOMAN_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandosDAO.IDCOMAN_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(PARAMETROS_PARAM, SqlDbType.VarChar, 255));
            sqlCmd.Parameters[PARAMETROS_PARAM].SourceColumn = kan_comandosDAO.PARAMETROS_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOIMPLEMENTA_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[TIPOIMPLEMENTA_PARAM].SourceColumn = kan_comandosDAO.TIPOIMPLEMENTA_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_comandosDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_comandosDAO.KAN_COMANDOS_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_comandosDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_comandosDAO data = new kan_comandosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_comandosDAO SelectID(System.Int32 idcomando)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCOMANDO_PARAM].Value = idcomando;
            kan_comandosDAO data = new kan_comandosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectProp para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetSelectProp()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectProp, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_comandosDAO SelectProp(System.Int32 idporpiedad)
        {
            SqlCommand sqlCmd = GetSelectProp();

            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idporpiedad;
            kan_comandosDAO data = new kan_comandosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
            return data;
        }

/*
        /// <summary>
        /// Comando SelectProp para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetSelectNomCom()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectNomCom, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }


        public kan_comandosDAO SelectNomCom(string nombre,string nombrecom)
        {
            SqlCommand sqlCmd = GetSelectNomCom();

            sqlCmd.Parameters[NOMBRECOM_PARAM].Value = nombre;
            sqlCmd.Parameters[].Value = idcomando;
            kan_comandosDAO data = new kan_comandosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
            return data;
        }
        */

        /// <summary>
        /// Comando SelectProp para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetSelectComandosBD(String spropiedad)
        {
            string sqlSelectComandDB = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos WHERE ( idpropiedad IN ("+spropiedad+") )";
    
            SqlCommand sqlCmd = new SqlCommand(sqlSelectComandDB, sqlconn);
            return sqlCmd;
        }

        public kan_comandosDAO SelectComandosBD(String spropiedad)
        {
            SqlCommand sqlCmd = GetSelectComandosBD(spropiedad);

            kan_comandosDAO data = new kan_comandosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
            return data;
        }


        /// <summary>
        /// Comando Update para el objeto kan_comandos
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);
            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMANDO_PARAM].SourceColumn = kan_comandosDAO.IDCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_comandosDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRECOM_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMBRECOM_PARAM].SourceColumn = kan_comandosDAO.NOMBRECOM_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(SQL_PARAM, SqlDbType.VarChar, 2000));
            sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_comandosDAO.SQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOCOMANDO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_comandosDAO.TIPOCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOPARAMETRO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_comandosDAO.TIPOPARAMETRO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDCOMAN_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandosDAO.IDCOMAN_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(PARAMETROS_PARAM, SqlDbType.VarChar, 255));
            sqlCmd.Parameters[PARAMETROS_PARAM].SourceColumn = kan_comandosDAO.PARAMETROS_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOIMPLEMENTA_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[TIPOIMPLEMENTA_PARAM].SourceColumn = kan_comandosDAO.TIPOIMPLEMENTA_CAMPO;

            return sqlCmd;
        }

        public void Update(kan_comandosDAO data)
        {
            sqlDA.UpdateCommand = GetUpdate();
            sqlDA.ContinueUpdateOnError = true;
            sqlDA.Update(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
        }

    }
}
