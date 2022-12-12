
namespace ProjectKAN.DAO
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

	[Serializable()]
	public class VwKan_DirPlantillaDAO : DataSet
    {
        //Constantes

        /// <summary>Constante con el nombre de la tabla VwKan_DirPlantilla</summary>
        public const string VWKAN_DIRPLANTILLA_TABLA = "VwKan_DirPlantilla";

        /// <summary>Constante con el nombre del campo idplantilla</summary>
        public const string IDPLANTILLA_CAMPO = "idplantilla";
        /// <summary>Constante con el nombre del campo idprogectp</summary>
        public const string IDPROGECTP_CAMPO = "idprogectp";
        /// <summary>Constante con el nombre del campo idsalida</summary>
        public const string IDSALIDA_CAMPO = "idsalida";
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
        /// <summary>Constante con el nombre del campo directoriosalida</summary>
        public const string DIRECTORIOSALIDA_CAMPO = "directoriosalida";

        // Constructor
        public VwKan_DirPlantillaDAO()
        {
            BuildDataTables();
        }

        private void BuildDataTables()
        {
            DataTable table;
            DataColumnCollection columns;
            table = new DataTable(VwKan_DirPlantillaDAO.VWKAN_DIRPLANTILLA_TABLA);
            columns = table.Columns;

            columns.Add(IDPLANTILLA_CAMPO, typeof(System.Int32));
            columns.Add(IDPROGECTP_CAMPO, typeof(System.Int32));
            columns.Add(IDSALIDA_CAMPO, typeof(System.Int32));
            columns.Add(DESCRIP_CAMPO, typeof(System.String));
            columns.Add(TIPOARCHIVO_CAMPO, typeof(System.String));
            columns.Add(PLANTILLA_CAMPO, typeof(System.String));
            columns.Add(FORMATONOM_CAMPO, typeof(System.String));
            columns.Add(LIMPIAASPX_CAMPO, typeof(System.Int32));
            columns.Add(DIRECTORIOSALIDA_CAMPO, typeof(System.String));
            this.Tables.Add(table);
        }
			
	}
}
