using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvider.Infra
{

    public interface IProvData:IInventario, IDeposito, IProducto
    {

        OOB.Resultado.Ficha Inicializa();

    }

}