using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAL;
using ProjectKAN.DAO;

namespace ProjectKAN.BLL
{
    public class kan_tiposcomandoBLL
    {

        public void Delete(string tipocomando)
        {
            kan_tiposcomandoDAL dataDAL = new kan_tiposcomandoDAL();
            dataDAL.Delete(System.Int32.Parse(tipocomando));
        }

        public void Insert(string tipocomando, string comando)
        {
            kan_tiposcomandoDAL dataDAL = new kan_tiposcomandoDAL();
            kan_tiposcomandoDAO data = new kan_tiposcomandoDAO();
            DataRow dr = data.Tables[kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA].NewRow();
            if (tipocomando != "")
                dr[kan_tiposcomandoDAO.TIPOCOMANDO_CAMPO] = System.Int32.Parse(tipocomando);
            else
                dr[kan_tiposcomandoDAO.TIPOCOMANDO_CAMPO] = System.DBNull.Value; ;
            dr[kan_tiposcomandoDAO.COMANDO_CAMPO] = comando;

            data.Tables[kan_tiposcomandoDAO.KAN_TIPOSCOMANDO_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_tiposcomandoDAO SelectALL()
        {
            kan_tiposcomandoDAL dataDAL = new kan_tiposcomandoDAL();
            kan_tiposcomandoDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_tiposcomandoDAO SelectID(string tipocomando)
        {
            kan_tiposcomandoDAL dataDAL = new kan_tiposcomandoDAL();
            kan_tiposcomandoDAO data = dataDAL.SelectID(System.Int32.Parse(tipocomando));
            return data;
        }


        public void Update(string tipocomando, string comando)
        {
            kan_tiposcomandoDAL dataDAL = new kan_tiposcomandoDAL();
            dataDAL.Update(System.Int32.Parse(tipocomando), comando);
        }

    }
}
