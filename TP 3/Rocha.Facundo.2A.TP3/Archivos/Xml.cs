using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo <T>
    {

        /// <summary>
        /// Metodo que serializa datos
        /// </summary>
        /// <param name="archivo">Destino</param>
        /// <param name="datos">Datos a serializar</param>
        /// <returns></returns>
         public bool Guardar(string archivo,T datos)
        {
            bool retorno = false;

            try
            {
                if(archivo!=null)
                {
                    XmlTextWriter w = new XmlTextWriter(archivo,Encoding.UTF8);
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    s.Serialize(w, datos);
                    retorno = true;
                    w.Close();
                }


            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que deserializa datos
        /// </summary>
        /// <param name="archivo">Destino</param>
        /// <param name="datos">datos a deserializar</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default;

            try
            {
                if(archivo!=null)
                {
                    XmlTextReader r = new XmlTextReader(archivo);
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    datos = (T)s.Deserialize(r);
                    retorno = true;
                    r.Close();  

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
