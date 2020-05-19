using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleMySql
{

    class Program
    {
      
        static void Main(string[] args)
        {

            Provider.Infra.IProvider _dp = new Provider.Data.DataProvider();
            var r01 = _dp.Inicializa();
            if (r01.Result == DTO.Resultado.Enumerados.EnumResult.isError)
            {
                Console.WriteLine(r01.Mensaje);
            }
            else
            {
                var autoPrd = "0000001114";
                var autoDep = "0000000001";
                var desde = new DateTime(2020, 04, 01);
                var filtro = new DTO.Inventario.Movimiento.Filtro()
                {
                    AutoProducto = autoPrd,
                    AutoDeposito = autoDep,
                    DesdeFecha = desde,
                    HastaFecha = null,
                };
                var r02 = _dp.MovimientoFicha(filtro);
                if (r02.Result == DTO.Resultado.Enumerados.EnumResult.isError)
                {
                    Console.WriteLine(r02.Mensaje);
                }
            }
        }

    }

}
