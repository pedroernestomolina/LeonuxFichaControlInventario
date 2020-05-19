using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvider.Infra
{
    
    public interface IInventario
    {

        OOB.Resultado.Entidad<OOB.Inventario.Movimiento.Ficha> MovimientoFicha(OOB.Inventario.Movimiento.Filtro filtro);

    }

}