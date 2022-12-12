using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProjectKAN.DAO;
using ProjectKAN.DAL;


namespace ProjectKAN.BLL
{
    public class kan_configgenBLL
    {
        public void Delete(string idconfiggen)
        {
            kan_configgenDAL dataDAL = new kan_configgenDAL();
            dataDAL.Delete(System.Int32.Parse(idconfiggen));
        }

        public void Insert(string contante, string variable)
        {
            kan_configgenDAL dataDAL = new kan_configgenDAL();
            kan_configgenDAO data = new kan_configgenDAO();
            DataRow dr = data.Tables[kan_configgenDAO.KAN_CONFIGGEN_TABLA].NewRow();
            dr[kan_configgenDAO.CONTANTE_CAMPO] = contante;
            dr[kan_configgenDAO.VARIABLE_CAMPO] = variable;

            data.Tables[kan_configgenDAO.KAN_CONFIGGEN_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_configgenDAO SelectALL()
        {
            kan_configgenDAL dataDAL = new kan_configgenDAL();
            kan_configgenDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_configgenDAO SelectID(string idconfiggen)
        {
            kan_configgenDAL dataDAL = new kan_configgenDAL();
            kan_configgenDAO data = dataDAL.SelectID(System.Int32.Parse(idconfiggen));
            return data;
        }

        public void Update(string idconfiggen, string contante, string variable)
        {
            kan_configgenDAL dataDAL = new kan_configgenDAL();
            dataDAL.Update(System.Int32.Parse(idconfiggen), contante, variable);
        }
    }
}
