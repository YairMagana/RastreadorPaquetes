namespace RastreadorPaquetes
{
    public interface IMedioTransporte
    {
        int cNombre { get; set; }
        double dCosto { get; set; }
        double dVelocidadEntrega { get; set; }
    }
}
