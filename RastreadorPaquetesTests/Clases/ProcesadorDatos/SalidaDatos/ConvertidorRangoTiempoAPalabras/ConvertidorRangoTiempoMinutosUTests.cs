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
    public class ConvertidorRangoTiempoMinutosUTests
    {
        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaEnMinutos_TextoConDiferenciaEnMinutos()
        {
            //Arrange
            DateTime dt1 = new DateTime(2019, 01, 01, 01, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 01, 10, 0);

            var SUT = new ConvertidorRangoTiempoMinutos();

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1,dt2);

            //Assert
            Assert.AreEqual("10 minutos", resultado);
        }

        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaQueExeda59Minutos_UsarLaSiguienteResponsabilidadNula()
        {
            //Arrange
            DateTime dt1 = new DateTime(2019, 01, 01, 01, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 02, 0, 0);

            var SUT = new ConvertidorRangoTiempoMinutos();

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1, dt2);

            //Assert
            Assert.AreEqual(null, resultado);
        }
    }
}