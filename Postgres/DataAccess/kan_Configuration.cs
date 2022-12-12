using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ProjectKAN.Data.PGSQL;

namespace ProjectKAN.DAL
{
   public class kan_Configuration
   {

      public static String ConnectionString
      {
         get
         {
            return DataBaseConnection.GetConnectionString();
         }
      }

   }
}
