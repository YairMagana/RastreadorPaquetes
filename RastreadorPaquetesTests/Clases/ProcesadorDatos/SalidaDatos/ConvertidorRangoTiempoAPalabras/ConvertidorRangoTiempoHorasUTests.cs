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
    public class ConvertidorRangoTiempoHorasUTests
    {
        [TestMethod()]
        public void EstablecerSiguienteConvertidor_EstablecerObjetoEnClase_DevolverObjetoPasadoComoArgemento()
        {
            //Arrange
            var SUT = new ConvertidorRangoTiempoHoras();
            var Objeto = new ConvertidorRangoTiempoHoras();

            //Act
            var resultado = SUT.EstablecerSiguienteConvertidor(Objeto);

            //Assert
            Assert.IsInstanceOfType(resultado, Objeto.GetType());
        }

        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaEnHoras_TextoConDiferenciaEnHoras()
        {
            //Arrange
            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConvertidorRangoTiempoHoras();

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1,dt2);

            //Assert
            Assert.AreEqual("10 horas", resultado);
        }

        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaQueExeda24Horas_UsarLaSiguienteResponsabilidadNula()
        {
            //Arrange
            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 10, 01, 0, 0, 0);

            var SUT = new ConvertidorRangoTiempoHoras();

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1, dt2);

            //Assert
            Assert.AreEqual(null, resultado);
        }

        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaQueExeda24Horas_UsarLaSiguienteResponsabilidadNoNula()
        {
            //Arrange
            var DOCConvertidorRangoTiempo = new Mock<IConvertidorRangoTiempo>();
            DOCConvertidorRangoTiempo.Setup(s => s.ConvertirRangoTiempoAPalabras(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("Tiempo calculado");

            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 10, 01, 0, 0, 0);

            var SUT = new ConvertidorRangoTiempoHoras();
            SUT.EstablecerSiguienteConvertidor(DOCConvertidorRangoTiempo.Object);

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1, dt2);

            //Assert
            Assert.AreEqual("Tiempo calculado", resultado);
        }
    }
}