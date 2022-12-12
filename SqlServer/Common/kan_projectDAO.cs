using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;


namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_projectDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_project</summary>
        public const string KAN_PROJECT_TABLA = "kan_project";

        /// <summary>Constante con el nombre del campo idproject</summary>
        public const string IDPROJECT_CAMPO = "idproject";
        /// <summary>Constante con el nombre del campo nomproject</summary>
        public const string NOMPROJECT_CAMPO = "nomproject";
        /// <summary>Constante con el nombre del campo namespaceproject</summary>
        public const string NAMESPACEPROJECT_CAMPO = "namespaceproject";

        // Constructor
        public kan_projectDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_projectDAO.KAN_PROJECT_TABLA);
            columns = table.Columns;

            columns.Add(IDPROJECT_CAMPO, typeof(System.Int32));
            columns.Add(NOMPROJECT_CAMPO, typeof(System.String));
            columns.Add(NAMESPACEPROJECT_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
    }
}
