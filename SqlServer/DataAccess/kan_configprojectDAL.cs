﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlClient;
using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_configprojectDAL
    {


        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idconfigp</summary>
        public static string IDCONFIGP_PARAM = "@idconfigp";
        /// <summary>Constante con el nombre del parametro idproject</summary>
        public static string IDPROJECT_PARAM = "@idproject";
        /// <summary>Constante con el nombre del parametro nameproject</summary>
        public static string NAMEPROJECT_PARAM = "@nameproject";
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_configproject WHERE idconfigp = @idconfigp";
        private string sqlInsert = "INSERT INTO kan_configproject (idproject, nameproject) VALUES (@idproject, @nameproject)";
        private string sqlSelectALL = "SELECT idconfigp, idproject, nameproject FROM kan_configproject";
        private string sqlSelectID = "SELECT idconfigp, idproject, nameproject FROM kan_configproject WHERE idconfigp = @idconfigp";
        private string sqlSelectPro = "SELECT idconfigp, idproject, nameproject FROM kan_configproject WHERE idproject = @idproject";
        private string sqlUpdate = "UPDATE kan_configproject SET idproject = @idproject, nameproject = @nameproject WHERE idconfigp = @idconfigp";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_configproject
        /// </summary>
        public kan_configprojectDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
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
        /// Comando Delete para el objeto kan_configproject
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIGP_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idconfigp)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDCONFIGP_PARAM].Value = idconfigp;

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
        /// Comando Insert para el objeto kan_configproject
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIGP_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCONFIGP_PARAM].SourceColumn = kan_configprojectDAO.IDCONFIGP_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROJECT_PARAM].SourceColumn = kan_configprojectDAO.IDPROJECT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NAMEPROJECT_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NAMEPROJECT_PARAM].SourceColumn = kan_configprojectDAO.NAMEPROJECT_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_configprojectDAO ds)
        {
            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_configproject
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_configprojectDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_configprojectDAO data = new kan_configprojectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_configproject
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIGP_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_configprojectDAO SelectID(System.Int32 idconfigp)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCONFIGP_PARAM].Value = idconfigp;
            kan_configprojectDAO data = new kan_configprojectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_configproject
        /// </summary>
        private SqlCommand GetSelectPro()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_configprojectDAO SelectPro(System.Int32 idproject)
        {
            SqlCommand sqlCmd = GetSelectPro();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
            kan_configprojectDAO data = new kan_configprojectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            return data;
        }
        /// <summary>
        /// Comando Update para el objeto kan_configproject
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDCONFIGP_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NAMEPROJECT_PARAM, SqlDbType.VarChar, 60));

            return sqlCmd;
        }

        public void Update(System.Int32 idconfigp, System.Int32 idproject, System.String nameproject)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDCONFIGP_PARAM].Value = idconfigp;
            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
            sqlCmd.Parameters[NAMEPROJECT_PARAM].Value = nameproject;
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
