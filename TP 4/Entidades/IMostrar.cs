using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar <T>
    {
        #region Método
        /// <summary>
        /// Método a implementar de la interfaz.
        /// </summary>
        /// <param name="elemento">Recine una Interfaz</param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);

        #endregion
    }
}
