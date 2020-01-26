namespace RastreadorPaquetes
{
    public interface IMedioTransporte
    {
        string cNombre { get; set; }
        double dCosto { get; set; }
        double dVelocidadEntrega { get; set; }
    }
}
