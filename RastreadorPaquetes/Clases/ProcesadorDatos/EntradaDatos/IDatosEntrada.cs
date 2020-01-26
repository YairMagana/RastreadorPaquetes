using System;

namespace RastreadorPaquetes
{
    public interface IDatosEntrada
    {
        string cOrigen { get; set; }
        string cDestino { get; set; }
        double dDistancia { get; set; }
        IEmpresa objEmpresa { get; set; }
        IMedioTransporte objMedioTransporte { get; set; }
        DateTime dtFechaPedido { get; set; }

        double dTiempoTraslado { get; set; }
        DateTime dtFechaEntrega { get; set; }
        double dCostoEnvio { get; set; }
    }
}
