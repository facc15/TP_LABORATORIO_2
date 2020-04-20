using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// constructores
        /// </summary>
        public Numero()
        {
            this.numero = 0; //inicializo en 0

        }

        public Numero(double numero)
        {
            this.numero = numero;  //asigno el valor de la variable
        }

        private string SetNumero   { set { this.numero = ValidarNumero(value);  }  } //valido el numero

        public Numero(string strNumero)
        {
            this.SetNumero=strNumero;  // asigno el valor string
        }



        private double ValidarNumero (string strNumero)
        {
            double retorno = 0;

            if(double.TryParse(strNumero,out retorno))   //si es un numero devuelve el retorno.
            {
                return retorno;
            }

            return retorno;
        }

        /// <summary>
        /// paso de binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>el valor string en decimal</returns>

        public string BinarioDecimal(string binario)
        {
            int resto;
            int resultado = 0;
            int exponente = 0;
            char caracter;
            bool validacion=true;
            string msjError = "Valor invalido";

            for (int i = 0; i < binario.Length; i++)
            {
                caracter = binario[i];

                if (caracter != '0' && caracter != '1' && caracter != ',')
                {
                    validacion = false;
                }
            }

            int decim = int.Parse(binario);

            if (validacion)
            {

                do
                {
                    resto = decim % 10; //guardo el resto.
                    decim /= 10; //dividir decimal en 10.
                    resultado += (int)(resto * Math.Pow(2, exponente)); //resultado es  resultado + resto
                                                                          //por 2 a la exponente.
                    exponente++;

                } while (decim != 0);

                return resultado.ToString();
            }
            else
            {
                return msjError;
            }
        }

        /// <summary>
        /// paso de decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>el valor el binario</returns>
        public string DecimalBinario(string numero)
        {
            int resto;
            string resultado = "";
            string error = "Valor invalido";
            string salida ="";

            int deci = int.Parse(numero);

            if (deci > 0)
            {
                do
                {
                    resto = deci % 2; //guardamos el resto de la division entre 2.                                      
                    deci /= 2;  // numero igual a numero divido 2.
                    resultado += resto; //concatenamos el resto en el resultado.


                } while (deci > 0);
                
                for(int i=resultado.Length-1;i>=0;i--)
                {
                    salida += resultado[i]; 
                }

                return salida;
            }
            else
            {
                return error;
            }

        }

        /// <summary>
        /// llama a la funcion que pasa a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>el string convertido en binario</returns>
        public string DecimalBinario(double numero)
        {
            string resultado = DecimalBinario(numero.ToString());

            return resultado;
        }


        /// <summary>
        /// sobrecarga de operadores
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>retorna el resultado de las operaciones</returns>
        public static double operator +(Numero num1,Numero num2)
        {
            double resultado = num1.numero + num2.numero;

            return resultado;
        }

        public static double operator -(Numero num1,Numero num2)
        {
            double resultado = num1.numero - num2.numero;

            return resultado;
        }

        public static double operator *(Numero num1,Numero num2)
        {
            double resultado = num1.numero * num2.numero;

            return resultado;
        }

        public static double operator /(Numero num1,Numero num2)
        {
            double resultado;

            if(num2.numero==0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = num1.numero / num2.numero;
            }

            return resultado;
        }


    }
}
