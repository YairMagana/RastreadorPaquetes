using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*** SERVICIOS ***/
                // * Argumento
                IObtenedorTextoArgumentos obtenedorTextoPrimerArgumento = new ObtenedorTextoPrimerArgumento(args);
                // Archivo
                IValidadorArchivo validadorArchivo = new ValidarArchivoTexto();
                ILectorArchivoTexto lectorArchivoTexto = new LectorArchivoTexto(obtenedorTextoPrimerArgumento.ObtenerTextoArgumentos(), validadorArchivo);
                IObtenedorRegistrosArchivoListaStrings obtenedorContenidoArchivoListaStrings = new ObtenedorRegistrosArchivoListaStrings(lectorArchivoTexto);

                Console.WriteLine(String.Join("\n", obtenedorContenidoArchivoListaStrings.ObtenerRegistrosArchivo()));

                // * Procesamiento
                IDivisorLinea divisorLinea = new DivisorLinea();

                Console.WriteLine(String.Join("\n", divisorLinea.DividirLinea(obtenedorContenidoArchivoListaStrings.ObtenerRegistrosArchivo()[0],6).Select(s => string.IsNullOrEmpty(s)?"null":s)));



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
