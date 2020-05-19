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

        public OOB.Resultado.Lista<OOB.Inventario.Producto.Ficha> ProductoLista(OOB.Inventario.Producto.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Inventario.Producto.Ficha>();

            var filtroDTO = new DTO.Inventario.Producto.Filtro();
            filtroDTO.cadena = filtro.cadena;
            filtroDTO.preferenciaBusqueda =  (DTO.Inventario.Producto.Eumerados.enumPreferenciaBusqueda)filtro.preferenciaBusqueda;
            var r01 = MyData.ProductoLista(filtroDTO);
            if (r01.Result ==  DTO.Resultado.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result =  OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            result.MyLista = new List<OOB.Inventario.Producto.Ficha>();
            if (r01.MyLista!= null)
            {
                if (r01.MyLista.Count > 0)
                {
                    result.MyLista= r01.MyLista.Select(s =>
                    {
                        return new OOB.Inventario.Producto.Ficha()
                        {
                            Auto = s.Auto,
                            CodigoPrd = s.CodigoPrd,
                            NombrePrd = s.NombrePrd,
                            Referencia = s.ReferenciaPrd,
                            IsActivo = s.IsActivo,
                        };
                    }).ToList();
                }
            }

            return result;
        }

    }

}
