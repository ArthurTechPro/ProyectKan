using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAO;
using ProjectKAN.BLL;

namespace ProjectKAN.WIN
{
    public class GeneraObjeto
    {

        public Configuracion ConfigActual;
        public ConfiguracionMotor ConfigMotor;
        public DataSet DataSetBase;
        //  VwKan_propiedades  // Tablas
        // private DataSet dataSet;


        /// <summary>
        /// Genera la plantilla de del codigo XML
        /// </summary>
        /// <param name="idPlantilla">Id de Plantilla</param>
        /// <param name="wl_NomPropiedad">Nombre de la Propiedad ( Tabla ) </param>
        /// <param name="idProjectp">ID del proyecto</param>
        /// <param name="esXML">Si solo genera el archivo XML para Verificacion</param>
        /// <returns>NO APLICA</returns>
        public string Planilla(string idPlantilla, string wl_NomPropiedad, string idProject, string idProjectp, bool esXML)
        {
            string resultado = "";
            string arcPlantilla = "";
            string frmPlantilla = "";
            string arcClaseSalida = "";
            string TipoArchivo = "";
            string DirSalida = "";

            VwKan_DirPlantillaDAO Kan_DPlantDAO = new VwKan_DirPlantillaDAO();
            VwKan_DirPlantillaBLL Kan_DPlantBLL = new VwKan_DirPlantillaBLL();

            Kan_DPlantDAO = Kan_DPlantBLL.SelectID(idPlantilla, idProject);

            foreach (DataRow dr in Kan_DPlantDAO.Tables[0].Rows)
            {
                arcPlantilla = ConfigActual.DIR_PLANTILLAS.ToString().Trim() + "\\" + dr[kan_plantillasDAO.PLANTILLA_CAMPO].ToString().Trim();
                //arcPlantilla = dr[kan_plantillasDAO.PLANTILLA_CAMPO].ToString();
                frmPlantilla = dr[VwKan_DirPlantillaDAO.FORMATONOM_CAMPO].ToString().Trim();
                arcClaseSalida = string.Format(frmPlantilla, wl_NomPropiedad.ToString().Trim());
                TipoArchivo = dr[VwKan_DirPlantillaDAO.TIPOARCHIVO_CAMPO].ToString().Trim();
                DirSalida = dr[VwKan_DirPlantillaDAO.DIRECTORIOSALIDA_CAMPO].ToString().Trim();
            }
            if (esXML)
                arcClaseSalida += ".xml";

            bool esASPX = false;

            VwKan_PropiedadesDAO VwKan_PropDAO = new VwKan_PropiedadesDAO();
            VwKan_PropiedadesBLL VwKan_PropBLL = new VwKan_PropiedadesBLL();

            VwKan_PropDAO = VwKan_PropBLL.SelectID(wl_NomPropiedad);

            GenerarXML GenXml = new GenerarXML();
            GenXml.ConfigActual = ConfigActual;
            GenXml.ConfigMotor = ConfigMotor;
            GenXml.TipoArchivo = TipoArchivo;
            GenXml.DataSetBase = VwKan_PropDAO;


            /// <summary>
            /// Tranforma la Plantilla.. Foirmato XML.
            /// </summary>
            string xmlSalida = GenXml.Transformar(wl_NomPropiedad, arcPlantilla, arcClaseSalida, esASPX, esXML);

            //string arcBackup = directorioBackup + "\\" + arcClaseSalida;

            string arcBackup = @"D:\\Archivos\\Backup\\" + arcClaseSalida.Trim();

            //arcClaseSalida = "..\\" + DirSalida + "\\" + arcClaseSalida;
            arcClaseSalida = @"D:\\Archivos\\Salida\\" + arcClaseSalida.Trim();

            if (xmlSalida != "")
            {
                if (File.Exists(arcClaseSalida))
                    File.Copy(arcClaseSalida, arcBackup, true);

                StreamWriter sw = File.CreateText(arcClaseSalida);
                sw.Write(xmlSalida);
                sw.Close();
                resultado = arcClaseSalida;
            }

            return resultado;
        }
    }
}
