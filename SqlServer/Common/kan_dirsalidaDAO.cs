using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_dirsalidaDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_dirsalida</summary>
        public const string KAN_DIRSALIDA_TABLA = "kan_dirsalida";

        /// <summary>Constante con el nombre del campo idsalida</summary>
        public const string IDSALIDA_CAMPO = "idsalida";
        /// <summary>Constante con el nombre del campo idprogect</summary>
        public const string IDPROGECTP_CAMPO = "idprogectp";
        /// <summary>Constante con el nombre del campo idplantilla</summary>
        public const string IDPLANTILLA_CAMPO = "idplantilla";
        /// <summary>Constante con el nombre del campo directoriosalida</summary>
        public const string DIRECTORIOSALIDA_CAMPO = "directoriosalida";

        // Constructor
        public kan_dirsalidaDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA);
            columns = table.Columns;

            columns.Add(IDSALIDA_CAMPO, typeof(System.Int32));
            columns.Add(IDPROGECTP_CAMPO, typeof(System.Int32));
            columns.Add(IDPLANTILLA_CAMPO, typeof(System.Int32));
            columns.Add(DIRECTORIOSALIDA_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
		
    }
}
