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
    public class FabricaEmpresasUTests
    {
        [TestMethod()]
        public void FabricarEmpresa_ComprobarCreacionDeEmpresaDHL_InstanciaDeDHL()
        {
            //Arrange
            var SUT = new FabricaEmpresas();

            //Act
            var resultado = SUT.FabricarEmpresa("DHL");

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(DHL));
        }

        [TestMethod()]
        public void FabricarEmpresa_ComprobarCreacionDeEmpresaEstafeta_InstanciaDeEstafete()
        {
            //Arrange
            var SUT = new FabricaEmpresas();

            //Act
            var resultado = SUT.FabricarEmpresa("Estafeta");

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(Estafeta));
        }

        [TestMethod()]
        public void FabricarEmpresa_ComprobarCreacionDeEmpresaFedex_InstanciaDeFedex()
        {
            //Arrange
            var SUT = new FabricaEmpresas();

            //Act
            var resultado = SUT.FabricarEmpresa("Fedex");

            //Assert
            Assert.IsInstanceOfType(resultado, typeof(Fedex));
        }

        [TestMethod()]
        public void FabricarEmpresa_ComprobarErrorDeCreacionEmpresaNoExistente_MensajeDeErrorDeEmpresa()
        {
            //Arrange
            var SUT = new FabricaEmpresas();

            string s = string.Empty;
            //Act
            try
            {
                var resultado = SUT.FabricarEmpresa("X");
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }

            //Assert
            Assert.AreEqual("La Paquetería: X no se encuentra registrada en nuestra red de distribución.", s);
        }
    }
}