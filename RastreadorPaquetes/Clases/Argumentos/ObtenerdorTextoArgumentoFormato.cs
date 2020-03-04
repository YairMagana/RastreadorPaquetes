using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorPaquetes
{
    class ObtenerdorTextoArgumentoFormato : IObtenerdorTextoArgumentoFormato
    {
        private string[] args;

        public ObtenerdorTextoArgumentoFormato(string[] _args)
        {
            args = _args;
        }

        public string ObtenerTextoArgumentoFormato()
        {
            if (args != null && args.Length > 1)
            {
                if (args[1].ToUpper() == "-F")
                {
                    if(args != null && args.Length > 2 && (args[2].ToUpper() == "CSV" || args[2].ToUpper() == "JSON"))
                    {
                        return args[2];
                    } else
                    {
                        throw new Exception("Se debe proporcionar el valor correcto de formato del archivo de Entrada: CSV o JSON.");
                    }
                }
                else
                {
                    throw new Exception("Opción incorrecta, debe ser -f ");
                }
            }
            else
            {
                throw new Exception("Se debe establecer el formato del archivo de datos (CSV o JSON)");
            }
        }
    }
}
