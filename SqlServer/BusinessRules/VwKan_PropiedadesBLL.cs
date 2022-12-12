using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAO;
using ProjectKAN.DAL;

namespace ProjectKAN.BLL
{
    public class VwKan_PropiedadesBLL
    {
        public VwKan_PropiedadesDAO SelectALL()
        {
            VwKan_PropiedadesDAL dataDAL = new VwKan_PropiedadesDAL();
            VwKan_PropiedadesDAO data = dataDAL.SelectALL();
            return data;
        }

        public VwKan_PropiedadesDAO SelectID(string nombre)
        {
            VwKan_PropiedadesDAL dataDAL = new VwKan_PropiedadesDAL();
            VwKan_PropiedadesDAO data = dataDAL.SelectID(nombre);
            return data;
        }
    }
}
