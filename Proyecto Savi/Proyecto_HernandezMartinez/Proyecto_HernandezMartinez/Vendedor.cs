using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HernandezMartinez
{
    public class Vendedor
    {
        public String nombre;
        public String cve_vendedor;
        public String contraseña;
        public int ventasAcumuladas;
        public List<tipoVenta> listaDeVentas;

        

        public Vendedor()
        {
            nombre = "";
            listaDeVentas = new List<tipoVenta>();
        }

    }
}
