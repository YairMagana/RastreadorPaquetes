using System;

namespace RastreadorPaquetes
{
    public class FabricaEmpresas : IFabricaEmpresas
    {
        public IEmpresa FabricarEmpresa(string _nombre)
        {
            switch(_nombre.ToUpper())
            {
                case "FEDEX":
                    return new Fedex();

                case "DHL":
                    return new DHL();

                case "ESTAFETA":
                    return new Estafeta();

                default:
                    throw new Exception($"La Paquetería: {_nombre} no se encuentra registrada en nuestra red de distribución.");
            }
        }
    }
}
