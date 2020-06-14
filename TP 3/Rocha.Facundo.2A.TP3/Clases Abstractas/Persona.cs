using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get { return this.apellido; }
            set { 
                if(ValidarNombreApellido(value)!=null)
                {
                    this.apellido = value;
                }     
            }
        }

        public int Dni
        {
            get { return this.dni; }
            set { this.dni=ValidarDni(this.nacionalidad,value); }
        }


        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad=value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }

            }
        }

        public string StringToDni
        {
            
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }






        #endregion

        #region Constructores


        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Sobrecargas de constructor con parametros, invoca al por defecto.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,ENacionalidad nacionalidad):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDni = dni;
        }


        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que valida el Dni ingresado
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el numero de dni.</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            int dni = -1;
            bool a = false;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    dni = dato;
                    a = true;
                }               
            }
            else
            {
                if(dato>= 90000000 && dato<= 99999999)
                {
                    dni = dato;
                    a = true;
                }
               
            }
            if(!a)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }


            return dni;
        }

        /// <summary>
        /// Sobrecarga de metodo que llama al otro y valida el dni.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = -1;
            int aux = 0;

            try
            {
                aux = int.Parse(dato);

                

            }
            catch (Exception)
            {
                throw new DniInvalidoException();
            }

            dni = ValidarDni(nacionalidad, aux);

            return dni;
        }

        /// <summary>
        /// Metodo que valida el nombre ingresado
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>retorna el nombre validado o null</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex miRegex = new Regex("^[A-Z][a-z]{2,10}$");
            string nombre = null;

            if(miRegex.IsMatch(dato))
            {
                nombre = dato;

            }
            return nombre;

        }




        #endregion

        #region Polimorfismo

        /// <summary>
        /// Metodo que retorna una cadena con los datos de la persona.
        /// </summary>
        /// <returns>Retorna la cadena</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad.ToString());
            sb.AppendLine("DNI: " + this.dni.ToString());

            return sb.ToString();
        }
        #endregion

        #region Enumerados

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion 
    }
}
