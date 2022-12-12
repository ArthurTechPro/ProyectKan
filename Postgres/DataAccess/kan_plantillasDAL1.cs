/// <summary>
/// DATA ACCESS Class for: Kan_plantillasDAL 
/// CODEGEN Proyecto KAN ( semilla ) 
/// Derechos Reservados ( CARLOS ARTURO HERNANDEZ ) 
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using ProjectKAN.DAO; 

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_plantillasDAL1
    {
        private NpgsqlConnection SqlConn;
 		/// <summary>
		/// Parametro de Conneccition 
		/// </summary>
		public kan_plantillasDAL1() 
		{ 
            SqlConn = new NpgsqlConnection(kan_Configuration.ConnectionString) ; 
        } 
	
    }
}
