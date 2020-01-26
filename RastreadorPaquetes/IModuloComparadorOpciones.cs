namespace RastreadorPaquetes
{
    public interface IModuloComparadorOpciones
    {
        string CompararOpciones(string _cEmpresaActual, IMedioTransporte _medioTransporteActual, double _dCostoActual, double _dDistancia);
    }
}
