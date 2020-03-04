using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    public class MedioTransporte : IMedioTransporte
    {
        public string cNombre { get; set; }
        public double dCosto { get; set; }
        public double dVelocidadEntrega { get; set; }
    }
}
