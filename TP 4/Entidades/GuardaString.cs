using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public static class GuardaString
    {
        #region Método
        /// <summary>
        /// Método de extensión que guarda un archivo de texto en el escritorio.
        /// Si no existe lo crea, si existe agrega información.
        /// </summary>
        /// <param name="texto">Objeto al que se le agrega el método de extensión.</param>
        /// <param name="archivo">Cadena del nombre del archivo de texto a guardar.</param>
        /// <returns>Retorna true si pudo guardar. False si no pudo.</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StringBuilder sb = new StringBuilder(path+ "//" + archivo);
            StreamWriter sw;
            bool retorno = false;
            if(File.Exists(sb.ToString()))
            {
                sw = new StreamWriter(sb.ToString(), true); ;

                sw.WriteLine(texto);

                sw.Close();
                retorno = true;
            }else
            {
                sw = new StreamWriter(sb.ToString());
                sw.WriteLine(texto);
                sw.Close();
                retorno = true;

            }


            return retorno;
        }
        #endregion
    }
}
