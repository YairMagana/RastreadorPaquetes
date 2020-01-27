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
    public class ModuloComparadorOpcionesUTests
    {
        [TestMethod()]
        public void GenerarMensajeOpcionOptima_EncontrarUnaOpcionMasBarataDeEnvioCuandoExiste_MensajeDeOpcionMasBarata()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCIMedioTransporte = new Mock<IMedioTransporte>();
            DOCIMedioTransporte.Setup(s => s.cNombre).Returns("A");
            DOCIMedioTransporte.Setup(s => s.dCosto).Returns(1);
            DOCIMedioTransporte.Setup(s => s.dVelocidadEntrega).Returns(1);

            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();
            DOCFabricaMediosTransporte.Setup(s => s.FabricarMedioTransporte(It.IsAny<string>())).Returns(DOCIMedioTransporte.Object);


            var DOCIEmpresa = new Mock<IEmpresa>();
            DOCIEmpresa.Setup(s => s.cNombre).Returns("Y");
            DOCIEmpresa.Setup(s => s.dMargenUtilidad).Returns(0);
            DOCIEmpresa.Setup(s => s.lstTTransportesUsados).Returns(new List<Type> { DOCIMedioTransporte.Object.GetType() });

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            DOCFabricaEmpresas.Setup(s => s.FabricarEmpresa(It.IsAny<string>())).Returns(DOCIEmpresa.Object);

            var SUT = new ModuloComparadorOpciones(DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            var resultado = SUT.GenerarMensajeOpcionOptima("X", DOCIMedioTransporte.Object, 2 , 1);

            //Assert
            Assert.AreEqual("Si hubieras pedido en Y te hubiera costado $1.00 más barato.\n", resultado);
        }

        [TestMethod()]
        public void GenerarMensajeOpcionOptima_EncontrarUnaOpcionMasBarataDeEnvioCuandoNOExiste_MensajeVacio()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCIMedioTransporte = new Mock<IMedioTransporte>();
            DOCIMedioTransporte.Setup(s => s.cNombre).Returns("A");
            DOCIMedioTransporte.Setup(s => s.dCosto).Returns(10);
            DOCIMedioTransporte.Setup(s => s.dVelocidadEntrega).Returns(1);

            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();
            DOCFabricaMediosTransporte.Setup(s => s.FabricarMedioTransporte(It.IsAny<string>())).Returns(DOCIMedioTransporte.Object);


            var DOCIEmpresa = new Mock<IEmpresa>();
            DOCIEmpresa.Setup(s => s.cNombre).Returns("Y");
            DOCIEmpresa.Setup(s => s.dMargenUtilidad).Returns(0);
            DOCIEmpresa.Setup(s => s.lstTTransportesUsados).Returns(new List<Type> { DOCIMedioTransporte.Object.GetType() });

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            DOCFabricaEmpresas.Setup(s => s.FabricarEmpresa(It.IsAny<string>())).Returns(DOCIEmpresa.Object);

            var SUT = new ModuloComparadorOpciones(DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            var resultado = SUT.GenerarMensajeOpcionOptima("X", DOCIMedioTransporte.Object, 2, 1);

            //Assert
            Assert.AreEqual("", resultado);
        }
    }
}