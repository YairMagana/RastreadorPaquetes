using System.Collections.Generic;

namespace RastreadorPaquetes
{
    public class ModuloComparadorOpciones : IModuloComparadorOpciones
    {
        private List<IEmpresa> lstEmpresas;
        private List<IMedioTransporte> lstMediosTransporte;

        public ModuloComparadorOpciones(IFabricaEmpresas _fabricaEmpresas, IFabricaMediosTransporte _fabricaMediosTransporte)
        {
            lstEmpresas = new List<IEmpresa> {
                _fabricaEmpresas.FabricarEmpresa("DHL"),
                _fabricaEmpresas.FabricarEmpresa("Estafeta"),
                _fabricaEmpresas.FabricarEmpresa("Fedex") };

            lstMediosTransporte = new List<IMedioTransporte> { 
                _fabricaMediosTransporte.FabricarMedioTransporte("Tren"),
                _fabricaMediosTransporte.FabricarMedioTransporte("Barco"),
                _fabricaMediosTransporte.FabricarMedioTransporte("Avión") };
        }

        public string GenerarMensajeOpcionOptima(string _cEmpresaActual, IMedioTransporte _medioTransporteActual, double _dCostoActual, double _dDistancia)
        {
            string v = string.Empty;
            KeyValuePair<string, double> empresaMenorCosto = ObtenerEmpresaMenorCosto(_dDistancia, _cEmpresaActual, _medioTransporteActual);
            if (_cEmpresaActual != empresaMenorCosto.Key && _dCostoActual > empresaMenorCosto.Value)
            {
                v = string.Format("Si hubieras pedido en {0} te hubiera costado ${1} más barato.\n", empresaMenorCosto.Key, (_dCostoActual - empresaMenorCosto.Value).ToString("0.00"));
            }
            return v;
        }

        private KeyValuePair<string,double> ObtenerEmpresaMenorCosto (double _dDistancia, string _cExcluirEmpresa, IMedioTransporte _medioTransporteActual)
        {
            double a, min = double.MaxValue;
            KeyValuePair<string, double> empresaMenorCosto = new KeyValuePair<string, double>("", min);
            foreach (IEmpresa empresa in lstEmpresas)
            {
                if (empresa.cNombre != _cExcluirEmpresa && empresa.lstTTransportesUsados.Contains(_medioTransporteActual.GetType()))
                {
                    a = _medioTransporteActual.dCosto * _dDistancia * (1 + empresa.dMargenUtilidad);
                    if (a < empresaMenorCosto.Value)
                    {
                        empresaMenorCosto = new KeyValuePair<string, double>(empresa.cNombre, a);
                    }
                }
            }
            return empresaMenorCosto;
        }
    }
}
