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
    public class ConstructorDatosSalidaUTests
    {
        [TestMethod()]
        public void GenerarExpresion1_FechaActualMenorAFechaEntrega_CadenaHaSalido()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt1;

            //Act
            var resultado = SUT.GenerarExpresion1(dt2);

            //Assert
            Assert.AreEqual("ha salido", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion1_FechaActualMayorAFechaEntrega_CadenaSalio()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt2;

            //Act
            var resultado = SUT.GenerarExpresion1(dt1);

            //Assert
            Assert.AreEqual("salió", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion2_FechaActualMenorAFechaEntrega_CadenaLlegara()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt1;

            //Act
            var resultado = SUT.GenerarExpresion2(dt2);

            //Assert
            Assert.AreEqual("llegará", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion2_FechaActualMayorAFechaEntrega_CadenaLlego()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt2;

            //Act
            var resultado = SUT.GenerarExpresion2(dt1);

            //Assert
            Assert.AreEqual("llegó", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion3_FechaActualMenorAFechaEntrega_CadenaDentroDe()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt1;

            //Act
            var resultado = SUT.GenerarExpresion3(dt2);

            //Assert
            Assert.AreEqual("dentro de", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion3_FechaActualMayorAFechaEntrega_CadenaHace()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt2;

            //Act
            var resultado = SUT.GenerarExpresion3(dt1);

            //Assert
            Assert.AreEqual("hace", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion4_FechaActualMenorAFechaEntrega_CadenaTendra()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt1;

            //Act
            var resultado = SUT.GenerarExpresion4(dt2);

            //Assert
            Assert.AreEqual("tendrá", resultado);
        }

        [TestMethod()]
        public void GenerarExpresion4_FechaActualMayorAFechaEntrega_CadenaTuvo()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt2;

            //Act
            var resultado = SUT.GenerarExpresion4(dt1);

            //Assert
            Assert.AreEqual("tuvo", resultado);
        }

        [TestMethod()]
        public void GenerarRangoTiempo_ObtenerCadenaConTiempo_TiempoEnPalabras()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();
            DOCConstructorDatosSalida.Setup(s => s.ConvertirRangoTiempoAPalabras(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("Tiempo calculado");

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt1;

            //Act
            var resultado = SUT.GenerarRangoTiempo(dt1);

            //Assert
            Assert.AreEqual("Tiempo calculado", resultado);
        }

        [TestMethod()]
        public void GenerarColor_FechaActualMenorAFechaEntrega_Entero1()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt1;

            //Act
            var resultado = SUT.GenerarColor(dt2);

            //Assert
            Assert.AreEqual(1, resultado);
        }

        [TestMethod()]
        public void GenerarColor_FechaActualMayorAFechaEntrega_Entero0()
        {
            //Arrange
            var DOCConstructorDatosSalida = new Mock<IConvertidorRangoTiempo>();

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConstructorDatosSalida(DOCConstructorDatosSalida.Object);
            SUT.dtFechaBase = dt2;

            //Act
            var resultado = SUT.GenerarColor(dt1);

            //Assert
            Assert.AreEqual(0, resultado);
        }
    }
}