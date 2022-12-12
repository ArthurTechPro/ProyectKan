using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace ProjectKAN.Data.PGSQL
{
    public class DataBaseConnection
    {
        private NpgsqlConnection PgConn = new NpgsqlConnection(GetConnectionString());
        //private NpgsqlDataAdapter PgDA = new NpgsqlDataAdapter();

       
        private string _SQLQuery;
        private string _SQLTabla;
        private string _ConnectionDataBase;

        public string SQLQuery
        {
            get { return _SQLQuery; }
            set { _SQLQuery = value; }
        }

        public string SQLTabla
        {
            get { return _SQLTabla; }
            set { _SQLTabla = value; }
        }

        public string ConnectionDataBase
        {
            get { return _ConnectionDataBase; }
            set { _ConnectionDataBase = value; }
        }

        public static String DBPlatform()
        {
            return "POSTGRESQL";
        }

        public static String GetConnectionString()
        {
            return  ConfigurationManager.AppSettings["PGSQLConnectionString"];
        }


        public DataSet SqlEjecuta()
        {

            DataSet data = new DataSet();
            PgConn.Open();
            NpgsqlTransaction transac = PgConn.BeginTransaction();
            NpgsqlCommand PgCmd = new NpgsqlCommand(SQLQuery, PgConn);
            NpgsqlDataAdapter PgDA = new NpgsqlDataAdapter(PgCmd);
            PgDA.SelectCommand = PgCmd;
            PgDA.Fill(data, SQLTabla);
            transac.Commit();
            PgConn.Close();
            return data;

        }

        public DataSet SqlSchema()
        {
            try
            {
                DataSet data = new DataSet();
                //NpgsqlConnection PgConn = new NpgsqlConnection(GetConnectionString());
                //SqlConn.Open();
                //SqlTransaction transac = SqlConn.BeginTransaction();
                NpgsqlCommand IfxCmd = new NpgsqlCommand(SQLQuery, PgConn);
                NpgsqlDataAdapter IfxDA = new NpgsqlDataAdapter(IfxCmd);
                IfxDA.SelectCommand = IfxCmd;
                IfxDA.FillSchema(data, SchemaType.Source);
                //transac.Commit();
                //SqlConn.Close();
                return data;
            }
            catch (Exception Ex)
            {
                string Error = Ex.Message;
                throw;
            }
        }

    }
}
