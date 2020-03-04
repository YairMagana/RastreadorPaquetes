using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    public class ObtenedorDatosEmpresasJSON: IObtenedorDatosEmpresasJSON
    {
        public List<IEmpresaDatos> ObtenerDatos(List<string> _lstLineas)
        {
            try
            {
                List<string> lstLineas = new List<string>();
                string cJson = string.Join(" ", _lstLineas);
                return ParsearJson(cJson, ref lstLineas);
            }
            catch (Exception ex)
            {
                throw new Exception("El formato JSON de congfiguración es inválido. "+ ex.Message);
            }
        }

        private List<IEmpresaDatos> ParsearJson(string _cJson, ref List<string> _lstLineas)
        {
            List<IEmpresaDatos> empresas = new List<IEmpresaDatos>();

            JArray objConfig = JsonConvert.DeserializeObject<JArray>(_cJson);
            var cValores = JsonConvert.DeserializeAnonymousType(objConfig[1].ToString(), new
            {
                Paqueterias = new[] { new { Paqueteria = "", MargenUtilidad = "", Medios = new[] { new { Medio = "" } } } }.ToList()
            });

            foreach (var empr in cValores.Paqueterias)
            {
                IEmpresaDatos empresa = new EmpresaDatos();
                empresa.cNombre = empr.Paqueteria;
                empresa.dMargenUtilidad = Double.Parse(empr.MargenUtilidad);
                empresa.lstTransportesUsados = new List<string>();
                foreach (var medio in empr.Medios)
                {
                    empresa.lstTransportesUsados.Add(medio.ToString());
                }
                empresas.Add(empresa);
            }

            return empresas;
        }
    }
}
