using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
       /// <summary>
       /// Atributos privados de la clase correo
       /// </summary>
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto de la clase Correo.
        /// </summary>
        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura que retorna una lista de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Implementación de la interfaz. Recorrre la lista de paquetes y las retorna en formato de string.
        /// </summary>
        /// <param name="elemento">lista de paquetes</param>
        /// <returns>cadena de paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete item in this.paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));

            }

            return sb.ToString();
        }

        /// <summary>
        /// Método que recorre los hilos activos y los cierra.
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread item in this.mockPaquetes)
            {
                if(item.IsAlive)
                {
                    item.Abort();
                }
            }

        }

        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga del operador suma. Recorre los paquetes y si son iguales lanza la excepcion.
        /// </summary>
        /// <param name="c">Objeto de tipo Correo</param>
        /// <param name="p">Objeto de tipo Paquete</param>
        /// <returns>Retorna el objeto Correo con el Paquete agregado</returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            if(c!=null)
            {
                foreach (Paquete item in c.paquetes)
                {
                    if (item == p)
                    {
                        throw new TrackingIdRepetidoException("El paquete ya se encuentra en el correo");
                    }
                }


            }

            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();



            return c;

        }

  

        #endregion


    }
}
