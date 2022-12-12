using System;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Winner.Globals
{
    public class WinnerDefault
    {
        public static string Culture(HttpApplicationState Application)
        {
            string sCulture = Sql.ToString(Application["CONFIG.default_language"]);
            if (HttpContext.Current != null && HttpContext.Current.Cache != null)
            {
                ///  coloca el nombre de la cultura
                /// sCulture = Sql.ToString(CultureInfo.CurrentCulture.DisplayName);
                sCulture = Sql.ToString(CultureInfo.CurrentCulture.Name);
            }
            if (Sql.IsEmptyString(sCulture))
                sCulture = "es-CO";
            //return L10N.NormalizeCulture(sCulture);
            return sCulture;
        }

        public static string Culture()
        {
            return Culture(HttpContext.Current.Application);
        }

        public static string Theme()
        {
            string sTheme = Sql.ToString(HttpContext.Current.Application["CONFIG.default_theme"]);
            if (Sql.IsEmptyString(sTheme))
                sTheme = "Winner";
            return sTheme;
        }
    }
}
