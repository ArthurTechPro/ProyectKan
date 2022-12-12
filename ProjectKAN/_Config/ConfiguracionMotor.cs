using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.WIN
{
    public class ConfiguracionMotor
    {
        public ConfiguracionMotor()
        {
    
        }

        private int intSinInstanciar = 0 ;
        private string strSelectTables;
        private string strSelectColumns;
        private string strSelectSP;
        private string strSelectIDX;


        public int IntSinInstanciar
        {
            get { return intSinInstanciar; }
            set { intSinInstanciar = value; }
        }

        public string StrSelectTables
        {
            get { return strSelectTables; }
            set { strSelectTables = value; }
        }

        public string StrSelectColumns
        {
            get { return strSelectColumns; }
            set { strSelectColumns = value; }
        }

        public string StrSelectSP
        {
            get { return strSelectSP; }
            set { strSelectSP = value; }
        }

        public string StrSelectIDX
        {
            get { return strSelectIDX; }
            set { strSelectIDX = value; }
        }

    }
}
