using System;

namespace RastreadorPaquetes
{
    class Program
    {
        static void Main(string[] args)
        {
            // ** Desplegador
            IDesplegador desplegador = new Desplegador();

            try
            {
                /*** SERVICIOS ***/
                // ** Argumento
                IObtenedorTextoArgumentos obtenedorTextoPrimerArgumento = new ObtenedorTextoPrimerArgumento(args);
                //  Archivo
                IValidadorArchivo validadorArchivo = new ValidarArchivoTexto();
                ILectorArchivoTexto lectorArchivoTexto = new LectorArchivoTexto(obtenedorTextoPrimerArgumento.ObtenerTextoArgumentos(), validadorArchivo);
                IObtenedorRegistrosArchivoListaStrings obtenedorContenidoArchivoListaStrings = new ObtenedorRegistrosArchivoListaStrings(lectorArchivoTexto);

                // ** Procesamiento
                IDivisorLinea divisorLinea = new DivisorLinea();

                // * Creación de Fábricas: Empresas y Medios de Transporte
                IFabricaEmpresas fabricaEmpresas = new FabricaEmpresas();
                IFabricaMediosTransporte fabricaMediosTransporte = new FabricaMediosTransporte();

                //  Creación de obtención de Rangos de Tiempos con Cadena de Responsabilidad
                IConvertidorRangoTiempo convertidorRangoMeses = new ConvertidorRangoTiempoMeses();
                IConvertidorRangoTiempo convertidorRangoDias = new ConvertidorRangoTiempoDias();
                IConvertidorRangoTiempo convertidorRangoHoras = new ConvertidorRangoTiempoHoras();
                IConvertidorRangoTiempo convertidorRangoMinutos = new ConvertidorRangoTiempoMinutos();

                convertidorRangoMinutos.EstablecerSiguienteConvertidor(convertidorRangoHoras);
                convertidorRangoHoras.EstablecerSiguienteConvertidor(convertidorRangoDias);
                convertidorRangoDias.EstablecerSiguienteConvertidor(convertidorRangoMeses);

                // * Herramientas para procesamiento
                IDatosEntrada datosEntrada = new DatosEntrada();
                IDatosSalida datosSalida = new DatosSalida(); ;

                // ** Modulo Comparador de Opciones
                IModuloComparadorOpciones moduloComparadorOpciones = new ModuloComparadorOpciones(fabricaEmpresas, fabricaMediosTransporte);
                RastrearPaquetes(obtenedorContenidoArchivoListaStrings, divisorLinea, fabricaEmpresas, fabricaMediosTransporte, convertidorRangoMinutos, datosEntrada, datosSalida, desplegador, moduloComparadorOpciones);
            }
            catch (Exception ex)
            {
                string texto = $"Ha ocurrido un error: {ex.Message}";
                desplegador.DesplegarMensaje(texto);
            }
        }

        private static void RastrearPaquetes(IObtenedorRegistrosArchivoListaStrings obtenedorContenidoArchivoListaStrings, IDivisorLinea divisorLinea, IFabricaEmpresas fabricaEmpresas,
            IFabricaMediosTransporte fabricaMediosTransporte, IConvertidorRangoTiempo convertidorRangoMinutos, IDatosEntrada datosEntrada, IDatosSalida datosSalida, IDesplegador desplegador, IModuloComparadorOpciones moduloComparadorOpciones)
        {
            // Builders de Datos de Entrada y Salida
            IConstructorDatosEntrada constructorDatosEntrada = new ConstructorDatosEntrada(datosEntrada, fabricaEmpresas, fabricaMediosTransporte);
            IDirectorDatosEntrada directorDatosEntrada;
            IConstructorDatosSalida constructorDatosSalida = new ConstructorDatosSalida(convertidorRangoMinutos);
            IDirectorMensajeSalida directorMensajeSalida;

            // Por cada línea del archivo se calculan los datos
            foreach (string registro in obtenedorContenidoArchivoListaStrings.ObtenerRegistrosArchivo())
            {
                // Dividir los campos
                directorDatosEntrada = new DirectorDatosEntrada(divisorLinea.DividirLinea(registro, 6), constructorDatosEntrada);

                // Generar los mensajes de salida
                datosSalida = new DatosSalida();
                directorMensajeSalida = new DirectorMensajeSalida(directorDatosEntrada, constructorDatosSalida, datosSalida);
                datosSalida = directorMensajeSalida.ConstruirMensajeSalida();

                // Almacenar en buffer
                desplegador.GuardarEnBuffer(datosSalida.cMensaje, datosSalida.color);

                // Móulo Comparador de Costos
                CompararCostos(datosEntrada, datosSalida, desplegador, moduloComparadorOpciones);
            }
            // Mostrar Datos
            desplegador.Desplegar();
        }

        private static void CompararCostos(IDatosEntrada datosEntrada, IDatosSalida datosSalida, IDesplegador desplegador, IModuloComparadorOpciones moduloComparadorOpciones)
        {
            if (datosSalida.color != ConsoleColor.Red)
            {
                string mensajeComparacion = moduloComparadorOpciones.GenerarMensajeOpcionOptima(datosEntrada.objEmpresa.cNombre,
                    datosEntrada.objMedioTransporte,
                    datosEntrada.dCostoEnvio,
                    datosEntrada.dDistancia);
                // Mostrar resultado del módulo
                desplegador.GuardarEnBuffer(mensajeComparacion, ConsoleColor.White);
            }
        }
    }
}
