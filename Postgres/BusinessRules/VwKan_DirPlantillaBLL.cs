
namespace ProjectKAN.BLL
{
    using System;
    using System.Data;
    using ProjectKAN.DAO;
    using ProjectKAN.DAL;

	public class VwKan_DirPlantillaBLL
    {

        public VwKan_DirPlantillaDAO SelectALL()
        {
            VwKan_DirPlantillaDAL dataDAL = new VwKan_DirPlantillaDAL();
            VwKan_DirPlantillaDAO data = dataDAL.SelectALL();
            return data;
        }

        public VwKan_DirPlantillaDAO SelectID(string idplantilla, string idprogectp)
        {
            VwKan_DirPlantillaDAL dataDAL = new VwKan_DirPlantillaDAL();
            VwKan_DirPlantillaDAO data = dataDAL.SelectID(System.Int32.Parse(idplantilla), System.Int32.Parse(idprogectp));
            return data;
        }


        public VwKan_DirPlantillaDAO SelectProp(string idprogectp)
        {
            VwKan_DirPlantillaDAL dataDAL = new VwKan_DirPlantillaDAL();
            VwKan_DirPlantillaDAO data = dataDAL.SelectProp( System.Int32.Parse(idprogectp));
            return data;
        }
		
	}
}
