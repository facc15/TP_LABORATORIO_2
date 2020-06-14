using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {

        /// <summary>
        /// Método por defecto que invoca al que recibe parametros.
        /// </summary>
        public DniInvalidoException() : this("Error DNI inválido")
        {

        }

        /// <summary>
        /// Método que recibe parametro e invoca al base enviandole el mensaje y la causa de la excepción.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : base(e.Message,e)
        {

        }

        /// <summary>
        /// Método que recibe el mensaje de error e invoca al base y lo envía.
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {

        }

        /// <summary>
        /// Método que recibe dos parametros e invoca al base enviándolos.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message,Exception e) : base(message,e)
        {

        }
    }
}
