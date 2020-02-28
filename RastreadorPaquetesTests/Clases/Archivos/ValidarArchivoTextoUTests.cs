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
    public class ValidarArchivoTextoUTests
    {
        [TestMethod()]
        public void ValidarArchivo_ValidarRecepcionDeNombreArchivo_EjecutarLaFuncion()
        {
            //Arrange
            var DOCValidadorArchivo = new Mock<IValidadorArchivo>();
            DOCValidadorArchivo.Setup(s => s.ValidarArchivo(It.IsAny<string>())).Returns(true);

            var SUT = new ValidarArchivoTexto();

            //Act
            DOCValidadorArchivo.Object.ValidarArchivo("Archivo");

            //Assert
            DOCValidadorArchivo.Verify(v => v.ValidarArchivo("Archivo"), Times.Once());
        }
    }
}