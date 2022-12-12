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
    public class kan_comandoDAL
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idcoman</summary>
        public static string IDCOMAN_PARAM = "@idcoman";
        /// <summary>Constante con el nombre del parametro comando</summary>
        public static string COMANDO_PARAM = "@comando";
        private NpgsqlConnection sqlconn;
        private NpgsqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_comando WHERE idcoman = @idcoman";
        private string sqlInsert = "INSERT INTO kan_comando (idcoman, comando) VALUES ( @idcoman, @comando)";
        private string sqlSelectALL = "SELECT idcoman, comando FROM kan_comando";
        private string sqlSelectID = "SELECT idcoman, comando FROM kan_comando WHERE idcoman = @idcoman";
        private string sqlUpdate = "UPDATE kan_comando SET comando = @comando WHERE idcoman = @idcoman";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_comando
        /// </summary>
        public kan_comandoDAL()
        {
            sqlconn = new NpgsqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new NpgsqlDataAdapter();
            sqlDA.TableMappings.Add(kan_comandoDAO.KAN_COMANDO_TABLA, kan_comandoDAO.KAN_COMANDO_TABLA);
        }

        /// <summary>
        /// Comando Delete para el objeto kan_comando
        /// </summary>
        private NpgsqlCommand GetDelete()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCOMAN_PARAM, NpgsqlDbType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 idcoman)
        {
            NpgsqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDCOMAN_PARAM].Value = idcoman;

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
        /// Comando Insert para el objeto kan_comando
        /// </summary>
        private NpgsqlCommand GetInsert()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCOMAN_PARAM, NpgsqlDbType.Integer));
            sqlCmd.Parameters[IDCOMAN_PARAM].SourceColumn = kan_comandoDAO.IDCOMAN_CAMPO;

            sqlCmd.Parameters.Add(new NpgsqlParameter(COMANDO_PARAM, NpgsqlDbType.Varchar));
            sqlCmd.Parameters[COMANDO_PARAM].SourceColumn = kan_comandoDAO.COMANDO_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_comandoDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_comandoDAO.KAN_COMANDO_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_comando
        /// </summary>
        private NpgsqlCommand GetSelectALL()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_comandoDAO SelectALL()
        {
            NpgsqlCommand sqlCmd = GetSelectALL();
            kan_comandoDAO data = new kan_comandoDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandoDAO.KAN_COMANDO_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_comando
        /// </summary>
        private NpgsqlCommand GetSelectID()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCOMAN_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public kan_comandoDAO SelectID(System.Int32 idcoman)
        {
            NpgsqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDCOMAN_PARAM].Value = idcoman;
            kan_comandoDAO data = new kan_comandoDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_comandoDAO.KAN_COMANDO_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_comando
        /// </summary>
        private NpgsqlCommand GetUpdate()
        {
            NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new NpgsqlParameter(COMANDO_PARAM, NpgsqlDbType.Varchar));
            sqlCmd.Parameters.Add(new NpgsqlParameter(IDCOMAN_PARAM, NpgsqlDbType.Integer));

            return sqlCmd;
        }

        public void Update(System.Int32 idcoman, System.String comando)
        {
            NpgsqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[COMANDO_PARAM].Value = comando;
            sqlCmd.Parameters[IDCOMAN_PARAM].Value = idcoman;
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
