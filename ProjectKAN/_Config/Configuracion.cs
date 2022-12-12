using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ProjectKAN.WIN
{
    public class Configuracion
    {
        public Configuracion()
        {

        }

        private int intSinInstanciar = 0;
        private string _SQLCONN;
        private string _SQLDA;
        private string _SQLCMM;
        private string _SQLTRANSAC;
        private string _DBPLATAFOR;
        private string _CONFIGSETING;
        private string _DATAPROVEEDOR;
        private string _STRINGCONNECTION;
        private string _SQLPARAM;
        private string _CONSTANTE_DATATABLE;
        private string _CONSTANTE_TABLA;
        private string _CONSTANTE_BLL;
        private string _CONSTANTE_DAO;
        private string _CONSTANTE_DAL;
        private string _CONSTANTE_CAMPO;
        private string _CONSTANTE_PARAMETRO;
        private string _DEFAULT_STRINGCONNECTION;
        private string _DIR_PLANTILLAS;
        private string _TYPEDATASQL;

        public int IntSinInstanciar
        {
            get { return intSinInstanciar; }
            set { intSinInstanciar = value; }
        }

        public string SQLCONN
        {
            get { return _SQLCONN; }
            set { _SQLCONN = value; }
        }
        
        public string SQLDA
        {
            get { return _SQLDA; }
            set { _SQLDA = value; }
        }

        public string SQLCMM
        {
            get { return _SQLCMM; }
            set { _SQLCMM = value; }
        }

        public string SQLTRANSAC
        {
            get { return _SQLTRANSAC; }
            set { _SQLTRANSAC = value; }
        }
        
        public string DBPLATAFOR
        {
            get { return _DBPLATAFOR; }
            set { _DBPLATAFOR = value; }
        }
        
        public string CONFIGSETING
        {
            get { return _CONFIGSETING; }
            set { _CONFIGSETING = value; }
        }
        
        public string STRINGCONNECTION
        {
            get { return _STRINGCONNECTION; }
            set { _STRINGCONNECTION = value; }
        }
        
        public string DATAPROVEEDOR
        {
            get { return _DATAPROVEEDOR; }
            set { _DATAPROVEEDOR = value; }
        }
        
        public string SQLPARAM
        {
            get { return _SQLPARAM; }
            set { _SQLPARAM = value; }
        }
        
        public string CONSTANTE_DATATABLE
        {
            get { return _CONSTANTE_DATATABLE; }
            set { _CONSTANTE_DATATABLE = value; }
        }
        
        public string CONSTANTE_TABLA
        {
            get { return _CONSTANTE_TABLA; }
            set { _CONSTANTE_TABLA = value; }
        }
        
        public string CONSTANTE_BLL
        {
            get { return _CONSTANTE_BLL; }
            set { _CONSTANTE_BLL = value; }
        }
        
        public string CONSTANTE_DAO
        {
            get { return _CONSTANTE_DAO; }
            set { _CONSTANTE_DAO = value; }
        }
        
        public string CONSTANTE_DAL
        {
            get { return _CONSTANTE_DAL; }
            set { _CONSTANTE_DAL = value; }
        }
        
        public string CONSTANTE_CAMPO
        {
            get { return _CONSTANTE_CAMPO; }
            set { _CONSTANTE_CAMPO = value; }
        }

        public string CONSTANTE_PARAMETRO
        {
            get { return _CONSTANTE_PARAMETRO; }
            set { _CONSTANTE_PARAMETRO = value; }
        }

        public string DEFAULT_STRINGCONNECTION
        {
            get { return _DEFAULT_STRINGCONNECTION; }
            set { _DEFAULT_STRINGCONNECTION = value; }
        }

        public string DIR_PLANTILLAS
        {
            get { return _DIR_PLANTILLAS; }
            set { _DIR_PLANTILLAS = value; }
        }

        public string TYPEDATASQL
        {
            get { return _TYPEDATASQL; }
            set { _TYPEDATASQL = value; }
        }
    }
}
