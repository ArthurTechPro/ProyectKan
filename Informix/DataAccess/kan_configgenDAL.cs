using System;
using System.Data;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using IBM.Data.Informix;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
   public class kan_configgenDAL
   {
      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro idconfiggen</summary>
      public static string IDCONFIGGEN_PARAM = "@idconfiggen";
      /// <summary>Constante con el nombre del parametro contante</summary>
      public static string CONTANTE_PARAM = "@contante";
      /// <summary>Constante con el nombre del parametro variable</summary>
      public static string VARIABLE_PARAM = "@variable";
      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_configgen WHERE idconfiggen = ?";
      private string sqlInsert = "INSERT INTO kan_configgen (contante, variable) VALUES ( ?, ?)";
      private string sqlSelectALL = "SELECT idconfiggen, contante, variable FROM kan_configgen";
      private string sqlSelectID = "SELECT idconfiggen, contante, variable FROM kan_configgen WHERE idconfiggen = ?";
      private string sqlUpdate = "UPDATE kan_configgen SET contante = ?, variable = ? WHERE idconfiggen = ? ";


      /// <summary>
      /// Clase de acceso a datos para el objeto kan_configgen
      /// </summary>
      public kan_configgenDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(kan_configgenDAO.KAN_CONFIGGEN_TABLA, kan_configgenDAO.KAN_CONFIGGEN_TABLA);
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
      /// Comando Delete para el objeto kan_configgen
      /// </summary>
      private IfxCommand GetDelete()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDCONFIGGEN_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idconfiggen)
      {
         IfxCommand sqlCmd = GetDelete();

         sqlCmd.Parameters[IDCONFIGGEN_PARAM].Value = idconfiggen;

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
      /// Comando Insert para el objeto kan_configgen
      /// </summary>
      private IfxCommand GetInsert()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

         sqlCmd.Parameters.Add(new IfxParameter(CONTANTE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[CONTANTE_PARAM].SourceColumn = kan_configgenDAO.CONTANTE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(VARIABLE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[VARIABLE_PARAM].SourceColumn = kan_configgenDAO.VARIABLE_CAMPO;

         return sqlCmd;
      }

      public void Insert(kan_configgenDAO ds)
      {

         sqlDA.InsertCommand = GetInsert();
         sqlDA.Update(ds, kan_configgenDAO.KAN_CONFIGGEN_TABLA);

      }

      /// <summary>
      /// Comando SelectALL para el objeto kan_configgen
      /// </summary>
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_configgenDAO SelectALL()
      {
         try
         {
            IfxCommand sqlCmd = GetSelectALL();
            kan_configgenDAO data = new kan_configgenDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_configgenDAO.KAN_CONFIGGEN_TABLA);
            return data;
         }
         catch (Exception ex)
         {
            string MES = ex.Message;
            throw;
         }

      }

      /// <summary>
      /// Comando SelectID para el objeto kan_configgen
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDCONFIGGEN_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_configgenDAO SelectID(System.Int32 idconfiggen)
      {
         IfxCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDCONFIGGEN_PARAM].Value = idconfiggen;
         kan_configgenDAO data = new kan_configgenDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_configgenDAO.KAN_CONFIGGEN_TABLA);
         return data;
      }

      /// <summary>
      /// Comando Update para el objeto kan_configgen
      /// </summary>
      private IfxCommand GetUpdate()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

         //Parametros CamposRegistro
         sqlCmd.Parameters.Add(new IfxParameter(CONTANTE_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(VARIABLE_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(IDCONFIGGEN_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public void Update(System.Int32 idconfiggen, System.String contante, System.String variable)
      {
         IfxCommand sqlCmd = GetUpdate();

         sqlCmd.Parameters[CONTANTE_PARAM].Value = contante;
         sqlCmd.Parameters[VARIABLE_PARAM].Value = variable;
         sqlCmd.Parameters[IDCONFIGGEN_PARAM].Value = idconfiggen;

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
