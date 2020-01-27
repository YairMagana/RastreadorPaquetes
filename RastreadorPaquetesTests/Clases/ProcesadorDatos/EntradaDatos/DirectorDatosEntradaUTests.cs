using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreadorPaquetes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes.Tests
{
    [TestClass()]
    public class DirectorDatosEntradaUTests
    {
        [TestMethod()]
        public void ContruirDatosEntrada_VerificarDevolucionDeObjetoDatosEntrada_ObjetoDatosEntrada()
        {
            //Arrange
            var DOCIDatosEntrada = new Mock<IDatosEntrada>();

            var DOCIConstructorDatosEntrada = new Mock<IConstructorDatosEntrada>();
            DOCIConstructorDatosEntrada.Setup(s => s.ObtenerDatosEntrada()).Returns(DOCIDatosEntrada.Object);

            string[] datos = new string[] { "A", "B", "1", "X", "Y", "01/01/2020 12:00:00 am" };

            var SUT = new DirectorDatosEntrada(datos, DOCIConstructorDatosEntrada.Object);

            //Act
            var resultado = SUT.ContruirDatosEntrada();

            //Assert
            Assert.IsInstanceOfType(DOCIDatosEntrada.Object, resultado.GetType());
        }

        [TestMethod()]
        public void ContruirDatosEntrada_VerificarDevolucionDeObjetoDatosEntradaConExcepcion_MensajeDeExcepcion()
        {
            //Arrange
            var DOCIDatosEntrada = new Mock<IDatosEntrada>();

            var DOCIConstructorDatosEntrada = new Mock<IConstructorDatosEntrada>();
            DOCIConstructorDatosEntrada.Setup(s => s.EstablecerCampoOrigen(It.IsAny<string>())).Throws(new Exception("Excepción"));

            string[] datos = new string[] { "" };

            var SUT = new DirectorDatosEntrada(datos, DOCIConstructorDatosEntrada.Object);
            var v = string.Empty;

            //Act
            try
            {
                SUT.ContruirDatosEntrada();
            }
            catch (Exception ex)
            {
                v = ex.Message;
            }

            //Assert
            Assert.AreEqual("Excepción", v);
        }
    }
}