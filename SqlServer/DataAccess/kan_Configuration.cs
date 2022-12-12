using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAL
{
    public class kan_Configuration
    {   

        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["MSSQLConnectionString"].ToString();
            }
        }
  
    }
}
