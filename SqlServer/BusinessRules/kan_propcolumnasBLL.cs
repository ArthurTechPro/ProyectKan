using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_propcolumnasBLL
    {

        public void Delete(string idpropcolumna)
        {
            kan_propcolumnasDAL dataDAL = new kan_propcolumnasDAL();
            dataDAL.Delete(System.Int32.Parse(idpropcolumna));
        }

        public void Insert(kan_propcolumnasDAO data)
        {
            kan_propcolumnasDAL dataDAL = new kan_propcolumnasDAL();
           dataDAL.Insert(data);
        }

        public kan_propcolumnasDAO SelectALL()
        {
            kan_propcolumnasDAL dataDAL = new kan_propcolumnasDAL();
            kan_propcolumnasDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_propcolumnasDAO SelectID(string idpropcolumna)
        {
            kan_propcolumnasDAL dataDAL = new kan_propcolumnasDAL();
            kan_propcolumnasDAO data = dataDAL.SelectID(System.Int32.Parse(idpropcolumna));
            return data;
        }

        public kan_propcolumnasDAO SelectPro(string idpropiedad)
        {
            kan_propcolumnasDAL dataDAL = new kan_propcolumnasDAL();
            kan_propcolumnasDAO data = dataDAL.SelectPro(System.Int32.Parse(idpropiedad));
            return data;
        }


        public void Update(kan_propcolumnasDAO data)
        {
            kan_propcolumnasDAL dataDAL = new kan_propcolumnasDAL();
            dataDAL.Update(data);
        }
		

    }
}
