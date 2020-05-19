using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataService.Infra
{
    
    public interface IInventario
    {

        DTO.Resultado.Entidad<DTO.Inventario.Movimiento.Ficha> MovimientoFicha(DTO.Inventario.Movimiento.Filtro filtro);

    }

}