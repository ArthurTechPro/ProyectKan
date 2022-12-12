﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using ProjectKAN.DAO; 

namespace ProjectKAN.DAL
{
    public class kan_plantillasDAL
    {
        //Parametros para el llamado de comandos

        /// <summary>Constante con el nombre del parametro idplantilla</summary>
        public static string IDPLANTILLA_PARAM = "@idplantilla";
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
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlDA;

        //Sentencias SQL o Procedimientos almacenados
        private string sqlDelete = "DELETE FROM kan_plantillas WHERE idplantilla = @idplantilla";
        private string sqlInsert = "INSERT INTO kan_plantillas (descrip, tipoarchivo, plantilla, formatonom, limpiaaspx) VALUES (@descrip, @tipoarchivo, @plantilla, @formatonom, @limpiaaspx)";
        private string sqlSelectALL = "SELECT idplantilla, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx FROM kan_plantillas";
        private string sqlSelectID = "SELECT idplantilla, descrip, tipoarchivo, plantilla, formatonom, limpiaaspx FROM kan_plantillas WHERE idplantilla = @idplantilla";
        private string sqlUpdate = "UPDATE kan_plantillas SET descrip = @descrip, tipoarchivo = @tipoarchivo, plantilla = @plantilla, formatonom = @formatonom, limpiaaspx = @limpiaaspx WHERE idplantilla = @idplantilla";


        /// <summary>
        /// Clase de acceso a datos para el objeto kan_plantillas
        /// </summary>
        public kan_plantillasDAL()
        {
            sqlconn = new SqlConnection(kan_Configuration.ConnectionString);
            sqlDA = new SqlDataAdapter();
            sqlDA.TableMappings.Add(kan_plantillasDAO.KAN_PLANTILLAS_TABLA, kan_plantillasDAO.KAN_PLANTILLAS_TABLA);
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
        /// Comando Delete para el objeto kan_plantillas
        /// </summary>
        private SqlCommand GetDelete()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlDelete, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));
            return sqlCmd;
        }

        public void Delete(System.Int32 idplantilla)
        {
            SqlCommand sqlCmd = GetDelete();

            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;

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
        /// Comando Insert para el objeto kan_plantillas
        /// </summary>
        private SqlCommand GetInsert()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlconn);

            //Parametros Update
            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[IDPLANTILLA_PARAM].SourceColumn = kan_plantillasDAO.IDPLANTILLA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(DESCRIP_PARAM, SqlDbType.VarChar, 100));
            sqlCmd.Parameters[DESCRIP_PARAM].SourceColumn = kan_plantillasDAO.DESCRIP_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(TIPOARCHIVO_PARAM, SqlDbType.VarChar, 16));
            sqlCmd.Parameters[TIPOARCHIVO_PARAM].SourceColumn = kan_plantillasDAO.TIPOARCHIVO_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(PLANTILLA_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[PLANTILLA_PARAM].SourceColumn = kan_plantillasDAO.PLANTILLA_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(FORMATONOM_PARAM, SqlDbType.VarChar, 60));
            sqlCmd.Parameters[FORMATONOM_PARAM].SourceColumn = kan_plantillasDAO.FORMATONOM_CAMPO;

            sqlCmd.Parameters.Add(new SqlParameter(LIMPIAASPX_PARAM, SqlDbType.Int, 4));
            sqlCmd.Parameters[LIMPIAASPX_PARAM].SourceColumn = kan_plantillasDAO.LIMPIAASPX_CAMPO;

            return sqlCmd;
        }

        public void Insert(kan_plantillasDAO ds)
        {

            sqlDA.InsertCommand = GetInsert();
            sqlDA.Update(ds, kan_plantillasDAO.KAN_PLANTILLAS_TABLA);

        }

        /// <summary>
        /// Comando SelectALL para el objeto kan_plantillas
        /// </summary>
        private SqlCommand GetSelectALL()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectALL, sqlconn);

            return sqlCmd;
        }

        public kan_plantillasDAO SelectALL()
        {
            SqlCommand sqlCmd = GetSelectALL();
            kan_plantillasDAO data = new kan_plantillasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_plantillasDAO.KAN_PLANTILLAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando SelectID para el objeto kan_plantillas
        /// </summary>
        private SqlCommand GetSelectID()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlSelectID, sqlconn);

            //Parametros CamposLlave
            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public kan_plantillasDAO SelectID(System.Int32 idplantilla)
        {
            SqlCommand sqlCmd = GetSelectID();

            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;
            kan_plantillasDAO data = new kan_plantillasDAO();
            sqlDA.SelectCommand = sqlCmd;
            sqlDA.Fill(data, kan_plantillasDAO.KAN_PLANTILLAS_TABLA);
            return data;
        }

        /// <summary>
        /// Comando Update para el objeto kan_plantillas
        /// </summary>
        private SqlCommand GetUpdate()
        {
            SqlCommand sqlCmd = new SqlCommand(sqlUpdate, sqlconn);

            //Parametros CamposRegistro
            sqlCmd.Parameters.Add(new SqlParameter(IDPLANTILLA_PARAM, SqlDbType.Int, 4));

            sqlCmd.Parameters.Add(new SqlParameter(DESCRIP_PARAM, SqlDbType.VarChar, 100));

            sqlCmd.Parameters.Add(new SqlParameter(TIPOARCHIVO_PARAM, SqlDbType.VarChar, 16));

            sqlCmd.Parameters.Add(new SqlParameter(PLANTILLA_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(FORMATONOM_PARAM, SqlDbType.VarChar, 60));

            sqlCmd.Parameters.Add(new SqlParameter(LIMPIAASPX_PARAM, SqlDbType.Int, 4));

            return sqlCmd;
        }

        public void Update(System.Int32 idplantilla, System.String descrip, System.String tipoarchivo, System.String plantilla, System.String formatonom, System.Int32 limpiaaspx)
        {
            SqlCommand sqlCmd = GetUpdate();

            sqlCmd.Parameters[IDPLANTILLA_PARAM].Value = idplantilla;
            sqlCmd.Parameters[DESCRIP_PARAM].Value = descrip;
            sqlCmd.Parameters[TIPOARCHIVO_PARAM].Value = tipoarchivo;
            sqlCmd.Parameters[PLANTILLA_PARAM].Value = plantilla;
            sqlCmd.Parameters[FORMATONOM_PARAM].Value = formatonom;
            sqlCmd.Parameters[LIMPIAASPX_PARAM].Value = limpiaaspx;
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
