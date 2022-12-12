using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winner.Functions
{
    public class DigitoSOAT
    {
        /// <summary>
        /// Calculando el digito de virificacion de las polizas de SOAT, 
        /// ASEGURADORA SEGURO DEL ESTADO
        /// </summary>
        /// <param name="NoSOAT">Nomero de Polizas ( Incluyendo el digito de chequeo.</param>
        /// <returns>true - False</returns>
        public bool Calcular(string NoSOAT)
        {
            bool Validado = false;  
            int Digito_Calculado = 0, 
                Dig_Chequeo = 0, 
                Operacion1 = 0, 
                Operacion2 = 0;
            
            string Cdna_Validar1 = "", Cdna_Validar2 = "";
            
            if (NoSOAT == "0")
                Validado = false; 
            else
            {
                Cdna_Validar1 = NoSOAT.Substring(0, NoSOAT.Length - 1);
                Dig_Chequeo = Int32.Parse(NoSOAT.Substring(NoSOAT.Length - 1, 1));
                Operacion1 = Int32.Parse(Cdna_Validar1) / 7;
                Operacion2 = Operacion1 * 7;
                Cdna_Validar2 = Operacion2.ToString().Substring(0, Operacion2.ToString().Length);
                Digito_Calculado = Int32.Parse(Cdna_Validar1) - Int32.Parse(Cdna_Validar2);
                
                if (Digito_Calculado == Dig_Chequeo)
                    Validado = true; 
                else    
                    Validado = false;
            }
            return Validado;
        }
    }
}
