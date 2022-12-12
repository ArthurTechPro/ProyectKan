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
   public class kan_tiposdatosDAL : IDisposable
   {


      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro tipo</summary>
      public static string TIPO_PARAM = "@tipo";
      /// <summary>Constante con el nombre del parametro dbplatform</summary>
      public static string DBPLATFORM_PARAM = "@dbplatform";
      /// <summary>Constante con el nombre del parametro typedatasql</summary>
      public static string TYPEDATASQL_PARAM = "@typedatasql";
      /// <summary>Constante con el nombre del parametro codigosql</summary>
      public static string CODIGOSQL_PARAM = "@codigosql";
      /// <summary>Constante con el nombre del parametro nombresql</summary>
      public static string NOMBRESQL_PARAM = "@nombresql";
      /// <summary>Constante con el nombre del parametro nombresql</summary>
      public static string NOMBRECOD_PARAM = "@nombrecod";
      /// <summary>Constante con el nombre del parametro nombresql</summary>
      public static string NOMBRETIPO_PARAM = "@nombretipo";
      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_tiposdatos WHERE tipo = ? ";
      private string sqlInsert = "INSERT INTO kan_tiposdatos (dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo) VALUES ( ?, ?, ?, ?, ?)";
      private string sqlSelectALL = "SELECT tipo, dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo FROM kan_tiposdatos";
      private string sqlSelectID = "SELECT tipo, dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo FROM kan_tiposdatos WHERE tipo = ?";
      private string sqlSelectCod = "SELECT tipo, dbplatform, typedatasql, codigosql, nombresql, nombrecod, nombretipo FROM kan_tiposdatos WHERE ( codigosql = ? ) AND ( dbplatform = ? )";
      private string sqlUpdate = "UPDATE kan_tiposdatos SET dbplatform = ?, typedatasql = ?, codigosql = ?, nombresql = ?, nombrecod = ?, nombretipo = ? WHERE tipo = ?";


      /// <summary>
      /// Clase de acceso a datos para el objeto kan_tiposdatos
      /// </summary>
      public kan_tiposdatosDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
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
      /// Comando Delete para el objeto kan_tiposdatos
      /// </summary>
      private IfxCommand GetDelete()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(TIPO_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 tipo)
      {
         IfxCommand sqlCmd = GetDelete();

         sqlCmd.Parameters[TIPO_PARAM].Value = tipo;

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
      /// Comando Insert para el objeto kan_tiposdatos
      /// </summary>
      private IfxCommand GetInsert()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

         sqlCmd.Parameters.Add(new IfxParameter(DBPLATFORM_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[DBPLATFORM_PARAM].SourceColumn = kan_tiposdatosDAO.DBPLATFORM_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TYPEDATASQL_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[TYPEDATASQL_PARAM].SourceColumn = kan_tiposdatosDAO.TYPEDATASQL_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CODIGOSQL_PARAM, IfxType.SmallInt));
         sqlCmd.Parameters[CODIGOSQL_PARAM].SourceColumn = kan_tiposdatosDAO.CODIGOSQL_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRESQL_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRESQL_PARAM].SourceColumn = kan_tiposdatosDAO.NOMBRESQL_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRECOD_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRESQL_PARAM].SourceColumn = kan_tiposdatosDAO.NOMBRECOD_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRETIPO_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRESQL_PARAM].SourceColumn = kan_tiposdatosDAO.NOMBRETIPO_CAMPO;

         return sqlCmd;
      }

      public void Insert(kan_tiposdatosDAO ds)
      {
         sqlDA.InsertCommand = GetInsert();
         sqlDA.Update(ds, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);

      }

      /// <summary>
      /// Comando SelectALL para el objeto kan_tiposdatos
      /// </summary>
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_tiposdatosDAO SelectALL()
      {
         IfxCommand sqlCmd = GetSelectALL();
         kan_tiposdatosDAO data = new kan_tiposdatosDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
         return data;
      }

      /// <summary>
      /// Comando SelectID para el objeto kan_tiposdatos
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(TIPO_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_tiposdatosDAO SelectID(System.Int32 tipo)
      {
         IfxCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[TIPO_PARAM].Value = tipo;
         kan_tiposdatosDAO data = new kan_tiposdatosDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
         return data;
      }


      /// <summary>
      /// Comando SelectID para el objeto kan_tiposdatos
      /// </summary>
      private IfxCommand GetSelectCod()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectCod, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(CODIGOSQL_PARAM, IfxType.Integer));
         sqlCmd.Parameters.Add(new IfxParameter(DBPLATFORM_PARAM, IfxType.VarChar));

         return sqlCmd;
      }

      public kan_tiposdatosDAO SelectCod(System.Int32 codigosql, string dbplatform)
      {
         try
         {
            IfxCommand sqlCmd = GetSelectCod();

            sqlCmd.Parameters[CODIGOSQL_PARAM].Value = codigosql;
            sqlCmd.Parameters[DBPLATFORM_PARAM].Value = dbplatform;
            kan_tiposdatosDAO data = new kan_tiposdatosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }

      }

      /// <summary>
      /// Comando Update para el objeto kan_tiposdatos
      /// </summary>
      private IfxCommand GetUpdate()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

         //Parametros CamposRegistro
         sqlCmd.Parameters.Add(new IfxParameter(DBPLATFORM_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(TYPEDATASQL_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(CODIGOSQL_PARAM, IfxType.SmallInt));

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRESQL_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRECOD_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRETIPO_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(TIPO_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Update(System.Int32 tipo, System.String dbplatform, System.String typedatasql, System.Int16 codigosql, System.String nombresql, System.String nombrecod, System.String nombretipo)
      {
         IfxCommand sqlCmd = GetUpdate();

         sqlCmd.Parameters[DBPLATFORM_PARAM].Value = dbplatform;
         sqlCmd.Parameters[TYPEDATASQL_PARAM].Value = typedatasql;
         sqlCmd.Parameters[CODIGOSQL_PARAM].Value = codigosql;
         sqlCmd.Parameters[NOMBRESQL_PARAM].Value = nombresql;
         sqlCmd.Parameters[NOMBRECOD_PARAM].Value = nombrecod;
         sqlCmd.Parameters[NOMBRETIPO_PARAM].Value = nombretipo;
         sqlCmd.Parameters[TIPO_PARAM].Value = tipo;
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
