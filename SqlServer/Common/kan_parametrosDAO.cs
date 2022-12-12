using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_parametrosDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_parametros</summary>
        public const string KAN_PARAMETROS_TABLA = "kan_parametros";

        /// <summary>Constante con el nombre del campo idparametro</summary>
        public const string IDPARAMETRO_CAMPO = "idparametro";
        /// <summary>Constante con el nombre del campo idcomando</summary>
        public const string IDCOMANDO_CAMPO = "idcomando";
        /// <summary>Constante con el nombre del campo nomcomando</summary>
        public const string NOMCOMANDO_CAMPO = "nomcomando";
        /// <summary>Constante con el nombre del campo nomparametro</summary>
        public const string NOMPARAMETRO_CAMPO = "nomparametro";
        /// <summary>Constante con el nombre del campo tipodato</summary>
        public const string TIPODATO_CAMPO = "tipodato";
        /// <summary>Constante con el nombre del campo tipodato</summary>
        public const string TAMANO_CAMPO = "tamano";
        /// <summary>Constante con el nombre del campo direccion</summary>
        public const string DIRECCION_CAMPO = "direccion";

        // Constructor
        public kan_parametrosDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_parametrosDAO.KAN_PARAMETROS_TABLA);
            columns = table.Columns;

            columns.Add(IDPARAMETRO_CAMPO, typeof(System.Int32));
            columns.Add(IDCOMANDO_CAMPO, typeof(System.Int32));
            columns.Add(NOMCOMANDO_CAMPO, typeof(System.String));
            columns.Add(NOMPARAMETRO_CAMPO, typeof(System.String));
            columns.Add(TIPODATO_CAMPO, typeof(System.String));
            columns.Add(TAMANO_CAMPO, typeof(System.Int32));
            columns.Add(DIRECCION_CAMPO, typeof(System.Int16));
            this.Tables.Add(table);
        }

    }
}
