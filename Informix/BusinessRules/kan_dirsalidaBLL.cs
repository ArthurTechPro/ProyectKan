using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAL;
using ProjectKAN.DAO;

namespace ProjectKAN.BLL
{
    public class kan_dirsalidaBLL
    {

        public void Delete(string idsalida)
        {
            kan_dirsalidaDAL dataDAL = new kan_dirsalidaDAL();
            dataDAL.Delete(System.Int32.Parse(idsalida));
        }

        public void Insert(string idprogect, string idplantilla, string directoriosalida)
        {
            kan_dirsalidaDAL dataDAL = new kan_dirsalidaDAL();
            kan_dirsalidaDAO data = new kan_dirsalidaDAO();
            DataRow dr = data.Tables[kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA].NewRow();
            if (idprogect != "")
                dr[kan_dirsalidaDAO.IDPROJECT_CAMPO] = System.Int32.Parse(idprogect);
            else
                dr[kan_dirsalidaDAO.IDPROJECT_CAMPO] = System.DBNull.Value; ;
            if (idplantilla != "")
                dr[kan_dirsalidaDAO.IDPLANTILLA_CAMPO] = System.Int32.Parse(idplantilla);
            else
                dr[kan_dirsalidaDAO.IDPLANTILLA_CAMPO] = System.DBNull.Value; ;
            dr[kan_dirsalidaDAO.DIRECTORIOSALIDA_CAMPO] = directoriosalida;

            data.Tables[kan_dirsalidaDAO.KAN_DIRSALIDA_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_dirsalidaDAO SelectALL()
        {
            kan_dirsalidaDAL dataDAL = new kan_dirsalidaDAL();
            kan_dirsalidaDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_dirsalidaDAO SelectID(string idsalida)
        {
            kan_dirsalidaDAL dataDAL = new kan_dirsalidaDAL();
            kan_dirsalidaDAO data = dataDAL.SelectID(System.Int32.Parse(idsalida));
            return data;
        }

        public kan_dirsalidaDAO SelectPro(string idprojectp)
        {
            kan_dirsalidaDAL dataDAL = new kan_dirsalidaDAL();
            kan_dirsalidaDAO data = dataDAL.SelectPro(System.Int32.Parse(idprojectp));
            return data;
        }

        public void Update(string idsalida, string idprogect, string idplantilla, string directoriosalida)
        {
            kan_dirsalidaDAL dataDAL = new kan_dirsalidaDAL();
            dataDAL.Update(System.Int32.Parse(idsalida), System.Int32.Parse(idprogect), System.Int32.Parse(idplantilla), directoriosalida);
        }
		

    }
}
