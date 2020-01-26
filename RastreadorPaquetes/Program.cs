using System;

namespace RastreadorPaquetes
{
    class Program
    {
        static void Main(string[] args)
        {
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

                IConstructorDatosEntrada constructorDatosEntrada = new ConstructorDatosEntrada(datosEntrada, fabricaEmpresas, fabricaMediosTransporte);
                IDirectorDatosEntrada directorDatosEntrada;

                IConstructorDatosSalida constructorDatosSalida = new ConstructorDatosSalida(convertidorRangoMinutos);
                IDirectorMensajeSalida directorMensajeSalida;

                // ** Desplegador
                IDesplegador desplegador = new Desplegador();

                // ** Modulo Comparador de Opciones
                IModuloComparadorOpciones moduloComparadorOpciones = new ModuloComparadorOpciones(fabricaEmpresas, fabricaMediosTransporte);

                foreach (string registro in obtenedorContenidoArchivoListaStrings.ObtenerRegistrosArchivo())
                {
                    // Dividir los campos
                    directorDatosEntrada = new DirectorDatosEntrada(divisorLinea.DividirLinea(registro, 6), constructorDatosEntrada);

                    // Generar los mensajes de salida
                    datosSalida = new DatosSalida();
                    directorMensajeSalida = new DirectorMensajeSalida(directorDatosEntrada, constructorDatosSalida, datosSalida);
                    
                    // Mostrar Datos
                    desplegador.Desplegar(directorMensajeSalida.ConstruirMensajeSalida());

                    // Móulo Comparador de Costos
                    if (datosSalida.color != ConsoleColor.Red)
                    {
                        string mensajeComparacion = moduloComparadorOpciones.CompararOpciones(datosEntrada.objEmpresa.cNombre,
                            datosEntrada.objMedioTransporte,
                            datosEntrada.dCostoEnvio,
                            datosEntrada.dDistancia);
                        // Mostrar resultado del módulo
                        datosSalida.cMensaje = mensajeComparacion;
                        datosSalida.color = ConsoleColor.White;
                        desplegador.Desplegar(datosSalida);
                    }
                }

            }
            catch (Exception ex)
            {
                string texto = $"Ha ocurrido un error: {ex.Message}";
                Console.WriteLine(texto);
            }

            Console.ReadKey();
        }
    }
}
