using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    class ObtenedorDatosStrategyJSON : IObtenedorDatosStrategy
    {
        public List<string> ObtenerDatos(List<string> _lstLineas)
        {
            try
            {
                List<string> lstLineas = new List<string>();
                string cJson = string.Join(" ", _lstLineas);
                ParsearJson(cJson, ref lstLineas);
                return lstLineas;
            }
            catch (Exception ex)
            {
                throw new Exception("El formato JSON para los envíos es inválido.");
            }
        }

        private void ParsearJson(string _cJson, ref List<string> _lstLineas)
        {
            string cRegistro;
            var cValores = JsonConvert.DeserializeAnonymousType(_cJson, new
            {
                Pedidos = new[] { new { Procedencia = "", Destino = "", Dist_KM = "", Empresa = "", MedioTrans = "", FechaPedido = "" } }.ToList()
            });

            foreach (var pedido in cValores.Pedidos)
            {
                cRegistro = string.Empty;
                cRegistro += pedido.Procedencia + ",";
                cRegistro += pedido.Destino + ",";
                cRegistro += pedido.Dist_KM + ",";
                cRegistro += pedido.Empresa + ",";
                cRegistro += pedido.MedioTrans + ",";
                cRegistro += pedido.FechaPedido;
                _lstLineas.Add(cRegistro);
            }
        }
    }
}

