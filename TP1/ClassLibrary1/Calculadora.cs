using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class Calculadora
    {
        /// <summary>
        /// valido que el operador sea el correcto
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>el operador validado</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador=="+" || operador =="-" || operador =="*" || operador == "/")
            {
                return operador;
            }      
            
            operador = "+";

            return operador;
        }

        /// <summary>
        /// metodo que realiza las operaciones y busca a las sobrecarga de operadores
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>el resultado de las operaciones</returns>
        public static double Operar(Numero num1,Numero num2, string operador)
        {
            double respuesta=0.0; 

            if(operador=="+")
            {
                respuesta= num1 + num2;
            }

            if (operador == "-")
            {
                respuesta= num1 - num2;
            }

            if (operador == "*")
            {
                respuesta= num1 * num2;
            }

            if (operador == "/")
            {
                respuesta= num1 / num2;
            }


            return respuesta;
        }

    }
}
