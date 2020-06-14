using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
   public class AlumnoRepetidoException: Exception
    {
        /// <summary>
        /// Metodo que invoca al Exception enviandole una cadena.
        /// </summary>
        public AlumnoRepetidoException() : base("Error, Alumno repetido")
        {

        }
    }
}
