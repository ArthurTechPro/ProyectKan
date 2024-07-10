using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Informix.Net.Core;

namespace WebApiAcusesFacturas.Helper
{
    public class IfxConnectBd
    {
        #region Propiedades de la Clase

        /// <summary>Propiedad que Expone el DataReader en donde se encuentran los datos leidos
        /// </summary>
        public IfxDataReader DataReader;

        /// <summary>Propiedad que almacena el objeto de Conexion a la BD
        /// </summary>
        public IfxConnection Conexion { get; set; }

        /// <summary>Propiedad que devuelve un objeto SqlCeCommand
        /// </summary>
        public IfxCommand Commando { get; set; }

        /// <summary>Objeto para el manejo de las Transacciones
        /// </summary>
        public IfxTransaction Transaction { get; set; }

        /// <summary> Datatable con el resultado de la consulta
        /// </summary>
        public DataTable Datos { get; set; }

        #endregion

        #region Constructores

        /// <summary>Constructor vacio de la Clase
        /// </summary>
        public IfxConnectBd()
        {
            Commando = new IfxCommand();
            Conexion = new IfxConnection();
        }

        #endregion

        #region Metodos




        /// <summary>revisa con los parametros suministrados si se puede hacer la conexion
        /// </summary>
        //public bool Open(string cadenaConexion)
        //{
        //    IfxConnection ConexionBD;

        //    try
        //    {
        //        ConexionBD = new IfxConnection(cadenaConexion);
        //        ConexionBD.Open();
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //    ConexionBD.Close();
        //    return true;

        //}


        /// <summary>Busca que conexion esta activa o sirve
        /// </summary>
        public int FindConexion()
        {

            //if (Open(ConfigurationManager.ConnectionStrings["Libreria"].ToString()))
            //    return 1;

            //if (Open(ConfigurationManager.ConnectionStrings["Formas"].ToString()))
            //    return 2;

            //if (Open(ConfigurationManager.ConnectionStrings["Outsourcing"].ToString()))
            //    return 3;

            //if (Open(ConfigurationManager.ConnectionStrings["Editorial"].ToString()))
            //    return 4;

            //if (Open(ConfigurationManager.ConnectionStrings["Coopanamericana"].ToString()))
            //    return 11;

            //if (Open(ConfigurationManager.ConnectionStrings["Carpincoop"].ToString()))
            //    return 14;

            return 0;

        }

