using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IEmpresa
    {
        string cNombre { get; set; }
        double dMargenUtilidad { get; set; }

        List<Type> lstTTransportesUsados { get; set; }
    }
}
