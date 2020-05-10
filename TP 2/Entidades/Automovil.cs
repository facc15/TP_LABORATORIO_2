using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region Atributos
        /// <summary>
        /// Atributos del objeto automovil.
        /// </summary>
        public enum ETipo { Monovolumen, Sedan }
        ETipo tipo;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(marca, chasis, color)
        {
            tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Constructor que inicia valores e invoca al constructor base.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion


        #region Propiedades
        /// <summary>
        /// Propiedad que retorna el tamaño del objeto Automovil. Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion


        #region Metodo
        /// <summary>
        /// Sobreescritura del metodo virtual de la clase base. 
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--AUTOMOVIL--");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
