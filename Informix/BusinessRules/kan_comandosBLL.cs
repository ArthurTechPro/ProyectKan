using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_comandosBLL
    {

        public void Delete(string idcomando)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            dataDAL.Delete(System.Int32.Parse(idcomando));
        }

        public void Insert(kan_comandosDAO data)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            dataDAL.Insert(data);
        }

        public kan_comandosDAO SelectALL()
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            kan_comandosDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_comandosDAO SelectID(string idcomando)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            kan_comandosDAO data = dataDAL.SelectID(System.Int32.Parse(idcomando));
            return data;
        }

        public kan_comandosDAO SelectProp(string idpropiedad)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            kan_comandosDAO data = dataDAL.SelectProp(System.Int32.Parse(idpropiedad));
            return data;
        }
        /*
        public kan_comandosDAO SelectNomCom(string nombre, string nombrecom)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            kan_comandosDAO data = dataDAL.SelectNomCom(nombre,nombrecom);
            return data;
        }
         */
        public kan_comandosDAO SelectComandosBD(string sdpropiedad)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            kan_comandosDAO data = dataDAL.SelectComandosBD(sdpropiedad);
            return data;
        }

        public void Update(kan_comandosDAO data)
        {
            kan_comandosDAL dataDAL = new kan_comandosDAL();
            dataDAL.Update(data);
        }

    }
}
