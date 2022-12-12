using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
//using ProjectKAN.Data.MSSQL;
using ProjectKAN.Data.PGSQL;


namespace ProjectKAN.Data
{
    public class ObjetDataConn
    {
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
            return DBPlatform();
        }

        public DataSet SqlEjecut()
        {
            //SQLQuery, SQLTabla
            DataSet data;
            DataBaseConnection DataBaseConn = new DataBaseConnection();
            DataBaseConn.SQLQuery = SQLQuery.ToString().Trim();
            DataBaseConn.SQLTabla = SQLTabla.ToString().Trim();
            DataBaseConn.ConnectionDataBase = ConnectionDataBase.ToString().Trim();
            data = DataBaseConn.SqlEjecuta();
            return data;
        }

        public DataSet SqlSchema()
        {
            //SQLQuery, SQLTabla
            DataSet data;
            DataBaseConnection DataBaseConn = new DataBaseConnection();
            DataBaseConn.SQLQuery = SQLQuery.ToString().Trim();
            DataBaseConn.SQLTabla = SQLTabla.ToString().Trim();
            DataBaseConn.ConnectionDataBase = ConnectionDataBase.ToString().Trim();
            data = DataBaseConn.SqlSchema();
            return data;
        
        }
    }
}
