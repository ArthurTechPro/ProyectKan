﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winner.Functions
{
    public class DigitoDIAN
    {
        /// <summary>
        /// Funcion para calcular el Digito de Chequeo de la DIAN, 
        /// Recibe el NIT - SIN EL DIGITO DE CHEQUEO
        /// </summary>
        /// <param name="Nit">Nit a Calcular</param>
        /// <returns></returns>
        public int Calcular(string Nit)
        {
            string Temp;
            int Contador;
            int Residuo;
            int Acumulador;
            int[] Vector = new int[15];

            Vector[0] = 3;
            Vector[1] = 7;
            Vector[2] = 13;
            Vector[3] = 17;
            Vector[4] = 19;
            Vector[5] = 23;
            Vector[6] = 29;
            Vector[7] = 37;
            Vector[8] = 41;
            Vector[9] = 43;
            Vector[10] = 47;
            Vector[11] = 53;
            Vector[12] = 59;
            Vector[13] = 67;
            Vector[14] = 71;

            Acumulador = 0;

            Residuo = 0;

            for (Contador = 0; Contador < Nit.Length; Contador++)
            {
                Temp = Nit[(Nit.Length - 1) - Contador].ToString();
                Acumulador = Acumulador + (Convert.ToInt32(Temp) * Vector[Contador]);
            }

            Residuo = Acumulador % 11;

            if (Residuo > 1)
                return (11 - Residuo);
            else
                return Residuo;
        }
    }
}
