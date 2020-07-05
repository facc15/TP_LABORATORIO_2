using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Paquete.
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con parámetros que inicia valores del objeto.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega,string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedades publicas de lectura y escritura de los atributos de la clase.
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value;}
        }

        #endregion

        #region Sobrecarga
        /// <summary>
        /// Sobrecarga del operador igual. Iguala los objetos que recibe por parámetro.
        /// </summary>
        /// <param name="p1">Objeto tipo Paquete</param>
        /// <param name="p2">Objeto tipo Paquete</param>
        /// <returns>Retorna true si los objetos son iguales, false si no lo son.</returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            bool retorno = false;

            if (p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador distinto. Invoca a la sobrecarga del igual y lo niega.
        /// </summary>
        /// <param name="p1">Objeto tipo Paquete</param>
        /// <param name="p2">Objeto tipo Paquete</param>
        /// <returns>Retorna true si los objetos son iguales, false si no lo son.</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Delegado
        /// <summary>
        /// Objeto tipo delegado con su firma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Evento
        /// <summary>
        /// Evento asociado al delegado.
        /// </summary>
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Métodos
        /// <summary>
        /// Implementación de la interfaz. Encadena con el string.Format los atributos del parámetro recibido.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Retorna la cadena concatenada.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
            return retorno;
        }

        /// <summary>
        /// Método que invoca al evento InformaEstado cada vez que va actualizando el estado.
        /// Una vez que llega al ultimo estado, se guarda en la base de datos.
        /// </summary>
        public void MockCicloVida()
        {
            this.InformaEstado.Invoke(this, null);
            while (this.estado!=EEstado.Entregado)
            { 
                
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado.Invoke(this, null);

            }

            PaqueteDAO.Insertar(this);
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Override del TosTring. 
        /// </summary>
        /// <returns>Retorna el método MostrarDatos, con la instancia recibida como parámetro.</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Enumerado para los cambios de estado.
        /// </summary>
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        #endregion

    }
}
