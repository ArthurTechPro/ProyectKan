using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_comandosmBLL
    {

        public void Delete(string idcomandom)
        {
            kan_comandosmDAL dataDAL = new kan_comandosmDAL();
            dataDAL.Delete(System.Int32.Parse(idcomandom));
        }

        public void Insert(string nombrecom, string sql, string tipocomando, string tipoparametro, string idcoman)
        {
            kan_comandosmDAL dataDAL = new kan_comandosmDAL();
            kan_comandosmDAO data = new kan_comandosmDAO();
            DataRow dr = data.Tables[kan_comandosmDAO.kan_comandosm_TABLA].NewRow();
            dr[kan_comandosmDAO.NOMBRECOM_CAMPO] = nombrecom;
            dr[kan_comandosmDAO.SQL_CAMPO] = sql;
            if (tipocomando != "")
                dr[kan_comandosmDAO.TIPOCOMANDO_CAMPO] = System.Int32.Parse(tipocomando);
            else
                dr[kan_comandosmDAO.TIPOCOMANDO_CAMPO] = System.DBNull.Value; ;
            if (tipoparametro != "")
                dr[kan_comandosmDAO.TIPOPARAMETRO_CAMPO] = System.Int32.Parse(tipoparametro);
            else
                dr[kan_comandosmDAO.TIPOPARAMETRO_CAMPO] = System.DBNull.Value; ;
            if (idcoman != "")
                dr[kan_comandosmDAO.IDCOMAN_CAMPO] = System.Int32.Parse(idcoman);
            else
                dr[kan_comandosmDAO.IDCOMAN_CAMPO] = System.DBNull.Value; ;

            data.Tables[kan_comandosmDAO.kan_comandosm_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_comandosmDAO SelectALL()
        {
           kan_comandosmDAL dataDAL = new kan_comandosmDAL();
            kan_comandosmDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_comandosmDAO SelectID(string idcomandom)
        {
           kan_comandosmDAL dataDAL = new kan_comandosmDAL();
            kan_comandosmDAO data = dataDAL.SelectID(System.Int32.Parse(idcomandom));
            return data;
        }

        public void Update(string idcomandom, string nombrecom, string sql, string tipocomando, string tipoparametro, string idcoman)
        {
           kan_comandosmDAL dataDAL = new kan_comandosmDAL();
            dataDAL.Update(System.Int32.Parse(idcomandom), nombrecom, sql, System.Int32.Parse(tipocomando), System.Int32.Parse(tipoparametro), System.Int32.Parse(idcoman));
        }
    }
}
