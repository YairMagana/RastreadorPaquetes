using System;

namespace RastreadorPaquetes
{
    public class DatosEntrada : IDatosEntrada
    {
        public string cOrigen { get; set; }
        public string cDestino { get; set; }
        public double dDistancia { get; set; }
        public IEmpresa objEmpresa { get; set; }
        public IMedioTransporte objMedioTransporte { get; set; }
        public DateTime dtFechaPedido { get; set; }

        public double dTiempoTraslado { get; set; }
        public DateTime dtFechaEntrega { get; set; }
        public double dCostoEnvio { get; set; }
    }
}
