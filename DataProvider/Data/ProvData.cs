using DataProvider.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvider.Data
{
    
    public partial class ProvData: IProvData
    {

        DataService.Infra.IDataService MyData;


        public ProvData() 
        {
            MyData = new DataService.Data.DataService();
        }


        public OOB.Resultado.Ficha Inicializa()
        {
            var result = new OOB.Resultado.Ficha();

            var r01 = MyData.Inicializa();
            if (r01.Result == DTO.Resultado.Enumerados.EnumResult.isError) 
            {
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                result.Mensaje = r01.Mensaje;
                return result;
            }

            return result;
        }

    }

}