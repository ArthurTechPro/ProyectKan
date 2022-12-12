using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_relacionesDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_relaciones</summary>
        public const string KAN_RELACIONES_TABLA = "kan_relaciones";

        /// <summary>Constante con el nombre del campo idrelacion</summary>
        public const string IDRELACION_CAMPO = "idrelacion";
        /// <summary>Constante con el nombre del campo idpropiedad</summary>
        public const string IDPROPIEDAD_CAMPO = "idpropiedad";
        /// <summary>Constante con el nombre del campo nomhijo</summary>
        public const string NOMHIJO_CAMPO = "nomhijo";
        /// <summary>Constante con el nombre del campo nomrelacion</summary>
        public const string NOMRELACION_CAMPO = "nomrelacion";
        /// <summary>Constante con el nombre del campo relpadre</summary>
        public const string RELPADRE_CAMPO = "relpadre";
        /// <summary>Constante con el nombre del campo relhijo</summary>
        public const string RELHIJO_CAMPO = "relhijo";
        /// <summary>Constante con el nombre del campo omitir</summary>
        public const string OMITIR_CAMPO = "omitir";

        // Constructor
        public kan_relacionesDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_relacionesDAO.KAN_RELACIONES_TABLA);
            columns = table.Columns;

            columns.Add(IDRELACION_CAMPO, typeof(System.Int32));
            columns.Add(IDPROPIEDAD_CAMPO, typeof(System.Int32));
            columns.Add(NOMHIJO_CAMPO, typeof(System.String));
            columns.Add(NOMRELACION_CAMPO, typeof(System.String));
            columns.Add(RELPADRE_CAMPO, typeof(System.String));
            columns.Add(RELHIJO_CAMPO, typeof(System.String));
            columns.Add(OMITIR_CAMPO, typeof(System.Int16));
            this.Tables.Add(table);
        }
    }
}
