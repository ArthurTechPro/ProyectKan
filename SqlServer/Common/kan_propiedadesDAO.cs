using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_propiedadesDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_propiedades</summary>
        public const string KAN_PROPIEDADES_TABLA = "kan_propiedades";

        /// <summary>Constante con el nombre del campo idpropiedad</summary>
        public const string IDPROPIEDAD_CAMPO = "idpropiedad";
        /// <summary>Constante con el nombre del campo idprojectp</summary>
        public const string IDPROJECTP_CAMPO = "idprojectp";
        /// <summary>Constante con el nombre del campo iddata</summary>
        public const string IDDATA_CAMPO = "iddata";
        /// <summary>Constante con el nombre del campo tipopropiedar</summary>
        public const string TIPOPROPIEDAD_CAMPO = "tipopropiedad";
        /// <summary>Constante con el nombre del campo nombre</summary>
        public const string NOMBRE_CAMPO = "nombre";
        /// <summary>Constante con el nombre del campo padre</summary>
        public const string PADRE_CAMPO = "padre";
        /// <summary>Constante con el nombre del campo creaselect</summary>
        public const string CREASELECT_CAMPO = "creaselect";
        /// <summary>Constante con el nombre del campo creainsert</summary>
        public const string CREAINSERT_CAMPO = "creainsert";
        /// <summary>Constante con el nombre del campo creadelete</summary>
        public const string CREADELETE_CAMPO = "creadelete";
        /// <summary>Constante con el nombre del campo creaupdate</summary>
        public const string CREAUPDATE_CAMPO = "creaupdate";

        // Constructor
        public kan_propiedadesDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_propiedadesDAO.KAN_PROPIEDADES_TABLA);
            columns = table.Columns;

            columns.Add(IDPROPIEDAD_CAMPO, typeof(System.Int32));
            columns.Add(IDPROJECTP_CAMPO, typeof(System.Int32));
            columns.Add(IDDATA_CAMPO, typeof(System.Int32));
            columns.Add(TIPOPROPIEDAD_CAMPO, typeof(System.String));
            columns.Add(NOMBRE_CAMPO, typeof(System.String));
            columns.Add(PADRE_CAMPO, typeof(System.String));
            columns.Add(CREASELECT_CAMPO, typeof(System.Int32));
            columns.Add(CREAINSERT_CAMPO, typeof(System.Int32));
            columns.Add(CREADELETE_CAMPO, typeof(System.Int32));
            columns.Add(CREAUPDATE_CAMPO, typeof(System.Int32));
            this.Tables.Add(table);
        }

    }
}
