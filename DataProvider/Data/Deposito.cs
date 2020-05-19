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

        public OOB.Resultado.Lista<OOB.Inventario.Deposito.Ficha> DepoistoLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Inventario.Deposito.Ficha>();

            var r01 = MyData.DepositoLista();
            if (r01.Result == DTO.Resultado.Enumerados.EnumResult.isError) 
            {
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                result.Mensaje = r01.Mensaje;
                return result;
            }

            var lst = new List<OOB.Inventario.Deposito.Ficha>();
            if (r01.MyLista != null) 
            {
                if (r01.MyLista.Count > 0) 
                {
                    lst = r01.MyLista.Select(s =>
                    {
                        var rt = new OOB.Inventario.Deposito.Ficha()
                        {
                            Auto = s.Auto,
                            Codigo = s.Codigo,
                            Nombre = s.Nombre,
                        };
                        return rt;
                    }).ToList();
                }
            }
            result.MyLista = lst;

            return result;
        }

    }

}