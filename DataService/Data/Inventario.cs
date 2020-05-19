using DataService.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataService.Data
{

    public partial class DataService: IDataService
    {

        public DTO.Resultado.Entidad<DTO.Inventario.Movimiento.Ficha> MovimientoFicha(DTO.Inventario.Movimiento.Filtro filtro)
        {
            return MyService.MovimientoFicha(filtro);
        }

    }

}