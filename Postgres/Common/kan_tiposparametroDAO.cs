using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_tiposparametroDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_tiposparametro</summary>
        public const string KAN_TIPOSPARAMETRO_TABLA = "kan_tiposparametro";

        /// <summary>Constante con el nombre del campo tipoparametro</summary>
        public const string TIPOPARAMETRO_CAMPO = "tipoparametro";
        /// <summary>Constante con el nombre del campo parametro</summary>
        public const string PARAMETRO_CAMPO = "parametro";

        // Constructor
        public kan_tiposparametroDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA);
            columns = table.Columns;

            columns.Add(TIPOPARAMETRO_CAMPO, typeof(System.Int32));
            columns.Add(PARAMETRO_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
    }
}
