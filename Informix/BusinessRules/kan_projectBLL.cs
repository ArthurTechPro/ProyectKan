using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAL;
using ProjectKAN.DAO;

namespace ProjectKAN.BLL
{
    public class kan_projectBLL
    {
        public void Delete(string idproject)
        {
            kan_projectDAL dataDAL = new kan_projectDAL();
            dataDAL.Delete(System.Int32.Parse(idproject));
        }

        public void Insert(string nomproject, string namespaceproject)
        {
            kan_projectDAL dataDAL = new kan_projectDAL();
            kan_projectDAO data = new kan_projectDAO();
            DataRow dr = data.Tables[kan_projectDAO.KAN_PROJECT_TABLA].NewRow();
            dr[kan_projectDAO.NOMPROJECT_CAMPO] = nomproject;
            dr[kan_projectDAO.NAMESPACEPROJECT_CAMPO] = namespaceproject;

            data.Tables[kan_projectDAO.KAN_PROJECT_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_projectDAO SelectALL()
        {
            kan_projectDAL dataDAL = new kan_projectDAL();
            kan_projectDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_projectDAO SelectID(string idproject)
        {
            kan_projectDAL dataDAL = new kan_projectDAL();
            kan_projectDAO data = dataDAL.SelectID(System.Int32.Parse(idproject));
            return data;
        }

        public void Update(string idproject, string nomproject, string namespaceproject)
        {
            kan_projectDAL dataDAL = new kan_projectDAL();
            dataDAL.Update(System.Int32.Parse(idproject), nomproject, namespaceproject);
        }
    }
}
