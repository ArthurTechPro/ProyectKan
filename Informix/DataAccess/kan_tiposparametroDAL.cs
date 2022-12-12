using System;
using System.Data;
using IBM.Data.Informix;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_tiposparametroDAL : IDisposable
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro tipoparametro</summary>
        public static string TIPOPARAMETRO_PARAM = "@tipoparametro";
        /// <summary>Constante con el nombre del parametro parametro</summary>
        public static string PARAMETRO_PARAM = "@parametro";
        private IfxConnection sqlconn;
        private IfxDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_tiposparametro WHERE tipoparametro = ?";
        private string sqlInsert = "INSERT INTO kan_tiposparametro (tipoparametro, parametro) VALUES ( ?, ?)";
        private string sqlSelectALL = "SELECT tipoparametro, parametro FROM kan_tiposparametro";
        private string sqlSelectID = "SELECT tipoparametro, parametro FROM kan_tiposparametro WHERE tipoparametro = ? ";
        private string sqlUpdate = "UPDATE kan_tiposparametro SET parametro = ? WHERE tipoparametro = ? ";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_tiposparametro
        /// </summary>
        public kan_tiposparametroDAL()
        {
            sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
            sqlDA = new IfxDataAdapter();
            sqlDA.TableMappings.Add(kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA, kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA);
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
        /// Comando Delete para el objeto kan_tiposparametro
        /// </summary>
        private IfxCommand GetDelete()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 tipoparametro)
        {
            IfxCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].Value = tipoparametro;

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
        /// Comando Insert para el objeto kan_tiposparametro
        /// </summary>
        private IfxCommand GetInsert()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));
            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_tiposparametroDAO.TIPOPARAMETRO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(PARAMETRO_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[PARAMETRO_PARAM].SourceColumn = kan_tiposparametroDAO.PARAMETRO_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_tiposparametroDAO ds)
        {

             sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_tiposparametro
        /// </summary>
        private IfxCommand GetSelectALL()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_tiposparametroDAO SelectALL()
        {
            IfxCommand sqlCmd = GetSelectALL();
            kan_tiposparametroDAO data = new kan_tiposparametroDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_tiposparametro
        /// </summary>
        private IfxCommand GetSelectID()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public kan_tiposparametroDAO SelectID(System.Int32 tipoparametro)
        {
            IfxCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].Value = tipoparametro;
            kan_tiposparametroDAO data = new kan_tiposparametroDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_tiposparametro
        /// </summary>
        private IfxCommand GetUpdate()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new IfxParameter(PARAMETRO_PARAM, IfxType.VarChar));  
            sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public void Update(System.Int32 tipoparametro, System.String parametro)
        {
            IfxCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[PARAMETRO_PARAM].Value = parametro;
            sqlCmd.Parameters[TIPOPARAMETRO_PARAM].Value = tipoparametro;
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
