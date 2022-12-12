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
   public class kan_relacionesDAL
   {

      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro idrelacion</summary>
      public static string IDRELACION_PARAM = "@idrelacion";
      /// <summary>Constante con el nombre del parametro idpropiedad</summary>
      public static string IDPROPIEDAD_PARAM = "@idpropiedad";
      /// <summary>Constante con el nombre del parametro nomhijo</summary>
      public static string NOMHIJO_PARAM = "@nomhijo";
      /// <summary>Constante con el nombre del parametro nomrelacion</summary>
      public static string NOMRELACION_PARAM = "@nomrelacion";
      /// <summary>Constante con el nombre del parametro relpadre</summary>
      public static string RELPADRE_PARAM = "@relpadre";
      /// <summary>Constante con el nombre del parametro relhijo</summary>
      public static string RELHIJO_PARAM = "@relhijo";
      /// <summary>Constante con el nombre del parametro omitir</summary>
      public static string OMITIR_PARAM = "@omitir";
      private NpgsqlConnection sqlconn;
      private NpgsqlDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_relaciones WHERE idrelacion = @idrelacion";
      private string sqlInsert = "INSERT INTO kan_relaciones (idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir) VALUES (@idpropiedad, @nomhijo, @nomrelacion, @relpadre, @relhijo, @omitir)";
      private string sqlSelectALL = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones";
      private string sqlSelectID = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idrelacion = @idrelacion";
      private string sqlSelectRelPadre = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idpropiedad = @idpropiedad";
      private string sqlSelectRelHijo = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idpropiedad = @idpropiedad";
      private string sqlUpdate = "UPDATE kan_relaciones SET idpropiedad = @idpropiedad, nomhijo = @nomhijo, nomrelacion = @nomrelacion, relpadre = @relpadre, relhijo = @relhijo, omitir = @omitir WHERE idrelacion = @idrelacion";


      /// <summary>
      /// Clase de acceso a datos para el objeto kan_relaciones
      /// </summary>
      public kan_relacionesDAL()
      {
         sqlconn = new NpgsqlConnection(kan_Configuration.ConnectionString);
         sqlDA = new NpgsqlDataAdapter();
         sqlDA.TableMappings.Add(kan_relacionesDAO.KAN_RELACIONES_TABLA, kan_relacionesDAO.KAN_RELACIONES_TABLA);
      }


      /// <summary>
      /// Comando Delete para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetDelete()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDRELACION_PARAM, NpgsqlDbType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idrelacion)
      {
         NpgsqlCommand sqlCmd = GetDelete();

         sqlCmd.Parameters[IDRELACION_PARAM].Value = idrelacion;

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
      /// Comando Insert para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetInsert()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlInsert, sqlconn);

         //Parametros Update
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROPIEDAD_PARAM, NpgsqlDbType.Integer));
         sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_relacionesDAO.IDPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMHIJO_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[NOMHIJO_PARAM].SourceColumn = kan_relacionesDAO.NOMHIJO_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMRELACION_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[NOMRELACION_PARAM].SourceColumn = kan_relacionesDAO.NOMRELACION_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(RELPADRE_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[RELPADRE_PARAM].SourceColumn = kan_relacionesDAO.RELPADRE_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(RELHIJO_PARAM, NpgsqlDbType.Varchar));
         sqlCmd.Parameters[RELHIJO_PARAM].SourceColumn = kan_relacionesDAO.RELHIJO_CAMPO;

         sqlCmd.Parameters.Add(new NpgsqlParameter(OMITIR_PARAM, NpgsqlDbType.Smallint));
         sqlCmd.Parameters[OMITIR_PARAM].SourceColumn = kan_relacionesDAO.OMITIR_CAMPO;

         return sqlCmd;
      }

      public void Insert(kan_relacionesDAO ds)
      {

         sqlDA.InsertCommand = GetInsert();
         sqlDA.Update(ds, kan_relacionesDAO.KAN_RELACIONES_TABLA);

      }

      /// <summary>
      /// Comando SelectALL para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetSelectALL()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_relacionesDAO SelectALL()
      {
         NpgsqlCommand sqlCmd = GetSelectALL();
         kan_relacionesDAO data = new kan_relacionesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
         return data;
      }

      /// <summary>
      /// Comando SelectID para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetSelectRelPadre()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectRelPadre, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROPIEDAD_PARAM, NpgsqlDbType.Integer));

         return sqlCmd;
      }

      public kan_relacionesDAO SelectRelPadre(System.Int32 idpropiedad)
      {
         try
         {
            NpgsqlCommand sqlCmd = GetSelectRelPadre();

            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
            kan_relacionesDAO data = new kan_relacionesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }


      }


      /// <summary>
      /// Comando SelectID para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetSelectRelHijo()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectRelHijo, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMHIJO_PARAM, NpgsqlDbType.Integer));

         return sqlCmd;
      }

      public kan_relacionesDAO SelectRelHijo(System.Int32 nomhijo)
      {
         NpgsqlCommand sqlCmd = GetSelectRelHijo();

         sqlCmd.Parameters[NOMHIJO_PARAM].Value = nomhijo;
         kan_relacionesDAO data = new kan_relacionesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
         return data;
      }


      /// <summary>
      /// Comando SelectID para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetSelectID()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDRELACION_PARAM, NpgsqlDbType.Integer));

         return sqlCmd;
      }

      public kan_relacionesDAO SelectID(System.Int32 idrelacion)
      {
         NpgsqlCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDRELACION_PARAM].Value = idrelacion;
         kan_relacionesDAO data = new kan_relacionesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
         return data;
      }

      /// <summary>
      /// Comando Update para el objeto kan_relaciones
      /// </summary>
      private NpgsqlCommand GetUpdate()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlUpdate, sqlconn);

         //Parametros CamposRegistro
         sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROPIEDAD_PARAM, NpgsqlDbType.Integer));

         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMHIJO_PARAM, NpgsqlDbType.Varchar));

         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMRELACION_PARAM, NpgsqlDbType.Varchar));

         sqlCmd.Parameters.Add(new NpgsqlParameter(RELPADRE_PARAM, NpgsqlDbType.Varchar));

         sqlCmd.Parameters.Add(new NpgsqlParameter(RELHIJO_PARAM, NpgsqlDbType.Varchar));

         sqlCmd.Parameters.Add(new NpgsqlParameter(OMITIR_PARAM, NpgsqlDbType.Smallint));

         sqlCmd.Parameters.Add(new NpgsqlParameter(IDRELACION_PARAM, NpgsqlDbType.Integer));
         return sqlCmd;
      }

      public void Update(System.Int32 idrelacion, System.Int32 idpropiedad, System.String nomhijo, System.String nomrelacion, System.String relpadre, System.String relhijo, System.Int16 omitir)
      {
         NpgsqlCommand sqlCmd = GetUpdate();

         sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
         sqlCmd.Parameters[NOMHIJO_PARAM].Value = nomhijo;
         sqlCmd.Parameters[NOMRELACION_PARAM].Value = nomrelacion;
         sqlCmd.Parameters[RELPADRE_PARAM].Value = relpadre;
         sqlCmd.Parameters[RELHIJO_PARAM].Value = relhijo;
         sqlCmd.Parameters[OMITIR_PARAM].Value = omitir;
         sqlCmd.Parameters[IDRELACION_PARAM].Value = idrelacion;
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
