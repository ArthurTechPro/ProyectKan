using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_comandosDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_comandos</summary>
        public const string KAN_COMANDOS_TABLA = "kan_comandos";

        /// <summary>Constante con el nombre del campo idcomando</summary>
        public const string IDCOMANDO_CAMPO = "idcomando";
        /// <summary>Constante con el nombre del campo idpropiedad</summary>
        public const string IDPROPIEDAD_CAMPO = "idpropiedad";
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
        /// <summary>Constante con el nombre del campo parametros</summary>
        public const string PARAMETROS_CAMPO = "parametros";
        /// <summary>Constante con el nombre del campo tipoimplementa</summary>
        public const string TIPOIMPLEMENTA_CAMPO = "tipoimplementa";
      
        // Constructor
        public kan_comandosDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_comandosDAO.KAN_COMANDOS_TABLA);
            columns = table.Columns;

            columns.Add(IDCOMANDO_CAMPO, typeof(System.Int32));
            columns.Add(IDPROPIEDAD_CAMPO, typeof(System.Int32));
            columns.Add(NOMBRECOM_CAMPO, typeof(System.String));
            columns.Add(SQL_CAMPO, typeof(System.String));
            columns.Add(TIPOCOMANDO_CAMPO, typeof(System.Int32));
            columns.Add(TIPOPARAMETRO_CAMPO, typeof(System.Int32));
            columns.Add(IDCOMAN_CAMPO, typeof(System.Int32));
            columns.Add(PARAMETROS_CAMPO, typeof(System.String));
            columns.Add(TIPOIMPLEMENTA_CAMPO, typeof(System.Int16));
            this.Tables.Add(table);
        }
    }
}
