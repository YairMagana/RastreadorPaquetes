using System;

namespace RastreadorPaquetes
{
    public interface IDatosSalida
    {
        string cMensaje { get; set; }
        ConsoleColor color { get; set; }
    }
}
