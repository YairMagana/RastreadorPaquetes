using System;

namespace RastreadorPaquetes
{
    public class DirectorDatosEntrada : IDirectorDatosEntrada
    {
        private IConstructorDatosEntrada constructorDatosEntrada;
        private string[] datos { get; set; }

        public DirectorDatosEntrada(string[] _datos, IConstructorDatosEntrada _constructorDatosEntrada)
        {
            datos = _datos;
            constructorDatosEntrada = _constructorDatosEntrada;
        }
        public IDatosEntrada ContruirDatosEntrada()
        {
            try
            {
                constructorDatosEntrada.EstablecerCampoOrigen(datos[0]);
                constructorDatosEntrada.EstablecerCampoDestino(datos[1]);
                constructorDatosEntrada.EstablecerCampoDistancia(datos[2]);
                constructorDatosEntrada.EstablecerCampoEmpresa(datos[3]);
                constructorDatosEntrada.EstablecerCampoMedioTransporte(datos[4]);
                constructorDatosEntrada.EstablecerCampoFechaPedido(datos[5]);

                constructorDatosEntrada.EstablecerCampoTiempoTraslado();
                constructorDatosEntrada.EstablecerCampoFechaEntrega();
                constructorDatosEntrada.EstablecerCampoCostoEnvio();

                return constructorDatosEntrada.ObtenerDatosEntrada();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
