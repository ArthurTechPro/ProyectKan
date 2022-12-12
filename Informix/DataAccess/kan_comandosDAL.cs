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
   public class kan_comandosDAL : IDisposable
   {

      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro idcomando</summary>
      public static string IDCOMANDO_PARAM = "@idcomando";
      /// <summary>Constante con el nombre del parametro idpropiedad</summary>
      public static string IDPROPIEDAD_PARAM = "@idpropiedad";
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
      /// <summary>Constante con el nombre del parametro parametros</summary>
      public static string PARAMETROS_PARAM = "@parametros";
      /// <summary>Constante con el nombre del parametro tipoimplementa</summary>
      public static string TIPOIMPLEMENTA_PARAM = "@tipoimplementa";
      /// <summary>Constante con el nombre del parametro nombrecom</summary>
      public static string SPROPIEDAD_PARAM = "@spropiedad";


      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_comandos WHERE idcomando = ?";
      private string sqlInsert = "INSERT INTO kan_comandos (idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
      private string sqlSelectALL = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos";
      private string sqlSelectID = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos WHERE idcomando = ?";
      private string sqlSelectProp = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos WHERE idpropiedad = ?";
      private string sqlUpdate = "UPDATE kan_comandos SET idpropiedad = ?, nombrecom = ?, sql = ?, tipocomando = ?, tipoparametro = ?, idcoman = ?, parametros = ?, tipoimplementa = ? WHERE idcomando = ?";


      /// <summary>
      /// Clase de acceso a datos para el objeto kan_comandos
      /// </summary>
      public kan_comandosDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(kan_comandosDAO.KAN_COMANDOS_TABLA, kan_comandosDAO.KAN_COMANDOS_TABLA);
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
      /// Comando Delete para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetDelete()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDO_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idcomando)
      {
         IfxCommand sqlCmd = GetDelete();

         sqlCmd.Parameters[IDCOMANDO_PARAM].Value = idcomando;

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
      /// Comando Insert para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetInsert()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

         //Parametros Update
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_comandosDAO.IDPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRECOM_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRECOM_PARAM].SourceColumn = kan_comandosDAO.NOMBRECOM_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(SQL_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_comandosDAO.SQL_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_comandosDAO.TIPOCOMANDO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_comandosDAO.TIPOPARAMETRO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDCOMAN_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandosDAO.IDCOMAN_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(PARAMETROS_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[PARAMETROS_PARAM].SourceColumn = kan_comandosDAO.PARAMETROS_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOIMPLEMENTA_PARAM, IfxType.SmallInt));
         sqlCmd.Parameters[TIPOIMPLEMENTA_PARAM].SourceColumn = kan_comandosDAO.TIPOIMPLEMENTA_CAMPO;

         return sqlCmd;
      }

      public void Insert(kan_comandosDAO ds)
      {
         try
         {
            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_comandosDAO.KAN_COMANDOS_TABLA);
         }
         catch (Exception EX)
         {
            String ERR = EX.Message;
            throw;
         }

      }

      /// <summary>
      /// Comando SelectALL para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_comandosDAO SelectALL()
      {
         IfxCommand sqlCmd = GetSelectALL();
         kan_comandosDAO data = new kan_comandosDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
         return data;
      }

      /// <summary>
      /// Comando SelectID para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDO_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_comandosDAO SelectID(System.Int32 idcomando)
      {
         IfxCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDCOMANDO_PARAM].Value = idcomando;
         kan_comandosDAO data = new kan_comandosDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
         return data;
      }


      /// <summary>
      /// Comando SelectProp para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetSelectProp()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectProp, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_comandosDAO SelectProp(System.Int32 idporpiedad)
      {
         try
         {
            IfxCommand sqlCmd = GetSelectProp();

            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idporpiedad;
            kan_comandosDAO data = new kan_comandosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }

      }

      /*
              /// <summary>
              /// Comando SelectProp para el objeto kan_comandos
              /// </summary>
              private IfxCommand GetSelectNomCom()
              {
                  IfxCommand sqlCmd = new IfxCommand(sqlSelectNomCom, sqlconn);

                  //Parametros CamposLlave
                  sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDO_PARAM, IfxType.Int, 4));

                  return sqlCmd;
              }


              public kan_comandosDAO SelectNomCom(string nombre,string nombrecom)
              {
                  IfxCommand sqlCmd = GetSelectNomCom();

                  sqlCmd.Parameters[NOMBRECOM_PARAM].Value = nombre;
                  sqlCmd.Parameters[].Value = idcomando;
                  kan_comandosDAO data = new kan_comandosDAO();
                  sqlDA.SelectCommand = sqlCmd;
                  sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
                  return data;
              }
              */

      /// <summary>
      /// Comando SelectProp para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetSelectComandosBD(String spropiedad)
      {
         string sqlSelectComandDB = "SELECT idcomando, idpropiedad, nombrecom, sql, tipocomando, tipoparametro, idcoman, parametros, tipoimplementa FROM kan_comandos WHERE ( idpropiedad IN (" + spropiedad + ") )";

         IfxCommand sqlCmd = new IfxCommand(sqlSelectComandDB, sqlconn);
         return sqlCmd;
      }

      public kan_comandosDAO SelectComandosBD(String spropiedad)
      {
         IfxCommand sqlCmd = GetSelectComandosBD(spropiedad);

         kan_comandosDAO data = new kan_comandosDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
         return data;
      }


      /// <summary>
      /// Comando Update para el objeto kan_comandos
      /// </summary>
      private IfxCommand GetUpdate()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);
         //Parametros Update
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_comandosDAO.IDPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRECOM_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRECOM_PARAM].SourceColumn = kan_comandosDAO.NOMBRECOM_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(SQL_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[SQL_PARAM].SourceColumn = kan_comandosDAO.SQL_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOCOMANDO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[TIPOCOMANDO_PARAM].SourceColumn = kan_comandosDAO.TIPOCOMANDO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOPARAMETRO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[TIPOPARAMETRO_PARAM].SourceColumn = kan_comandosDAO.TIPOPARAMETRO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDCOMAN_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandosDAO.IDCOMAN_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(PARAMETROS_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[PARAMETROS_PARAM].SourceColumn = kan_comandosDAO.PARAMETROS_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOIMPLEMENTA_PARAM, IfxType.SmallInt));
         sqlCmd.Parameters[TIPOIMPLEMENTA_PARAM].SourceColumn = kan_comandosDAO.TIPOIMPLEMENTA_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDCOMANDO_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDCOMANDO_PARAM].SourceColumn = kan_comandosDAO.IDCOMANDO_CAMPO;
         return sqlCmd;
      }

      public void Update(kan_comandosDAO data)
      {
         sqlDA.UpdateCommand = GetUpdate();
         sqlDA.ContinueUpdateOnError = true;
         sqlDA.Update(data, kan_comandosDAO.KAN_COMANDOS_TABLA);
      }

   }
}
