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
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_relaciones WHERE idrelacion = @idrelacion";
        private string sqlInsert = "INSERT INTO kan_relaciones (idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir) VALUES (@idpropiedad, @nomhijo, @nomrelacion, @relpadre, @relhijo, @omitir)";
        private string sqlSelectALL = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones";
        private string sqlSelectID = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idrelacion = @idrelacion";
        private string sqlSelectRelPadre = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE idpropiedad = @idpropiedad";
        private string sqlSelectRelHijo = "SELECT idrelacion, idpropiedad, nomhijo, nomrelacion, relpadre, relhijo, omitir FROM kan_relaciones WHERE nomhijo = @nomhijo";
        private string sqlUpdate = "UPDATE kan_relaciones SET idpropiedad = @idpropiedad, nomhijo = @nomhijo, nomrelacion = @nomrelacion, relpadre = @relpadre, relhijo = @relhijo, omitir = @omitir WHERE idrelacion = @idrelacion";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_relaciones
        /// </summary>
        public kan_relacionesDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_relacionesDAO.KAN_RELACIONES_TABLA, kan_relacionesDAO.KAN_RELACIONES_TABLA);
        }


        /// <summary>
        /// Comando Delete para el objeto kan_relaciones
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDRELACION_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idrelacion)
        {
            SqlCommand sqlCmd = GetDelete();

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
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDRELACION_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDRELACION_PARAM].SourceColumn = kan_relacionesDAO.IDRELACION_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_relacionesDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMHIJO_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMHIJO_PARAM].SourceColumn = kan_relacionesDAO.NOMHIJO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMRELACION_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMRELACION_PARAM].SourceColumn = kan_relacionesDAO.NOMRELACION_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(RELPADRE_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[RELPADRE_PARAM].SourceColumn = kan_relacionesDAO.RELPADRE_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(RELHIJO_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[RELHIJO_PARAM].SourceColumn = kan_relacionesDAO.RELHIJO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(OMITIR_PARAM, SqlDbType.SmallInt, 2));
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
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_relacionesDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_relacionesDAO data = new kan_relacionesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_relaciones
        /// </summary>
        private SqlCommand GetSelectRelPadre()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectRelPadre, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_relacionesDAO SelectRelPadre(System.Int32 idpropiedad)
        {
            SqlCommand sqlCmd = GetSelectRelPadre();

            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
            kan_relacionesDAO data = new kan_relacionesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectID para el objeto kan_relaciones
        /// </summary>
        private SqlCommand GetSelectRelHijo()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectRelHijo, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(NOMHIJO_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_relacionesDAO SelectRelHijo(System.Int32 nomhijo)
        {
            SqlCommand sqlCmd = GetSelectRelHijo();

            sqlCmd.Parameters[NOMHIJO_PARAM].Value = nomhijo;
            kan_relacionesDAO data = new kan_relacionesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectID para el objeto kan_relaciones
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDRELACION_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_relacionesDAO SelectID(System.Int32 idrelacion)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDRELACION_PARAM].Value = idrelacion;
            kan_relacionesDAO data = new kan_relacionesDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_relacionesDAO.KAN_RELACIONES_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_relaciones
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDRELACION_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NOMHIJO_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(NOMRELACION_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(RELPADRE_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(RELHIJO_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(OMITIR_PARAM, SqlDbType.SmallInt, 2));

            return sqlCmd;
        }

        public void Update(System.Int32 idrelacion, System.Int32 idpropiedad, System.String nomhijo, System.String nomrelacion, System.String relpadre, System.String relhijo, System.Int16 omitir)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDRELACION_PARAM].Value = idrelacion;
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
            sqlCmd.Parameters[NOMHIJO_PARAM].Value = nomhijo;
            sqlCmd.Parameters[NOMRELACION_PARAM].Value = nomrelacion;
            sqlCmd.Parameters[RELPADRE_PARAM].Value = relpadre;
            sqlCmd.Parameters[RELHIJO_PARAM].Value = relhijo;
            sqlCmd.Parameters[OMITIR_PARAM].Value = omitir;
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
