
namespace ProjectKAN.DAL
{
   using System;
   using System.Data;
   using System.Runtime.Serialization;
   using System.Diagnostics;
   using System.ComponentModel;
   using IBM.Data.Informix;
   using System.Text;
   using ProjectKAN.DAO;

   [Serializable()]
   public class VwKan_DirPlantillaDAL : IDisposable
   {

      //Parametros para el llamado de comandos

      /// <summary>Constante con el nombre del parametro idplantilla</summary>
      public static string IDPLANTILLA_PARAM = "@idplantilla";
      /// <summary>Constante con el nombre del parametro idprogectp</summary>
      public static string IDPROJECT_PARAM = "@idproject";
      /// <summary>Constante con el nombre del parametro idsalida</summary>
      public static string IDSALIDA_PARAM = "@idsalida";
      /// <summary>Constante con el nombre del parametro descrip</summary>
      public static string DESCRIP_PARAM = "@descrip";
      /// <summary>Constante con el nombre del parametro tipoarchivo</summary>
      public static string TIPOARCHIVO_PARAM = "@tipoarchivo";
      /// <summary>Constante con el nombre del parametro plantilla</summary>
      public static string PLANTILLA_PARAM = "@plantilla";
      /// <summary>Constante con el nombre del parametro formatonom</summary>
      public static string FORMATONOM_PARAM = "@formatonom";
      /// <summary>Constante con el nombre del parametro limpiaaspx</summary>
      public static string LIMPIAASPX_PARAM = "@limpiaaspx";
      /// <summary>Constante con el nombre del parametro directoriosalida</summary>
      public static string DIRECTORIOSALIDA_PARAM = "@directoriosalida";
      private IfxConnection sqlconn;
      private IfxDataAdapter sqlDA;

      //Sentencias SQL o Procedimientos almacenados
      private string sqlSelectALL = "SELECT idplantilla, idproject, idsalida, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx, directoriosalida FROM VwKan_DirPlantilla";
      private string sqlSelectID = "SELECT idplantilla, idproject, idsalida, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx, directoriosalida FROM VwKan_DirPlantilla WHERE idplantilla = ? AND idproject = ?";
      private string sqlSelectProp = "SELECT idplantilla, idproject, idsalida, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx, directoriosalida FROM VwKan_DirPlantilla WHERE idproject = ? ";


      /// <summary>
      /// Clase de acceso a datos para el objeto VwKan_DirPlantilla
      /// </summary>
      public VwKan_DirPlantillaDAL()
      {
         sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
         sqlDA = new IfxDataAdapter();
         sqlDA.TableMappings.Add(VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA, VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
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
      /// Comando SelectALL para el objeto VwKan_DirPlantilla
      /// </summary>
      private IfxCommand GetSelectALL()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

         return sqlCmd;
      }

      public VwKan_DirPlantillaDAO SelectALL()
      {
         IfxCommand sqlCmd = GetSelectALL();
         VwKan_DirPlantillaDAO data = new VwKan_DirPlantillaDAO();
         sqlDA.SelectCommand = sqlCmd;
         sqlDA.Fill(data, VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
         return data;
      }

      /// <summary>
      /// Comando SelectID para el objeto VwKan_DirPlantilla
      /// </summary>
      private IfxCommand GetSelectID()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPLANTILLA_PARAM, IfxType.Integer));

         sqlCmd.Parameters.Add(new IfxParameter(IDPROJECT_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public VwKan_DirPlantillaDAO SelectID(System.Int32 idplantilla, System.Int32 idprogectp)
      {

         try
         {
            IfxCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idprogectp;
            VwKan_DirPlantillaDAO data = new VwKan_DirPlantillaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
            return data;
         }
         catch (Exception EX)
         {
            string ERR = EX.Message;
            throw;
         }


      }

      /// <summary>
      /// Comando SelectID para el objeto VwKan_DirPlantilla
      /// </summary>
      private IfxCommand GetSelectProp()
      {
         IfxCommand sqlCmd = new IfxCommand(sqlSelectProp, sqlconn);

         //Parametros CamposLlave
         sqlCmd.Parameters.Add(new IfxParameter(IDPROJECT_PARAM, IfxType.Integer));

         return sqlCmd;
      }

      public VwKan_DirPlantillaDAO SelectProp(System.Int32 idprogect)
      {
         try
         {
            IfxCommand sqlCmd = GetSelectProp();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idprogect;
            VwKan_DirPlantillaDAO data = new VwKan_DirPlantillaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
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
