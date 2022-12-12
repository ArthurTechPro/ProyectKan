using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectKAN.DAL;
using ProjectKAN.DAO;

namespace ProjectKAN.BLL
{
    public class kan_tiposdatosBLL
    {

        public void Delete(string tipo)
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            dataDAL.Delete(System.Int32.Parse(tipo));
        }

        public void Insert(string dbplatform, string typedatasql, string codigosql, string nombresql, string nombrecod)
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            kan_tiposdatosDAO data = new kan_tiposdatosDAO();
            DataRow dr = data.Tables[kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA].NewRow();
            dr[kan_tiposdatosDAO.DBPLATFORM_CAMPO] = dbplatform;
            dr[kan_tiposdatosDAO.TYPEDATASQL_CAMPO] = typedatasql;
            if (codigosql != "")
                dr[kan_tiposdatosDAO.CODIGOSQL_CAMPO] = System.Int16.Parse(codigosql);
            else
                dr[kan_tiposdatosDAO.CODIGOSQL_CAMPO] = System.DBNull.Value;

            dr[kan_tiposdatosDAO.NOMBRESQL_CAMPO] = nombresql;
            dr[kan_tiposdatosDAO.NOMBRECOD_CAMPO] = nombrecod;

            data.Tables[kan_tiposdatosDAO.KAN_TIPOSDATOS_TABLA].Rows.Add(dr);
            dataDAL.Insert(data);
        }

        public kan_tiposdatosDAO SelectALL()
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            kan_tiposdatosDAO data = dataDAL.SelectALL();
            return data;
        }

        public kan_tiposdatosDAO SelectID(string tipo)
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            kan_tiposdatosDAO data = dataDAL.SelectID(System.Int32.Parse(tipo));
            return data;
        }

        public kan_tiposdatosDAO SelectCod(Int32 codigosql, string dbplatform)
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            kan_tiposdatosDAO data = dataDAL.SelectCod(codigosql, dbplatform);
            return data;
        }

        public kan_tiposdatosDAO SelectCod(Int32 codigosql, string nombresql, string dbplatform)
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            kan_tiposdatosDAO data = dataDAL.SelectCod(codigosql, nombresql, dbplatform);
            return data;
        }


        public void Update(string tipo, string dbplatform, string typedatasql, string codigosql, string nombresql, string nombrecod, string nombretipo)
        {
            kan_tiposdatosDAL dataDAL = new kan_tiposdatosDAL();
            dataDAL.Update(System.Int32.Parse(tipo), dbplatform, typedatasql, System.Int16.Parse(codigosql), nombresql, nombrecod, nombretipo);
        }

    }
}
