using System;

namespace RastreadorPaquetes
{
    public class ConvertidorRangoTiempoMinutos : IConvertidorRangoTiempo
    {
        private IConvertidorRangoTiempo objConvertidorRangoTiempoSiguiente;

        public IConvertidorRangoTiempo EstablecerSiguienteConvertidor(IConvertidorRangoTiempo _convertidorRangoTiempo)
        {
            objConvertidorRangoTiempoSiguiente = _convertidorRangoTiempo;
            return objConvertidorRangoTiempoSiguiente;
        }

        public string ConvertirRangoTiempoAPalabras(DateTime dt1, DateTime dt2)
        {
            string v = string.Empty;
            double minutosTranscurridos = (dt1 - dt2).TotalMinutes;
            if (Math.Round(Math.Abs(minutosTranscurridos)) < 60)
                v = Math.Round(Math.Abs(minutosTranscurridos)).ToString() + " minutos";
            else if (objConvertidorRangoTiempoSiguiente != null)
            {
                v = objConvertidorRangoTiempoSiguiente.ConvertirRangoTiempoAPalabras(dt1, dt2);
            }
            else
            {
                return null;
            }
            return v;
        }
    }
}
