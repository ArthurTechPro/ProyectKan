using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;


namespace ProjectKAN.Data.MSSQL
{
    [Serializable()]
    public class DataBaseConnection 
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

        //private SqlConnection SqlConn = new SqlConnection(ConnectionDataBase.ToString());
        //private SqlDataAdapter  SqlDA = new SqlDataAdapter();

        public static String DBPlatform()
        {
            return "MSSQL";
        }
     

        public DataSet SqlEjecut()
        {
            try
            {
                DataSet data = new DataSet();
                SqlConnection SqlConn = new SqlConnection(ConnectionDataBase.ToString());
                //SqlConn.Open();
                //SqlTransaction transac = SqlConn.BeginTransaction();
                SqlDataAdapter  SqlDA = new SqlDataAdapter();
                SqlCommand SqlCmd = new SqlCommand(SQLQuery, SqlConn);
                SqlDA.SelectCommand = SqlCmd;
                SqlDA.Fill(data, SQLTabla);
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
      
        public DataSet SqlSchema()
        {
            try
            {
                DataSet data = new DataSet();
                SqlConnection SqlConn = new SqlConnection(ConnectionDataBase.ToString());
                //SqlConn.Open();
                //SqlTransaction transac = SqlConn.BeginTransaction();
                SqlDataAdapter SqlDA = new SqlDataAdapter();
                SqlCommand SqlCmd = new SqlCommand(SQLQuery, SqlConn);
                SqlDA.SelectCommand = SqlCmd;
                SqlDA.FillSchema(data, SchemaType.Source);
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
