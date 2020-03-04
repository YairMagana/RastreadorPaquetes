using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    public class ConvertidorRangoTiempoAnios : IConvertidorRangoTiempo
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
            if (Math.Round(Math.Abs(diasTranscurridos)) >= 365)
                v = Math.Round(Math.Abs(diasTranscurridos) / 365).ToString() + " años";
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
