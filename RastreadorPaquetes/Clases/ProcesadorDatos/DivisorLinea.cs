using System;

namespace RastreadorPaquetes
{
    public class DivisorLinea : IDivisorLinea
    {
        public string[] DividirLinea(string _texto, int nCampos)
        {
            string[] v = new string[nCampos];
            if (!string.IsNullOrEmpty(_texto))
            {
                string[] campos = _texto.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i< campos.Length && i < nCampos; i++)
                {
                    v[i] = campos[i].Trim();
                }
            }
            return v;
        }
    }
}
