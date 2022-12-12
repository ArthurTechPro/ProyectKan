using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlClient;
using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    public class kan_configmotorDAL
    {
        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idconfig</summary>
        public static string IDCONFIG_PARAM = "@idconfig";
        /// <summary>Constante con el nombre del parametro nomcomando</summary>
        public static string NOMCOMANDO_PARAM = "@nomcomando";
        /// <summary>Constante con el nombre del parametro sql</summary>
        public static string SQL_PARAM = "@sql";
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_configmotor WHERE idconfig = @idconfig";
        private string sqlInsert = "INSERT INTO kan_configmotor (idconfig, nomcomando, sql) VALUES (@idconfig, @nomcomando, @sql)";
        private string sqlSelectALL = "SELECT idconfig, nomcomando, sql FROM kan_configmotor";
        private string sqlSelectID = "SELECT idconfig, nomcomando, sql FROM kan_configmotor WHERE idconfig = @idconfig";
        private string sqlUpdate = "UPDATE kan_configmotor SET idconfig = @idconfig, nomcomando = @nomcomando, sql = @sql WHERE idconfig = @idconfig";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_configmotor
        /// </summary>
        public kan_configmotorDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString); 
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA, kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);
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
        /// Comando Delete para el objeto kan_configmotor
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIG_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idconfig)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDCONFIG_PARAM].Value = idconfig;

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
        /// Comando Insert para el objeto kan_configmotor
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIG_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCONFIG_PARAM].SourceColumn = kan_configmotorDAO.IDCONFIG_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMCOMANDO_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMCOMANDO_PARAM].SourceColumn = kan_configmotorDAO.NOMCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(SQL_PARAM, SqlDbType.VarChar, 2000));
            sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_configmotorDAO.SQL_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_configmotorDAO ds)
        {

           sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_configmotor
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_configmotorDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_configmotorDAO data = new kan_configmotorDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_configmotor
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIG_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_configmotorDAO SelectID(System.Int32 idconfig)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCONFIG_PARAM].Value = idconfig;
            kan_configmotorDAO data = new kan_configmotorDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_configmotor
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIG_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NOMCOMANDO_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(SQL_PARAM, SqlDbType.VarChar, 2000));

            return sqlCmd;
        }

        public void Update(System.Int32 idconfig, System.String nomcomando, System.String sql)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDCONFIG_PARAM].Value = idconfig;
            sqlCmd.Parameters[NOMCOMANDO_PARAM].Value = nomcomando;
            sqlCmd.Parameters[SQL_PARAM].Value = sql;
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
