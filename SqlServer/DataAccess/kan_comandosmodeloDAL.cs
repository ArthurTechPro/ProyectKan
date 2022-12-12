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
    public class kan_comandosmDAL
    {


        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idcomandom</summary>
        public static string IDCOMANDOM_PARAM = "@idcomandom";
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
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_comandosm WHERE idcomandom = @idcomandom";
        private string sqlInsert = "INSERT INTO kan_comandosm (nombrecom, sql, tipocomando, tipoparametro, idcoman) VALUES (@nombrecom, @sql, @tipocomando, @tipoparametro, @idcoman)";
        private string sqlSelectALL = "SELECT idcomandom, nombrecom, sql, tipocomando, tipoparametro, idcoman FROM kan_comandosm";
        private string sqlSelectID = "SELECT idcomandom, nombrecom, sql, tipocomando, tipoparametro, idcoman FROM kan_comandosm WHERE idcomandom = @idcomandom";
        private string sqlUpdate = "UPDATE kan_comandosm SET nombrecom = @nombrecom, sql = @sql, tipocomando = @tipocomando, tipoparametro = @tipoparametro, idcoman = @idcoman WHERE idcomandom = @idcomandom";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_comandosm
        /// </summary>
        public kan_comandosmDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_comandosmDAO.kan_comandosm_TABLA, kan_comandosmDAO.kan_comandosm_TABLA);
        }
     
        /// <summary>
        /// Comando Delete para el objeto kan_comandosm
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDOM_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idcomandom)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDCOMANDOM_PARAM].Value = idcomandom;

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
        /// Comando Insert para el objeto kan_comandosm
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDOM_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMANDOM_PARAM].SourceColumn = kan_comandosmDAO.IDCOMANDOM_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRECOM_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMBRECOM_PARAM].SourceColumn = kan_comandosmDAO.NOMBRECOM_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(SQL_PARAM, SqlDbType.VarChar, 2000));
            sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_comandosmDAO.SQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOCOMANDO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_comandosmDAO.TIPOCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOPARAMETRO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_comandosmDAO.TIPOPARAMETRO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDCOMAN_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandosmDAO.IDCOMAN_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_comandosmDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_comandosmDAO.kan_comandosm_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_comandosm
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_comandosmDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_comandosmDAO data = new kan_comandosmDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosmDAO.kan_comandosm_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_comandosm
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDOM_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_comandosmDAO SelectID(System.Int32 idcomandom)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCOMANDOM_PARAM].Value = idcomandom;
            kan_comandosmDAO data = new kan_comandosmDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosmDAO.kan_comandosm_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_comandosm
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDOM_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRECOM_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(SQL_PARAM, SqlDbType.VarChar, 2000));

            sqlCmd.Parameters.Add(new SqlParameter(TIPOCOMANDO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(TIPOPARAMETRO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDCOMAN_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public void Update(System.Int32 idcomandom, System.String nombrecom, System.String sql, System.Int32 tipocomando, System.Int32 tipoparametro, System.Int32 idcoman)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDCOMANDOM_PARAM].Value = idcomandom;
            sqlCmd.Parameters[NOMBRECOM_PARAM].Value = nombrecom;
            sqlCmd.Parameters[SQL_PARAM].Value = sql;
            sqlCmd.Parameters[TIPOCOMANDO_PARAM].Value = tipocomando;
            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].Value = tipoparametro;
            sqlCmd.Parameters[IDCOMAN_PARAM].Value = idcoman;
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
