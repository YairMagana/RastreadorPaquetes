using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public class DHL : IEmpresa
    {
        public string cNombre { get; set; }
        public double dMargenUtilidad { get; set; }
        public List<Type> lstTTransportesUsados { get; set; }

        public DHL()
        {
            cNombre = "DHL";
            dMargenUtilidad = 0.4;
            lstTTransportesUsados = new List<Type> { typeof(Avion), typeof(Barco) };
        }
    }
}
