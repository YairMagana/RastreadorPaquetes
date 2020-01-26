using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public class Fedex : IEmpresa
    {
        public string cNombre { get; set; }
        public double dMargenUtilidad { get; set; }
        public List<Type> lstTTransportesUsados { get; set; }

        public Fedex()
        {
            cNombre = "Fedex";
            dMargenUtilidad = 0.5;
            lstTTransportesUsados = new List<Type> { typeof(Barco) };
        }
    }
}
