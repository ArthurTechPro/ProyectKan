using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Data.Common;


namespace Winner.Globals
{
    public class Security
    {
        public static int USER_ID
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return (int)HttpContext.Current.Session["USER_ID"];
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_ID"] = value;
            }
        }

        public static int SUB_MODULO
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return (int)HttpContext.Current.Session["SUB_MODULO"];
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["SUB_MODULO"] = value;
            }
        }

        public static decimal NIT_USER
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return (decimal)HttpContext.Current.Session["NIT_USER"];
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["NIT_USER"] = value;
            }
        }

        public static decimal NIT_AGENTE
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return (decimal)HttpContext.Current.Session["NIT_AGENTE"];
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["NIT_AGENTE"] = value;
            }
        }

        public static decimal NIT_CLIENTE
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return (decimal)HttpContext.Current.Session["NIT_CLIENTE"];
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["NIT_CLIENTE"] = value;
            }
        }

        public static int USER_TIPO
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return (int)HttpContext.Current.Session["USER_TIPO"];
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_TIPO"] = value;
            }
        }

        public static string USER_EMAIL
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["USER_EMAIL"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_EMAIL"] = value;
            }
        }

        public static string USER_MODULO
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["USER_MODULO"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_MODULO"] = value;
            }
        }

        public static string USER_NAME
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["USER_NAME"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_NAME"] = value;
            }
        }

        public static string USER_LANG
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["USER_LANG"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_LANG"] = value;
            }
        }

        public static string USER_CODWEB
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["USER_CODWEB"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_CODWEB"] = value;
            }
        }

        public static string USER_DATABASE
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["USER_DATABASE"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_DATABASE"] = value;
            }
        }

        public static string FULL_NAME
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["FULL_NAME"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["FULL_NAME"] = value;
            }
        }

        public static bool IS_ADMIN
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToBoolean(HttpContext.Current.Session["IS_ADMIN"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["IS_ADMIN"] = value;
            }
        }

        public static bool USER_LOGIN
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToBoolean(HttpContext.Current.Session["USER_LOGIN"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["USER_LOGIN"] = value;
            }
        }

        public static bool MENU_SUB
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToBoolean(HttpContext.Current.Session["MENU_SUB"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["MENU_SUB"] = value;
            }
        }

        public static bool MENU_PPAL
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToBoolean(HttpContext.Current.Session["MENU_PPAL"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["MENU_PPAL"] = value;
            }
        }

        public static bool IsWindowsAuthentication()
        {
            string sAUTH_USER = Sql.ToString(HttpContext.Current.Request.ServerVariables["AUTH_USER"]);

            return !Sql.IsEmptyString(sAUTH_USER) && sAUTH_USER != USER_NAME;
        }

        public static bool IsAuthenticated()
        {
            //return !Sql.IsEmptyGuid(Security.USER_ID);
            //return !Sql.IsEmptyGuid(Security.USER_LOGIN);
            return Security.USER_LOGIN;
        }

        public static string HashPassword(string sPASSWORD)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] aby = utf8.GetBytes(sPASSWORD);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] binMD5 = md5.ComputeHash(aby);
            return Sql.HexEncode(binMD5);
        }

        public static string EncryptPassword(string sPASSWORD, Guid gKEY, Guid gIV)
        {
            UTF8Encoding utf8 = new UTF8Encoding(false);

            string sResult = null;
            byte[] byPassword = utf8.GetBytes(sPASSWORD);
            using (MemoryStream stm = new MemoryStream())
            {
                Rijndael rij = Rijndael.Create();
                rij.Key = gKEY.ToByteArray();
                rij.IV = gIV.ToByteArray();
                using (CryptoStream cs = new CryptoStream(stm, rij.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(byPassword, 0, byPassword.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                sResult = Convert.ToBase64String(stm.ToArray());
            }
            return sResult;
        }

        public static string DecryptPassword(string sPASSWORD, Guid gKEY, Guid gIV)
        {
            UTF8Encoding utf8 = new UTF8Encoding(false);

            string sResult = null;
            byte[] byPassword = Convert.FromBase64String(sPASSWORD);
            using (MemoryStream stm = new MemoryStream())
            {
                Rijndael rij = Rijndael.Create();
                rij.Key = gKEY.ToByteArray();
                rij.IV = gIV.ToByteArray();
                using (CryptoStream cs = new CryptoStream(stm, rij.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(byPassword, 0, byPassword.Length);
                    cs.Flush();
                    cs.Close();
                }
                byte[] byResult = stm.ToArray();
                sResult = utf8.GetString(byResult, 0, byResult.Length);
            }
            return sResult;
        }

        /// <summary>
        /// VARIABLES DE SESION PAGOS 
        /// </summary>

        public static string ID_POL
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["ID_POL"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["ID_POL"] = value;
            }
        }

        public static string NUM_COTIZA
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["NUM_COTIZA"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["NUM_COTIZA"] = value;
            }
        }

        public static string NUM_DOC
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["NUM_DOC"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["NUM_DOC"] = value;
            }
        }

        public static string VR_PRIMA
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["VR_PRIMA"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["VR_PRIMA"] = value;
            }
        }

        public static string VR_IVA
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                return Sql.ToString(HttpContext.Current.Session["VR_IVA"]);
            }
            set
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                    throw (new Exception("HttpContext.Current.Session is null"));
                HttpContext.Current.Session["VR_IVA"] = value;
            }
        }

        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