        public void Open(string conexion)
        {
            IfxCommand commandParametros = new IfxCommand();
            string cadena = string.Empty;

            // Si hay una conexion abierta la mantengo
            if (Conexion.State == ConnectionState.Open)
                return;

            cadena = conexion;

            // Se Abre la conexion
            try
            {
                Conexion = new IfxConnection(cadena);
                Conexion.ConnectionTimeout = 5;
                Commando.CommandTimeout = 5;
                //Conexion.ConnectionString = cadena;
                Conexion.Open();
                //Permite que la aplicacion no se rompa y si hay un bloqueo de una tabla esperaA
                //a que se desbloquee para que poder continuar la consulta
                commandParametros.Connection = Conexion;
                commandParametros.CommandText = "SET LOCK MODE TO WAIT; ";
                commandParametros.ExecuteNonQuery();

            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Crea un Objeto SqlCeCommand para ser utilizado
        /// </summary>
        public void InicializarComando()
        {
            try
            {
                Commando = new IfxCommand();//Conexion.CreateCommand();
                Commando.CommandTimeout = 1000;
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Metodo que permite crear los parametros de las diferentes consultas a realizar
        /// </summary>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="typeParam">Tipo del parametro</param>
        /// <param name="paramValue">Valor del parametro</param>
        public void AddInParameters(String paramName, IfxType typeParam, Object paramValue)
        {
            try
            {
                IfxParameter objSqlParameter = new IfxParameter
                {
                    ParameterName = paramName,
                    IfxType = typeParam,
                    Value = paramValue
                };

                Commando.Parameters.Add(objSqlParameter);
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Metodo que permite crear los parametros de las diferentes consultas a realizar
        /// </summary>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="typeParam">Tipo del parametro</param>
        /// <param name="paramValue">Valor del parametro</param>
        public void AddInParameters(String paramName, IfxType typeParam, Object paramValue, int paramsize)
        {
            try
            {
                IfxParameter objSqlParameter = new IfxParameter
                {
                    ParameterName = paramName,
                    IfxType = typeParam,
                    Value = paramValue,
                    Size = paramsize
                };

                Commando.Parameters.Add(objSqlParameter);
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Metodo que permite crear los parametros de las diferentes consultas a realizar
        /// </summary>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="typeParam">Tipo del parametro</param>
        /// <param name="paramValue">Valor del parametro</param>
        //public void AddInParameters(String paramName, IfxType typeParam, Object paramValue)
        //{
        //    try
        //    {

        //        IfxParameter objSqlParameter = new IfxParameter(paramName, typeParam) { Value = paramValue };

        //        Commando.Parameters.Add(objSqlParameter);
        //    }
        //    catch (IfxException ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}

        /// <summary>Ejecuta sentencias SQL en la Base de datos SQL Mobile
        /// </summary>
        /// <param name="tipoComando">Un CommandType para saber que se hace con la instruccion</param>
        /// <param name="query">La sentencia SQL a Ejecutar</param>
        /// <returns>Un Datareader para ser recorrido</returns>
        public IfxDataReader ExecuteReader(CommandType tipoComando, String query)
        {
            DataReader = null;
            VerificarComando();
            Commando.Connection = Conexion;
            Commando.CommandType = tipoComando;
            Commando.CommandText = query;


            try
            {
                DataReader = Commando.ExecuteReader();
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DataReader;
        }

        /// <summary> Metodo que ejecuta una sentencia y devuelve un DataSet
        /// </summary>
        /// <param name="tipoComando"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(CommandType tipoComando, String query, String compania)
        {
            string parametros = string.Empty;
            DataSet ds = new DataSet();

            VerificarComando();
            Commando.Connection = Conexion;
            Commando.CommandType = tipoComando;
            Commando.CommandText = query;

            try
            {
                IfxDataAdapter da = new IfxDataAdapter(Commando);
                da.Fill(ds);
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }


        /// <summary>Ejecuta Sentencias SQL pero devuelve un solo valor
        /// </summary>
        /// <param name="tipoComando">Tipo de comando a Ejecutar</param>
        /// <param name="query">Instruccion SQL a Ejecutar</param>
        /// <returns>Devuelve una cadena con el resultado d ela consulta SQL</returns>
        public String ExecuteScalar(CommandType tipoComando, String query, String compania)
        {
            string parametros = string.Empty;
            VerificarComando();
            Commando.Connection = Conexion;
            Commando.CommandType = tipoComando;
            Commando.CommandText = query;
            String stReturn = null;


            try
            {
                object escalar = Commando.ExecuteScalar();
                if (escalar != null)
                {
                    stReturn = escalar.ToString();
                }
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stReturn;
        }

        /// <summary> Ejecuta sentencias de INSERT, DELETE y UPDATE 
        /// </summary>
        /// <param name="tipoComando">Tipo de comando a Ejecutar</param>
        /// <param name="query">Instruccion SQL a Ejecutar</param>
        /// <returns>Un entero con el numero de registros Afectados</returns>
        public int ExecuteNonQuery(CommandType tipoComando, String query, String compania)
        {
            VerificarComando();
            Commando.Connection = Conexion;
            Commando.CommandType = tipoComando;
            Commando.CommandText = query;
            int stReturn;

            try
            {
                stReturn = Commando.ExecuteNonQuery();
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stReturn;
        }

        /// <summary>Metodo que Inicia una Transaccion para almacenar los datos y asegurarlos todos
        /// </summary>
        public IfxTransaction BeginTransaction()// DB2Transaction BeginTransaction()
        {
            try
            {
                Transaction = null;
                Transaction = Conexion.BeginTransaction();
                VerificarComando();
                Commando.Transaction = Transaction;
                return Transaction;
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Metodo que agrega una Transaccion a un comando para almacenar los datos y asegurarlos todos
        /// </summary>
        public void AddTransaction(IfxTransaction transaction)
        {
            try
            {
                VerificarComando();
                Commando.Transaction = transaction;
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>Metodo que le Hace Commit a la Transaccion
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                Transaction.Commit();
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Metodo que hace RollBack a la transaccion
        /// </summary>
        public void RollBackTransaction()
        {
            try
            {
                Transaction.Rollback();
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Metodo que Cierra la conexion y libera recursos
        /// </summary>
        public void Close()
        {
            try
            {
                Conexion.Close();
                Conexion.Dispose();
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que ejecuta una sentencia y devuelve un DataTable
        /// </summary>
        /// <param name="query">Sentencia SQl a ejecutar contra la base de datos</param>
        /// <returns>Un Datatable con los datos</returns>
        public DataTable ExecuteDataTable(String query, CommandType Type)
        {

            IfxDataAdapter daTmp = new IfxDataAdapter();

            try
            {
                DataReader = null;
                VerificarComando();
                Commando.Connection = Conexion;
                Commando.CommandType = Type;
                Commando.CommandText = query;
                daTmp = new IfxDataAdapter(Commando);
                Datos = new DataTable();
                daTmp.Fill(Datos);
            }
            catch (IfxException ex)
            {
                throw ex;
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (AccessViolationException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Datos;
        }

        /// <summary> Metodo que Verifica si el Comando no es nulo, si es nulo lo inicializa
        /// </summary>
        private void VerificarComando()
        {
            Commando.CommandTimeout = 20;
            if (Commando == null)
            {
                InicializarComando();
            }
        }

        public string Getparametros(string vf_opcion)
        {
            string parametros = string.Empty;

            foreach (IfxParameter item in Commando.Parameters)
            {
                if (vf_opcion.Trim().Equals("SI"))
                {
                    if (string.IsNullOrEmpty(parametros))
                    {
                        parametros = item.ParameterName + ": " + item.Value.ToString().Trim();
                    }
                    else
                    {
                        parametros = parametros.Trim() + ", " + item.ParameterName + ": " + item.Value.ToString().Trim();
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(parametros))
                    {
                        parametros = item.Value.ToString().Trim();
                    }
                    else
                    {
                        parametros = parametros.Trim() + ", " + item.Value.ToString().Trim();
                    }
                }



            }

            return parametros;
        }


        #endregion
    }
}