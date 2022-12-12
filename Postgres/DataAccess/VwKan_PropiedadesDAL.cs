using System;
using System.Data;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;
using System.Linq;
using Npgsql;
using NpgsqlTypes;
using ProjectKAN.DAO;
using ProjectKAN.Data.PGSQL;

namespace ProjectKAN.DAL
{
   [Serializable()]
   public class VwKan_PropiedadesDAL : IDisposable
   {

      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro nomproject</summary>
      public static string NOMPROJECT_PARAM = "@nomproject";
      /// <summary>Constante con el nombre del parametro namespaceproject</summary>
      public static string NAMESPACEPROJECT_PARAM = "@namespaceproject";
      /// <summary>Constante con el nombre del parametro nameproject</summary>
      public static string NAMEPROJECT_PARAM = "@nameproject";
      /// <summary>Constante con el nombre del parametro idpropiedad</summary>
      public static string IDPROPIEDAD_PARAM = "@idpropiedad";
      /// <summary>Constante con el nombre del parametro idprogect</summary>
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
      private string sqlSelectALL = "SELECT nomproject, namespaceproject, nameproject, idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM VwKan_Propiedades";
      private string sqlSelectID = "SELECT nomproject, namespaceproject, nameproject, idpropiedad, idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate FROM VwKan_Propiedades WHERE nombre = @nombre";


      /// <summary>
      /// Clase de acceso a datos para el objeto VwKan_Propiedades
      /// </summary>
      public VwKan_PropiedadesDAL()
      {
         sqlconn = new NpgsqlConnection(DataBaseConnection.GetConnectionString());
         sqlDA = new NpgsqlDataAdapter();
         //lDA.TableMappings.Add(VwKan_PropiedadesDAO.VWKAN_PROPIEDADES_TABLA, VwKan_PropiedadesDAO.VWKAN_PROPIEDADES_TABLA);
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
      /// Comando SelectALL para el objeto VwKan_Propiedades
      /// </summary>
      private NpgsqlCommand GetSelectALL()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public VwKan_PropiedadesDAO SelectALL()
      {
         NpgsqlCommand sqlCmd = GetSelectALL();
         VwKan_PropiedadesDAO data = new VwKan_PropiedadesDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, VwKan_PropiedadesDAO.VWKAN_PROPIEDADES_TABLA);
         return data;
      }

      /// <summary>
      /// Comando SelectID para el objeto VwKan_Propiedades
      /// </summary>
      private NpgsqlCommand GetSelectID()
      {
         NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new NpgsqlParameter(NOMBRE_PARAM, NpgsqlDbType.Varchar ));

         return sqlCmd;
      }

      public VwKan_PropiedadesDAO SelectID(System.String nombre)
      {
         try
         {
            NpgsqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[NOMBRE_PARAM].Value = nombre;
            VwKan_PropiedadesDAO data = new VwKan_PropiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, VwKan_PropiedadesDAO.VWKAN_PROPIEDADES_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }

      }

   }
}
