using EntityMySql;
using Provider.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Provider.Data
{

    public partial class DataProvider: IProvider
    {

        public DTO.Resultado.Lista<DTO.Inventario.Deposito.Resumen> DepositoLista()
        {
            var result = new DTO.Resultado.Lista<DTO.Inventario.Deposito.Resumen>();

            try
            {
                using (var ctx = new leonuxEntities (_cn.ConnectionString))
                {
                    var list = new List<DTO.Inventario.Deposito.Resumen>();

                    var q = ctx.empresa_depositos.ToList();
                    if (q.Count > 0)
                    {
                        list = q.Select(d =>
                        {
                            return new DTO.Inventario.Deposito.Resumen()
                            {
                                Auto=d.auto,
                                Codigo=d.codigo,
                                Nombre=d.nombre,
                            };
                        }).ToList();
                    }

                    result.cntRegistro = list.Count();
                    result.MyLista = list;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Resultado.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}