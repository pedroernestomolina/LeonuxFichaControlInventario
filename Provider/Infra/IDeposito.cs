using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.Infra
{
    
    public interface IDeposito
    {

        DTO.Resultado.Lista<DTO.Inventario.Deposito.Resumen> DepositoLista ();
        
    }

}