/// <summary>
/// DATA ACCESS Class for: kan_plantillasDAO 
/// CODEGEN Proyecto KAN ( semilla ) 
/// Derechos Reservados ( CARLOS ARTURO HERNANDEZ ) 
/// </summary>

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{

    [Serializable()]
    public class kan_plantillasDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_plantillas</summary>
        public const string KAN_PLANTILLAS_TABLA = "kan_plantillas";

        /// <summary>Constante con el nombre del campo idplantilla</summary>
        public const string IDPLANTILLA_CAMPO = "idplantilla";
        /// <summary>Constante con el nombre del campo descrip</summary>
        public const string DESCRIP_CAMPO = "descrip";
        /// <summary>Constante con el nombre del campo tipoarchivo</summary>
        public const string TIPOARCHIVO_CAMPO = "tipoarchivo";
        /// <summary>Constante con el nombre del campo plantilla</summary>
        public const string PLANTILLA_CAMPO = "plantilla";
        /// <summary>Constante con el nombre del campo formatonom</summary>
        public const string FORMATONOM_CAMPO = "formatonom";
        /// <summary>Constante con el nombre del campo limpiaaspx</summary>
        public const string LIMPIAASPX_CAMPO = "limpiaaspx";

        // Constructor
        public kan_plantillasDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_plantillasDAO.KAN_PLANTILLAS_TABLA);
            columns = table.Columns;

            columns.Add(IDPLANTILLA_CAMPO, typeof(System.Int32));
            columns.Add(DESCRIP_CAMPO, typeof(System.String));
            columns.Add(TIPOARCHIVO_CAMPO, typeof(System.String));
            columns.Add(PLANTILLA_CAMPO, typeof(System.String));
            columns.Add(FORMATONOM_CAMPO, typeof(System.String));
            columns.Add(LIMPIAASPX_CAMPO, typeof(System.Int32));
            this.Tables.Add(table);
        }
    }
}
