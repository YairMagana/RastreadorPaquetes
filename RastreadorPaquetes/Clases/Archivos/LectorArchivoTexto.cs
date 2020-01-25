using System;
using System.IO;

namespace RastreadorPaquetes
{
    public class LectorArchivoTexto : ILectorArchivoTexto
    {
        private readonly string nombreArchivo;
        private readonly IValidadorArchivo validadorArchivo;

        public LectorArchivoTexto(string _nombreArchivo, IValidadorArchivo _validadorArchivo)
        {
            nombreArchivo = _nombreArchivo;
            validadorArchivo = _validadorArchivo;
        }

        public StreamReader LeerArchivoTexto()
        {
            if (validadorArchivo.ValidarArchivo(nombreArchivo))
            {
                StreamReader sr = new StreamReader(nombreArchivo);
                return sr;
            }
            else
            {
                throw new Exception($"No se pudo encontrar el archivo {nombreArchivo}");
            }
        }

    }
}
