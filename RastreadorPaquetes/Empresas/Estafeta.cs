using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public class Estafeta : IEmpresa
    {
        public string cNombre { get; set; }
        public double dMargenUtilidad { get; set; }
        public List<Type> lstTTransportesUsados { get; set; }

        public Estafeta()
        {
            cNombre = "Estafeta";
            dMargenUtilidad = 0.2;
            lstTTransportesUsados = new List<Type> { typeof(Tren) };
        }
    }
}
