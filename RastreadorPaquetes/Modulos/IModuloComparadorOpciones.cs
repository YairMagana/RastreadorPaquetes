namespace RastreadorPaquetes
{
    public interface IModuloComparadorOpciones
    {
        string GenerarMensajeOpcionOptima(string _cEmpresaActual, IMedioTransporte _medioTransporteActual, double _dCostoActual, double _dDistancia);
    }
}
