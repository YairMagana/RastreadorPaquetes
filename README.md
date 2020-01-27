# RastreadorPaquetes
Tarea final de la capacitación de Analistas.

## Agregar nuevas Empresas o Medios de Transporte

### Paqueterías
Para agregar más paqueterías 
Se debe crear una nueva clase [Nueva_Empresa] que extienda la interfaz IEmpresa, establecer los valores de la empresa, y crear una lista de Tipos de transportes utilizados.

Ejemplo:
```c#
public class Nueva_Empresa : IEmpresa
{
  public string cNombre { get; set; }
  public double dMargenUtilidad { get; set; }
  public List<Type> lstTTransportesUsados { get; set; }

  public Fedex()
  {
      cNombre = "Nueva_Empresa";
      dMargenUtilidad = 0.75;
      lstTTransportesUsados = new List<Type> { typeof(Barco), typeof(Avion) };
  }
}
```

Añadir la nueva opción en la clase de Fabrica/Estrategia *FabricaEmpresas.cs*:

```c#
    public class FabricaEmpresas : IFabricaEmpresas
    {
        public IEmpresa FabricarEmpresa(string _nombre)
        {
            switch(_nombre.ToUpper())
            {
                // ...
                
                /* Nueva Empresa */
                case "NUEVA_EMPRESA":
                    return new Nueva_Empresa();

                default:
                    throw new Exception($"La Paquetería: {_nombre} no se encuentra registrada en nuestra red de distribución.");
            }
        }
    }
```

### Medios de Transporte
Para agregar más medios de transporte 
Se debe crear una nueva clase [Nuevo_Medio] que extienda la interfaz IMedioTransporte, establecer los valores del medio de transporte.

Ejemplo:
```c#
public class Nuevo_Medio : IMedioTransporte
    {
        public string cNombre { get; set; } = "Nuevo Medio";
        public double dCosto { get; set; } = 20;
        public double dVelocidadEntrega { get; set; } = 400;  // Km/h
    }
```

Añadir la nueva opción en la clase de Fabrica/Estrategia *FabricaMediosTransporte.cs*:

```c#
public IMedioTransporte FabricarMedioTransporte(string _nombre)
        {
            switch (_nombre.ToUpper())
            {
                // ...
                
                /* Nuevo Medio de Transporte */
                case "NUEVO_MEDIO":
                    return new Nuevo_Medio();

                default:
                    throw new Exception("Medio de Tansporte No Existe");
            }
        }
```

### Módulo de comparación de Opciones más baratas
Para agregar las nuevas empresas o medios de trasnsporte al módulo de Obtención de Entrega  más barata *ModuloComparadorOpciones.cs*.

Ejemplo:
```c#
public ModuloComparadorOpciones(IFabricaEmpresas _fabricaEmpresas, IFabricaMediosTransporte _fabricaMediosTransporte)
        {
            lstEmpresas = new List<IEmpresa> {
                _fabricaEmpresas.FabricarEmpresa("DHL"),
                _fabricaEmpresas.FabricarEmpresa("Estafeta"),
                _fabricaEmpresas.FabricarEmpresa("Fedex"),
                // Agregar Empresas para comparación:
                _fabricaEmpresas.FabricarEmpresa("Nueva_Empresa")
                };

            lstMediosTransporte = new List<IMedioTransporte> { 
                _fabricaMediosTransporte.FabricarMedioTransporte("Tren"),
                _fabricaMediosTransporte.FabricarMedioTransporte("Barco"),
                _fabricaMediosTransporte.FabricarMedioTransporte("Avión"),
                // Agregar Medio de Transporte para comparación:
                _fabricaMediosTransporte.FabricarMedioTransporte("Nuevo_Medio")
                };
        }

```
