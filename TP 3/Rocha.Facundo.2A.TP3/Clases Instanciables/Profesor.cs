using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de clase por defecto. Inicializa el atributo Random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto. Inicializa la colección e invoca metodos.
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Sobrecarga de Constructor que invoca al base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que asigna datoss a la colección de forma aleatoria.
        /// </summary>
        private void _randomClases()
        {
            int aux = random.Next(0, 4);

            this.clasesDelDia.Enqueue((Universidad.EClases)aux);
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del igual. 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Si un profesor da la clase retorna true, sino false.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del distinto. Invoca al igual.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {

            return !(i == clase);
        }


        #endregion

        #region Polimorfismo

        /// <summary>
        /// Metodo que retorna cadena.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        } 

        /// <summary>
        /// Metodo que muestra los datos del profesor.
        /// </summary>
        /// <returns>Retorna cadena.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Método override que invoca al MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

    }
}
