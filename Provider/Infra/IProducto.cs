using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.Infra
{
    
    public interface IProducto
    {

        DTO.Resultado.Lista<DTO.Inventario.Producto.Resumen> ProductoLista(DTO.Inventario.Producto.Filtro filtro);

    }

}