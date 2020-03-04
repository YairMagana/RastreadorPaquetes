using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IEmpresaDatos
    {
        string cNombre { get; set; }
        double dMargenUtilidad { get; set; }

        List<string> lstTransportesUsados { get; set; }
    }
}
