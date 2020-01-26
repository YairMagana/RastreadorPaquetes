namespace RastreadorPaquetes
{
    public class Avion : IMedioTransporte
    {
        public string cNombre { get; set; } = "Avión";
        public double dCosto { get; set; } = 10;
        public double dVelocidadEntrega { get; set; } = 600;
    }
}
