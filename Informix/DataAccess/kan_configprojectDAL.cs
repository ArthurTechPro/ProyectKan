using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using IBM.Data.Informix;
using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_configprojectDAL
    {


        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idconfigp</summary>
        public static string IDCONFIGP_PARAM = "idconfigp";
        /// <summary>Constante con el nombre del parametro idproject</summary>
        public static string IDPROJECT_PARAM = "idproject";
        /// <summary>Constante con el nombre del parametro nameproject</summary>
        public static string NAMEPROJECT_PARAM = "nameproject";
        private IfxConnection sqlconn;
        private IfxDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_configproject WHERE idconfigp = ?";
        private string sqlInsert = "INSERT INTO kan_configproject (idproject, nameproject) VALUES ( ?, ?)";
        private string sqlSelectALL = "SELECT idconfigp, idproject, nameproject FROM kan_configproject";
        private string sqlSelectID = "SELECT idconfigp, idproject, nameproject FROM kan_configproject WHERE ? = ? ";
        private string sqlSelectPro = "SELECT idconfigp, idproject, nameproject FROM kan_configproject WHERE idproject = ? ";
        private string sqlUpdate = "UPDATE kan_configproject SET idproject = ? , nameproject = ? WHERE idconfigp = ? ";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_configproject
        /// </summary>
        public kan_configprojectDAL()
        {
            sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
            sqlDA = new IfxDataAdapter();
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
        private IfxCommand GetDelete()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(IDCONFIGP_PARAM, IfxType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 idconfigp)
        {
            IfxCommand sqlCmd = GetDelete();

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
        private IfxCommand GetInsert()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

            sqlCmd.Parameters.Add(new IfxParameter(IDPROJECT_PARAM, IfxType.Integer));
            sqlCmd.Parameters[IDPROJECT_PARAM].SourceColumn = kan_configprojectDAO.IDPROJECT_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(NAMEPROJECT_PARAM, IfxType.VarChar));
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
        private IfxCommand GetSelectALL()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_configprojectDAO SelectALL()
        {
            IfxCommand sqlCmd = GetSelectALL();
            kan_configprojectDAO data = new kan_configprojectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_configproject
        /// </summary>
        private IfxCommand GetSelectID()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(IDCONFIGP_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public kan_configprojectDAO SelectID(System.Int32 idconfigp)
        {
            IfxCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCONFIGP_PARAM].Value = idconfigp;
            kan_configprojectDAO data = new kan_configprojectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_configproject
        /// </summary>
        private IfxCommand GetSelectPro()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(IDPROJECT_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public kan_configprojectDAO SelectPro(System.Int32 idproject)
        {
            IfxCommand sqlCmd = GetSelectPro();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idproject;
            kan_configprojectDAO data = new kan_configprojectDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            return data;
        }
        /// <summary>
        /// Comando Update para el objeto kan_configproject
        /// </summary>
        private IfxCommand GetUpdate()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new IfxParameter(IDCONFIGP_PARAM, IfxType.Integer));

            sqlCmd.Parameters.Add(new IfxParameter(IDPROJECT_PARAM, IfxType.Integer));

            sqlCmd.Parameters.Add(new IfxParameter(NAMEPROJECT_PARAM, IfxType.VarChar));

            return sqlCmd;
        }

        public void Update(System.Int32 idconfigp, System.Int32 idproject, System.String nameproject)
        {
            IfxCommand sqlCmd = GetUpdate();

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
