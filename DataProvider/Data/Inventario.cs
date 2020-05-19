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

        public OOB.Resultado.Entidad<OOB.Inventario.Movimiento.Ficha> MovimientoFicha(OOB.Inventario.Movimiento.Filtro filtro)
        {
            var result = new OOB.Resultado.Entidad<OOB.Inventario.Movimiento.Ficha>();

            var filtroDto = new DTO.Inventario.Movimiento.Filtro()
            {
                AutoProducto = filtro.AutoProducto,
                AutoDeposito = filtro.AutoDeposito,
                DesdeFecha = filtro.DesdeFecha,
                HastaFecha = filtro.HastaFecha,
            };
            var r01 = MyData.MovimientoFicha(filtroDto);
            if (r01.Result == DTO.Resultado.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var rg=r01.MyEntidad;
            var nr = new OOB.Inventario.Movimiento.Ficha()
            {
                autoProducto = rg.autoProducto,
                codigProducto = rg.codigProducto,
                descripcionProducto = rg.descripcionProducto,
                isPesado=rg.isPesado,
                ExistenciaAntesFecha = rg.ExistenciaAntesFecha,
            };
            var dep = new List<OOB.Inventario.Movimiento.DepositoExistencia>();
            var ven = new List<OOB.Inventario.Movimiento.MovPorVenta>();
            var com = new List<OOB.Inventario.Movimiento.MovPorCompra>();
            var inv = new List<OOB.Inventario.Movimiento.MovPorInventario>();
            var kdx = new List<OOB.Inventario.Movimiento.Kardex>();

            if (rg.Depositos != null) 
            {
                if (rg.Depositos.Count > 0) 
                {
                    dep = rg.Depositos.Select(s =>
                    {
                        var it = new OOB.Inventario.Movimiento.DepositoExistencia()
                        {
                             autoDeposito=s.autoDeposito,
                             DepositoCodigo=s.DepositoCodigo,
                             DepositoDescripcion=s.DepositoDescripcion,
                             ExFisica=s.ExFisica,
                        };
                        return it;
                    }).ToList();
                }
            }
            if (rg.MovVentas != null)
            {
                if (rg.MovVentas.Count > 0)
                {
                    ven = rg.MovVentas.Select(s =>
                    {
                        var it = new OOB.Inventario.Movimiento.MovPorVenta()
                        {
                            autoVenta = s.autoVenta,
                            autoDeposito=s.autoDeposito,
                            Cantidad = s.Cantidad,
                            CiRif = s.CiRif,
                            CodigoSucursal = s.CodigoSucursal,
                            DocumentoCodigo = s.DocumentoCodigo,
                            DocumentoNombre = s.DocumentoNombre,
                            DocumentoNro = s.DocumentoNro,
                            DocumentoTipo = s.DocumentoTipo,
                            Entidad = s.Entidad,
                            Fecha = s.Fecha,
                            Hora = s.Hora,
                            Signo = s.Signo,
                            NombreDeposito=s.NombreDeposito,
                            CodigoDeposito=s.CodigoDeposito,
                        };
                        return it;
                    }).ToList();
                }
            }
            if (rg.MovCompra != null)
            {
                if (rg.MovCompra.Count > 0)
                {
                    com = rg.MovCompra.Select(s =>
                    {
                        var it = new OOB.Inventario.Movimiento.MovPorCompra()
                        {
                            autoCompra = s.autoCompra,
                            autoDeposito = s.autoDeposito,
                            CodigoDeposito = s.CodigoDeposito,
                            NombreDeposito = s.NombreDeposito,
                            Notas = s.Notas,
                            Cantidad = s.Cantidad,
                            CodigoSucursal = s.CodigoSucursal,
                            DocumentoCodigo = s.DocumentoCodigo,
                            DocumentoNombre = s.DocumentoNombre,
                            DocumentoNro = s.DocumentoNro,
                            DocumentoTipo = s.DocumentoTipo,
                            Entidad = s.Entidad,
                            Fecha = s.Fecha,
                            Hora = s.Hora,
                            Signo = s.Signo,
                        };
                        return it;
                    }).ToList();
                }
            }
            if (rg.MovInventario != null)
            {
                if (rg.MovInventario.Count > 0)
                {
                    inv = rg.MovInventario.Select(s =>
                    {
                        var it = new OOB.Inventario.Movimiento.MovPorInventario()
                        {
                            autoConcepto = s.autoConcepto,
                            autoDepositoDestino = s.autoDepositoDestino,
                            autoDepositoOrigen = s.autoDepositoOrigen,
                            autoDocumento = s.autoDocumento,
                            ConceptoCodigo = s.ConceptoCodigo,
                            ConceptoNombre = s.ConceptoNombre,
                            DepositoDestinoCodigo = s.DepositoDestinoCodigo,
                            DepositoDestinoNombre = s.DepositoDestinoNombre,
                            DepositoOrigenCodigo = s.DepositoOrigenCodigo,
                            DepositoOrigenNombre = s.DepositoOrigenNombre,
                            Nota = s.Nota,
                            Cantidad = s.Cantidad,
                            DocumentoNombre = s.DocumentoNombre,
                            DocumentoNro = s.DocumentoNro,
                            DocumentoTipo = s.DocumentoTipo,
                            Fecha = s.Fecha,
                            Hora = s.Hora,
                            Signo = s.Signo,
                        };
                        return it;
                    }).ToList();
                }
            }
            if (rg.Kardex != null)
            {
                if (rg.Kardex.Count > 0)
                {
                    kdx = rg.Kardex.Select(s =>
                    {
                        var it = new OOB.Inventario.Movimiento.Kardex()
                        {
                            autoCocepto=s.autoCocepto,
                            autoDeposito=s.autoDeposito,
                            autoDocumento = s.autoDocumento,
                            ConceptoCodigo = s.ConceptoCodigo,
                            ConceptoNombre = s.ConceptoNombre,
                            DepositoCodigo=s.DepositoCodigo,
                            DepositoNombre=s.DepositoNombre,
                            DocumentoNro = s.DocumentoNro,
                            DocumentoCodigo = s.DocumentoCodigo,
                            DocumentoModulo=s.DocumentoModulo,
                            DocumentoSiglas=s.DocumentoSiglas,
                            Entidad=s.Entidad,
                            Cantidad = s.Cantidad,
                            Fecha = s.Fecha,
                            Hora = s.Hora,
                            Signo = s.Signo,
                        };
                        return it;
                    }).ToList();
                }
            }
            nr.Depositos = dep;
            nr.MovVentas = ven;
            nr.MovCompra = com;
            nr.MovInventario = inv;
            nr.Kardex = kdx;
            result.MyEntidad = nr;

            return result;
        }

    }

}