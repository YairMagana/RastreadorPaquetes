using System;

namespace RastreadorPaquetes
{
    public class ConvertidorRangoTiempoHoras : IConvertidorRangoTiempo
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
            double horasTranscurridas = (dt1 - dt2).TotalHours;
            if (Math.Round(Math.Abs(horasTranscurridas)) < 24)
                v = Math.Round(Math.Abs(horasTranscurridas)).ToString() + " horas";
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
