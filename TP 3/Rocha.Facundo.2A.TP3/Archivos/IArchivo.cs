using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {

        #region Metodos

        /// <summary>
        /// Declaracion de metodo guardar
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Declaracion de metodo leer
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);

        #endregion

    }
}
