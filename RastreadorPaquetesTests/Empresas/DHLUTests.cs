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
    public class DHLUTests
    {
        [TestMethod()]
        public void DHLTest_ComprobarCreacionDeEmpresaDHL_ValoresDeBarcoCorrectos()
        {
            //Arrange
            bool b = false;
            var esperado = new DHL();
            esperado.cNombre = "DHL";
            esperado.dMargenUtilidad = 0.4;
            esperado.lstTTransportesUsados = new List<Type> { typeof(Avion), typeof(Barco) };

            var SUT = new FabricaEmpresas();

            //Act
            var resultado = SUT.FabricarEmpresa("DHL");

            //Assert
            if (esperado.cNombre == resultado.cNombre && esperado.dMargenUtilidad == resultado.dMargenUtilidad && !esperado.lstTTransportesUsados.Except(resultado.lstTTransportesUsados).Any())
                b = true;

            Assert.IsTrue(b);
        }
    }
}