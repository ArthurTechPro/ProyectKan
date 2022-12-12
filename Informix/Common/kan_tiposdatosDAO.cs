using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_tiposdatosDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_tiposdatos</summary>
        public const string KAN_TIPOSDATOS_TABLA = "kan_tiposdatos";

        /// <summary>Constante con el nombre del campo tipo</summary>
        public const string TIPO_CAMPO = "tipo";
        /// <summary>Constante con el nombre del campo dbplatform</summary>
        public const string DBPLATFORM_CAMPO = "dbplatform";
        /// <summary>Constante con el nombre del campo typedatasql</summary>
        public const string TYPEDATASQL_CAMPO = "typedatasql";
        /// <summary>Constante con el nombre del campo codigosql</summary>
        public const string CODIGOSQL_CAMPO = "codigosql";
        /// <summary>Constante con el nombre del campo nombresql</summary>
        public const string NOMBRESQL_CAMPO = "nombresql";
        /// <summary>Constante con el nombre del campo nombresql</summary>
        public const string NOMBRECOD_CAMPO = "nombrecod";
        /// <summary>Constante con el nombre del campo nombresql</summary>
        public const string NOMBRETIPO_CAMPO = "nombretipo";

        // Constructor
        public kan_tiposdatosDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA);
            columns = table.Columns;

            columns.Add(TIPO_CAMPO, typeof(System.Int32));
            columns.Add(DBPLATFORM_CAMPO, typeof(System.String));
            columns.Add(TYPEDATASQL_CAMPO, typeof(System.String));
            columns.Add(CODIGOSQL_CAMPO, typeof(System.Int16));
            columns.Add(NOMBRESQL_CAMPO, typeof(System.String));
            columns.Add(NOMBRECOD_CAMPO, typeof(System.String));
            columns.Add(NOMBRETIPO_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
    }
}
