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
        public void FabricarMedioTransporte_ComprobarCreacionDeMedioTransporteBarco_ValoresDeBarcoCorrectos()
        {
            //Arrange
            bool b = false;
            var esperado = new Barco();
            esperado.cNombre = "Barco";
            esperado.dCosto = 1;
            esperado.dVelocidadEntrega = 46;

            var SUT = new FabricaMediosTransporte();

            //Act
            var resultado = SUT.FabricarMedioTransporte("Barco");

            //Assert
            if (esperado.cNombre == resultado.cNombre && esperado.dCosto == resultado.dCosto && esperado.dVelocidadEntrega == resultado.dVelocidadEntrega)
                b = true;

            Assert.IsTrue(b);
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
        public void FabricarMedioTransporte_ComprobarCreacionDeMedioTransporteTren_ValoresDeBarcoCorrectos()
        {
            //Arrange
            bool b = false;
            var esperado = new Tren();
            esperado.cNombre = "Tren";
            esperado.dCosto = 5;
            esperado.dVelocidadEntrega = 80;

            var SUT = new FabricaMediosTransporte();

            //Act
            var resultado = SUT.FabricarMedioTransporte("Tren");

            //Assert
            if (esperado.cNombre == resultado.cNombre && esperado.dCosto == resultado.dCosto && esperado.dVelocidadEntrega == resultado.dVelocidadEntrega)
                b = true;

            Assert.IsTrue(b);
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
        public void FabricarMedioTransporte_ComprobarCreacionDeMedioTransporteAvion_ValoresDeBarcoCorrectos()
        {
            //Arrange
            bool b = false;
            var esperado = new Avion();
            esperado.cNombre = "Avión";
            esperado.dCosto = 10;
            esperado.dVelocidadEntrega = 600;

            var SUT = new FabricaMediosTransporte();

            //Act
            var resultado = SUT.FabricarMedioTransporte("Avion");

            //Assert
            if (esperado.cNombre == resultado.cNombre && esperado.dCosto == resultado.dCosto && esperado.dVelocidadEntrega == resultado.dVelocidadEntrega)
                b = true;

            Assert.IsTrue(b);
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