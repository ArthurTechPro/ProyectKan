using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlClient;
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
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_propiedades WHERE idpropiedad = @idpropiedad";
        private string sqlInsert = "INSERT INTO kan_propiedades (idprojectp, iddata, tipopropiedad, nombre, padre, creaselect, creainsert, creadelete, creaupdate) VALUES (@idprojectp, @iddata, @tipopropiedad, @nombre, @padre, @creaselect, @creainsert, @creadelete, @creaupdate)";
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
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString); 
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_propiedadesDAO.KAN_PROPIEDADES_TABLA, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
        }

        /// <summary>
        /// Comando Delete para el objeto kan_propiedades
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idpropiedad)
        {
            SqlCommand sqlCmd = GetDelete();

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
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECTP_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = kan_propiedadesDAO.IDPROJECTP_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDDATA_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDDATA_PARAM].SourceColumn = kan_propiedadesDAO.IDDATA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOPROPIEDAD_PARAM, SqlDbType.VarChar, 1));
            sqlCmd.Parameters[TIPOPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRE_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMBRE_PARAM].SourceColumn = kan_propiedadesDAO.NOMBRE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(PADRE_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[PADRE_PARAM].SourceColumn = kan_propiedadesDAO.PADRE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREASELECT_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREASELECT_PARAM].SourceColumn = kan_propiedadesDAO.CREASELECT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREAINSERT_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREAINSERT_PARAM].SourceColumn = kan_propiedadesDAO.CREAINSERT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREADELETE_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREADELETE_PARAM].SourceColumn = kan_propiedadesDAO.CREADELETE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREAUPDATE_PARAM, SqlDbType.Int, 4));
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
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_propiedadesDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectALL para el objeto kan_propiedades
        /// </summary>
        private SqlCommand GetSelectIdTity()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectIdTity, sqlconn);

            return sqlCmd;
        }

        public kan_propiedadesDAO SelectIdTity()
        {
            SqlCommand sqlCmd = GetSelectIdTity();
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
        }
        /// <summary>
        /// Comando SelectID para el objeto kan_propiedades
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_propiedadesDAO SelectID(System.Int32 idpropiedad)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectID para el objeto kan_propiedades
        /// </summary>
        private SqlCommand GetSelectPro()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECTP_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_propiedadesDAO SelectPro(System.Int32 idprojectp)
        {
            SqlCommand sqlCmd = GetSelectPro();

            sqlCmd.Parameters[IDPROJECTP_PARAM].Value = idprojectp;
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
        }
        /// <summary>
        /// Comando Update para el objeto kan_propiedades
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECTP_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROJECTP_PARAM].SourceColumn = kan_propiedadesDAO.IDPROJECTP_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDDATA_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDDATA_PARAM].SourceColumn = kan_propiedadesDAO.IDDATA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOPROPIEDAD_PARAM, SqlDbType.VarChar, 1));
            sqlCmd.Parameters[TIPOPROPIEDAD_PARAM].SourceColumn = kan_propiedadesDAO.TIPOPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMBRE_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMBRE_PARAM].SourceColumn = kan_propiedadesDAO.NOMBRE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(PADRE_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[PADRE_PARAM].SourceColumn = kan_propiedadesDAO.PADRE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREASELECT_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREASELECT_PARAM].SourceColumn = kan_propiedadesDAO.CREASELECT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREAINSERT_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREAINSERT_PARAM].SourceColumn = kan_propiedadesDAO.CREAINSERT_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREADELETE_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREADELETE_PARAM].SourceColumn = kan_propiedadesDAO.CREADELETE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CREAUPDATE_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[CREAUPDATE_PARAM].SourceColumn = kan_propiedadesDAO.CREAUPDATE_CAMPO;

            return sqlCmd;

        }

        public void Update(kan_propiedadesDAO data)
        {
            sqlDA.UpdateCommand = GetUpdate();
            sqlDA.ContinueUpdateOnError = true;
            sqlDA.Update(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);

        }

        private SqlCommand GetSelectTablasBD()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectTablasBD, sqlconn);
            sqlCmd.Parameters.Add(new SqlParameter(IDPROJECTP_PARAM, SqlDbType.Int, 4));
            sqlCmd.CommandType = CommandType.Text;
            return sqlCmd;
        }

        public kan_propiedadesDAO SelectTablasBD(Int32 idprojectp)
        {
            if (sqlDA == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            }
            
            SqlCommand sqlCmd = GetSelectTablasBD();
            sqlCmd.Parameters[IDPROJECTP_PARAM].Value = idprojectp;
            
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlDA.Fill(data, kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            return data;
        }
	
    }
}
