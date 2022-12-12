
namespace ProjectKAN.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Text;
    using ProjectKAN.DAO;   
 
	[Serializable()]
	public class VwKan_DirPlantillaDAL : IDisposable
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idplantilla</summary>
        public static string IDPLANTILLA_PARAM = "@idplantilla";
        /// <summary>Constante con el nombre del parametro idprogectp</summary>
        public static string IDPROGECTP_PARAM = "@idprogectp";
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
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlSelectALL = "SELECT idplantilla, idprogectp, idsalida, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx, directoriosalida FROM VwKan_DirPlantilla";
        private string sqlSelectID = "SELECT idplantilla, idprogectp, idsalida, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx, directoriosalida FROM VwKan_DirPlantilla WHERE idplantilla = @idplantilla AND idprogectp = @idprogectp";


        /// <summary>
        /// Clase de acceso a datos para el objeto VwKan_DirPlantilla
        /// </summary>
        public VwKan_DirPlantillaDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
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
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public VwKan_DirPlantillaDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            VwKan_DirPlantillaDAO data = new VwKan_DirPlantillaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto VwKan_DirPlantilla
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDPROGECTP_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public VwKan_DirPlantillaDAO SelectID(System.Int32 idplantilla, System.Int32 idprogectp)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;

            sqlCmd.Parameters[IDPROGECTP_PARAM].Value = idprogectp;
            VwKan_DirPlantillaDAO data = new VwKan_DirPlantillaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
            return data;
        }
	}
}
