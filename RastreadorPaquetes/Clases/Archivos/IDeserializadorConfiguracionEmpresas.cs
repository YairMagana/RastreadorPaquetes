using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IDeserializadorConfiguracionEmpresas
    {
        List<IEmpresaDatos> DeserializarEmpresas();
    }
}
