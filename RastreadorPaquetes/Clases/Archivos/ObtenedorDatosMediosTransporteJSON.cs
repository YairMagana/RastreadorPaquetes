using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    public class ObtenedorDatosMediosTransporteJSON: IObtenedorDatosMediosTransporteJSON
    {
        public List<IMedioTransporte> ObtenerDatos(List<string> _lstLineas)
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

        private List<IMedioTransporte> ParsearJson(string _cJson, ref List<string> _lstLineas)
        {
            List<IMedioTransporte> mediosTransporte = new List<IMedioTransporte>();

            JArray objConfig = JsonConvert.DeserializeObject<JArray>(_cJson);
            var cValores = JsonConvert.DeserializeAnonymousType(objConfig[0].ToString(), new
            {
                MediosTransporte = new[] { new { Medio = "", Velocidad = "", CostoPorKilometro = "" } }.ToList()
            });

            foreach (var medio in cValores.MediosTransporte)
            {
                IMedioTransporte medioTransporte = new MedioTransporte();
                medioTransporte.cNombre = medio.Medio;
                medioTransporte.dVelocidadEntrega = Double.Parse(medio.Velocidad);
                medioTransporte.dCosto = Double.Parse(medio.CostoPorKilometro);
                mediosTransporte.Add(medioTransporte);
            }

            return mediosTransporte;
        }
    }
}
