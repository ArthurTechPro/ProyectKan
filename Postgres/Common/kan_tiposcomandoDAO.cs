using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_tiposcomandoDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_tiposcomando</summary>
        public const string KAN_TIPOSCOMANDO_TABLA = "kan_tiposcomando";

        /// <summary>Constante con el nombre del campo tipocomando</summary>
        public const string TIPOCOMANDO_CAMPO = "tipocomando";
        /// <summary>Constante con el nombre del campo comando</summary>
        public const string COMANDO_CAMPO = "comando";

        // Constructor
        public kan_tiposcomandoDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA);
            columns = table.Columns;

            columns.Add(TIPOCOMANDO_CAMPO, typeof(System.Int32));
            columns.Add(COMANDO_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
    }
}
