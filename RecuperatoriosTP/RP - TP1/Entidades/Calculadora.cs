using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Método de clase que valida el operador recibido como parámetro.
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>retorna el string validado</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = default;
            switch (operador)
            {
                case '+':
                    retorno = "+";
                    break;
                case '-':
                    retorno = "-";
                    break;
                case '*':
                    retorno = "*";
                    break;
                case '/':
                    retorno = "/";
                    break;
                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Método de clase que depende al operador, realiza las operaciones matemáticas.
        /// </summary>
        /// <param name="num1">Objeto de tipo Numero</param>
        /// <param name="num2">Objeto de tipo Numero</param>
        /// <param name="operador">El operador</param>
        /// <returns>Resultado de la operación.</returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado = default;

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;    
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*": 
                    resultado= num1 * num2;
                    break;
                case "/": 
                    resultado= num1 / num2;
                    break;
                default:
                    resultado= num1 + num2;

                    break;
            }

            return resultado;
        }

        #endregion
        
        
    }
}
