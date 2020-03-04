using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreadorPaquetes
{
    public class FabricaEmpresas : IFabricaEmpresas
    {
        List<IEmpresaDatos> empresasDatos;

        public FabricaEmpresas(List<IEmpresaDatos> _empresasDatos)
        {
            empresasDatos = _empresasDatos;
        }
        public IEmpresa FabricarEmpresa(string _nombre)
        {
            switch(_nombre.ToUpper())
            {
                case "FEDEX":
                    return new Fedex(empresasDatos.Where(w => w.cNombre.ToUpper() == "FEDEX").FirstOrDefault());

                case "DHL":
                    return new DHL(empresasDatos.Where(w => w.cNombre.ToUpper() == "DHL").FirstOrDefault());

                case "ESTAFETA":
                    return new Estafeta(empresasDatos.Where(w => w.cNombre.ToUpper() == "ESTAFETA").FirstOrDefault());

                default:
                    throw new Exception($"La Paquetería: {_nombre} no se encuentra registrada en nuestra red de distribución.");
            }
        }
    }
}
