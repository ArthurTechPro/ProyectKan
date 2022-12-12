using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
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
        public static string IDPROJECT_PARAM = "@idproject";
        /// <summary>Constante con el nombre del parametro idplantilla</summary>
        public static string IDPLANTILLA_PARAM = "@idplantilla";
        /// <summary>Constante con el nombre del parametro directoriosalida</summary>
        public static string DIRECTORIOSALIDA_PARAM = "@directoriosalida";
        private NpgsqlConnection sqlconn;
        private NpgsqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_dirsalida WHERE idsalida = @idsalida";
        private string sqlInsert = "INSERT INTO kan_dirsalida (idproject, idplantilla, directoriosalida) VALUES (@idproject, @idplantilla, @directoriosalida)";
        private string sqlSelectALL = "SELECT idsalida, idproject, idplantilla, directoriosalida FROM kan_dirsalida";
        private string sqlSelectID = "SELECT idsalida, idproject, idplantilla, directoriosalida FROM kan_dirsalida WHERE idsalida = @idsalida";
        private string sqlSelectPro = "SELECT idsalida, idproject, idplantilla, directoriosalida FROM kan_dirsalida WHERE idprogectp = @idprogectp";
        private string sqlUpdate = "UPDATE kan_dirsalida SET idproject = @idproject, idplantilla = @idplantilla, directoriosalida = @directoriosalida WHERE idsalida = @idsalida";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_dirsalida
        /// </summary>
        public kan_dirsalidaDAL()
        {
            sqlconn = new NpgsqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new NpgsqlDataAdapter();
            sqlDA.TableMappings.Add(kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
        }


        /// <summary>
        /// Comando Delete para el objeto kan_dirsalida
        /// </summary>
        private NpgsqlCommand GetDelete()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDSALIDA_PARAM, NpgsqlDbType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 idsalida)
        {
            NpgsqlCommand sqlCmd = GetDelete();

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
        private NpgsqlCommand GetInsert()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECT_PARAM, NpgsqlDbType.Integer));
            sqlCmd.Parameters[IDPROJECT_PARAM].SourceColumn = kan_dirsalidaDAO.IDPROJECT_CAMPO;

            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPLANTILLA_PARAM, NpgsqlDbType.Integer));
            sqlCmd.Parameters[IDPLANTILLA_PARAM].SourceColumn = kan_dirsalidaDAO.IDPLANTILLA_CAMPO;

            sqlCmd.Parameters.Add(new NpgsqlParameter(DIRECTORIOSALIDA_PARAM, NpgsqlDbType.Varchar));
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
        private NpgsqlCommand GetSelectALL()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_dirsalidaDAO SelectALL()
        {
            NpgsqlCommand sqlCmd = GetSelectALL();
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_dirsalida
        /// </summary>
        private NpgsqlCommand GetSelectID()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDSALIDA_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public kan_dirsalidaDAO SelectID(System.Int32 idsalida)
        {
            NpgsqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDSALIDA_PARAM].Value = idsalida;
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_dirsalida
        /// </summary>
        private NpgsqlCommand GetSelectPro()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECT_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public kan_dirsalidaDAO SelectPro(System.Int32 idprojectp)
        {
            NpgsqlCommand sqlCmd = GetSelectPro();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idprojectp;
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            return data;
        }
        /// <summary>
        /// Comando Update para el objeto kan_dirsalida
        /// </summary>
        private NpgsqlCommand GetUpdate()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPROJECT_PARAM, NpgsqlDbType.Integer));

            sqlCmd.Parameters.Add(new NpgsqlParameter(IDPLANTILLA_PARAM, NpgsqlDbType.Integer));

            sqlCmd.Parameters.Add(new NpgsqlParameter(DIRECTORIOSALIDA_PARAM, NpgsqlDbType.Varchar));

            sqlCmd.Parameters.Add(new NpgsqlParameter(IDSALIDA_PARAM, NpgsqlDbType.Integer));
            return sqlCmd;
        }

        public void Update(System.Int32 idsalida, System.Int32 idprogect, System.Int32 idplantilla, System.String directoriosalida)
        {
            NpgsqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDPROJECT_PARAM].Value = idprogect;
            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;
            sqlCmd.Parameters[DIRECTORIOSALIDA_PARAM].Value = directoriosalida;
            sqlCmd.Parameters[IDSALIDA_PARAM].Value = idsalida;
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
