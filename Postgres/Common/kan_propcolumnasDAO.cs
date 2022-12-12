using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKAN.DAO
{
    [Serializable()]
    public class kan_propcolumnasDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla kan_propcolumnas</summary>
        public const string KAN_PROPCOLUMNAS_TABLA = "kan_propcolumnas";

        /// <summary>Constante con el nombre del campo idpropcolumna</summary>
        public const string IDPROPCOLUMNA_CAMPO = "idpropcolumna";
        /// <summary>Constante con el nombre del campo idpropiedad</summary>
        public const string IDPROPIEDAD_CAMPO = "idpropiedad";
        /// <summary>Constante con el nombre del campo nomcolumna</summary>
        public const string NOMCOLUMNA_CAMPO = "nomcolumna";
        /// <summary>Constante con el nombre del campo esprimarykey</summary>
        public const string ESPRIMARYKEY_CAMPO = "esprimarykey";
        /// <summary>Constante con el nombre del campo grupo</summary>
        public const string GRUPO_CAMPO = "grupo";
        /// <summary>Constante con el nombre del campo descripcion</summary>
        public const string DESCRIPCION_CAMPO = "descripcion";
        /// <summary>Constante con el nombre del campo control</summary>
        public const string CONTROL_CAMPO = "control";
        /// <summary>Constante con el nombre del campo orden</summary>
        public const string ORDEN_CAMPO = "orden";
        /// <summary>Constante con el nombre del campo tipodato</summary>
        public const string TIPODATO_CAMPO = "tipodato";
        /// <summary>Constante con el nombre del campo tipodato</summary>
        public const string TIPODATOSQL_CAMPO = "tipodatosql";
        /// <summary>Constante con el nombre del campo oculto</summary>
        public const string OCULTO_CAMPO = "oculto";
        /// <summary>Constante con el nombre del campo requerido</summary>
        public const string REQUERIDO_CAMPO = "requerido";
        /// <summary>Constante con el nombre del campo esidentity</summary>
        public const string ESIDENTITY_CAMPO = "esidentity";
        /// <summary>Constante con el nombre del campo formulario</summary>
        public const string FORMULARIO_CAMPO = "formulario";
        /// <summary>Constante con el nombre del campo listado</summary>
        public const string LISTADO_CAMPO = "listado";
        /// <summary>Constante con el nombre del campo tamano</summary>
        public const string TAMANO_CAMPO = "tamano";
        /// <summary>Constante con el nombre del campo bloquedado</summary>
        public const string BLOQUEDADO_CAMPO = "bloquedado";

        // Constructor
        public kan_propcolumnasDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(kan_propcolumnasDAO.KAN_PROPCOLUMNAS_TABLA);
            columns = table.Columns;

            columns.Add(IDPROPCOLUMNA_CAMPO, typeof(Int32));
            columns.Add(IDPROPIEDAD_CAMPO, typeof(Int32));
            columns.Add(NOMCOLUMNA_CAMPO, typeof(String));
            columns.Add(ESPRIMARYKEY_CAMPO, typeof(Int16));
            columns.Add(GRUPO_CAMPO, typeof(Int32));
            columns.Add(DESCRIPCION_CAMPO, typeof(String));
            columns.Add(CONTROL_CAMPO, typeof(String));
            columns.Add(ORDEN_CAMPO, typeof(Int16));
            columns.Add(TIPODATO_CAMPO, typeof(String));
            columns.Add(TIPODATOSQL_CAMPO, typeof(String));
            columns.Add(OCULTO_CAMPO, typeof(Int16));
            columns.Add(REQUERIDO_CAMPO, typeof(Int16));
            columns.Add(ESIDENTITY_CAMPO, typeof(Int16));
            columns.Add(FORMULARIO_CAMPO, typeof(Int16));
            columns.Add(LISTADO_CAMPO, typeof(Int16));
            columns.Add(TAMANO_CAMPO, typeof(Int32));
            columns.Add(BLOQUEDADO_CAMPO, typeof(Int16));
            this.Tables.Add(table);
        }
    }

}