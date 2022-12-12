using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_dirsalidaDAL 
    {
        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idsalida</summary>
        public static string IDSALIDA_PARAM = "@idsalida";
        /// <summary>Constante con el nombre del parametro idprogect</summary>
        public static string IDPROGECTP_PARAM = "@idprogectp";
        /// <summary>Constante con el nombre del parametro idplantilla</summary>
        public static string IDPLANTILLA_PARAM = "@idplantilla";
        /// <summary>Constante con el nombre del parametro directoriosalida</summary>
        public static string DIRECTORIOSALIDA_PARAM = "@directoriosalida";
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_dirsalida WHERE idsalida = @idsalida";
        private string sqlInsert = "INSERT INTO kan_dirsalida (idprogectp, idplantilla, directoriosalida) VALUES (@idprogectp, @idplantilla, @directoriosalida)";
        private string sqlSelectALL = "SELECT idsalida, idprogectp, idplantilla, directoriosalida FROM kan_dirsalida";
        private string sqlSelectID = "SELECT idsalida, idprogectp, idplantilla, directoriosalida FROM kan_dirsalida WHERE idsalida = @idsalida";
        private string sqlSelectPro = "SELECT idsalida, idprogectp, idplantilla, directoriosalida FROM kan_dirsalida WHERE idprogectp = @idprogectp";
        private string sqlUpdate = "UPDATE kan_dirsalida SET idprogectp = @idprogectp, idplantilla = @idplantilla, directoriosalida = @directoriosalida WHERE idsalida = @idsalida";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_dirsalida
        /// </summary>
        public kan_dirsalidaDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
        }


        /// <summary>
        /// Comando Delete para el objeto kan_dirsalida
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDSALIDA_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idsalida)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDSALIDA_PARAM].Value = idsalida;

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
        /// Comando Insert para el objeto kan_dirsalida
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDSALIDA_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDSALIDA_PARAM].SourceColumn = kan_dirsalidaDAO.IDSALIDA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROGECTP_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROGECTP_PARAM].SourceColumn = kan_dirsalidaDAO.IDPROGECTP_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPLANTILLA_PARAM].SourceColumn = kan_dirsalidaDAO.IDPLANTILLA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(DIRECTORIOSALIDA_PARAM, SqlDbType.VarChar, 259));
            sqlCmd.Parameters[DIRECTORIOSALIDA_PARAM].SourceColumn = kan_dirsalidaDAO.DIRECTORIOSALIDA_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_dirsalidaDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_dirsalida
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_dirsalidaDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_dirsalida
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDSALIDA_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_dirsalidaDAO SelectID(System.Int32 idsalida)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDSALIDA_PARAM].Value = idsalida;
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_dirsalida
        /// </summary>
        private SqlCommand GetSelectPro()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROGECTP_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_dirsalidaDAO SelectPro(System.Int32 idprojectp)
        {
            SqlCommand sqlCmd = GetSelectPro();

            sqlCmd.Parameters[IDPROGECTP_PARAM].Value = idprojectp;
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            return data;
        }
        /// <summary>
        /// Comando Update para el objeto kan_dirsalida
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDSALIDA_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDPROGECTP_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(DIRECTORIOSALIDA_PARAM, SqlDbType.VarChar, 259));

            return sqlCmd;
        }

        public void Update(System.Int32 idsalida, System.Int32 idprogect, System.Int32 idplantilla, System.String directoriosalida)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDSALIDA_PARAM].Value = idsalida;
            sqlCmd.Parameters[IDPROGECTP_PARAM].Value = idprogect;
            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;
            sqlCmd.Parameters[DIRECTORIOSALIDA_PARAM].Value = directoriosalida;
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
