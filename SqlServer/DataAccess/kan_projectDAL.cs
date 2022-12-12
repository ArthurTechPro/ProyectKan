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
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_project WHERE idproject = @idproject";
        private string sqlInsert = "INSERT INTO kan_project (nomproject, namespaceproject) VALUES (@nomproject, @namespaceproject)";
        private string sqlSelectALL = "SELECT idproject, nomproject, namespaceproject FROM kan_project";
        private string sqlSelectID = "SELECT idproject, nomproject, namespaceproject FROM kan_project WHERE idproject = @idproject";
        private string sqlUpdate = "UPDATE kan_project SET nomproject = @nomproject, namespaceproject = @namespaceproject WHERE idproject = @idproject";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_project
        /// </summary>
        public kan_projectDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString); 
            sqlDA = new SqlDataAdapter();
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
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idproject)
        {
            SqlCommand sqlCmd = GetDelete();

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
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROJECT_PARAM].SourceColumn = kan_projectDAO.IDPROJECT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMPROJECT_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMPROJECT_PARAM].SourceColumn = kan_projectDAO.NOMPROJECT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NAMESPACEPROJECT_PARAM, SqlDbType.VarChar, 60));
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
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_projectDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_projectDAO data = new kan_projectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_projectDAO.KAN_PROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_project
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_projectDAO SelectID(System.Int32 idproject)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
            kan_projectDAO data = new kan_projectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_projectDAO.KAN_PROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_project
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECT_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NOMPROJECT_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(NAMESPACEPROJECT_PARAM, SqlDbType.VarChar, 60));

            return sqlCmd;
        }

        public void Update(System.Int32 idproject, System.String nomproject, System.String namespaceproject)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
            sqlCmd.Parameters[NOMPROJECT_PARAM].Value = nomproject;
            sqlCmd.Parameters[NAMESPACEPROJECT_PARAM].Value = namespaceproject;
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
