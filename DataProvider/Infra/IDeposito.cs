using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvider.Infra
{
    
    public interface IDeposito
    {

        OOB.Resultado.Lista<OOB.Inventario.Deposito.Ficha> DepoistoLista();

    }

}