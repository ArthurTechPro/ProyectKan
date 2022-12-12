using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_configgenDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_configgen</summary>
        public const string KAN_CONFIGGEN_TABLA = "kan_configgen";

        /// <summary>Constante con el nombre del campo idconfiggen</summary>
        public const string IDCONFIGGEN_CAMPO = "idconfiggen";
        /// <summary>Constante con el nombre del campo contante</summary>
        public const string CONTANTE_CAMPO = "contante";
        /// <summary>Constante con el nombre del campo variable</summary>
        public const string VARIABLE_CAMPO = "variable";

        // Constructor
        public kan_configgenDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_configgenDAO.KAN_CONFIGGEN_TABLA);
            columns = table.Columns;

            columns.Add(IDCONFIGGEN_CAMPO, typeof(Int32));
            columns.Add(CONTANTE_CAMPO, typeof(String));
            columns.Add(VARIABLE_CAMPO, typeof(String));
            this.Tables.Add(table);
        }
    }
}
