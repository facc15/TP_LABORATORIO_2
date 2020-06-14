using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        #region Atributos
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor con parametros que invoca al constructor base.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #region Propiedad
        /// <summary>
        /// Propiedad que expone el atributo privado.
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }
        #endregion



        #endregion

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga del igual. 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Si Son iguales en dni o legajo retorna true, sino false.</returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            bool retorno = false;

            if(pg1.Dni==pg2.Dni || pg1.legajo==pg2.legajo)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del distinto.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }


        #endregion

        #region Polimorfismo

        /// <summary>
        /// Override del equals. Iguala al objeto con el atributo object que recibe por parametro.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (((Universitario)obj)==this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Declaración de método abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Método virtual que muestra los datos a través de una cadena.
        /// </summary>
        /// <returns>Retorna la cadena</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("");
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo.ToString());

            return sb.ToString();
        }


        #endregion




    }
}
