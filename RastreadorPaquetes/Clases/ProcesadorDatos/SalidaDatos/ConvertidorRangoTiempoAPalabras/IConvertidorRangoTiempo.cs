using System;

namespace RastreadorPaquetes
{
    public interface IConvertidorRangoTiempo
    {
        IConvertidorRangoTiempo EstablecerSiguienteConvertidor(IConvertidorRangoTiempo _convertidorRangoTiempo);
        string ConvertirRangoTiempoAPalabras(DateTime dt1, DateTime dt2);
    }
}
