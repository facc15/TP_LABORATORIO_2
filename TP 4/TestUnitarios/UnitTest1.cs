using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstanciaListaCorreo()
        {
            //Arrange
            Correo c;

            //Act
            c = new Correo();

            //Assert
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void TestTrackingRepetido()
        {
            //Arrange
            Paquete p1 = new Paquete("Rosario 123", "1231231234");
            Paquete p2 = new Paquete("Debenedetti 2000", "1231231234");
            Correo c = new Correo();

            //Act
            try
            {
                c += p1;
                c += p2;

            }
            catch (TrackingIdRepetidoException e)
            {


                //Assert
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
            


          
        }
    }
}
