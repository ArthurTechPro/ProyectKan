using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace Winner.Globals
{
    class Sql
    {
        public static string HexEncode(byte[] aby)
        {
            string hex = "0123456789abcdef";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < aby.Length; i++)
            {
                sb.Append(hex[(aby[i] & 0xf0) >> 4]);
                sb.Append(hex[aby[i] & 0x0f]);
            }
            return sb.ToString();
        }

        public static bool IsEmptyString(string str)
        {
            if (str == null || str == String.Empty)
                return true;
            return false;
        }

        public static bool IsEmptyString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return true;
            if (obj.ToString() == String.Empty)
                return true;
            return false;
        }

        public static Guid ToGuid(Guid g)
        {
            return g;
        }

        public static Guid ToGuid(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return Guid.Empty;
            // If datatype is Guid, then nothing else is necessary. 
            if (obj.GetType() == Type.GetType("System.Guid"))
                return (Guid)obj;
            string str = obj.ToString();
            if (str == String.Empty)
                return Guid.Empty;
            return XmlConvert.ToGuid(str);
        }

        public static string ToString(DateTime dt)
        {
            // If datatype is DateTime, then nothing else is necessary. 
            if (dt == DateTime.MinValue)
                return String.Empty;
            return dt.ToString();
        }
        public static string ToString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return String.Empty;
            return obj.ToString();
        }
        public static string ToString(string str)
        {
            if (str == null)
                return String.Empty;
            return str;
        }
        public static Boolean ToBoolean(Boolean b)
        {
            return b;
        }

        public static Boolean ToBoolean(Int32 n)
        {
            return (n == 0) ? false : true;
        }

        public static Boolean ToBoolean(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return false;
            if (obj.GetType() == Type.GetType("System.Int32"))
                return (Convert.ToInt32(obj) == 0) ? false : true;
            // 01/15/2007 Paul.  Allow a Byte field to also be treated as a boolean. 
            if (obj.GetType() == Type.GetType("System.Byte"))
                return (Convert.ToByte(obj) == 0) ? false : true;
            // 12/19/2005 Paul.  MySQL 5 returns SByte for a TinyInt. 
            if (obj.GetType() == Type.GetType("System.SByte"))
                return (Convert.ToSByte(obj) == 0) ? false : true;
            // 12/17/2005 Paul.  Oracle returns booleans as Int16. 
            if (obj.GetType() == Type.GetType("System.Int16"))
                return (Convert.ToInt16(obj) == 0) ? false : true;
            // 03/06/2006 Paul.  Oracle returns SYNC_CONTACT as decimal.
            if (obj.GetType() == Type.GetType("System.Decimal"))
                return (Convert.ToDecimal(obj) == 0) ? false : true;
            if (obj.GetType() == Type.GetType("System.String"))
            {
                string s = obj.ToString().ToLower();
                return (s == "true" || s == "on" || s == "1") ? true : false;
            }
            if (obj.GetType() != Type.GetType("System.Boolean"))
                return false;
            return bool.Parse(obj.ToString());
        }

        public static bool IsEmptyGuid(Guid g)
        {
            if (g == Guid.Empty)
                return true;
            return false;
        }

        public static bool IsEmptyGuid(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return true;
            string str = obj.ToString();
            if (str == String.Empty)
                return true;
            Guid g = XmlConvert.ToGuid(str);
            if (g == Guid.Empty)
                return true;
            return false;

        }
    }
}
