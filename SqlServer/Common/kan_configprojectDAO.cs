using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_configprojectDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_configproject</summary>
        public const string KAN_CONFIGPROJECT_TABLA = "kan_configproject";

        /// <summary>Constante con el nombre del campo idconfigp</summary>
        public const string IDCONFIGP_CAMPO = "idconfigp";
        /// <summary>Constante con el nombre del campo idproject</summary>
        public const string IDPROJECT_CAMPO = "idproject";
        /// <summary>Constante con el nombre del campo nameproject</summary>
        public const string NAMEPROJECT_CAMPO = "nameproject";

        // Constructor
        public kan_configprojectDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA);
            columns = table.Columns;

            columns.Add(IDCONFIGP_CAMPO, typeof(System.Int32));
            columns.Add(IDPROJECT_CAMPO, typeof(System.Int32));
            columns.Add(NAMEPROJECT_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
		
    }
}
