using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Inventario.Producto
{
    
    public class Filtro
    {

        public string cadena { get; set; }
        public Producto.Eumerados.enumPreferenciaBusqueda preferenciaBusqueda { get; set; }


        public Filtro()
        {
            cadena = "";
            preferenciaBusqueda = Eumerados.enumPreferenciaBusqueda.SinDefinir ;
        }

    }

}
