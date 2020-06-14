using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion     

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Sobrecarga de constructor que recibe parametros. Invoca al constructor base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma):
                        base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):
                    this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga del igual. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Si participa en la clase y no es deudor retorna true, sino false.</returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            bool retorno = false;

            if(a.claseQueToma==clase)
            {
                if(a.estadoCuenta!=EEstadoCuenta.Deudor)
                {
                    retorno = true;
                }
            }


            return retorno;
        }

        /// <summary>
        /// Sobrecarga del distinto. Invoca al igual.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {       
            return !(a==clase);
        }

        #endregion

        #region Polimorfismo

        /// <summary>
        /// Método override que retorna una cadena.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// Método override que retorna una cadena.
        /// </summary>
        /// <returns>Retorna los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());
            sb.AppendLine("ESTADO DE CUENTA " + this.estadoCuenta.ToString());
            sb.AppendLine("-------------------------------------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Método override que llama al MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion


    }
}
