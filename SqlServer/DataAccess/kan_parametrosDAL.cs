using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_parametrosDAL 
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idparametro</summary>
        public static string IDPARAMETRO_PARAM = "@idparametro";
        /// <summary>Constante con el nombre del parametro idcomando</summary>
        public static string IDCOMANDO_PARAM = "@idcomando";
        /// <summary>Constante con el nombre del parametro nomcomando</summary>
        public static string NOMCOMANDO_PARAM = "@nomcomando";
        /// <summary>Constante con el nombre del parametro nomparametro</summary>
        public static string NOMPARAMETRO_PARAM = "@nomparametro";
        /// <summary>Constante con el nombre del parametro tipodato</summary>
        public static string TIPODATO_PARAM = "@tipodato";
        /// <summary>Constante con el nombre del parametro tipodato</summary>
        public static string TAMANO_PARAM = "@tamano";
        /// <summary>Constante con el nombre del parametro direccion</summary>
        public static string DIRECCION_PARAM = "@direccion";
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_parametros WHERE idparametro = @idparametro";
        private string sqlInsert = "INSERT INTO kan_parametros (idcomando, nomcomando, nomparametro, tipodato, tamano, direccion) VALUES (@idcomando, @nomcomando, @nomparametro, @tipodato, @tamano, @direccion)";
        private string sqlSelectALL = "SELECT idparametro, idcomando, nomcomando, nomparametro, tipodato, tamano, direccion FROM kan_parametros";
        private string sqlSelectID = "SELECT idparametro, idcomando, nomcomando, nomparametro, tipodato, tamano, direccion FROM kan_parametros WHERE idparametro = @idparametro";
        private string sqlSelectPComand = "SELECT idparametro, idcomando, nomcomando, nomparametro, tipodato, tamano, direccion FROM kan_parametros WHERE idcomando = @idcomando";
        private string sqlUpdate = "UPDATE kan_parametros SET idcomando = @idcomando, nomcomando = @nomcomando, nomparametro = @nomparametro, tipodato = @tipodato, tamano = @tamano, direccion = @direccion WHERE idparametro = @idparametro";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_parametros
        /// </summary>
        public kan_parametrosDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_parametrosDAO.KAN_PARAMETROS_TABLA, kan_parametrosDAO.KAN_PARAMETROS_TABLA);
        }
        // Metodo para el manejo del GC

        /// <summary>
        /// Comando Delete para el objeto kan_parametros
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPARAMETRO_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idparametro)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDPARAMETRO_PARAM].Value = idparametro;

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
        /// Comando Insert para el objeto kan_parametros
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDPARAMETRO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPARAMETRO_PARAM].SourceColumn = kan_parametrosDAO.IDPARAMETRO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDCOMANDO_PARAM].SourceColumn = kan_parametrosDAO.IDCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMCOMANDO_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[NOMCOMANDO_PARAM].SourceColumn = kan_parametrosDAO.NOMCOMANDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMPARAMETRO_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[NOMPARAMETRO_PARAM].SourceColumn = kan_parametrosDAO.NOMPARAMETRO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPODATO_PARAM, SqlDbType.VarChar, 50));
            sqlCmd.Parameters[TIPODATO_PARAM].SourceColumn = kan_parametrosDAO.TIPODATO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TAMANO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TAMANO_PARAM].SourceColumn = kan_parametrosDAO.TAMANO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(DIRECCION_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[DIRECCION_PARAM].SourceColumn = kan_parametrosDAO.DIRECCION_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_parametrosDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_parametrosDAO.KAN_PARAMETROS_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_parametros
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_parametrosDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_parametrosDAO data = new kan_parametrosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_parametrosDAO.KAN_PARAMETROS_TABLA);
            return data;
        }


        /// <summary>
        /// Comando SelectID para el objeto kan_parametros
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPARAMETRO_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_parametrosDAO SelectID(System.Int32 idparametro)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPARAMETRO_PARAM].Value = idparametro;
            kan_parametrosDAO data = new kan_parametrosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_parametrosDAO.KAN_PARAMETROS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_parametros
        /// </summary>
        private SqlCommand GetSelectParamConado()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectPComand, sqlconn);
            sqlCmd.CommandType = CommandType.Text;
            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_parametrosDAO SelectParamComando(System.Int32 idcomando)
        {
            SqlCommand sqlCmd = GetSelectParamConado();

            sqlCmd.Parameters[IDCOMANDO_PARAM].Value = idcomando;
            kan_parametrosDAO data = new kan_parametrosDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_parametrosDAO.KAN_PARAMETROS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_parametros
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDPARAMETRO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDCOMANDO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NOMCOMANDO_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(NOMPARAMETRO_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(TIPODATO_PARAM, SqlDbType.VarChar, 50));

            sqlCmd.Parameters.Add(new SqlParameter(DIRECCION_PARAM, SqlDbType.SmallInt, 2));

            return sqlCmd;
        }

        public void Update(System.Int32 idparametro, System.Int32 idcomando, System.String nomcomando, System.String nomparametro, System.String tipodato, System.Int32 tamano, System.Int16 direccion)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDPARAMETRO_PARAM].Value = idparametro;
            sqlCmd.Parameters[IDCOMANDO_PARAM].Value = idcomando;
            sqlCmd.Parameters[NOMCOMANDO_PARAM].Value = nomcomando;
            sqlCmd.Parameters[NOMPARAMETRO_PARAM].Value = nomparametro;
            sqlCmd.Parameters[TIPODATO_PARAM].Value = tipodato;
            sqlCmd.Parameters[TAMANO_PARAM].Value = tamano;
            sqlCmd.Parameters[DIRECCION_PARAM].Value = direccion;
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
