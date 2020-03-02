using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public interface IDesplegador
    {
        List<Tuple<string, ConsoleColor>> buffer { get; set; }

        void GuardarEnBuffer(string mensaje, ConsoleColor color);

        void Desplegar();

        void DesplegarMensaje(string texto);
    }
}
