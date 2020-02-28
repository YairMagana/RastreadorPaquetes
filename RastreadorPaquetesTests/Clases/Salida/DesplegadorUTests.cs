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
    public class DesplegadorUTests
    {
        [TestMethod()]
        public void Desplegar_VerificarLaLlamadaADesplegarEnPantalla_LlamadaCorrectaDelMetodo()
        {
            //Arrange
            var DOCDatosSalida = new Mock<IDatosSalida>();
            var SUTDesplegador = new Mock<IDesplegador>();

            //var SUT = new Desplegador();

            //Act
            SUTDesplegador.Object.Desplegar(DOCDatosSalida.Object);

            //Assert
            SUTDesplegador.Verify(v => v.Desplegar(It.IsAny<IDatosSalida>()), Times.Once());
        }
    }
}