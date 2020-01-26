namespace RastreadorPaquetes
{
    public interface IConstructorDatosEntrada
    {
        IDatosEntrada ObtenerDatosEntrada();
        void EstablecerCampoOrigen(string _dato);
        void EstablecerCampoDestino(string _dato);
        void EstablecerCampoDistancia(string _dato);
        void EstablecerCampoEmpresa(string _dato);
        void EstablecerCampoMedioTransporte(string _dato);
        void EstablecerCampoFechaPedido(string _dato);
        void EstablecerCampoTiempoTraslado();
        void EstablecerCampoFechaEntrega();
        void EstablecerCampoCostoEnvio();
    }
}
