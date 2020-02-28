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
    public class FedexUTests
    {
        [TestMethod()]
        public void DHLTest_ComprobarCreacionDeEmpresaFedex_ValoresDeBarcoCorrectos()
        {
            //Arrange
            bool b = false;
            var esperado = new Fedex();
            esperado.cNombre = "Fedex";
            esperado.dMargenUtilidad = 0.5;
            esperado.lstTTransportesUsados = new List<Type> { typeof(Barco) };

            var SUT = new FabricaEmpresas();

            //Act
            var resultado = SUT.FabricarEmpresa("Fedex");

            //Assert
            if (esperado.cNombre == resultado.cNombre && esperado.dMargenUtilidad == resultado.dMargenUtilidad && !esperado.lstTTransportesUsados.Except(resultado.lstTTransportesUsados).Any())
                b = true;

            Assert.IsTrue(b);
        }
    }
}