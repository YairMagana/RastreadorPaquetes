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
    public class ConvertidorRangoTiempoMesesUTests
    {
        [TestMethod()]
        public void EstablecerSiguienteConvertidor_EstablecerObjetoEnClase_DevolverObjetoPasadoComoArgemento()
        {
            //Arrange
            var SUT = new ConvertidorRangoTiempoMeses();
            var Objeto = new ConvertidorRangoTiempoMeses();

            //Act
            var resultado = SUT.EstablecerSiguienteConvertidor(Objeto);

            //Assert
            Assert.IsInstanceOfType(resultado, Objeto.GetType());
        }

        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaEnMeses_TextoConDiferenciaEnMeses()
        {
            //Arrange
            DateTime dt1 = new DateTime(2019, 01, 01, 0, 0, 0);
            DateTime dt2 = new DateTime(2019, 10, 01, 0, 0, 0);

            var SUT = new ConvertidorRangoTiempoMeses();

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1,dt2);

            //Assert
            Assert.AreEqual("9 meses", resultado);
        }

        [TestMethod()]
        public void ConvertirRangoTiempoAPalabras_DeterminarDiferenciaInferiorA1Mes_UsarOtraResponsabilidad()
        {
            //Arrange
            DateTime dt1 = new DateTime(2019, 01, 01, 01, 0, 0);
            DateTime dt2 = new DateTime(2019, 01, 01, 10, 0, 0);

            var SUT = new ConvertidorRangoTiempoMeses();

            //Act
            var resultado = SUT.ConvertirRangoTiempoAPalabras(dt1, dt2);

            //Assert
            Assert.AreEqual(null, resultado);
        }
    }
}