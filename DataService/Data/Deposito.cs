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

        public DTO.Resultado.Lista<DTO.Inventario.Deposito.Resumen> DepositoLista()
        {
            return MyService.DepositoLista();
        }

    }

}