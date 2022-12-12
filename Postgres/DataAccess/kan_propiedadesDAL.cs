using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using Npgsql;
using NpgsqlTypes;
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
      private NpgsqlConnection sqlconn;
      private NpgsqlDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_propiedades WHERE idpropiedad = @idpropiedad";
      private string sqlInsert = "INSERT INTO kan_propiedades (idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate) VALUES (@idprojectp, @iddata, @tipopropiedad,@nombre, @padre, @creaselect, @creainsert, @creadelete, @creaupdate)";
      private string sqlSelectALL = "SELECT idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM kan_propiedades";
      private string sqlSelectID = "SELECT idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM kan_propiedades WHERE idpropiedad = @idpropiedad";
      private string sqlSelectPro = "SELECT idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM kan_propiedades WHERE idprojectp = @idprojectp";
      private string sqlUpdate = "UPDATE kan_propiedades SET idprojectp = @idprojectp, iddata = @iddata, tipopropiedad = @tipopropiedad, nombre = @nombre, padre = @padre, creaselect = @creaselect, creainsert = @creainsert, creadelete = @creadelete, creaupdate = @creaupdate WHERE idpropiedad = @idpropiedad";
      private string sqlSelectTablasBD = "SELECT * FROM kan_propiedades WHERE idprojectp = @idprojectp ";
      private string sqlSelectIdTity = "SELECT Max(idpropiedad) AS idpropiedad FROM kan_propiedades";

      /// <summary>
      /// Clase de acceso a datos para el objeto kan_propiedades
      /// </summary>
      public kan_propiedadesDAL()
      {
         sqlconn = new NpgsqlConnection(kan_Configuration.ConnectionString);
         sqlDA = new NpgsqlDataAdapter();
         sqlDA.TableMappings.Add(kan_propiedadesDAO.KAN_PROPIEDADES_TABLA, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
      }

      /// <summary>
      /// Comando Delete para el objeto kan_propiedades
      /// </summary>
      private NpgsqlCommand GetDelete()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROPIEDAD_PARAM, NpgsqlDbType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idpropiedad)
      {
         NpgsqlCommand sqlCmd = GetDelete();

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
      private NpgsqlCommand GetInsert()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlInsert, sqlconn);

         //Parametros Update

         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECTP_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = kan_propiedadesDAO.IDPROJECTP_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(IDDATA_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[IDDATA_PARAM].SourceColumn = kan_propiedadesDAO.IDDATA_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(TIPOPROPIEDAD_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[TIPOPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMBRE_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[NOMBRE_PARAM].SourceColumn = kan_propiedadesDAO.NOMBRE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(PADRE_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[PADRE_PARAM].SourceColumn = kan_propiedadesDAO.PADRE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREASELECT_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREASELECT_PARAM].SourceColumn = kan_propiedadesDAO.CREASELECT_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREAINSERT_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREAINSERT_PARAM].SourceColumn = kan_propiedadesDAO.CREAINSERT_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREADELETE_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREADELETE_PARAM].SourceColumn = kan_propiedadesDAO.CREADELETE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREAUPDATE_PARAM, NpgsqlDbType.Integer));
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
      private NpgsqlCommand GetSelectALL()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectALL()
      {
         try
         {
            NpgsqlCommand sqlCmd = GetSelectALL();
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
      private NpgsqlCommand GetSelectIdTity()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectIdTity, sqlconn);

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectIdTity()
      {
         NpgsqlCommand sqlCmd = GetSelectIdTity();
         kan_propiedadesDAO data = new kan_propiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
         return data;
      }
      /// <summary>
      /// Comando SelectID para el objeto kan_propiedades
      /// </summary>
      private NpgsqlCommand GetSelectID()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROPIEDAD_PARAM, NpgsqlDbType.Integer));

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectID(System.Int32 idpropiedad)
      {
         NpgsqlCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
         kan_propiedadesDAO data = new kan_propiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
         return data;
      }


      /// <summary>
      /// Comando SelectID para el objeto kan_propiedades
      /// </summary>
      private NpgsqlCommand GetSelectPro()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectPro, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECTP_PARAM, NpgsqlDbType.Integer));
         //sqlCmd.Parameters[IDPROJECTP_PARAM].Direction = ParameterDirection.Input;
         //sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = IDPROJECTP_PARAM;

         return sqlCmd;
      }

      public kan_propiedadesDAO SelectPro(System.Int32 idprojectp)
      {
         try
         {
            NpgsqlCommand sqlCmd = GetSelectPro();

            //sqlCmd.Parameters.AddWithValue(IDPROJECTP_PARAM, idprojectp);
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
      private NpgsqlCommand GetUpdate()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlUpdate, sqlconn);

         //Parametros Update
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECTP_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = kan_propiedadesDAO.IDPROJECTP_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(IDDATA_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[IDDATA_PARAM].SourceColumn = kan_propiedadesDAO.IDDATA_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(TIPOPROPIEDAD_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[TIPOPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMBRE_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[NOMBRE_PARAM].SourceColumn = kan_propiedadesDAO.NOMBRE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(PADRE_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[PADRE_PARAM].SourceColumn = kan_propiedadesDAO.PADRE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREASELECT_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREASELECT_PARAM].SourceColumn = kan_propiedadesDAO.CREASELECT_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREAINSERT_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREAINSERT_PARAM].SourceColumn = kan_propiedadesDAO.CREAINSERT_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREADELETE_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREADELETE_PARAM].SourceColumn = kan_propiedadesDAO.CREADELETE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(CREAUPDATE_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[CREAUPDATE_PARAM].SourceColumn = kan_propiedadesDAO.CREAUPDATE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROPIEDAD_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.IDPROPIEDAD_CAMPO;

         return sqlCmd;

      }

      public void Update(kan_propiedadesDAO data)
      {
         sqlDA.UpdateCommand = GetUpdate();
         sqlDA.ContinueUpdateOnError = true;
         sqlDA.Update(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);

      }

      private NpgsqlCommand GetSelectTablasBD()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectTablasBD, sqlconn);
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECTP_PARAM, NpgsqlDbType.Integer));
         sqlCmd.CommandType = CommandType.Text;
         return sqlCmd;
      }

      public kan_propiedadesDAO SelectTablasBD(Int32 idprojectp)
      {
         if (sqlDA == null)
         {
            throw new System.ObjectDisposedException(GetType().FullName);
         }

         NpgsqlCommand sqlCmd = GetSelectTablasBD();
         sqlCmd.Parameters[IDPROJECTP_PARAM].Value = idprojectp;

         kan_propiedadesDAO data = new kan_propiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
         sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
         return data;
      }

   }
}
