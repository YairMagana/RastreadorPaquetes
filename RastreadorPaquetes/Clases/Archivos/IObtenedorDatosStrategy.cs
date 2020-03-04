using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IObtenedorDatosStrategy
    {
        List<string> ObtenerDatos(List<string> _lstLineas);
    }
}

