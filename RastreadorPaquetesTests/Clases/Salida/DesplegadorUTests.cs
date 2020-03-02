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
            var SUTDesplegador = new Mock<IDesplegador>();

            //Act
            SUTDesplegador.Object.Desplegar();

            //Assert
            SUTDesplegador.Verify(v => v.Desplegar(), Times.Once());
        }

        [TestMethod()]
        public void DesplegarMensaje_VerificarLaLlamadaADesplegarEnPantalla_LlamadaCorrectaDelMetodo()
        {
            //Arrange
            var DOCDatosSalida = new Mock<IDatosSalida>();
            var SUTDesplegador = new Mock<IDesplegador>();

            //Act
            SUTDesplegador.Object.DesplegarMensaje("Texto");

            //Assert
            SUTDesplegador.Verify(v => v.DesplegarMensaje(It.IsAny<string>()), Times.Once());
        }

        [TestMethod()]
        public void GuardarEnBuffer_VerificarAlmacenamientoEnBufer_BufferConElementos()
        {
            //Arrange
            IDesplegador SUTDesplegador = new Desplegador();

            //Act
            SUTDesplegador.GuardarEnBuffer("Texto", ConsoleColor.Red);

            //Assert
            Assert.AreEqual(SUTDesplegador.buffer[0].Item1, "Texto");
        }
    }
}