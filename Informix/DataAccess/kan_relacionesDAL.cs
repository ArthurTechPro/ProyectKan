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
      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlDelete = "DELETE FROM kan_relaciones WHERE idrelacion = ?";
      private string sqlInsert = "INSERT INTO kan_relaciones (idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir) VALUES (?, ?, ?, ?, ?, ?)";
      private string sqlSelectALL = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones";
      private string sqlSelectID = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idrelacion = ?";
      private string sqlSelectRelPadre = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idpropiedad = ?";
      private string sqlSelectRelHijo = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE nomhijo = ?";
      private string sqlUpdate = "UPDATE kan_relaciones SET idpropiedad = ?, nomhijo = ?, nomrelacion = ?, relpadre = ?, relhijo = ?, omitir = ? WHERE idrelacion = ?";


      /// <summary>
      /// Clase de acceso a datos para el objeto kan_relaciones
      /// </summary>
      public kan_relacionesDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(kan_relacionesDAO.KAN_RELACIONES_TABLA, kan_relacionesDAO.KAN_RELACIONES_TABLA);
      }


      /// <summary>
      /// Comando Delete para el objeto kan_relaciones
      /// </summary>
      private IfxCommand GetDelete()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDRELACION_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Delete(System.Int32 idrelacion)
      {
         IfxCommand sqlCmd = GetDelete();

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
      private IfxCommand GetInsert()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

         //Parametros Update
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));
         sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_relacionesDAO.IDPROPIEDAD_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMHIJO_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMHIJO_PARAM].SourceColumn = kan_relacionesDAO.NOMHIJO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(NOMRELACION_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[NOMRELACION_PARAM].SourceColumn = kan_relacionesDAO.NOMRELACION_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(RELPADRE_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[RELPADRE_PARAM].SourceColumn = kan_relacionesDAO.RELPADRE_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(RELHIJO_PARAM, IfxType.VarChar));
         sqlCmd.Parameters[RELHIJO_PARAM].SourceColumn = kan_relacionesDAO.RELHIJO_CAMPO;

         sqlCmd.Parameters.Add(new IfxParameter(OMITIR_PARAM, IfxType.SmallInt));
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
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public kan_relacionesDAO SelectALL()
      {
         IfxCommand sqlCmd = GetSelectALL();
         kan_relacionesDAO data = new kan_relacionesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
         return data;
      }

      /// <summary>
      /// Comando SelectID para el objeto kan_relaciones
      /// </summary>
      private IfxCommand GetSelectRelPadre()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectRelPadre, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_relacionesDAO SelectRelPadre(System.Int32 idpropiedad)
      {
         try
         {
            IfxCommand sqlCmd = GetSelectRelPadre();

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
      private IfxCommand GetSelectRelHijo()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectRelHijo, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(NOMHIJO_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_relacionesDAO SelectRelHijo(System.Int32 nomhijo)
      {
         IfxCommand sqlCmd = GetSelectRelHijo();

         sqlCmd.Parameters[NOMHIJO_PARAM].Value = nomhijo;
         kan_relacionesDAO data = new kan_relacionesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
         return data;
      }


      /// <summary>
      /// Comando SelectID para el objeto kan_relaciones
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDRELACION_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public kan_relacionesDAO SelectID(System.Int32 idrelacion)
      {
         IfxCommand sqlCmd = GetSelectID();

         sqlCmd.Parameters[IDRELACION_PARAM].Value = idrelacion;
         kan_relacionesDAO data = new kan_relacionesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
         return data;
      }

      /// <summary>
      /// Comando Update para el objeto kan_relaciones
      /// </summary>
      private IfxCommand GetUpdate()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

         //Parametros CamposRegistro
         sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));

         sqlCmd.Parameters.Add(new IfxParameter(NOMHIJO_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(NOMRELACION_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(RELPADRE_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(RELHIJO_PARAM, IfxType.VarChar));

         sqlCmd.Parameters.Add(new IfxParameter(OMITIR_PARAM, IfxType.SmallInt));

         sqlCmd.Parameters.Add(new IfxParameter(IDRELACION_PARAM, IfxType.Integer));
         return sqlCmd;
      }

      public void Update(System.Int32 idrelacion, System.Int32 idpropiedad, System.String nomhijo, System.String nomrelacion, System.String relpadre, System.String relhijo, System.Int16 omitir)
      {
         IfxCommand sqlCmd = GetUpdate();

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
