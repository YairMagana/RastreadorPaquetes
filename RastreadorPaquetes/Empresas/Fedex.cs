using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public class Fedex : IEmpresa
    {
        public string cNombre { get; set; }
        public double dMargenUtilidad { get; set; }
        public List<Type> lstTTransportesUsados { get; set; }

        public Fedex( IEmpresaDatos _empresa)
        {
            cNombre = _empresa.cNombre;
            dMargenUtilidad = _empresa.dMargenUtilidad;
            lstTTransportesUsados = new List<Type>();
            foreach (var e in _empresa.lstTransportesUsados)
            {
                switch (e.ToUpper())
                {
                    case "AÉREO":
                    case "AEREO":
                        lstTTransportesUsados.Add(typeof(Avion));
                        break;
                    case "MARITIMO":
                    case "MARÍTIMO":
                        lstTTransportesUsados.Add(typeof(Barco));
                        break;
                    case "TERRESTRE":
                        lstTTransportesUsados.Add(typeof(Tren));
                        break;
                }
            }
        }
    }
}
