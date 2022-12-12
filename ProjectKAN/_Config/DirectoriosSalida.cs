using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.WIN
{
    public class DirectoriosSalida
    {
        private string strDirDAO = "";
        private string strDirDAL = "";
        private string strDirBLL = "";
        private string strDirWEB = "";
        private string strDirWIN = "";
        private string strPropiedad = "";

        public string StrDirDAO
        {
            get { return strDirDAO; }
            set { strDirDAO = value; }
        }
        
        public string StrDirDAL
        {
            get { return strDirDAL; }
            set { strDirDAL = value; }
        }
        
        public string StrDirBLL
        {
            get { return strDirBLL; }
            set { strDirBLL = value; }
        }
       

        public string StrDirWEB
        {
            get { return strDirWEB; }
            set { strDirWEB = value; }
        }

        public string StrDirWIN
        {
            get { return strDirWIN; }
            set { strDirWIN = value; }
        }

        public string StrPropiedad
        {
            get { return strPropiedad; }
            set { strPropiedad = value; }
        }

    }
}
