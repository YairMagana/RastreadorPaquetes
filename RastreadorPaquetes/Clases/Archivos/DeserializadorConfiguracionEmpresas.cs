using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    public class DeserializadorConfiguracionEmpresas: IDeserializadorConfiguracionEmpresas
    {
        private ILectorArchivoTexto lectorArchivoTexto;
        private IObtenedorDatosEmpresasJSON obtenedorDatosEmpresasJSON;

        public DeserializadorConfiguracionEmpresas(ILectorArchivoTexto _lectorArchivoTexto, IObtenedorDatosEmpresasJSON _obtenedorDatosEmpresasJSON)
        {
            lectorArchivoTexto = _lectorArchivoTexto;
            obtenedorDatosEmpresasJSON = _obtenedorDatosEmpresasJSON;
        }

        public List<IEmpresaDatos> DeserializarEmpresas()
        {
            List<string> lstTexto = new List<string>();
            using (StreamReader sr = lectorArchivoTexto.LeerArchivoTexto())
            {
                string linea;
                while (null != (linea = sr.ReadLine()))
                    if (!string.IsNullOrEmpty(linea))
                        lstTexto.Add(linea);
            }

            return obtenedorDatosEmpresasJSON.ObtenerDatos(lstTexto);
        }
    }
}
