using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.IO;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
         List<Alumno> alumnos;
         List<Jornada> jornada;
         List<Profesor> profesores;
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedades que exponen los atributos privados.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores 
        { get { return this.profesores; }
          set { this.profesores = value; } 
        }

        public List<Jornada> Jornadas 
        {
            get { return this.jornada; }
            set { this.jornada = value; } 
        }

        public Jornada this[int i]
        { get { return this.jornada[i];  }
          set { this.jornada[i] = value; }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto que inicializa las colecciones.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga del igual.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Si el alumno se encuentra retorna true, sino false.</returns>
        public static bool operator ==(Universidad g,Alumno a)
        {
            bool retorno = false;

            foreach(Alumno item in g.alumnos)
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
        /// Sobrecarga del distinto. Invoca al igual.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {   
            return !(g==a);
        }


        /// <summary>
        /// Sobrecarga del igual.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>Si el profesor se encuentra, retorna true, sino false.</returns>
        public static bool operator ==(Universidad g,Profesor i)
        {
            bool retorno = false;

            foreach(Profesor item in g.profesores)
            {
                if(item==i)
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
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }

        /// <summary>
        /// Sobrecarga del igual.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna un objeto profesor, si puede dar la clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            bool puedeDar = false;
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    retorno = item;
                    puedeDar = true;
                    break;
                }
            }

            if (!puedeDar)
            {
                throw new SinProfesorException();
            }

            return retorno;          
        }

        /// <summary>
        /// Sobrecarga del distinto.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            foreach(Profesor item in u.Instructores)
            {
                if(item!=clase)
                {
                    retorno = item;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operator +. Si el alumno no se encuentra lo agrega.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u,Alumno a)
        {
            if(u!=a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador +. Si el profesor no se encuentra lo agrega.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u!=i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador + . Se agrega una jornada.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            bool SeAgrega = false;
            Profesor aux = new Profesor();

            aux=u==clase;
            Jornada j = new Jornada(clase,aux);

            foreach(Alumno item in u.Alumnos)
            {
                if(item==clase)
                {
                    j += item;
                    SeAgrega = true;
                }
            }

            if(SeAgrega)
            {
                u.jornada.Add(j);
            }

            return u;

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo de clase que retorna cadena  con los datos.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA :");
            foreach(Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
            
        }

        /// <summary>
        /// Metodo que invoca al guardar en Xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Si pudo true, sino false.</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;

            Xml<Universidad> x = new Xml<Universidad>();
            string path = Directory.GetCurrentDirectory() + "\\Universidad.xml";

            if(x.Guardar(path,uni))
            {
                retorno = true;
            }
            

            return retorno;
        }

        /// <summary>
        /// Metodo que invoca al leer en Xml.
        /// </summary>
        /// <returns>Si pudo true, sino false.</returns>
        public Universidad Leer()
        {
            string path = Directory.GetCurrentDirectory() + "\\Universidad.xml";
            Xml<Universidad> x = new Xml<Universidad>();
            Universidad uni = default;

            x.Leer(path, out uni);

            return uni;
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Método override que invoca al MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Enumerados
        public enum EClases
        {
            Programacion,Laboratorio,Legislacion,SPD
        }
        #endregion


    }
}
