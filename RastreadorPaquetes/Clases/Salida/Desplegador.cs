using System;
using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public class Desplegador : IDesplegador
    {
        public List<Tuple<string, ConsoleColor>> buffer { get; set; }

        public Desplegador()
        {
            buffer = new List<Tuple<string, ConsoleColor>>();
        }

        public void Desplegar()
        {
            foreach (var item in buffer)
            {
                Console.ForegroundColor = item.Item2;
                Console.WriteLine(item.Item1);
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        public void DesplegarMensaje(string texto)
        {
            Console.WriteLine(texto);
            Console.ReadKey();
        }

        public void GuardarEnBuffer(string mensaje, ConsoleColor color)
        {
            buffer.Add(new Tuple<string, ConsoleColor>(mensaje, color));
        }

    }
}
