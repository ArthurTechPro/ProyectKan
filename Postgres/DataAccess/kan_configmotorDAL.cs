using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using Npgsql;
using NpgsqlTypes;
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
        private NpgsqlConnection sqlconn;
        private NpgsqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_configmotor WHERE idconfig = @idconfig";
        private string sqlInsert = "INSERT INTO kan_configmotor (idconfig, nomcomando, sql) VALUES (@idconfig, @nomcomando, @sql)";
        private string sqlSelectALL = "SELECT idconfig, nomcomando, sql FROM kan_configmotor";
        private string sqlSelectID = "SELECT idconfig, nomcomando, sql FROM kan_configmotor WHERE idconfig = @idconfig";
        private string sqlUpdate = "UPDATE kan_configmotor SET nomcomando = @nomcomando, sql = @sql WHERE idconfig = @idconfig";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_configmotor
        /// </summary>
        public kan_configmotorDAL()
        {
            sqlconn = new NpgsqlConnection(kan_Configuration.ConnectionString); 
            sqlDA = new NpgsqlDataAdapter();
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
        private NpgsqlCommand GetDelete()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCONFIG_PARAM, NpgsqlDbType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 idconfig)
        {
            NpgsqlCommand sqlCmd = GetDelete();

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
        private NpgsqlCommand GetInsert()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCONFIG_PARAM, NpgsqlDbType.Integer));
            sqlCmd.Parameters[IDCONFIG_PARAM].SourceColumn = kan_configmotorDAO.IDCONFIG_CAMPO;

            sqlCmd.Parameters.Add(new NpgsqlParameter(NOMCOMANDO_PARAM, NpgsqlDbType.Varchar));
            sqlCmd.Parameters[NOMCOMANDO_PARAM].SourceColumn = kan_configmotorDAO.NOMCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new NpgsqlParameter(SQL_PARAM, NpgsqlDbType.Varchar));
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
        private NpgsqlCommand GetSelectALL()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_configmotorDAO SelectALL()
        {
            NpgsqlCommand sqlCmd = GetSelectALL();
            kan_configmotorDAO data = new kan_configmotorDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_configmotor
        /// </summary>
        private NpgsqlCommand GetSelectID()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCONFIG_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public kan_configmotorDAO SelectID(System.Int32 idconfig)
        {
            NpgsqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCONFIG_PARAM].Value = idconfig;
            kan_configmotorDAO data = new kan_configmotorDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_configmotor
        /// </summary>
        private NpgsqlCommand GetUpdate()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new NpgsqlParameter(NOMCOMANDO_PARAM, NpgsqlDbType.Varchar));

            sqlCmd.Parameters.Add(new NpgsqlParameter(SQL_PARAM, NpgsqlDbType.Varchar));

            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCONFIG_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public void Update(System.Int32 idconfig, System.String nomcomando, System.String sql)
        {
            NpgsqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[NOMCOMANDO_PARAM].Value = nomcomando;
            sqlCmd.Parameters[SQL_PARAM].Value = sql;
            sqlCmd.Parameters[IDCONFIG_PARAM].Value = idconfig;
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
