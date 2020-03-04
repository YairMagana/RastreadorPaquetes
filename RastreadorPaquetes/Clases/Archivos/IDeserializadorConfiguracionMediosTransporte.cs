using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IDeserializadorConfiguracionMediosTransporte
    {
        List<IMedioTransporte> DeserializarMediosTransporte();
    }
}
