using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {


        #region Constructores
        /// <summary>
        /// Constructores del objeto derivado de Exception
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje):base(mensaje)
        {

        }

        public TrackingIdRepetidoException(string mensaje,Exception inner):base(mensaje,inner)
        {

        }
        #endregion
    }
}
