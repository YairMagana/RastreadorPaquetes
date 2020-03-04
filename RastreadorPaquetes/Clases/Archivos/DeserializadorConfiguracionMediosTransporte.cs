using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    public class DeserializadorConfiguracionMediosTransporte : IDeserializadorConfiguracionMediosTransporte
    {
        private ILectorArchivoTexto lectorArchivoTexto;
        private IObtenedorDatosMediosTransporteJSON obtenedorDatosMediosTransporteJSON;

        public DeserializadorConfiguracionMediosTransporte(ILectorArchivoTexto _lectorArchivoTexto, IObtenedorDatosMediosTransporteJSON _obtenedorDatosMediosTransporteJSON)
        {
            lectorArchivoTexto = _lectorArchivoTexto;
            obtenedorDatosMediosTransporteJSON = _obtenedorDatosMediosTransporteJSON;
        }

        public List<IMedioTransporte> DeserializarMediosTransporte()
        {
            List<string> lstTexto = new List<string>();
            using (StreamReader sr = lectorArchivoTexto.LeerArchivoTexto())
            {
                string linea;
                while (null != (linea = sr.ReadLine()))
                    if (!string.IsNullOrEmpty(linea))
                        lstTexto.Add(linea);
            }

            return obtenedorDatosMediosTransporteJSON.ObtenerDatos(lstTexto);
        }
    }
}
