using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class kan_propiedadesBLL
    {
       	public void Delete(string idpropiedad)
	    {
		    kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
		    dataDAL.Delete(System.Int32.Parse(idpropiedad));
	    }

        public void Insert(kan_propiedadesDAO data)
        {
            kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
            //data.Tables[kan_propiedadesDAO.KAN_PROPIEDADES_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

	    public kan_propiedadesDAO SelectALL()
	    {	
		    kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
		    kan_propiedadesDAO data = dataDAL.SelectALL();		
		    return data;
	    }

        public kan_propiedadesDAO SelectID(string idpropiedad )
	    {	
		    kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
		    kan_propiedadesDAO data = dataDAL.SelectID(System.Int32.Parse(idpropiedad));		
		    return data;
	    }

        public int SelectIdTity()
	    {
            int wIdTity = 0; 
            kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            data = dataDAL.SelectIdTity();
            foreach (DataRow drID in data.Tables[0].Rows)
            {
                wIdTity = Convert.ToInt32(drID[kan_propiedadesDAO.IDPROPIEDAD_CAMPO]);
            }
		    return wIdTity;
	    }


        public kan_propiedadesDAO SelectPro(string idprojectp)
        {
            kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
            kan_propiedadesDAO data = dataDAL.SelectPro(System.Int32.Parse(idprojectp));
            return data;
        }

        public void Update(kan_propiedadesDAO data)
	    {
		    kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
            dataDAL.Update(data);
	    }

        public kan_propiedadesDAO SelectTablasBD(string idprojectp)
        {
            kan_propiedadesDAL dataDAL = new kan_propiedadesDAL();
            kan_propiedadesDAO data = new kan_propiedadesDAO();
            data = dataDAL.SelectTablasBD(Int32.Parse(idprojectp));
            return data;
        }
    }
}
