using System.Collections.Generic;
using System.IO;

namespace RastreadorPaquetes
{
    public class ObtenedorRegistrosArchivoListaStrings : IObtenedorRegistrosArchivoListaStrings
    {
        private readonly ILectorArchivoTexto lectorArchivoTexto;

        public ObtenedorRegistrosArchivoListaStrings(ILectorArchivoTexto lectorArchivoTexto)
        {
            this.lectorArchivoTexto = lectorArchivoTexto;
        }

        public List<string> ObtenerRegistrosArchivo()
        {
            List<string> lstTexto = new List<string>();
            using (StreamReader sr = lectorArchivoTexto.LeerArchivoTexto())
            {
                string linea;
                while (null != (linea = sr.ReadLine()))
                    if (!string.IsNullOrEmpty(linea))
                        lstTexto.Add(linea);
            }
            return lstTexto;
        }
    }
}
