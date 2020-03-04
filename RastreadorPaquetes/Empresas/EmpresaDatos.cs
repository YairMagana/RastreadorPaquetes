using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    class EmpresaDatos : IEmpresaDatos
    {
        public string cNombre { get; set; }
        public double dMargenUtilidad { get; set; }

        public List<string> lstTransportesUsados { get; set; }
    }
}
