using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAO;
using ProjectKAN.DAL;


namespace ProjectKAN.BLL
{
    public class kan_configprojectBLL
    {
        public void Delete(string idconfigp)
        {
            kan_configprojectDAL dataDAL = new kan_configprojectDAL();
            dataDAL.Delete(System.Int32.Parse(idconfigp));
        }

        public void Insert(string idproject, string nameproject)
        {
            kan_configprojectDAL dataDAL = new kan_configprojectDAL();
            kan_configprojectDAO data = new kan_configprojectDAO();
            DataRow dr = data.Tables[kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA].NewRow();
            if (idproject != "")
                dr[kan_configprojectDAO.IDPROJECT_CAMPO] = System.Int32.Parse(idproject);
            else
                dr[kan_configprojectDAO.IDPROJECT_CAMPO] = System.DBNull.Value; ;
            dr[kan_configprojectDAO.NAMEPROJECT_CAMPO] = nameproject;

            data.Tables[kan_configprojectDAO.KAN_CONFIGPROJECT_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_configprojectDAO SelectALL()
        {
            kan_configprojectDAL dataDAL = new kan_configprojectDAL();
            kan_configprojectDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_configprojectDAO SelectID(string idconfigp)
        {
            kan_configprojectDAL dataDAL = new kan_configprojectDAL();
            kan_configprojectDAO data = dataDAL.SelectID(System.Int32.Parse(idconfigp));
            return data;
        }

        public kan_configprojectDAO SelectPro(string idproject)
        {
            kan_configprojectDAL dataDAL = new kan_configprojectDAL();
            kan_configprojectDAO data = dataDAL.SelectPro(System.Int32.Parse(idproject));
            return data;
        }

        public void Update(string idconfigp, string idproject, string nameproject)
        {
            kan_configprojectDAL dataDAL = new kan_configprojectDAL();
            dataDAL.Update(System.Int32.Parse(idconfigp), System.Int32.Parse(idproject), nameproject);
        }

    }
}
