using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_relacionesBLL
    {

        public void Delete(string idrelacion)
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            dataDAL.Delete(System.Int32.Parse(idrelacion));
        }

        public void Insert(string idpropiedad, string nomhijo, string nomrelacion, string relpadre, string relhijo, string omitir)
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            kan_relacionesDAO data = new kan_relacionesDAO();
            DataRow dr = data.Tables[kan_relacionesDAO.KAN_RELACIONES_TABLA].NewRow();
            if (idpropiedad != "")
                dr[kan_relacionesDAO.IDPROPIEDAD_CAMPO] = System.Int32.Parse(idpropiedad);
            else
                dr[kan_relacionesDAO.IDPROPIEDAD_CAMPO] = System.DBNull.Value; ;
            dr[kan_relacionesDAO.NOMHIJO_CAMPO] = nomhijo;
            dr[kan_relacionesDAO.NOMRELACION_CAMPO] = nomrelacion;
            dr[kan_relacionesDAO.RELPADRE_CAMPO] = relpadre;
            dr[kan_relacionesDAO.RELHIJO_CAMPO] = relhijo;
            if (omitir != "")
                dr[kan_relacionesDAO.OMITIR_CAMPO] = System.Int16.Parse(omitir);
            else
                dr[kan_relacionesDAO.OMITIR_CAMPO] = System.DBNull.Value; ;

            data.Tables[kan_relacionesDAO.KAN_RELACIONES_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_relacionesDAO SelectALL()
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            kan_relacionesDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_relacionesDAO SelectID(string idrelacion)
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            kan_relacionesDAO data = dataDAL.SelectID(System.Int32.Parse(idrelacion));
            return data;
        }

        public kan_relacionesDAO SelectRelPadre(string idrelacion)
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            kan_relacionesDAO data = dataDAL.SelectRelPadre(System.Int32.Parse(idrelacion));
            return data;
        }

        public kan_relacionesDAO SelectRelHijo(string idrelacion)
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            kan_relacionesDAO data = dataDAL.SelectRelHijo(System.Int32.Parse(idrelacion));
            return data;
        }
        public void Update(string idrelacion, string idpropiedad, string nomhijo, string nomrelacion, string relpadre, string relhijo, string omitir)
        {
            kan_relacionesDAL dataDAL = new kan_relacionesDAL();
            dataDAL.Update(System.Int32.Parse(idrelacion), System.Int32.Parse(idpropiedad), nomhijo, nomrelacion, relpadre, relhijo, System.Int16.Parse(omitir));
        }
    }
}
