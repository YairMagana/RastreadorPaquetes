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
    public class DirectorMensajeSalidaUTests
    {
        [TestMethod()]
        public void ConstruirMensajeSalida_ProbarLaConstruccionDeLaCadenaResultado_CadenaDeResultadoConstruida()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<IDatosEntrada>();
            DOCDatosEntrada.Setup(s => s.cOrigen).Returns("B");
            DOCDatosEntrada.Setup(s => s.cDestino).Returns("D");
            DOCDatosEntrada.Setup(s => s.dCostoEnvio).Returns(1);
            DOCDatosEntrada.Setup(s => s.objEmpresa.cNombre).Returns("H");

            var DOCDirectorDatosEntrada = new Mock<IDirectorDatosEntrada>();
            DOCDirectorDatosEntrada.Setup(s => s.ContruirDatosEntrada()).Returns(DOCDatosEntrada.Object);
            var DOCConstructorDatosSalida = new Mock<IConstructorDatosSalida>();

            DOCConstructorDatosSalida.Setup(s => s.GenerarExpresion1(It.IsAny<DateTime>())).Returns("A");
            DOCConstructorDatosSalida.Setup(s => s.GenerarExpresion2(It.IsAny<DateTime>())).Returns("C");
            DOCConstructorDatosSalida.Setup(s => s.GenerarExpresion3(It.IsAny<DateTime>())).Returns("E");
            DOCConstructorDatosSalida.Setup(s => s.GenerarRangoTiempo(It.IsAny<DateTime>())).Returns("F");
            DOCConstructorDatosSalida.Setup(s => s.GenerarExpresion4(It.IsAny<DateTime>())).Returns("G");

            var DOCdatosSalida = new Mock<DatosSalida>();

            var SUT = new DirectorMensajeSalida(DOCDirectorDatosEntrada.Object, DOCConstructorDatosSalida.Object, DOCdatosSalida.Object);

            //Act
            var resultado = SUT.ConstruirMensajeSalida();

            //Assert
            Assert.AreEqual("Tu paquete A de B y C a D E F y G un costo de $1.00 (Cualquier reclamación con H).", resultado.cMensaje);
        }

        [TestMethod()]
        public void ConstruirMensajeSalida_ProbarLaConstruccionDeLaCadenaResultadoConExcepcion_CadenaDeMensajeDeExcepcion()
        {
            //Arrange

            var DOCDirectorDatosEntrada = new Mock<IDirectorDatosEntrada>();
            DOCDirectorDatosEntrada.Setup(s => s.ContruirDatosEntrada()).Throws(new Exception("Excepción"));
            var DOCConstructorDatosSalida = new Mock<IConstructorDatosSalida>();

            var DOCdatosSalida = new Mock<DatosSalida>();

            var SUT = new DirectorMensajeSalida(DOCDirectorDatosEntrada.Object, DOCConstructorDatosSalida.Object, DOCdatosSalida.Object);

            //Act
            var resultado = SUT.ConstruirMensajeSalida();

            //Assert
            Assert.AreEqual("Excepción", resultado.cMensaje);
        }
    }
}