namespace RastreadorPaquetes
{
    public class Tren : IMedioTransporte
    {
        public string cNombre { get; set; } = "Tren";
        public double dCosto { get; set; } = 5;
        public double dVelocidadEntrega { get; set; } = 80;
    }
}
