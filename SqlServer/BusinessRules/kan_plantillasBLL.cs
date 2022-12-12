using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_plantillasBLL
    {
        public void Delete(string idplantilla)
        {
            kan_plantillasDAL dataDAL = new kan_plantillasDAL();
            dataDAL.Delete(System.Int32.Parse(idplantilla));
        }

        public void Insert(string descrip, string tipoarchivo, string plantilla, string formatonom, string limpiaaspx)
        {
            kan_plantillasDAL dataDAL = new kan_plantillasDAL();
            kan_plantillasDAO data = new kan_plantillasDAO();
            DataRow dr = data.Tables[kan_plantillasDAO.KAN_PLANTILLAS_TABLA].NewRow();
            dr[kan_plantillasDAO.DESCRIP_CAMPO] = descrip;
            dr[kan_plantillasDAO.TIPOARCHIVO_CAMPO] = tipoarchivo;
            dr[kan_plantillasDAO.PLANTILLA_CAMPO] = plantilla;
            dr[kan_plantillasDAO.FORMATONOM_CAMPO] = formatonom;
            if (limpiaaspx != "")
                dr[kan_plantillasDAO.LIMPIAASPX_CAMPO] = System.Int32.Parse(limpiaaspx);
            else
                dr[kan_plantillasDAO.LIMPIAASPX_CAMPO] = System.DBNull.Value; ;

            data.Tables[kan_plantillasDAO.KAN_PLANTILLAS_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_plantillasDAO SelectALL()
        {
            kan_plantillasDAL dataDAL = new kan_plantillasDAL();
            kan_plantillasDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_plantillasDAO SelectID(string idplantilla)
        {
            kan_plantillasDAL dataDAL = new kan_plantillasDAL();
            kan_plantillasDAO data = dataDAL.SelectID(System.Int32.Parse(idplantilla));
            return data;
        }

        public void Update(string idplantilla, string descrip, string tipoarchivo, string plantilla, string formatonom, string limpiaaspx)
        {
            kan_plantillasDAL dataDAL = new kan_plantillasDAL();
            dataDAL.Update(System.Int32.Parse(idplantilla), descrip, tipoarchivo, plantilla, formatonom, System.Int32.Parse(limpiaaspx));
        }
    }
}
