using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAL;
using ProjectKAN.DAO;
namespace ProjectKAN.BLL
{
    public class kan_tiposparametroBLL
    {

        public void Delete(string tipoparametro)
        {
            kan_tiposparametroDAL dataDAL = new kan_tiposparametroDAL();
            dataDAL.Delete(System.Int32.Parse(tipoparametro));
        }

        public void Insert(string tipoparametro, string parametro)
        {
            kan_tiposparametroDAL dataDAL = new kan_tiposparametroDAL();
            kan_tiposparametroDAO data = new kan_tiposparametroDAO();
            DataRow dr = data.Tables[kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA].NewRow();
            if (tipoparametro != "")
                dr[kan_tiposparametroDAO.TIPOPARAMETRO_CAMPO] = System.Int32.Parse(tipoparametro);
            else
                dr[kan_tiposparametroDAO.TIPOPARAMETRO_CAMPO] = System.DBNull.Value; ;
            dr[kan_tiposparametroDAO.PARAMETRO_CAMPO] = parametro;

            data.Tables[kan_tiposparametroDAO.KAN_TIPOSPARAMETRO_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_tiposparametroDAO SelectALL()
        {
            kan_tiposparametroDAL dataDAL = new kan_tiposparametroDAL();
            kan_tiposparametroDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_tiposparametroDAO SelectID(string tipoparametro)
        {
            kan_tiposparametroDAL dataDAL = new kan_tiposparametroDAL();
            kan_tiposparametroDAO data = dataDAL.SelectID(System.Int32.Parse(tipoparametro));
            return data;
        }

        public void Update(string tipoparametro, string parametro)
        {
            kan_tiposparametroDAL dataDAL = new kan_tiposparametroDAL();
            dataDAL.Update(System.Int32.Parse(tipoparametro), parametro);
        }

    }
}
