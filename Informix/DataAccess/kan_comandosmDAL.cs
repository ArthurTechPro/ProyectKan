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
      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_comandosm WHERE idcomandom = ?";
      private string sqlInsert = "INSERT INTO kan_comandosm (nombrecom, sql, tipocomando, tipoparametro, idcoman) VALUES ( ?, ?, ?, ?, ?)";
      private string sqlSelectALL = "SELECT idcomandom, nombrecom, sql, tipocomando, tipoparametro, idcoman FROM kan_comandosm";
      private string sqlSelectID = "SELECT idcomandom, nombrecom, sql, tipocomando, tipoparametro, idcoman FROM kan_comandosm WHERE idcomandom = ?";
      private string sqlUpdate = "UPDATE kan_comandosm SET nombrecom = ?, sql = ?, tipocomando = ?, tipoparametro = ?, idcoman = ? WHERE idcomandom = ?";


      /// <summary>
      /// Clase de acceso a datos para el objeto kan_comandosm
      /// </summary>
      public kan_comandosmDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(kan_comandosmDAO.KAN_COMANDOSM_TABLA, kan_comandosmDAO.KAN_COMANDOSM_TABLA);
      }

      /// <summary>
      /// Comando Delete para el objeto kan_comandosm
      /// </summary>
      private IfxCommand GetDelete()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDOM_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idcomandom)
      {
         IfxCommand sqlCmd = GetDelete();

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
      private IfxCommand GetInsert()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

         //Parametros Update
         sqlCmd.Parameters.Add(new IfxParameter(NOMBRECOM_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRECOM_PARAM].SourceColumn = kan_comandosmDAO.NOMBRECOM_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(SQL_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_comandosmDAO.SQL_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_comandosmDAO.TIPOCOMANDO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_comandosmDAO.TIPOPARAMETRO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDCOMAN_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandosmDAO.IDCOMAN_CAMPO;

         return sqlCmd;
      }

      public void Insert(kan_comandosmDAO ds)
      {

         sqlDA.InsertCommand = GetInsert();
         sqlDA.Update(ds, kan_comandosmDAO.KAN_COMANDOSM_TABLA);

      }

      /// <summary>
      /// Comando SelectALL para el objeto kan_comandosm
      /// </summary>
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_comandosmDAO SelectALL()
      {
         try
         {
            IfxCommand sqlCmd = GetSelectALL();
            kan_comandosmDAO data = new kan_comandosmDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosmDAO.KAN_COMANDOSM_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }

      }

      /// <summary>
      /// Comando SelectID para el objeto kan_comandosm
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDOM_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_comandosmDAO SelectID(System.Int32 idcomandom)
      {
         IfxCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDCOMANDOM_PARAM].Value = idcomandom;
         kan_comandosmDAO data = new kan_comandosmDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_comandosmDAO.KAN_COMANDOSM_TABLA);
         return data;
      }

      /// <summary>
      /// Comando Update para el objeto kan_comandosm
      /// </summary>
      private IfxCommand GetUpdate()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

         //Parametros CamposRegistro
         sqlCmd.Parameters.Add(new IfxParameter(NOMBRECOM_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(SQL_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));

         sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));

         sqlCmd.Parameters.Add(new IfxParameter(IDCOMAN_PARAM, IfxType.Integer));

         sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDOM_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public void Update(System.Int32 idcomandom, System.String nombrecom, System.String sql, System.Int32 tipocomando, System.Int32 tipoparametro, System.Int32 idcoman)
      {
         IfxCommand sqlCmd = GetUpdate();

         sqlCmd.Parameters[NOMBRECOM_PARAM].Value = nombrecom;
         sqlCmd.Parameters[SQL_PARAM].Value = sql;
         sqlCmd.Parameters[TIPOCOMANDO_PARAM].Value = tipocomando;
         sqlCmd.Parameters[TIPOPARAMETRO_PARAM].Value = tipoparametro;
         sqlCmd.Parameters[IDCOMAN_PARAM].Value = idcoman;
         sqlCmd.Parameters[IDCOMANDOM_PARAM].Value = idcomandom;
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
