using System;

namespace RastreadorPaquetes
{
    public class DatosSalida : IDatosSalida
    {
        public string cMensaje { get; set; }
        public ConsoleColor color { get; set; }
    }
}
