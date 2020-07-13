using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        /// <summary>
        /// Atributo privado que contiene un doble.
        /// </summary>
        private double numero;
        #endregion

        #region Constructores
        /// <summary>
        /// Constuctor por defecto, inicializa con 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un parámetro de tipo double.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que recibe un parámetro de tipo string y reutiliza el constructor anterior.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero):this(double.Parse(strNumero))
        {

        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad de sólo escritura que inicializa con el valor validado.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Valida que el parámetro recibido sea un número.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            
            if(double.TryParse(strNumero, out retorno ))
            {
                return retorno;
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si el parámetro recibido es un número binario.
        /// </summary>
        /// <param name="binario">parámetro a validar.</param>
        /// <returns>Retorna false si no es binario. True si lo es.</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for(int i=0;i<binario.Length-1;i++)
            {
                if (binario[i] != '1' && binario[i]!='0')
                {
                    retorno = false;
                    return retorno;
                }

            }

            return retorno;
        }

        /// <summary>
        /// Método que pasa el parámetro recibido de decimal a binario.
        /// </summary>
        /// <param name="binario">Parámetro a validar</param>
        /// <returns>Retorna el resultado o un mensaje de error.</returns>
        public string BinarioDecimal(string binario)
        {
            int resto;
            int resultado = 0;
            int exponente = 0;
            bool validacion = true;
            string msjError = "Valor invalido";

            for (int i = 0; i < binario.Length-1; i++)
            {

                if (binario[i] != '0' && binario[i] != '1')
                {
                    validacion = false;
                }
            }

            int decim = int.Parse(binario);

            if (validacion)
            {

                do
                {
                    resto = decim % 10; 
                    decim /= 10; 
                    resultado += (int)(resto * Math.Pow(2, exponente));
                                                                        
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
        /// Método que pasa el parámetro recibido de decimal a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>el valor el binario</returns>
        public string DecimalBinario(string numero)
        {
            int resto;
            string resultado = default;
            string error = "Valor invalido";
            string salida = default;

            int deci = int.Parse(numero);

            if (deci >= 0)
            {
                do
                {
                    resto = deci % 2;                                    
                    deci /= 2;  
                    resultado += resto; 


                } while (deci > 0);

                for (int i = resultado.Length - 1; i >= 0; i--)
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
        ///Invoca al método que pasa a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>String convertido en binario</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga del operador +. Suma dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -. Resta dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *. Multiplica dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la multiplicación.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /. Divide dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la división.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero==0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }
        #endregion

    }
}
