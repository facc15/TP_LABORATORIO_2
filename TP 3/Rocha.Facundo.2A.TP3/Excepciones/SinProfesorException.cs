using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Método que envía el mensaje de error al base.
        /// </summary>
        public SinProfesorException() : base("No existe profesor para la clase")
        {

        }
    }
}
