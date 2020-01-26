using System;

namespace RastreadorPaquetes
{
    public class ConstructorDatosEntrada : IConstructorDatosEntrada
    {
        private IDatosEntrada datosEntrada { get; set; }
        private IFabricaEmpresas fabricaEmpresas { get; }
        private IFabricaMediosTransporte fabricaMediosTransporte { get; }

        public ConstructorDatosEntrada(IDatosEntrada _datosEntrada, IFabricaEmpresas _fabricaEmpresas, IFabricaMediosTransporte _fabricaMediosTransporte)
        {
            datosEntrada = _datosEntrada;
            fabricaEmpresas = _fabricaEmpresas;
            fabricaMediosTransporte = _fabricaMediosTransporte;
        }

        /*public void InicializarConstructor()
        {
            datosEntrada = new DatosEntrada();
        }*/

        public IDatosEntrada ObtenerDatosEntrada()
        {
            return datosEntrada;
        }

        public void EstablecerCampoOrigen(string _dato)
        {
            if (!string.IsNullOrEmpty(_dato))
                datosEntrada.cOrigen = _dato;
            else
                throw new Exception("Origen inválido");
        }

        public void EstablecerCampoDestino(string _dato)
        {
            if (!string.IsNullOrEmpty(_dato))
                datosEntrada.cDestino = _dato;
            else
                throw new Exception("Destino inválido");
        }

        public void EstablecerCampoDistancia(string _dato)
        {
            try
            {
                double dDistancia;
                double.TryParse(_dato, out dDistancia);
                datosEntrada.dDistancia = dDistancia;
            }
            catch
            {
                throw new Exception("Distancia inválida");
            }
        }

        public void EstablecerCampoEmpresa(string _dato)
        {
            try
            {
                datosEntrada.objEmpresa = fabricaEmpresas.FabricarEmpresa(_dato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EstablecerCampoMedioTransporte(string _dato)
        {
            try
            {
                datosEntrada.objMedioTransporte = fabricaMediosTransporte.FabricarMedioTransporte(_dato);
                if (!datosEntrada.objEmpresa.lstTTransportesUsados.Contains(datosEntrada.objMedioTransporte.GetType()))
                {
                    throw new Exception($"{datosEntrada.objEmpresa.cNombre} no ofrece el servicio de transporte {datosEntrada.objMedioTransporte.cNombre}, te recomendamos cotizar en otra empresa.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EstablecerCampoFechaPedido(string _dato)
        {
            try
            {
                DateTime dtFechaPedido;
                DateTime.TryParse(_dato, out dtFechaPedido);
                datosEntrada.dtFechaPedido = dtFechaPedido;
            }
            catch
            {
                throw new Exception("Fecha de Pedido inválida");
            }
        }

        public void EstablecerCampoTiempoTraslado()
        {
            try
            {
                datosEntrada.dTiempoTraslado = datosEntrada.dDistancia / datosEntrada.objMedioTransporte.dVelocidadEntrega;
            }
            catch (Exception ex)
            {
                throw new Exception("Tiempo de Traslado inválido. " + ex);
            }
        }

        public void EstablecerCampoFechaEntrega()
        {
            try
            {
                datosEntrada.dtFechaEntrega = datosEntrada.dtFechaPedido.Add(new TimeSpan(
                Convert.ToInt32(Math.Floor(datosEntrada.dTiempoTraslado)),
                Convert.ToInt32((datosEntrada.dTiempoTraslado - Math.Floor(datosEntrada.dTiempoTraslado)) * 60),
                0));
            }
            catch (Exception ex)
            {
                throw new Exception("Fecha de Entrega inválido. " + ex);
            }
        }

        public void EstablecerCampoCostoEnvio()
        {
            try
            {
                datosEntrada.dCostoEnvio = datosEntrada.objMedioTransporte.dCosto * datosEntrada.dDistancia * (1 + datosEntrada.objEmpresa.dMargenUtilidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Costo de Envío inválido. " + ex);
            }
        }
    }
}
