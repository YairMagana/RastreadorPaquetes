using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RastreadorPaquetes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes.Tests
{
    [TestClass()]
    public class ObtenedorRegistrosArchivoListaStringsUTests
    {
        [TestMethod()]
        public void ObtenerRegistrosArchivo_ObtenerLineasSeparadasDeUnStream_ListaDeLineas()
        {
            //Arrange
            string contenido = "a\nb\nc";
            byte[] bytesContenido = Encoding.UTF8.GetBytes(contenido);
            MemoryStream memoryStream = new MemoryStream(bytesContenido);

            var DOCILectorArchivoTexto = new Mock<ILectorArchivoTexto>();
            DOCILectorArchivoTexto.Setup(s => s.LeerArchivoTexto()).Returns(new StreamReader(memoryStream));

            var SUT = new ObtenedorRegistrosArchivoListaStrings(DOCILectorArchivoTexto.Object);

            //Act
            var resultado = SUT.ObtenerRegistrosArchivo();

            //Assert
            CollectionAssert.AreEqual(new List<string> { "a", "b", "c" }, resultado);
        }
    }
}