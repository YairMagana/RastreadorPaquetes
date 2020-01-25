namespace RastreadorPaquetes
{
    public class ObtenedorTextoPrimerArgumento : IObtenedorTextoArgumentos
    {
        private string[] args;

        public ObtenedorTextoPrimerArgumento(string[] _args)
        {
            args = _args;
        }

        public string ObtenerTextoArgumentos()
        {
            return (args != null && args.Length > 0) ? args[0] : "";
        }
    }
}
