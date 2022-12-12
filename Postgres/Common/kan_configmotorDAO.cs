using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProjectKAN.DAO
{
    public class kan_configmotorDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_configmotor</summary>
        public const string KAN_CONFIGMOTOR_TABLA = "kan_configmotor";

        /// <summary>Constante con el nombre del campo idconfig</summary>
        public const string IDCONFIG_CAMPO = "idconfig";
        /// <summary>Constante con el nombre del campo nomcomando</summary>
        public const string NOMCOMANDO_CAMPO = "nomcomando";
        /// <summary>Constante con el nombre del campo sql</summary>
        public const string SQL_CAMPO = "sql";

        // Constructor
        public kan_configmotorDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA);
            columns = table.Columns;

            columns.Add(IDCONFIG_CAMPO, typeof(System.Int32));
            columns.Add(NOMCOMANDO_CAMPO, typeof(System.String));
            columns.Add(SQL_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
    }
}
