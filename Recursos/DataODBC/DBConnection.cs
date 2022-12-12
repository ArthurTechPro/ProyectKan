using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
using System.IO;
using System.Linq;


namespace Winner.Data
{
    public static class DBConnection
    {

        public static String DBPlatform()
        {
            return "ODBC";
        }

        private static string GetConnectionString()
        {
            return ConfigurationSettings.AppSettings["ODBCConnectionString"];
        }

    }
}
