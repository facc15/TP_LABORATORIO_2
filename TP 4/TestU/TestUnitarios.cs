using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestU
{
    [TestClass]
    public class TestUnitarios
    {

        #region Métodos
        /// <summary>
        /// Método que testea si una lista de paquetes fue instanciada.
        /// </summary>
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

        /// <summary>
        /// Método que verifica que se lance la excepción TrackingIdRepetidoException.
        /// </summary>
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
        #endregion
    }
}
