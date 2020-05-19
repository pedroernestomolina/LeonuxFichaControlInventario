using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataService.Infra
{
    
    public interface IDeposito
    {

        DTO.Resultado.Lista<DTO.Inventario.Deposito.Resumen> DepositoLista();

    }

}