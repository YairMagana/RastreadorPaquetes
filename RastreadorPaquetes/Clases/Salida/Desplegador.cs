using System;

namespace RastreadorPaquetes
{
    public class Desplegador : IDesplegador
    {
        public void Desplegar(IDatosSalida datos)
        {
            Console.ForegroundColor = datos.color;
            Console.WriteLine(datos.cMensaje);
            Console.ResetColor();
        }
    }
}
