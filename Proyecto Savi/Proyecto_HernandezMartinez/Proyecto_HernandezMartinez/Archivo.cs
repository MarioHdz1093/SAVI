using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HernandezMartinez
{
    public class Archivo
    {
        public string cve_vendedor;
        public tipoVenta vendio;
        public int cuantasVentas;

        public Archivo()
        {
            vendio = new tipoVenta();
        }
    }
}
