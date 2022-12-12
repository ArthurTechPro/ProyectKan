using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_comandoBLL
    {

        public void Delete(string idcoman)
        {
            kan_comandoDAL dataDAL = new kan_comandoDAL();
            dataDAL.Delete(System.Int32.Parse(idcoman));
        }

        public void Insert(string idcoman, string comando)
        {
            kan_comandoDAL dataDAL = new kan_comandoDAL();
            kan_comandoDAO data = new kan_comandoDAO();
            DataRow dr = data.Tables[kan_comandoDAO.KAN_COMANDO_TABLA].NewRow();
            if (idcoman != "")
                dr[kan_comandoDAO.IDCOMAN_CAMPO] = System.Int32.Parse(idcoman);
            else
                dr[kan_comandoDAO.IDCOMAN_CAMPO] = System.DBNull.Value; ;
            dr[kan_comandoDAO.COMANDO_CAMPO] = comando;

            data.Tables[kan_comandoDAO.KAN_COMANDO_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_comandoDAO SelectALL()
        {
            kan_comandoDAL dataDAL = new kan_comandoDAL();
            kan_comandoDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_comandoDAO SelectID(string idcoman)
        {
            kan_comandoDAL dataDAL = new kan_comandoDAL();
            kan_comandoDAO data = dataDAL.SelectID(System.Int32.Parse(idcoman));
            return data;
        }

        public void Update(string idcoman, string comando)
        {
            kan_comandoDAL dataDAL = new kan_comandoDAL();
            dataDAL.Update(System.Int32.Parse(idcoman), comando);
        }
    }
}
