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
    public class ObtenedorTextoPrimerArgumentoUTests
    {
        [TestMethod()]
        public void ObtenerTextoArgumentos_ObtenerArgumentoDeLista_PrimerArgumentoDeLista()
        {
            //Arrange
            string[] v = new string[] { "a", "b", "c" };

            var SUT = new ObtenedorTextoPrimerArgumento(v);

            //Act
            var resultado = SUT.ObtenerTextoArgumentos();

            //Assert
            Assert.AreEqual("a", resultado);
        }

        [TestMethod()]
        public void ObtenerTextoArgumentos_ObtenerArgumentoDeListaDeCeroElementos_CadenaVacia()
        {
            //Arrange
            string[] v = new string[0];

            var SUT = new ObtenedorTextoPrimerArgumento(v);

            //Act
            var resultado = SUT.ObtenerTextoArgumentos();

            //Assert
            Assert.AreEqual(string.Empty, resultado);
        }

        [TestMethod()]
        public void ObtenerTextoArgumentos_ObtenerArgumentoDeCadenaNula_CadenaVacia()
        {
            //Arrange
            string[] v = null;

            var SUT = new ObtenedorTextoPrimerArgumento(v);

            //Act
            var resultado = SUT.ObtenerTextoArgumentos();

            //Assert
            Assert.AreEqual(string.Empty, resultado);
        }
    }
}