using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException: Exception
    {
        /// <summary>
        /// Método que invoca al exception enviandole una cadena.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException):base("Error en el archivo",innerException)
        {

        }

    }
}
