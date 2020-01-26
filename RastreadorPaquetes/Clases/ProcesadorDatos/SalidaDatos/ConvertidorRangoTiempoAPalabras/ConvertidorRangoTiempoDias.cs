using System;

namespace RastreadorPaquetes
{
    public class ConvertidorRangoTiempoDias : IConvertidorRangoTiempo
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
            double diasTranscurridos = (dt1 - dt2).TotalDays;
            if (Math.Round(Math.Abs(diasTranscurridos)) < 30)
                v = Math.Round(Math.Abs(diasTranscurridos)).ToString() + " días";
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
