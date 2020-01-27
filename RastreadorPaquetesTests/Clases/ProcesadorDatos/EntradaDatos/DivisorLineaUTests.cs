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
    public class DivisorLineaUTests
    {
        [TestMethod()]
        public void DividirLinea_VerificarLaConstruccionDelArrayConValoresEntrada_ArrayConValoresDeCadenaDivididos()
        {
            //Arrange
            string s = "a,b,c";

            var SUT = new DivisorLinea();

            //Act
            var resultado = SUT.DividirLinea(s, 3);

            //Assert
            CollectionAssert.AreEqual(new string[] { "a", "b", "c" }, resultado);
        }

        [TestMethod()]
        public void DividirLinea_VerificarLaConstruccionDelArrayConValoresEntradaLongitudMayor_ArrayConValoresDeCadenaDivididos()
        {
            //Arrange
            string s = "a,b,c";

            var SUT = new DivisorLinea();

            //Act
            var resultado = SUT.DividirLinea(s, 4);

            //Assert
            CollectionAssert.AreEqual(new string[] { "a", "b", "c", null }, resultado);
        }

        [TestMethod()]
        public void DividirLinea_VerificarLaConstruccionDelArrayConValoresEntradaLongitudMenor_ArrayConValoresDeCadenaDivididos()
        {
            //Arrange
            string s = "a,b,c";

            var SUT = new DivisorLinea();

            //Act
            var resultado = SUT.DividirLinea(s, 2);

            //Assert
            CollectionAssert.AreEqual(new string[] { "a", "b" }, resultado);
        }
    }

}