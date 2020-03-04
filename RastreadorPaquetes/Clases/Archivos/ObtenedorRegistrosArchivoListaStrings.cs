using System.Collections.Generic;
using System.IO;

namespace RastreadorPaquetes
{
    public class ObtenedorRegistrosArchivoListaStrings : IObtenedorRegistrosArchivoListaStrings
    {
        private readonly ILectorArchivoTexto lectorArchivoTexto;
        private string cTipoArchivo;
        private IObtenedorDatosStrategy estategiaCSV;
        private IObtenedorDatosStrategy estategiaJSON;

        public ObtenedorRegistrosArchivoListaStrings(ILectorArchivoTexto _lectorArchivoTexto, string _cTipoArchivo, IObtenedorDatosStrategy _estategiaCSV, IObtenedorDatosStrategy _estategiaJSON)
        {
            lectorArchivoTexto = _lectorArchivoTexto;
            cTipoArchivo = _cTipoArchivo;
            estategiaCSV = _estategiaCSV;
            estategiaJSON = _estategiaJSON;
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

            return ObtenerListaDatosPorTipo(lstTexto);
        }

        private List<string> ObtenerListaDatosPorTipo(List<string> _lstTexto)
        {
            switch (cTipoArchivo)
            {
                case "CSV":
                    return estategiaCSV.ObtenerDatos(_lstTexto);
                case "JSON":
                    return estategiaJSON.ObtenerDatos(_lstTexto);
                default:
                    return _lstTexto;
            }
        }
    }
}
