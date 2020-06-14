using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Método que invoca al otro y le envía el mensaje de error.
        /// </summary>
        public NacionalidadInvalidaException() : this("Error, Dni inválido")
        {

        }

        /// <summary>
        /// Método que recibe el mensaje de error y lo envía al base.
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }

    }
}
