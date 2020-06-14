using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Método que testea la lectura de archivos.
        /// </summary>
        [TestMethod]
        public void TesteoArchivos()
        {
            //Arrange
            Xml<Universidad> x = new Xml<Universidad>();
            Universidad uni = default;
            string path = "lalalala";
            
            
            //Act
            try
            {
                x.Leer(path, out uni);

            }
            catch (Exception e)
            {

            //Assert
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
            
        }

        /// <summary>
        /// Método que testea la excepción en la nacionalidad del dni.
        /// </summary>
        [TestMethod]
        public void TesteoNacionalidadInvalida()
        {

            //Arrange
            Alumno a = default;

            //Act
            try
            {
                a = new Alumno(1, "Facundo", "Rocha", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            }
            catch (Exception e)
            {
                //Assert
                Assert.IsInstanceOfType(e,typeof(NacionalidadInvalidaException));
            }
           
        }

        /// <summary>
        /// Método que testea la excepción en el ingreso erróneo en dni.
        /// </summary>
        [TestMethod]
        public void TesteoDniInvalido()
        {

            //Arrange
            Alumno a = default;

           
            //Act
            try
            {
                a = new Alumno(1, "Facundo", "Rocha", "Juan", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            }
            catch (Exception e)
            {
             //Assert
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

        }


        /// <summary>
        /// Método que testea la excepción si el alumno está repetido en la colección.
        /// </summary>
        [TestMethod]
        public void TesteoAlumnoRepetido()
        {
            //Arrange
            Alumno a1 = new Alumno(1, "Joaquin", "Valero", "32454765", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            Alumno a2 = new Alumno(1, "Roberto", "Minusi", "32454765", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Universidad u = new Universidad();

            //Act
            try
            {
                u += a1;
                u += a2;
            }
            catch (Exception e)
            {
            //Assert
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        
        }

        /// <summary>
        /// Método que testea la excepción si no hay profesor para la clase.
        /// </summary>
        [TestMethod]
        public void TesteoSinProfesor()
        {
            //Arrange
            Universidad u = new Universidad();
            Universidad.EClases clase=Universidad.EClases.Legislacion;
            Profesor p = default;
           

            //Act
            try
            {
                p = (u == clase);
            }
            catch (Exception e)
            {
                //Assert
                Assert.IsInstanceOfType(e,typeof(SinProfesorException));
            }

            
        }
        /// <summary>
        /// Método que testea que se instancie la colección.
        /// </summary>
        [TestMethod]
        public void InstanciarColeccionJornada()
        {
            //Arrange
            Alumno a1 = new Alumno(1, "Facundo", "Rocha", "36904411", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Profesor p = new Profesor(1, "Juan", "Ramirez", "32938439", Persona.ENacionalidad.Argentino);
            List<Alumno> listaAlumnos = new List<Alumno>();
            
            Jornada j = new Jornada(Universidad.EClases.Programacion, p);

            //Act
            listaAlumnos.Add(a1);
            j.Alumnos = listaAlumnos;
            

            //Assert
            Assert.IsNotNull(j.Alumnos);
        }

        /// <summary>
        /// Método que testea que se instancien las colecciones.
        /// </summary>
        [TestMethod]
        public void InstanciarColeccionUniversidad()
        {
            //Arrange
            Universidad u = new Universidad();


            //Act
            Universidad u2 = u;


            //Assert
            Assert.IsNotNull(u2.Alumnos);
            Assert.IsNotNull(u2.Instructores);
            Assert.IsNotNull(u2.Jornadas);
        }   
    }
}
