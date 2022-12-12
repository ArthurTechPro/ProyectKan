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
    public class kan_tiposcomandoDAL : IDisposable
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro tipocomando</summary>
        public static string TIPOCOMANDO_PARAM = "@tipocomando";
        /// <summary>Constante con el nombre del parametro comando</summary>
        public static string COMANDO_PARAM = "@comando";
        private IfxConnection sqlconn;
        private IfxDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_tiposcomando WHERE tipocomando = ?";
        private string sqlInsert = "INSERT INTO kan_tiposcomando (tipocomando, comando) VALUES (?, ?)";
        private string sqlSelectALL = "SELECT tipocomando, comando FROM kan_tiposcomando";
        private string sqlSelectID = "SELECT tipocomando, comando FROM kan_tiposcomando WHERE tipocomando = ?";
        private string sqlUpdate = "UPDATE kan_tiposcomando SET comando = ? WHERE tipocomando = ?";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_tiposcomando
        /// </summary>
        public kan_tiposcomandoDAL()
        {
            sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
            sqlDA = new IfxDataAdapter();
            sqlDA.TableMappings.Add(kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA, kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA);
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
        /// Comando Delete para el objeto kan_tiposcomando
        /// </summary>
        private IfxCommand GetDelete()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 tipocomando)
        {
            IfxCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[TIPOCOMANDO_PARAM].Value = tipocomando;

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
        /// Comando Insert para el objeto kan_tiposcomando
        /// </summary>
        private IfxCommand GetInsert()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));
            sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_tiposcomandoDAO.TIPOCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(COMANDO_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[COMANDO_PARAM].SourceColumn = kan_tiposcomandoDAO.COMANDO_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_tiposcomandoDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_tiposcomando
        /// </summary>
        private IfxCommand GetSelectALL()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_tiposcomandoDAO SelectALL()
        {
            IfxCommand sqlCmd = GetSelectALL();
            kan_tiposcomandoDAO data = new kan_tiposcomandoDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_tiposcomando
        /// </summary>
        private IfxCommand GetSelectID()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public kan_tiposcomandoDAO SelectID(System.Int32 tipocomando)
        {
            IfxCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[TIPOCOMANDO_PARAM].Value = tipocomando;
            kan_tiposcomandoDAO data = new kan_tiposcomandoDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_tiposcomando
        /// </summary>
        private IfxCommand GetUpdate()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new IfxParameter(COMANDO_PARAM, IfxType.VarChar));

            sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));
            return sqlCmd;
        }

        public void Update(System.Int32 tipocomando, System.String comando)
        {
            IfxCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[COMANDO_PARAM].Value = comando;
            sqlCmd.Parameters[TIPOCOMANDO_PARAM].Value = tipocomando; 
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
