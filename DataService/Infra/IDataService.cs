using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataService.Infra
{
    
    public interface IDataService: IInventario, IDeposito, IProducto
    {

        DTO.Resultado.Ficha Inicializa();

    }

}
