using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedades de lectura y escritura para acceder a atributos privados.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }

            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
        
            set { this.instructor=value; } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto. Inicializa colección.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Sobrecarga de constructor que invoca al por defecto.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }


        #endregion

        #region Sobrecarga


        /// <summary>
        /// Sobrecarga del igual.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si el alumno pertenece a la jornada, sino false.</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool retorno = false;

            foreach(Alumno item in j.alumnos)
            {
                if(item==a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del distinto. Invoca al por defecto.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {


            return !(j==a);
        }

        /// <summary>
        /// Sobrecarga del operator +. Si no pertenece a la jornada, se agrega a la colección.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Retorna el objeto.</returns>
        public static Jornada operator +(Jornada j,Alumno a)
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo de clase que guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna si se abrió.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto t = new Texto();
            string path = Directory.GetCurrentDirectory() + "\\Jornada.txt";


            if(t.Guardar(path,jornada.ToString()))
            {
                retorno = true;
            }
            

            return retorno;
        }

        /// <summary>
        /// Metodo de clase que lee la jornada de un archivo de texto.
        /// </summary>
        /// <returns>Retorna los datos leidos.</returns>
        public static string Leer()
        {
            Texto t = new Texto();
            string path = Directory.GetCurrentDirectory() + "\\Jornada.txt";
            string datos = default;
            t.Leer(path, out datos);

            return datos;
            
        }

        #endregion

        #region Polimorfismo

        /// <summary>
        /// Método override que retorna cadena .
        /// </summary>
        /// <returns>Retorna los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE :" + this.Clase.ToString());
            sb.AppendLine("PROFESOR :" + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS : ");
            foreach(Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion

    }
}
