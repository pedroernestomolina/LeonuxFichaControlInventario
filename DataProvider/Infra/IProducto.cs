using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvider.Infra
{
    
    public interface IProducto
    {

        OOB.Resultado.Lista<OOB.Inventario.Producto.Ficha> ProductoLista(OOB.Inventario.Producto.Filtro filtro);

    }

}