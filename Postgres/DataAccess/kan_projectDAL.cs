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
    [Serializable()]
    public class kan_projectDAL
    {
        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idproject</summary>
        public static string IDPROJECT_PARAM = "@idproject";
        /// <summary>Constante con el nombre del parametro nomproject</summary>
        public static string NOMPROJECT_PARAM = "@nomproject";
        /// <summary>Constante con el nombre del parametro namespaceproject</summary>
        public static string NAMESPACEPROJECT_PARAM = "@namespaceproject";
        private NpgsqlConnection sqlconn;
        private NpgsqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_project WHERE idproject = @idproject";
        private string sqlInsert = "INSERT INTO kan_project (nomproject, namespaceproject) VALUES ( @nomproject, @namespaceproject)";
        private string sqlSelectALL = "SELECT idproject, nomproject, namespaceproject FROM kan_project";
        private string sqlSelectID = "SELECT idproject, nomproject, namespaceproject FROM kan_project WHERE idproject = @idproject";
        private string sqlUpdate = "UPDATE kan_project SET nomproject = @nomproject, namespaceproject = @namespaceproject WHERE idproject = @idproject";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_project
        /// </summary>
        public kan_projectDAL()
        {
            sqlconn = new NpgsqlConnection(kan_Configuration.ConnectionString); 
            sqlDA = new NpgsqlDataAdapter();
            sqlDA.TableMappings.Add(kan_projectDAO.KAN_PROJECT_TABLA, kan_projectDAO.KAN_PROJECT_TABLA);
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
        /// Comando Delete para el objeto kan_project
        /// </summary>
        private NpgsqlCommand GetDelete()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECT_PARAM, NpgsqlDbType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 idproject)
        {
            NpgsqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;

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
        /// Comando Insert para el objeto kan_project
        /// </summary>
        private NpgsqlCommand GetInsert()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new NpgsqlParameter(NOMPROJECT_PARAM, NpgsqlDbType.Varchar));
            sqlCmd.Parameters[NOMPROJECT_PARAM].SourceColumn = kan_projectDAO.NOMPROJECT_CAMPO;

            sqlCmd.Parameters.Add(new NpgsqlParameter(NAMESPACEPROJECT_PARAM, NpgsqlDbType.Varchar));
            sqlCmd.Parameters[NAMESPACEPROJECT_PARAM].SourceColumn = kan_projectDAO.NAMESPACEPROJECT_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_projectDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_projectDAO.KAN_PROJECT_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_project
        /// </summary>
        private NpgsqlCommand GetSelectALL()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_projectDAO SelectALL()
        {
            NpgsqlCommand sqlCmd = GetSelectALL();
            kan_projectDAO data = new kan_projectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_projectDAO.KAN_PROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_project
        /// </summary>
        private NpgsqlCommand GetSelectID()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECT_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public kan_projectDAO SelectID(System.Int32 idproject)
        {
            NpgsqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
            kan_projectDAO data = new kan_projectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_projectDAO.KAN_PROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_project
        /// </summary>
        private NpgsqlCommand GetUpdate()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new NpgsqlParameter(NOMPROJECT_PARAM, NpgsqlDbType.Varchar));

            sqlCmd.Parameters.Add(new NpgsqlParameter(NAMESPACEPROJECT_PARAM, NpgsqlDbType.Varchar));

            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECT_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public void Update(System.Int32 idproject, System.String nomproject, System.String namespaceproject)
        {
            NpgsqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[NOMPROJECT_PARAM].Value = nomproject;
            sqlCmd.Parameters[NAMESPACEPROJECT_PARAM].Value = namespaceproject;
            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
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
