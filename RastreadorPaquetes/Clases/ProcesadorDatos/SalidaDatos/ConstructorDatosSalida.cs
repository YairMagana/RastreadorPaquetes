using System;

namespace RastreadorPaquetes
{
    public class ConstructorDatosSalida : IConstructorDatosSalida
    {
        public DateTime dtFechaBase { get; set; }

        private IConvertidorRangoTiempo convertidorRangoTiempo;

        public ConstructorDatosSalida(IConvertidorRangoTiempo _convertidorRangoTiempo)
        {
            dtFechaBase = DateTime.Now;
            convertidorRangoTiempo = _convertidorRangoTiempo;
        }

        public string GenerarExpresion1(DateTime _dtFechaEntrega)
        {
            string v = "ha salido";
            if (_dtFechaEntrega < dtFechaBase)
                v = "salió";
            return v;
        }

        public string GenerarExpresion2(DateTime _dtFechaEntrega)
        {
            string v = "llegará";
            if (_dtFechaEntrega < dtFechaBase)
                v = "llegó";
            return v;
        }

        public string GenerarExpresion3(DateTime _dtFechaEntrega)
        {
            string v = "dentro de";
            if (_dtFechaEntrega < dtFechaBase)
                v = "hace";
            return v;
        }

        public string GenerarExpresion4(DateTime _dtFechaEntrega)
        {
            string v = "tendrá";
            if (_dtFechaEntrega < dtFechaBase)
                v = "tuvo";
            return v;
        }

        public string GenerarRangoTiempo(DateTime _dtFechaEntrega)
        {
            return convertidorRangoTiempo.ConvertirRangoTiempoAPalabras(_dtFechaEntrega, dtFechaBase);
        }

        public int GenerarColor(DateTime _dtFechaEntrega)
        {
            if (_dtFechaEntrega < dtFechaBase)
                return 0;
            else
                return 1;
        }
    }
}
