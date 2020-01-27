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
    public class ConstructorDatosEntradaUTests
    {
        [TestMethod()]
        public void ObtenerDatosEntrada_CorrectaDevolucionDeDatosDeEntrada_ObjetoDatosEntrada()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.ObtenerDatosEntrada();

            //Assert
            Assert.IsInstanceOfType(DOCDatosEntrada.Object, typeof(DatosEntrada));
        }

        [TestMethod()]
        public void EstablecerCampoOrigen_EstablecimientoDelCampoOrigen_ObjetoDatosEntradaConOrigen()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoOrigen("X");

            //Assert
            Assert.AreEqual("X", DOCDatosEntrada.Object.cOrigen);
        }

        [TestMethod()]
        public void EstablecerCampoDestino_EstablecimientoDelCampoDestino_ObjetoDatosEntradaConDestino()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoDestino("X");

            //Assert
            Assert.AreEqual("X", DOCDatosEntrada.Object.cDestino);
        }

        [TestMethod()]
        public void EstablecerCampoDistancia_EstablecimientoDelCampoDistanciaValida_ObjetoDatosEntradaConDistancia()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoDistancia("1000");

            //Assert
            Assert.AreEqual(1000, DOCDatosEntrada.Object.dDistancia);
        }

        [TestMethod()]
        public void EstablecerCampoDistancia_EstablecimientoDelCampoDistanciaInvalida_ObjetoDatosEntradaConDistancia()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);
            string resultado = string.Empty;

            //Act
            try
            {
                SUT.EstablecerCampoDistancia("X");
            } catch (Exception ex)
            {
                resultado = ex.Message;
            }

            //Assert
            Assert.AreEqual("Distancia inválida", resultado);
        }

        [TestMethod()]
        public void EstablecerCampoEmpresa_EstablecimientoDelCampoEmpresa_ObjetoDatosEntradaConObjetoEmpresa()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCEmpresa = new Mock<IEmpresa>();
            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            DOCFabricaEmpresas.Setup(s => s.FabricarEmpresa(It.IsAny<string>())).Returns(DOCEmpresa.Object);
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoEmpresa("X");

            //Assert
            Assert.IsInstanceOfType(DOCEmpresa.Object, DOCDatosEntrada.Object.objEmpresa.GetType());
        }

        [TestMethod()]
        public void EstablecerCampoMedioTransporte_EstablecimientoDelCampoMedioTransporte_ObjetoDatosEntradaConObjetoMedioTransporte()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCEmpresa = new Mock<IEmpresa>();
            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();

            var DOCIMedioTransporte = new Mock<IMedioTransporte>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();
            DOCFabricaMediosTransporte.Setup(s => s.FabricarMedioTransporte(It.IsAny<string>())).Returns(DOCIMedioTransporte.Object);

            DOCEmpresa.Setup(s => s.lstTTransportesUsados).Returns(new List<Type> { DOCFabricaMediosTransporte.Object.FabricarMedioTransporte("X").GetType() });
            DOCDatosEntrada.Object.objEmpresa = DOCEmpresa.Object;

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoMedioTransporte("X");

            //Assert
            Assert.IsInstanceOfType(DOCIMedioTransporte.Object, DOCDatosEntrada.Object.objMedioTransporte.GetType());
        }

        [TestMethod()]
        public void EstablecerCampoFechaPedido_EstablecimientoDelCampoFechaPedido_ObjetoDatosEntradaConFechaPedido()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoFechaPedido("01/01/2020");

            //Assert
            Assert.AreEqual(new DateTime(2020,01,01), DOCDatosEntrada.Object.dtFechaPedido);
        }

        [TestMethod()]
        public void EstablecerCampoTiempoTraslado_EstablecimientoDelCampoTiempoTraslado_ObjetoDatosEntradaConTiempoTraslado()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();
            DOCDatosEntrada.Object.dDistancia = 1;

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var DOCMedioTransporte = new Mock<IMedioTransporte>();
            DOCMedioTransporte.Setup(s => s.dVelocidadEntrega).Returns(1);
            DOCDatosEntrada.Object.objMedioTransporte = DOCMedioTransporte.Object;

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoTiempoTraslado();

            //Assert
            Assert.AreEqual(1, DOCDatosEntrada.Object.dTiempoTraslado);
        }

        [TestMethod()]
        public void EstablecerCampoFechaEntrega_EstablecimientoDelCampoFechaEntrega_ObjetoDatosEntradaConFechaEntrega()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();
            DOCDatosEntrada.Object.dtFechaPedido = new DateTime(2020,01,01);
            DOCDatosEntrada.Object.dTiempoTraslado = 1;

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoFechaEntrega();

            //Assert
            Assert.AreEqual(new DateTime(2020, 01, 01,01,00,00), DOCDatosEntrada.Object.dtFechaEntrega);
        }

        [TestMethod()]
        public void EstablecerCampoCostoEnvio_EstablecimientoDelCampoCostoEnvio_ObjetoDatosEntradaConCostoEnvio()
        {
            //Arrange
            var DOCDatosEntrada = new Mock<DatosEntrada>();
            DOCDatosEntrada.Object.dtFechaPedido = new DateTime(2020, 01, 01);
            DOCDatosEntrada.Object.dDistancia = 1;

            var DOCFabricaEmpresas = new Mock<IFabricaEmpresas>();
            var DOCFabricaMediosTransporte = new Mock<IFabricaMediosTransporte>();

            var DOCMedioTransporte = new Mock<IMedioTransporte>();
            DOCMedioTransporte.Setup(s => s.dCosto).Returns(1);
            DOCDatosEntrada.Object.objMedioTransporte = DOCMedioTransporte.Object;

            var DOCIEmpresa = new Mock<IEmpresa>();
            DOCIEmpresa.Setup(s => s.dMargenUtilidad).Returns(0);
            DOCDatosEntrada.Object.objEmpresa = DOCIEmpresa.Object;

            var SUT = new ConstructorDatosEntrada(DOCDatosEntrada.Object, DOCFabricaEmpresas.Object, DOCFabricaMediosTransporte.Object);

            //Act
            SUT.EstablecerCampoCostoEnvio();

            //Assert
            Assert.AreEqual(1, DOCDatosEntrada.Object.dCostoEnvio);
        }
    }
}