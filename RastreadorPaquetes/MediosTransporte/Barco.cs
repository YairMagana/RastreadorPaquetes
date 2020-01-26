namespace RastreadorPaquetes
{
    public class Barco : IMedioTransporte
    {
        public string cNombre { get; set; } = "Barco";
        public double dCosto { get; set; } = 1;
        public double dVelocidadEntrega { get; set; } = 46;
    }
}
