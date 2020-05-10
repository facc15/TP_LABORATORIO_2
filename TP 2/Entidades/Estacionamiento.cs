using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {

        #region Atributos
        /// <summary>
        /// atributos del objeto.
        /// </summary>
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        #endregion

        #region Enumerado Tipo
        /// <summary>
        /// Enumerados del tipo de vehiculo
        /// </summary>
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado que inicia la lista.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor publico que inicia valores y que invoca al privado.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tenemos " + c.vehiculos.Count + " lugares ocupados de un total de " + c.espacioDisponible + " disponibles");
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if(v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        
                        break;
                    case ETipo.Moto:
                        if(v is Moto)
                        {
                           sb.AppendLine(v.Mostrar());
                        }
                        
                        break;
                    case ETipo.Automovil:
                        if(v is Automovil)
                        {
                           sb.AppendLine(v.Mostrar());
                        }
                        
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if(c.vehiculos.Count < c.espacioDisponible)
            {         
                    foreach(Vehiculo v in c.vehiculos)
                    {
                        if(v == p)
                        {
                        return c;
                        }                      
                    }
                c.vehiculos.Add(p);                              
            }                   
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            for (int i=0;i<c.vehiculos.Count;i++)
            {
                if (c.vehiculos[i] == p)
                {
                    c.vehiculos.RemoveAt(i);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
