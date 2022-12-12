using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBM.Data.Informix;


namespace ProjectKAN.Data.IFX
{
   public class DataBaseConnection
   {

      private string _SQLQuery;
      private string _SQLTabla;
      private string _ConnectionDataBase;

      public string SQLQuery
      {
         get { return _SQLQuery; }
         set { _SQLQuery = value; }
      }

      public string SQLTabla
      {
         get { return _SQLTabla; }
         set { _SQLTabla = value; }
      }

      public string ConnectionDataBase
      {
         get { return _ConnectionDataBase; }
         set { _ConnectionDataBase = value; }
      }


      public static String DBPlatform()
      {
         return "IFXSQL";
      }

      private static string GetConnectionString()
      {
         return ConfigurationManager.AppSettings["IFXSQLConnectionString"];
      }

      public DataSet SqlEjecut()
      {
         try
         {
            DataSet data = new DataSet();
            IfxConnection IfxConn = new IfxConnection(GetConnectionString());
            IfxConn.Open();
            //IfxTransaction transac = IfxConn.BeginTransaction();
            IfxCommand IfxCmd = new IfxCommand(SQLQuery, IfxConn);
            IfxDataAdapter IfxDA = new IfxDataAdapter(IfxCmd);
            IfxDA.SelectCommand = IfxCmd;
            IfxDA.Fill(data, SQLTabla);
            //transac.Commit();
            IfxConn.Close();
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }


      }

      public DataSet SqlSchema()
      {
         try
         {
            DataSet data = new DataSet();
            IfxConnection IfxConn = new IfxConnection(GetConnectionString());
            //SqlConn.Open();
            //SqlTransaction transac = SqlConn.BeginTransaction();
            IfxCommand IfxCmd = new IfxCommand(SQLQuery, IfxConn);
            IfxDataAdapter IfxDA = new IfxDataAdapter(IfxCmd);
            IfxDA.SelectCommand = IfxCmd;
            IfxDA.FillSchema(data, SchemaType.Source);
            //transac.Commit();
            //SqlConn.Close();
            return data;
         }
         catch (Exception Ex)
         {
            string Error = Ex.Message;
            throw;
         }
      }

   }
}
