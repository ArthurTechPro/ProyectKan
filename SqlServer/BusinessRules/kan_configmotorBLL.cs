using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;
using ProjectKAN.DAL;


namespace ProjectKAN.BLL
{
    public class kan_configmotorBLL
    {
        public void Delete(string idconfig)
        {
            kan_configmotorDAL dataDAL = new kan_configmotorDAL();
            dataDAL.Delete(System.Int32.Parse(idconfig));
        }

        public void Insert(string idconfig, string nomcomando, string sql)
        {
            kan_configmotorDAL dataDAL = new kan_configmotorDAL();
            kan_configmotorDAO data = new kan_configmotorDAO();
            DataRow dr = data.Tables[kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA].NewRow();
            if (idconfig != "")
                dr[kan_configmotorDAO.IDCONFIG_CAMPO] = System.Int32.Parse(idconfig);
            else
                dr[kan_configmotorDAO.IDCONFIG_CAMPO] = System.DBNull.Value; ;
            dr[kan_configmotorDAO.NOMCOMANDO_CAMPO] = nomcomando;
            dr[kan_configmotorDAO.SQL_CAMPO] = sql;

            data.Tables[kan_configmotorDAO.KAN_CONFIGMOTOR_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_configmotorDAO SelectALL()
        {
            kan_configmotorDAL dataDAL = new kan_configmotorDAL();
            kan_configmotorDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_configmotorDAO SelectID(string idconfig)
        {
            kan_configmotorDAL dataDAL = new kan_configmotorDAL();
            kan_configmotorDAO data = dataDAL.SelectID(System.Int32.Parse(idconfig));
            return data;
        }

        public void Update(string idconfig, string nomcomando, string sql)
        {
            kan_configmotorDAL dataDAL = new kan_configmotorDAL();
            dataDAL.Update(System.Int32.Parse(idconfig), nomcomando, sql);
        }
			
    }
}
