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
using IBM.Data.Informix;
using System.Configuration;
using ProjectKAN.DAO; 

namespace ProjectKAN.DAL
{
    [Serializable()]
    public class kan_plantillasDAL1
    {
        private IfxConnection SqlConn;
 		/// <summary>
		/// Parametro de Conneccition 
		/// </summary>
		public kan_plantillasDAL1() 
		{ 
            SqlConn = new IfxConnection(kan_Configuration.ConnectionString) ; 
        } 
	
    }
}
