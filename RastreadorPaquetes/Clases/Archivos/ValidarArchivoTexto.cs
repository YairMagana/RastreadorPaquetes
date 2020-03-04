using System.IO;

namespace RastreadorPaquetes
{
    public class ValidarArchivoTexto : IValidadorArchivo
    {
        public bool ValidarArchivo(string _nombreArchivo)
        {
            bool v = ValidarExistenciaArchivo(_nombreArchivo);
            return v;
        }

        private bool ValidarExistenciaArchivo(string _nombreArchivo)
        {
            return File.Exists(_nombreArchivo);
        }
    }
}
