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
    public class kan_propcolumnasDAL
    {

        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idpropcolumna</summary>
        public static string IDPROPCOLUMNA_PARAM = "@idpropcolumna";
        /// <summary>Constante con el nombre del parametro idpropiedad</summary>
        public static string IDPROPIEDAD_PARAM = "@idpropiedad";
        /// <summary>Constante con el nombre del parametro nomcolumna</summary>
        public static string NOMCOLUMNA_PARAM = "@nomcolumna";
        /// <summary>Constante con el nombre del parametro esprimarykey</summary>
        public static string ESPRIMARYKEY_PARAM = "@esprimarykey";
        /// <summary>Constante con el nombre del parametro grupo</summary>
        public static string GRUPO_PARAM = "@grupo";
        /// <summary>Constante con el nombre del parametro descripcion</summary>
        public static string DESCRIPCION_PARAM = "@descripcion";
        /// <summary>Constante con el nombre del parametro control</summary>
        public static string CONTROL_PARAM = "@control";
        /// <summary>Constante con el nombre del parametro orden</summary>
        public static string ORDEN_PARAM = "@orden";
        /// <summary>Constante con el nombre del parametro tipodato</summary>
        public static string TIPODATO_PARAM = "@tipodato";
        /// <summary>Constante con el nombre del parametro tipodato</summary>
        public static string TIPODATOSQL_PARAM = "@tipodatosql";
        /// <summary>Constante con el nombre del parametro oculto</summary>
        public static string OCULTO_PARAM = "@oculto";
        /// <summary>Constante con el nombre del parametro requerido</summary>
        public static string REQUERIDO_PARAM = "@requerido";
        /// <summary>Constante con el nombre del parametro esidentity</summary>
        public static string ESIDENTITY_PARAM = "@esidentity";
        /// <summary>Constante con el nombre del parametro formulario</summary>
        public static string FORMULARIO_PARAM = "@formulario";
        /// <summary>Constante con el nombre del parametro listado</summary>
        public static string LISTADO_PARAM = "@listado";
        /// <summary>Constante con el nombre del parametro tamano</summary>
        public static string TAMANO_PARAM = "@tamano";
        /// <summary>Constante con el nombre del parametro bloquedado</summary>
        public static string BLOQUEDADO_PARAM = "@bloquedado";
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_propcolumnas WHERE idpropcolumna = @idpropcolumna";
        private string sqlInsert = "INSERT INTO kan_propcolumnas (idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado) VALUES (@idpropiedad, @nomcolumna, @esprimarykey, @grupo, @descripcion, @control, @orden, @tipodato, @tipodatosql, @oculto, @requerido, @esidentity, @formulario, @listado, @tamano, @bloquedado)";
        private string sqlSelectALL = "SELECT idpropcolumna, idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado FROM kan_propcolumnas";
        private string sqlSelectID = "SELECT idpropcolumna, idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado FROM kan_propcolumnas WHERE idpropcolumna = @idpropcolumna";
        private string sqlSelectPro = "SELECT idpropcolumna, idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado FROM kan_propcolumnas WHERE idpropiedad = @idpropiedad";
        private string sqlUpdate = "UPDATE kan_propcolumnas SET idpropiedad = @idpropiedad, nomcolumna = @nomcolumna, esprimarykey = @esprimarykey, grupo = @grupo, descripcion = @descripcion, control = @control, orden = @orden, tipodato = @tipodato, tipodatosql = @tipodatosql, oculto = @oculto, requerido = @requerido, esidentity = @esidentity, formulario = @formulario, listado = @listado, tamano = @tamano, bloquedado = @bloquedado WHERE idpropcolumna = @idpropcolumna";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_propcolumnas
        /// </summary>
        public kan_propcolumnasDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
        }

        /// <summary>
        /// Comando Delete para el objeto kan_propcolumnas
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPCOLUMNA_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idpropcolumna)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDPROPCOLUMNA_PARAM].Value = idpropcolumna;

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
        /// Comando Insert para el objeto kan_propcolumnas
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPCOLUMNA_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPCOLUMNA_PARAM].SourceColumn = kan_propcolumnasDAO.IDPROPCOLUMNA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_propcolumnasDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(NOMCOLUMNA_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[NOMCOLUMNA_PARAM].SourceColumn = kan_propcolumnasDAO.NOMCOLUMNA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(ESPRIMARYKEY_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[ESPRIMARYKEY_PARAM].SourceColumn = kan_propcolumnasDAO.ESPRIMARYKEY_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(GRUPO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[GRUPO_PARAM].SourceColumn = kan_propcolumnasDAO.GRUPO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(DESCRIPCION_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[DESCRIPCION_PARAM].SourceColumn = kan_propcolumnasDAO.DESCRIPCION_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(CONTROL_PARAM, SqlDbType.VarChar, 50));
            sqlCmd.Parameters[CONTROL_PARAM].SourceColumn = kan_propcolumnasDAO.CONTROL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(ORDEN_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[ORDEN_PARAM].SourceColumn = kan_propcolumnasDAO.ORDEN_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPODATO_PARAM, SqlDbType.VarChar, 50));
            sqlCmd.Parameters[TIPODATO_PARAM].SourceColumn = kan_propcolumnasDAO.TIPODATO_CAMPO;
            
            sqlCmd.Parameters.Add(new SqlParameter(TIPODATOSQL_PARAM, SqlDbType.VarChar, 50));
            sqlCmd.Parameters[TIPODATOSQL_PARAM].SourceColumn = kan_propcolumnasDAO.TIPODATOSQL_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(OCULTO_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[OCULTO_PARAM].SourceColumn = kan_propcolumnasDAO.OCULTO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(REQUERIDO_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[REQUERIDO_PARAM].SourceColumn = kan_propcolumnasDAO.REQUERIDO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(ESIDENTITY_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[ESIDENTITY_PARAM].SourceColumn = kan_propcolumnasDAO.ESIDENTITY_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(FORMULARIO_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[FORMULARIO_PARAM].SourceColumn = kan_propcolumnasDAO.FORMULARIO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(LISTADO_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[LISTADO_PARAM].SourceColumn = kan_propcolumnasDAO.LISTADO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TAMANO_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[TAMANO_PARAM].SourceColumn = kan_propcolumnasDAO.TAMANO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(BLOQUEDADO_PARAM, SqlDbType.SmallInt, 2));
            sqlCmd.Parameters[BLOQUEDADO_PARAM].SourceColumn = kan_propcolumnasDAO.BLOQUEDADO_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_propcolumnasDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_propcolumnas
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_propcolumnasDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_propcolumnasDAO data = new kan_propcolumnasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_propcolumnas
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPCOLUMNA_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_propcolumnasDAO SelectID(System.Int32 idpropcolumna)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPROPCOLUMNA_PARAM].Value = idpropcolumna;
            kan_propcolumnasDAO data = new kan_propcolumnasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_propcolumnas
        /// </summary>
        private SqlCommand GetSelectPro()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_propcolumnasDAO SelectPro(System.Int32 idpropiedad)
        {
            SqlCommand sqlCmd = GetSelectPro();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].Value = idpropiedad;
            kan_propcolumnasDAO data = new kan_propcolumnasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlDA.Fill(data, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_propcolumnas
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDPROPCOLUMNA_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(IDPROPIEDAD_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(NOMCOLUMNA_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(ESPRIMARYKEY_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(GRUPO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(DESCRIPCION_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(CONTROL_PARAM, SqlDbType.VarChar, 50));

            sqlCmd.Parameters.Add(new SqlParameter(ORDEN_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(TIPODATO_PARAM, SqlDbType.VarChar, 50));

            sqlCmd.Parameters.Add(new SqlParameter(TIPODATOSQL_PARAM, SqlDbType.VarChar, 50));

            sqlCmd.Parameters.Add(new SqlParameter(OCULTO_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(REQUERIDO_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(ESIDENTITY_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(FORMULARIO_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(LISTADO_PARAM, SqlDbType.SmallInt, 2));

            sqlCmd.Parameters.Add(new SqlParameter(TAMANO_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(BLOQUEDADO_PARAM, SqlDbType.SmallInt, 2));

            return sqlCmd;
        }

        public void Update(kan_propcolumnasDAO data)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlDA.UpdateCommand = sqlCmd;
            sqlDA.Update(data);
        }
    }
}