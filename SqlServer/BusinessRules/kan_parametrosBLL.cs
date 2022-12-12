using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_parametrosBLL
    {

        public void Delete(string idparametro)
        {
            kan_parametrosDAL dataDAL = new kan_parametrosDAL();
            dataDAL.Delete(System.Int32.Parse(idparametro));
        }

        public void Insert(string idcomando, string nomcomando, string nomparametro, string tipodato, string tamano, string direccion)
        {
            kan_parametrosDAL dataDAL = new kan_parametrosDAL();
            kan_parametrosDAO data = new kan_parametrosDAO();
            DataRow dr = data.Tables[kan_parametrosDAO.KAN_PARAMETROS_TABLA].NewRow();
            if (idcomando != "")
                dr[kan_parametrosDAO.IDCOMANDO_CAMPO] = System.Int32.Parse(idcomando);
            else
                dr[kan_parametrosDAO.IDCOMANDO_CAMPO] = System.DBNull.Value; ;
            dr[kan_parametrosDAO.NOMCOMANDO_CAMPO] = nomcomando;
            dr[kan_parametrosDAO.NOMPARAMETRO_CAMPO] = nomparametro;
            dr[kan_parametrosDAO.TIPODATO_CAMPO] = tipodato;
            if (idcomando != "")
                dr[kan_parametrosDAO.TAMANO_CAMPO] = System.Int32.Parse(tamano);
            else
                dr[kan_parametrosDAO.TAMANO_CAMPO] = System.DBNull.Value; 

            if (direccion != "")
                dr[kan_parametrosDAO.DIRECCION_CAMPO] = System.Int16.Parse(direccion);
            else
                dr[kan_parametrosDAO.DIRECCION_CAMPO] = System.DBNull.Value; ;

            data.Tables[kan_parametrosDAO.KAN_PARAMETROS_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_parametrosDAO SelectALL()
        {
            kan_parametrosDAL dataDAL = new kan_parametrosDAL();
            kan_parametrosDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_parametrosDAO SelectID(string idparametro)
        {
            kan_parametrosDAL dataDAL = new kan_parametrosDAL();
            kan_parametrosDAO data = dataDAL.SelectID(System.Int32.Parse(idparametro));
            return data;
        }

        public kan_parametrosDAO SelectParamComando(string idcomando)
        {
            kan_parametrosDAL dataDAL = new kan_parametrosDAL();
            kan_parametrosDAO data = dataDAL.SelectParamComando(System.Int32.Parse(idcomando));
            return data;
        }

        public void Update(string idparametro, string idcomando, string nomcomando, string nomparametro, string tipodato, string tamano, string direccion)
        {
            kan_parametrosDAL dataDAL = new kan_parametrosDAL();
            dataDAL.Update(System.Int32.Parse(idparametro), System.Int32.Parse(idcomando), nomcomando, nomparametro, tipodato, System.Int32.Parse(tamano), System.Int16.Parse(direccion));
        }

    }
}
