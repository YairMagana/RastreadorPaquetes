using System;

namespace RastreadorPaquetes
{
    public interface IConstructorDatosSalida
    {
        DateTime dtFechaBase { get; set; }
        string GenerarExpresion1(DateTime _dtFechaEntrega);
        string GenerarExpresion2(DateTime _dtFechaEntrega);
        string GenerarExpresion3(DateTime _dtFechaEntrega);
        string GenerarExpresion4(DateTime _dtFechaEntrega);
        string GenerarRangoTiempo(DateTime _dtFechaEntrega);
        int GenerarColor(DateTime _dtFechaEntrega);
    }
}
