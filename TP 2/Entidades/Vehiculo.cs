using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region enumerados
        /// <summary>
        /// Enumerados anidados
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region atributos
        /// <summary>
        /// Atributos de vehiculo
        /// </summary>
        EMarca marca;
        string chasis;
        ConsoleColor color;
        #endregion 

        #region constructor
        /// <summary>
        /// Constructor que inicializa los valores
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Vehiculo (EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;

        }


        #endregion


        #region propiedades
        /// <summary>
        /// Propiedad de solo lectura. Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        #endregion

        #region metodos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>retorna un string</returns>
         public virtual string Mostrar()
        {
            return (string)this;
        }

        #endregion

        #region sobrecarga
        /// <summary>
        /// Sobrecarga del operador string
        /// </summary>
        /// <param name="p">recibe un objeto vehiculo</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: "+  p.chasis );
            sb.AppendLine("MARCA : " + p.marca.ToString());
            sb.AppendLine("COLOR : " + p.color.ToString());
            sb.AppendLine("-                   -");

            return sb.ToString();
        }
        a
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">objeto tipo vehiculo</param>
        /// <param name="v2">objeto tipo vehiculo</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion 
    }
}
