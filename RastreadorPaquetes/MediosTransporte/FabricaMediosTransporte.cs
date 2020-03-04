using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreadorPaquetes
{
    public class FabricaMediosTransporte : IFabricaMediosTransporte
    {
        List<IMedioTransporte> medioTransportes;
        public FabricaMediosTransporte(List<IMedioTransporte> _medioTransportes)
        {
            medioTransportes = _medioTransportes;
        }

        public IMedioTransporte FabricarMedioTransporte(string _nombre)
        {
            IMedioTransporte transporte;
            switch (_nombre.ToUpper())
            {
                case "MARÍTIMO":
                    transporte = medioTransportes.Where(w => w.cNombre.ToUpper() == "MARÍTIMO").FirstOrDefault();
                    var trans1 = new Barco();
                    trans1.cNombre = transporte.cNombre;
                    trans1.dCosto = transporte.dCosto;
                    trans1.dVelocidadEntrega = transporte.dVelocidadEntrega;
                    return trans1;

                case "TERRESTRE":
                    transporte = medioTransportes.Where(w => w.cNombre.ToUpper() == "TERRESTRE").FirstOrDefault();
                    var trans2 = new Tren();
                    trans2.cNombre = transporte.cNombre;
                    trans2.dCosto = transporte.dCosto;
                    trans2.dVelocidadEntrega = transporte.dVelocidadEntrega;
                    return trans2;

                case "AÉREO":
                case "AEREO":
                    transporte = medioTransportes.Where(w => w.cNombre.ToUpper() == "AÉREO").FirstOrDefault();
                    var trans3 = new Avion();
                    trans3.cNombre = transporte.cNombre;
                    trans3.dCosto = transporte.dCosto;
                    trans3.dVelocidadEntrega = transporte.dVelocidadEntrega;
                    return trans3;

                default:
                    throw new Exception("Medio de Tansporte No Existe");
            }
        }
    }
}
