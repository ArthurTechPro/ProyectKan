using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using IBM.Data.Informix;
using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
   [Serializable()]
   public class kan_propiedadesDAL
   {
      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro idpropiedad</summary>
      public static string IDPROPIEDAD_PARAM = "@idpropiedad";
      /// <summary>Constante con el nombre del parametro idprojectp</summary>
      public static string IDPROJECTP_PARAM = "@idprojectp";
      /// <summary>Constante con el nombre del parametro iddata</summary>
      public static string IDDATA_PARAM = "@iddata";
      /// <summary>Constante con el nombre del parametro tipopropiedar</summary>
      public static string TIPOPROPIEDAD_PARAM = "@tipopropiedad";
      /// <summary>Constante con el nombre del parametro nombre</summary>
      public static string NOMBRE_PARAM = "@nombre";
      /// <summary>Constante con el nombre del parametro padre</summary>
      public static string PADRE_PARAM = "@padre";
      /// <summary>Constante con el nombre del parametro creaselect</summary>
      public static string CREASELECT_PARAM = "@creaselect";
      /// <summary>Constante con el nombre del parametro creainsert</summary>
      public static string CREAINSERT_PARAM = "@creainsert";
      /// <summary>Constante con el nombre del parametro creadelete</summary>
      public static string CREADELETE_PARAM = "@creadelete";
      /// <summary>Constante con el nombre del parametro creaupdate</summary>
      public static string CREAUPDATE_PARAM = "@creaupdate";
      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_propiedades WHERE idpropiedad = @";
      private string sqlInsert = "INSERT INTO kan_propiedades (idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate) VALUES (@, @, @, @, @, @, @, @, @)";
      private string sqlSelectALL = "SELECT idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM kan_propiedades";
      private string sqlSelectID = "SELECT idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM kan_propiedades WHERE idpropiedad = @";
      private string sqlSelectPro = "SELECT idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM kan_propiedades WHERE idprojectp = @";
      private string sqlUpdate = "UPDATE kan_propiedades SET idprojectp = @, iddata = @, tipopropiedad = @, nombre = @, padre = @, creaselect = @, creainsert = @, creadelete = @, creaupdate = @ WHERE idpropiedad = @";
      private string sqlSelectTablasBD = "SELECT * FROM kan_propiedades WHERE idprojectp = @ ";
      private string sqlSelectIdTity = "SELECT Max(idpropiedad) AS idpropiedad FROM kan_propiedades";

      /// <summary>
      /// Clase de acceso a datos para el objeto kan_propiedades
      /// </summary>
      public kan_propiedadesDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(kan_propiedadesDAO.KAN_PROPIEDADES_TABLA, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
      }

      /// <summary>
      /// Comando Delete para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetDelete()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idpropiedad)
      {
         IfxCommand sqlCmd = GetDelete();

         sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;

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
      /// Comando Insert para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetInsert()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

         //Parametros Update

         sqlCmd.Parameters.Add(new IfxParameter(IDPROJECTP_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = kan_propiedadesDAO.IDPROJECTP_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDDATA_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDDATA_PARAM].SourceColumn = kan_propiedadesDAO.IDDATA_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOPROPIEDAD_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[TIPOPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRE_PARAM].SourceColumn = kan_propiedadesDAO.NOMBRE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(PADRE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[PADRE_PARAM].SourceColumn = kan_propiedadesDAO.PADRE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREASELECT_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREASELECT_PARAM].SourceColumn = kan_propiedadesDAO.CREASELECT_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREAINSERT_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREAINSERT_PARAM].SourceColumn = kan_propiedadesDAO.CREAINSERT_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREADELETE_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREADELETE_PARAM].SourceColumn = kan_propiedadesDAO.CREADELETE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREAUPDATE_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREAUPDATE_PARAM].SourceColumn = kan_propiedadesDAO.CREAUPDATE_CAMPO;

         return sqlCmd;
      }

      public void Insert(kan_propiedadesDAO ds)
      {

         sqlDA.InsertCommand = GetInsert();
         sqlDA.Update(ds, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);

      }

      /// <summary>
      /// Comando SelectALL para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectALL()
      {
         try
         {
            IfxCommand sqlCmd = GetSelectALL();
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
         }
         catch (Exception ex)
         {
            string ERR = ex.Message;
            throw;
         }

      }


      /// <summary>
      /// Comando SelectALL para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetSelectIdTity()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectIdTity, sqlconn);

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectIdTity()
      {
         IfxCommand sqlCmd = GetSelectIdTity();
         kan_propiedadesDAO data = new kan_propiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
         return data;
      }
      /// <summary>
      /// Comando SelectID para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectID(System.Int32 idpropiedad)
      {
         IfxCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
         kan_propiedadesDAO data = new kan_propiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
         return data;
      }


      /// <summary>
      /// Comando SelectID para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetSelectPro()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectPro, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPROJECTP_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectPro(System.Int32 idprojectp)
      {
         try
         {
            IfxCommand sqlCmd = GetSelectPro();

            sqlCmd.Parameters[IDPROJECTP_PARAM].Value = idprojectp;
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }

      }
      /// <summary>
      /// Comando Update para el objeto kan_propiedades
      /// </summary>
      private IfxCommand GetUpdate()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

         //Parametros Update
         sqlCmd.Parameters.Add(new IfxParameter(IDPROJECTP_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = kan_propiedadesDAO.IDPROJECTP_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDDATA_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDDATA_PARAM].SourceColumn = kan_propiedadesDAO.IDDATA_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(TIPOPROPIEDAD_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[TIPOPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMBRE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMBRE_PARAM].SourceColumn = kan_propiedadesDAO.NOMBRE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(PADRE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[PADRE_PARAM].SourceColumn = kan_propiedadesDAO.PADRE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREASELECT_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREASELECT_PARAM].SourceColumn = kan_propiedadesDAO.CREASELECT_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREAINSERT_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREAINSERT_PARAM].SourceColumn = kan_propiedadesDAO.CREAINSERT_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREADELETE_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREADELETE_PARAM].SourceColumn = kan_propiedadesDAO.CREADELETE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(CREAUPDATE_PARAM, IfxType.Integer));
         sqlCmd.Parameters[CREAUPDATE_PARAM].SourceColumn = kan_propiedadesDAO.CREAUPDATE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.IDPROPIEDAD_CAMPO;

         return sqlCmd;

      }

      public void Update(kan_propiedadesDAO data)
      {
         sqlDA.UpdateCommand = GetUpdate();
         sqlDA.ContinueUpdateOnError = true;
         sqlDA.Update(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);

      }

      private IfxCommand GetSelectTablasBD()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectTablasBD, sqlconn);
         sqlCmd.Parameters.Add(new IfxParameter(IDPROJECTP_PARAM, IfxType.Integer));
         sqlCmd.CommandType = CommandType.Text;
         return sqlCmd;
      }

      public kan_propiedadesDAO SelectTablasBD(Int32 idprojectp)
      {
         if (sqlDA == null)
         {
            throw new System.ObjectDisposedException(GetType().FullName);
         }

         IfxCommand sqlCmd = GetSelectTablasBD();
         sqlCmd.Parameters[IDPROJECTP_PARAM].Value = idprojectp;

         kan_propiedadesDAO data = new kan_propiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
         sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
         return data;
      }

   }
}
