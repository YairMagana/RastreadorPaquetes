using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IObtenedorDatosEmpresasJSON
    {
        List<IEmpresaDatos> ObtenerDatos(List<string> _lstLineas);
    }
}
