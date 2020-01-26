using System;

namespace RastreadorPaquetes
{
    public class DirectorMensajeSalida : IDirectorMensajeSalida
    {
        private IConstructorDatosSalida constructorDatosSalida { get; set; }
        private IDirectorDatosEntrada directorDatosEntrada { get; set; }

        private IDatosSalida datosSalida { get; set; }

        public DirectorMensajeSalida(IDirectorDatosEntrada _directorDatosEntrada, IConstructorDatosSalida _constructorDatosSalida, IDatosSalida _datosSalida)
        {
            directorDatosEntrada = _directorDatosEntrada;
            constructorDatosSalida = _constructorDatosSalida;
            datosSalida = _datosSalida;
        }

        public IDatosSalida ConstruirMensajeSalida()
        {
            try
            {
                IDatosEntrada datosEntrada = directorDatosEntrada.ContruirDatosEntrada();
                string mensaje = string.Empty;
                mensaje = String.Format("Tu paquete {0} de {1} y {2} a {3} {4} {5} y {6} un costo de ${7} (Cualquier reclamación con {8}).",
                    constructorDatosSalida.GenerarExpresion1(datosEntrada.dtFechaEntrega),
                    datosEntrada.cOrigen,
                    constructorDatosSalida.GenerarExpresion2(datosEntrada.dtFechaEntrega),
                    datosEntrada.cDestino,
                    constructorDatosSalida.GenerarExpresion3(datosEntrada.dtFechaEntrega),
                    constructorDatosSalida.GenerarRangoTiempo(datosEntrada.dtFechaEntrega),
                    constructorDatosSalida.GenerarExpresion4(datosEntrada.dtFechaEntrega),
                    datosEntrada.dCostoEnvio.ToString("0.00"),
                    datosEntrada.objEmpresa.cNombre);
                datosSalida.cMensaje = mensaje;
                datosSalida.color = (constructorDatosSalida.GenerarColor(datosEntrada.dtFechaEntrega) > 0) ? ConsoleColor.Yellow : ConsoleColor.Green;
            }
            catch (Exception ex)
            {
                datosSalida.cMensaje = ex.Message.ToString();
                datosSalida.color = ConsoleColor.Red;
            }

            return datosSalida;
        }
    }
}
