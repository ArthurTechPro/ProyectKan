using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_comandosmDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_comandosm</summary>
        public const string KAN_COMANDOSM_TABLA = "kan_comandosm";

        /// <summary>Constante con el nombre del campo idcomandom</summary>
        public const string IDCOMANDOM_CAMPO = "idcomandom";
        /// <summary>Constante con el nombre del campo nombrecom</summary>
        public const string NOMBRECOM_CAMPO = "nombrecom";
        /// <summary>Constante con el nombre del campo sql</summary>
        public const string SQL_CAMPO = "sql";
        /// <summary>Constante con el nombre del campo tipocomando</summary>
        public const string TIPOCOMANDO_CAMPO = "tipocomando";
        /// <summary>Constante con el nombre del campo tipoparametro</summary>
        public const string TIPOPARAMETRO_CAMPO = "tipoparametro";
        /// <summary>Constante con el nombre del campo idcoman</summary>
        public const string IDCOMAN_CAMPO = "idcoman";

        // Constructor
        public kan_comandosmDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_comandosmDAO.KAN_COMANDOSM_TABLA);
            columns = table.Columns;

            columns.Add(IDCOMANDOM_CAMPO, typeof(System.Int32));
            columns.Add(NOMBRECOM_CAMPO, typeof(System.String));
            columns.Add(SQL_CAMPO, typeof(System.String));
            columns.Add(TIPOCOMANDO_CAMPO, typeof(System.Int32));
            columns.Add(TIPOPARAMETRO_CAMPO, typeof(System.Int32));
            columns.Add(IDCOMAN_CAMPO, typeof(System.Int32));
            this.Tables.Add(table);
        }
    }
}
