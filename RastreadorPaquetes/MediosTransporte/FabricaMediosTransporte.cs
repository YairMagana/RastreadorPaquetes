using System;

namespace RastreadorPaquetes
{
    public class FabricaMediosTransporte : IFabricaMediosTransporte
    {
        public IMedioTransporte FabricarMedioTransporte(string _nombre)
        {
            switch (_nombre.ToUpper())
            {
                case "BARCO":
                    return new Barco();

                case "TREN":
                    return new Tren();

                case "AVION":
                case "AVIÓN":
                    return new Avion();

                default:
                    throw new Exception("Medio de Tansporte No Existe");
            }
        }
    }
}
