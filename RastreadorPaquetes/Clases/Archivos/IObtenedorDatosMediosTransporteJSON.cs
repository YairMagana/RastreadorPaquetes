using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IObtenedorDatosMediosTransporteJSON
    {
        List<IMedioTransporte> ObtenerDatos(List<string> _lstLineas);
    }
}
