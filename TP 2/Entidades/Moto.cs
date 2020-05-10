using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor que invoca al constructor base.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):base(marca,chasis,color)
        {
            

        }

        #endregion


        #region Propiedad
        /// <summary>
        /// Retorna el tamaño del vehiculo .Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion


        #region Metodo

        /// <summary>
        /// Sobreescritura del metodo virtual mostrar
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("-----MOTO-----");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : "+ this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
