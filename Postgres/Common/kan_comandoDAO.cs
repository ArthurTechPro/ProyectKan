using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_comandoDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_comando</summary>
        public const string KAN_COMANDO_TABLA = "kan_comando";

        /// <summary>Constante con el nombre del campo idcoman</summary>
        public const string IDCOMAN_CAMPO = "idcoman";
        /// <summary>Constante con el nombre del campo comando</summary>
        public const string COMANDO_CAMPO = "comando";

        // Constructor
        public kan_comandoDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_comandoDAO.KAN_COMANDO_TABLA);
            columns = table.Columns;

            columns.Add(IDCOMAN_CAMPO, typeof(System.Int32));
            columns.Add(COMANDO_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
    }	
}