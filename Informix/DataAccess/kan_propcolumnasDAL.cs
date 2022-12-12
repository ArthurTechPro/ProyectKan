using System;
using System.Data;
using IBM.Data.Informix;
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
        private IfxConnection sqlconn;
        private IfxDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_propcolumnas WHERE idpropcolumna = ?";
        private string sqlInsert = "INSERT INTO kan_propcolumnas (idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private string sqlSelectALL = "SELECT idpropcolumna, idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado FROM kan_propcolumnas";
        private string sqlSelectID = "SELECT idpropcolumna, idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado FROM kan_propcolumnas WHERE idpropcolumna = ?";
        private string sqlSelectPro = "SELECT idpropcolumna, idpropiedad, nomcolumna, esprimarykey, grupo, descripcion, control, orden, tipodato, tipodatosql, oculto, requerido, esidentity, formulario, listado, tamano, bloquedado FROM kan_propcolumnas WHERE idpropiedad = ? ORDER BY orden";
        private string sqlUpdate = "UPDATE kan_propcolumnas SET idpropiedad = ?, nomcolumna = ?, esprimarykey = ?, grupo = ?, descripcion = ?, control = ?, orden = ?, tipodato = ?, tipodatosql = ?, oculto = ?, requerido = ?, esidentity = ?, formulario = ?, listado = ?, tamano = ?, bloquedado = ? WHERE idpropcolumna = ?";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_propcolumnas
        /// </summary>
        public kan_propcolumnasDAL()
        {
            sqlconn = new IfxConnection(kan_Configuration.ConnectionString);
            sqlDA = new IfxDataAdapter();
            sqlDA.TableMappings.Add(kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
        }

        /// <summary>
        /// Comando Delete para el objeto kan_propcolumnas
        /// </summary>
        private IfxCommand GetDelete()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(IDPROPCOLUMNA_PARAM, IfxType.Integer));
            return sqlCmd;
        }

        public void Delete(System.Int32 idpropcolumna)
        {
            IfxCommand sqlCmd = GetDelete();

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
        private IfxCommand GetInsert()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));
            sqlCmd.Parameters[IDPROPIEDAD_PARAM].SourceColumn = kan_propcolumnasDAO.IDPROPIEDAD_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(NOMCOLUMNA_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[NOMCOLUMNA_PARAM].SourceColumn = kan_propcolumnasDAO.NOMCOLUMNA_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(ESPRIMARYKEY_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[ESPRIMARYKEY_PARAM].SourceColumn = kan_propcolumnasDAO.ESPRIMARYKEY_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(GRUPO_PARAM, IfxType.Integer));
            sqlCmd.Parameters[GRUPO_PARAM].SourceColumn = kan_propcolumnasDAO.GRUPO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(DESCRIPCION_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[DESCRIPCION_PARAM].SourceColumn = kan_propcolumnasDAO.DESCRIPCION_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(CONTROL_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[CONTROL_PARAM].SourceColumn = kan_propcolumnasDAO.CONTROL_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(ORDEN_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[ORDEN_PARAM].SourceColumn = kan_propcolumnasDAO.ORDEN_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(TIPODATO_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[TIPODATO_PARAM].SourceColumn = kan_propcolumnasDAO.TIPODATO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(TIPODATOSQL_PARAM, IfxType.VarChar));
            sqlCmd.Parameters[TIPODATOSQL_PARAM].SourceColumn = kan_propcolumnasDAO.TIPODATOSQL_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(OCULTO_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[OCULTO_PARAM].SourceColumn = kan_propcolumnasDAO.OCULTO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(REQUERIDO_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[REQUERIDO_PARAM].SourceColumn = kan_propcolumnasDAO.REQUERIDO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(ESIDENTITY_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[ESIDENTITY_PARAM].SourceColumn = kan_propcolumnasDAO.ESIDENTITY_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(FORMULARIO_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[FORMULARIO_PARAM].SourceColumn = kan_propcolumnasDAO.FORMULARIO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(LISTADO_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[LISTADO_PARAM].SourceColumn = kan_propcolumnasDAO.LISTADO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(TAMANO_PARAM, IfxType.Integer));
            sqlCmd.Parameters[TAMANO_PARAM].SourceColumn = kan_propcolumnasDAO.TAMANO_CAMPO;

            sqlCmd.Parameters.Add(new IfxParameter(BLOQUEDADO_PARAM, IfxType.SmallInt));
            sqlCmd.Parameters[BLOQUEDADO_PARAM].SourceColumn = kan_propcolumnasDAO.BLOQUEDADO_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_propcolumnasDAO ds)
        {
            try
            {
                sqlDA.InsertCommand = GetInsert();
                sqlDA.Update(ds, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            }
            catch (Exception EX)
            {
                string ERR = EX.Message;
                throw;
            }


        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_propcolumnas
        /// </summary>
        private IfxCommand GetSelectALL()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_propcolumnasDAO SelectALL()
        {
            IfxCommand sqlCmd = GetSelectALL();
            kan_propcolumnasDAO data = new kan_propcolumnasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_propcolumnas
        /// </summary>
        private IfxCommand GetSelectID()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(IDPROPCOLUMNA_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public kan_propcolumnasDAO SelectID(System.Int32 idpropcolumna)
        {
            IfxCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPROPCOLUMNA_PARAM].Value = idpropcolumna;
            kan_propcolumnasDAO data = new kan_propcolumnasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_propcolumnas
        /// </summary>
        private IfxCommand GetSelectPro()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlSelectPro, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public kan_propcolumnasDAO SelectPro(System.Int32 idpropiedad)
        {
            IfxCommand sqlCmd = GetSelectPro();
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
        private IfxCommand GetUpdate()
        {
            IfxCommand sqlCmd = new IfxCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new IfxParameter(IDPROPIEDAD_PARAM, IfxType.Integer));

            sqlCmd.Parameters.Add(new IfxParameter(NOMCOLUMNA_PARAM, IfxType.VarChar));

            sqlCmd.Parameters.Add(new IfxParameter(ESPRIMARYKEY_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(GRUPO_PARAM, IfxType.Integer));

            sqlCmd.Parameters.Add(new IfxParameter(DESCRIPCION_PARAM, IfxType.VarChar));

            sqlCmd.Parameters.Add(new IfxParameter(CONTROL_PARAM, IfxType.VarChar));

            sqlCmd.Parameters.Add(new IfxParameter(ORDEN_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(TIPODATO_PARAM, IfxType.VarChar));

            sqlCmd.Parameters.Add(new IfxParameter(TIPODATOSQL_PARAM, IfxType.VarChar));

            sqlCmd.Parameters.Add(new IfxParameter(OCULTO_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(REQUERIDO_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(ESIDENTITY_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(FORMULARIO_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(LISTADO_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(TAMANO_PARAM, IfxType.Integer));

            sqlCmd.Parameters.Add(new IfxParameter(BLOQUEDADO_PARAM, IfxType.SmallInt));

            sqlCmd.Parameters.Add(new IfxParameter(IDPROPCOLUMNA_PARAM, IfxType.Integer));

            return sqlCmd;
        }

        public void Update(kan_propcolumnasDAO data)
        {
            IfxCommand sqlCmd = GetUpdate();

            sqlDA.UpdateCommand = sqlCmd;
            sqlDA.Update(data);
        }
    }
}