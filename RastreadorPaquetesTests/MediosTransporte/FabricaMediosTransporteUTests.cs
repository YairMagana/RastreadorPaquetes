using Microsoft.VisualStudio.TestTools.UnitTesting;
using RastreadorPaquetes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes.Tests
{
    [TestClass()]
    public class FabricaMediosTransporteUTests
    {
        [TestMethod()]
        public void FabricarMedioTransporte_ComprobarCreacionDeMedioTransporteBarco_InstanciaDeBarco()
        {
            //Arrange
            var SUT = new FabricaMediosTransporte();

            //Act
            var resultado = SUT.FabricarMedioTransporte("Barco");

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(Barco));
        }

        [TestMethod()]
        public void FabricarMedioTransporte_ComprobarCreacionDeMedioTransporteTren_InstanciaDeTren()
        {
            //Arrange
            var SUT = new FabricaMediosTransporte();

            //Act
            var resultado = SUT.FabricarMedioTransporte("Tren");

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(Tren));
        }

        [TestMethod()]
        public void FabricarMedioTransporte_ComprobarCreacionDeMedioTransporteAvion_InstanciaDeAvion()
        {
            //Arrange
            var SUT = new FabricaMediosTransporte();

            //Act
            var resultado = SUT.FabricarMedioTransporte("Avion");

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(Avion));
        }

        [TestMethod()]
        public void FabricarMedioTransporte_ComprobarErrorDeCreacionMedioTransporteNoExistente_MensajeDeErrorDeMedioTransporte()
        {
            //Arrange
            var SUT = new FabricaMediosTransporte();

            string s = string.Empty;
            //Act
            try
            {
                var resultado = SUT.FabricarMedioTransporte("X");
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }

            //Assert
            Assert.AreEqual("Medio de Tansporte No Existe", s);
        }
    }
}