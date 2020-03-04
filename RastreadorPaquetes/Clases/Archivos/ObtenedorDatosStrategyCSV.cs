using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    class ObtenedorDatosStrategyCSV : IObtenedorDatosStrategy
    {
        public List<string> ObtenerDatos(List<string> _lstLineas)
        {
            return _lstLineas;
        }
    }
}
