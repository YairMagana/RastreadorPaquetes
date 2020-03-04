using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    class Empresa : IEmpresa
    {
        public string cNombre { get; set; }
        public double dMargenUtilidad { get; set; }

        public List<Type> lstTTransportesUsados { get; set; }
    }
}
