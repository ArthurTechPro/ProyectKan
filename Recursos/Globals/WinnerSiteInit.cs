using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web.SessionState;
using System.Text;
using System.Xml;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Web.Caching;
using Winner.Admin.DAO;
using Winner.Admin.BLL;

namespace Winner.Globals
{
    public class WinnerSiteInit
    {
        public static void InitAppURLs()
        {
            HttpApplicationState Application = HttpContext.Current.Application;
            if (Sql.IsEmptyString(Application["imageURL"]))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                HttpRequest Request = HttpContext.Current.Request;
                string sServerName = Request.ServerVariables["SERVER_NAME"];
                string sServerIPAddress = Request.ServerVariables["LOCAL_ADDR"];
                string sApplicationPath = Request.ApplicationPath;
                Application["ManikVersion"] = asm.GetName().Version.ToString();
                Application["ServerName"] = sServerName;
                Application["ServerIPAddress"] = sServerIPAddress;
                Application["ApplicationPath"] = sApplicationPath;
                if (!sApplicationPath.EndsWith("/"))
                    sApplicationPath += "/";
                Application["rootURL"] = sApplicationPath;
                //Application["imageURL"]         = sApplicationPath + "Include/images/";
                Application["imageURL"] = sApplicationPath;
                Application["scriptURL"] = sApplicationPath + "Include/javascript/";
                Application["chartURL"] = sApplicationPath + "Include/charts/";
                // Application["CONFIG.default_module"] = "/home/Default.aspx";
            }
        }

        public static bool LoginUser(string sUSER_NAME, string sPASSWORD, int sTIPOUSUARIO)
        {
            return LoginUser(sUSER_NAME, sPASSWORD, sTIPOUSUARIO, false);
        }

        public static bool LoginUser(string sUSER_NAME, string sPASSWORD, int sTIPOUSUARIO, bool bIS_ADMIN)
        {
            HttpApplicationState Application = HttpContext.Current.Application;
            HttpSessionState Session = HttpContext.Current.Session;

            bool bValidUser = false;
            if (sTIPOUSUARIO == 1) // ASESORES - EMPLEADOS
            {
                vwusers_loginDAO vuserLoginDAO = new vwusers_loginDAO();
                vwusers_loginBLL vuserLoginBLL = new vwusers_loginBLL();

                vuserLoginDAO = vuserLoginBLL.SelectLogin(sUSER_NAME, sPASSWORD);

                if (vuserLoginDAO.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in vuserLoginDAO.Tables[0].Rows)
                    {

                        bValidUser = true;
                        Security.FULL_NAME = dr[vwusers_loginDAO.NOMBRES_CAMPO].ToString();
                        Security.IS_ADMIN = Convert.ToBoolean(dr[vwusers_loginDAO.ISADMIN_CAMPO]);
                        // Security.USER_DATABASE = dr[vwusers_loginDAO.DBBASE_CAMPO].ToString();
                        Security.USER_ID = (int)(dr[vwusers_loginDAO.IDUSUARIO_CAMPO]);
                        Security.USER_NAME = dr[vwusers_loginDAO.USUARIO_CAMPO].ToString();
                        Security.USER_TIPO = sTIPOUSUARIO;
                        Security.USER_LOGIN = true;
                    }
                }
                else
                    bValidUser = false;
            }
            if (sTIPOUSUARIO == 3) //  AGENTES
            {
                /*
                vwagen_loginDAO vageLoginDAO = new vwagen_loginDAO();
                vwagen_loginBLL vageLoginBLL = new vwagen_loginBLL();

                vageLoginDAO = vageLoginBLL.SelectLogin(sUSER_NAME, sPASSWORD);

                if (vageLoginDAO.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in vageLoginDAO.Tables[0].Rows)
                    {
                        bValidUser = true;
                        Security.FULL_NAME = dr[vwagen_loginDAO.NOMBRES_CAMPO].ToString();
                        Security.IS_ADMIN = false;
                        //Security.USER_DATABASE = "none";
                        Security.USER_ID = (int)(dr[vwagen_loginDAO.IDAGENTE_CAMPO]);
                        Security.USER_NAME = dr[vwagen_loginDAO.NOMBRES_CAMPO].ToString();
                        Security.USER_TIPO = sTIPOUSUARIO;
                        Security.NIT_AGENTE = (decimal)(dr[vwagen_loginDAO.NITAGENTE_CAMPO]);
                        Security.USER_LOGIN = true;
                    }
                }
                else
                    bValidUser = false;
                */
            }

