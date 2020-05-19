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

        public static Provider.Infra.IProvider MyService;


        public DataService() 
        {
            MyService = new Provider.Data.DataProvider();
        }


        public DTO.Resultado.Ficha Inicializa()
        {
            return MyService.Inicializa();
        }

    }

}