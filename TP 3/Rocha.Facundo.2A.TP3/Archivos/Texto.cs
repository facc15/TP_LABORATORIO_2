using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo que guarda archivo de texto
        /// </summary>
        /// <param name="archivo">destino a guardar</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo,string datos)
        {
            bool retorno = false;
            try
            {
                if(archivo!=null)
                {
                    StreamWriter sw = new StreamWriter(archivo);
                    sw.WriteLine(datos);
                    retorno = true;
                    sw.Close();
                        
                }

            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

           return retorno;
        }

        /// <summary>
        /// Metodo que lee archivo de texto
        /// </summary>
        /// <param name="archivo">destino a leer</param>
        /// <param name="datos">datos que se leen</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = null;

            try
            {
                if(archivo!=null)
                {
                    StreamReader sr = new StreamReader(archivo);
                    datos=sr.ReadToEnd();
                    retorno = true;
                    sr.Close();
                }

            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

            return retorno; 
        }
    }
}