            return bValidUser; // throw(new Exception("Users.ERR_INVALID_PASSWORD"));
        }

        public static void LoadUserPreferences(Guid gID, string sTheme, string sCulture)
        {

            HttpApplicationState Application = HttpContext.Current.Application;
            HttpSessionState Session = HttpContext.Current.Session;

            string sApplicationPath = Sql.ToString(Application["rootURL"]);

            Session["USER_ID"] = 0;

            sTheme = WinnerDefault.Theme();
            Session["THEME"] = sTheme;
            Session["themeURL"] = sApplicationPath + "App_Themes/" + sTheme + "/";
            sCulture = WinnerDefault.Culture();
            string[] arrUserCultura = sCulture.Split('-');
            Session["USER_LANG"] = arrUserCultura[0];
            Session["USER_CODWEB"] = arrUserCultura[1];

            ///
            ///
            //  CARGA VARIABLES DE USUARIO SI ESTA LOGEADOI. 
            ///
        }


        public static void InitSession()
        {
            InitAppURLs();
            try
            {
                HttpSessionState Session = HttpContext.Current.Session;
                string sTheme = WinnerDefault.Theme();

                Security.SUB_MODULO = 0;
                Security.USER_MODULO = "/Home/Default.aspx";
                Security.MENU_PPAL = false;
                Security.MENU_SUB = false;

                Session["THEME"] = sTheme;

                Session["themeURL"] = Sql.ToString(HttpContext.Current.Application["rootURL"]) + "App_Themes/" + sTheme + "/";

                if (Security.IsWindowsAuthentication())
                {
                    string[] arrUserName = HttpContext.Current.User.Identity.Name.Split('\\');
                    string sUSER_DOMAIN = String.Empty;
                    string sUSER_NAME = String.Empty;
                    int sTIPOUSUARIO = 0;
                    if (arrUserName.Length > 1)
                    {
                        sUSER_DOMAIN = arrUserName[0];
                        sUSER_NAME = arrUserName[1];
                    }
                    else
                    {
                        sUSER_DOMAIN = System.Environment.MachineName;
                        sUSER_NAME = arrUserName[0];
                    }
                    bool bIS_ADMIN = false;
                    LoginUser(sUSER_NAME, String.Empty, sTIPOUSUARIO, bIS_ADMIN);
                }
                else
                {
                    // Security.PORTAL_ONLY = true;
                    LoadUserPreferences(Guid.Empty, String.Empty, String.Empty);
                }


            }
            catch (Exception Error)
            {

                throw;
            }
        }

        public static void InitTerminology()
        {

        }

        public static void InitApp()
        {
           // adm_configDAO Conf_DAO = new adm_configDAO();
           // adm_configBLL Conf_BLL = new adm_configBLL();

            try
            {
                HttpApplicationState Application = HttpContext.Current.Application;

                Application.Clear();
                InitAppURLs();
                InitTerminology();
            /*
                Conf_DAO = Conf_BLL.SelectCategoria("programa");

                if (Conf_DAO.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in Conf_DAO.Tables[0].Rows)
                    {
                        Application["CONFIG." + dr[adm_configDAO.NOMBRE_CAMPO].ToString().Trim()] = dr[adm_configDAO.VALUE_CAMPO].ToString().Trim();
                    }
                }
             */
            }
            catch (Exception ex)
            {
                //ManikError.SystemError(new StackTrace(true).GetFrame(0), ex);
                HttpContext.Current.Response.Write(ex.Message);
            }
        }

        public static void ChangeTheme(string sTHEME, string sLANGUAGE)
        {
            string sApplicationPath = Sql.ToString(HttpContext.Current.Application["rootURL"]);
            HttpContext.Current.Session["THEME"] = sTHEME;
            HttpContext.Current.Session["themeURL"] = sApplicationPath + "App_Themes/" + sTHEME + "/";
            //HttpContext.Current.Session["CULTURE"] = sLANGUAGE;
        }

      
    }
}
