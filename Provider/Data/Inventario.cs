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
        
        public DTO.Resultado.Entidad<DTO.Inventario.Movimiento.Ficha> MovimientoFicha(DTO.Inventario.Movimiento.Filtro filtro)
        {
            var result = new DTO.Resultado.Entidad<DTO.Inventario.Movimiento.Ficha>();
            var autoPrd = filtro.AutoProducto;
            var autoDeposito = filtro.AutoDeposito;

            try
            {
                using (var ctx = new leonuxEntities(_cn.ConnectionString))
                {
                    var entPrd = ctx.productos.Find(autoPrd);
                    if (entPrd == null)
                    {
                        result.Mensaje = "[ ID ] PRODUCTO NO ENCONTRADO";
                        result.Result = DTO.Resultado.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var entListDep = ctx.productos_deposito.Join(ctx.empresa_depositos, pd => pd.auto_deposito, dep => dep.auto, (pd, dep) => new { prdDep=pd, dep=dep }).
                        Where(w => w.prdDep.auto_producto == autoPrd).ToList();
                    if (entListDep == null) 
                    {
                        result.Mensaje = "DEPOSITOS NO DEFINIDO";
                        result.Result = DTO.Resultado.Enumerados.EnumResult.isError;
                        return result;
                    }

                    if (entListDep.Count == 0) 
                    {
                        result.Mensaje = "DEPOSITOS NO ASIGNADOS";
                        result.Result = DTO.Resultado.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var entListVenta = ctx.ventas_detalle.Join(ctx.ventas, vd => vd.auto_documento, v => v.auto, (vd, v) => new { det=vd, venta=v }).
                        Where(w => w.det.auto_producto == autoPrd).ToList();
                    if (entListVenta!=null)
                    {
                        if (entListVenta.Count > 0) 
                        {
                            if (autoDeposito != "") 
                            {
                                entListVenta = entListVenta.Where(w => w.det.auto_deposito == autoDeposito).ToList();
                            }
                            if (filtro.DesdeFecha.HasValue) 
                            {
                                entListVenta = entListVenta.Where(w => w.det.fecha>=filtro.DesdeFecha.Value).ToList();
                            }
                            if (filtro.HastaFecha.HasValue)
                            {
                                entListVenta = entListVenta.Where(w => w.det.fecha <= filtro.HastaFecha.Value).ToList();
                            }
                            entListVenta = entListVenta.Where(w => w.det.estatus_anulado=="0").ToList();
                        }
                    }

                    var entListCompra = ctx.compras_detalle.Join(ctx.compras, cd=>cd.auto_documento, c=>c.auto, (cd,c) => new {det=cd, compra=c}).
                        Where(w => w.det.auto_producto == autoPrd).ToList();
                    if (entListCompra != null)
                    {
                        if (entListCompra.Count > 0)
                        {
                            if (filtro.DesdeFecha.HasValue)
                            {
                                entListCompra = entListCompra.Where(w => w.det.fecha >= filtro.DesdeFecha.Value).ToList();
                            }
                            if (filtro.HastaFecha.HasValue)
                            {
                                entListCompra = entListCompra.Where(w => w.det.fecha <= filtro.HastaFecha.Value).ToList();
                            }
                            entListCompra = entListCompra.Where(w => w.det.estatus_anulado== "0").ToList();
                            entListCompra = entListCompra.Where(w => w.det.tipo=="01" || w.det.tipo=="03").ToList();
                        }
                    }

                    var entListInv = ctx.productos_movimientos_detalle.Join(ctx.productos_movimientos, pmd => pmd.auto_documento, pm => pm.auto, (pmd, pm) => new { det=pmd, mov=pm }).
                        Where(w => w.det.auto_producto == autoPrd).ToList();
                    if (entListInv != null)
                    {
                        if (entListInv.Count > 0)
                        {
                            if (filtro.AutoDeposito!="")
                            {
                                entListInv = entListInv.Where(w => w.mov.auto_deposito==autoDeposito || 
                                    w.mov.auto_destino==autoDeposito).ToList();
                            }
                            if (filtro.DesdeFecha.HasValue)
                            {
                                entListInv = entListInv.Where(w => w.det.fecha >= filtro.DesdeFecha.Value).ToList();
                            }
                            if (filtro.HastaFecha.HasValue)
                            {
                                entListInv = entListInv.Where(w => w.det.fecha <= filtro.HastaFecha.Value).ToList();
                            }
                            entListInv = entListInv.Where(w => w.det.estatus_anulado == "0").ToList();
                        }
                    }

                    var existenciaAntesFecha = 0.0m;
                    var entListKardex = ctx.productos_kardex.Join(ctx.productos_conceptos, pk => pk.auto_concepto, pc => pc.auto, (k, c) => new { kardex=k, concepto=c }).
                        Where(w => w.kardex.auto_producto == autoPrd).ToList();
                    if (entListKardex != null)
                    {
                        if (entListKardex.Count > 0)
                        {
                            entListKardex = entListKardex.Where(w => w.kardex.estatus_anulado == "0").ToList();
                            if (filtro.AutoDeposito != "")
                            {
                                entListKardex = entListKardex.Where(w => w.kardex.auto_deposito == autoDeposito).ToList();
                            }
                            if (filtro.DesdeFecha.HasValue)
                            {
                                existenciaAntesFecha = entListKardex.Where(w => w.kardex.fecha < filtro.DesdeFecha.Value).Sum(s=>s.kardex.cantidad_und*s.kardex.signo);
                                entListKardex = entListKardex.Where(w => w.kardex.fecha >= filtro.DesdeFecha.Value).ToList();
                            }
                            if (filtro.HastaFecha.HasValue)
                            {
                                entListKardex = entListKardex.Where(w => w.kardex.fecha <= filtro.HastaFecha.Value).ToList();
                            }
                        }
                    }


                    var listDep = new List<DTO.Inventario.Movimiento.DepositoExistencia>();
                    foreach (var rg in entListDep) 
                    {
                        var nr = new DTO.Inventario.Movimiento.DepositoExistencia()
                        {
                            autoDeposito=rg.prdDep.auto_deposito,
                            DepositoCodigo=rg.dep.codigo,
                            DepositoDescripcion=rg.dep.nombre,
                            ExFisica=rg.prdDep.fisica,
                        };
                        listDep.Add(nr);
                    }

                    var listVenta = new List<DTO.Inventario.Movimiento.MovPorVenta>();
                    foreach (var rg in entListVenta)
                    {
                        var nr = new DTO.Inventario.Movimiento.MovPorVenta()
                        {
                            autoVenta=rg.venta.auto,
                            autoDeposito=rg.det.auto_deposito,
                            Cantidad=rg.det.cantidad_und,
                            CodigoSucursal=rg.venta.codigo_sucursal,
                            DocumentoNombre=rg.venta.documento_nombre,
                            DocumentoNro=rg.venta.documento,
                            DocumentoTipo=rg.venta.documento_tipo,
                            DocumentoCodigo=rg.venta.tipo,
                            CiRif=rg.venta.ci_rif,
                            Entidad=rg.venta.razon_social,
                            Fecha=rg.venta.fecha,
                            Hora=rg.venta.hora,
                            Signo=rg.det.signo,
                            CodigoDeposito=rg.det.codigo_deposito,
                            NombreDeposito=rg.det.deposito
                        };
                        listVenta.Add(nr);
                    }

                    var listCompra = new List<DTO.Inventario.Movimiento.MovPorCompra>();
                    foreach (var rg in entListCompra)
                    {
                        var nr = new DTO.Inventario.Movimiento.MovPorCompra()
                        {
                            autoCompra=rg.compra.auto,
                            autoDeposito=rg.det.auto_deposito,
                            Cantidad=rg.det.cantidad_und,
                            CodigoDeposito=rg.det.codigo_deposito,
                            CodigoSucursal=rg.compra.codigo_sucursal,
                            DocumentoNombre=rg.compra.documento_nombre,
                            DocumentoNro=rg.compra.documento,
                            DocumentoTipo=rg.compra.documento_tipo,
                            DocumentoCodigo=rg.compra.tipo,
                            Entidad=rg.compra.razon_social,
                            Fecha=rg.det.fecha,
                            Hora=rg.compra.hora,
                            NombreDeposito=rg.det.deposito,
                            Notas=rg.det.detalle,
                            Signo=rg.det.signo,
                        };
                        listCompra.Add(nr);
                    }

                    var listInventario = new List<DTO.Inventario.Movimiento.MovPorInventario>();
                    foreach (var rg in entListInv)
                    {
                        var nr = new DTO.Inventario.Movimiento.MovPorInventario()
                        {
                             autoConcepto=rg.mov.auto_concepto,
                             autoDepositoDestino=rg.mov.auto_destino,
                             autoDepositoOrigen=rg.mov.auto_deposito,
                             autoDocumento=rg.det.auto_documento,
                             Cantidad=rg.det.cantidad_und,
                             ConceptoCodigo=rg.mov.codigo_concepto,
                             ConceptoNombre=rg.mov.concepto,
                             DepositoDestinoCodigo=rg.mov.codigo_destino,
                             DepositoDestinoNombre=rg.mov.destino,
                             DepositoOrigenCodigo=rg.mov.codigo_deposito,
                             DepositoOrigenNombre=rg.mov.deposito,
                             DocumentoNombre=rg.mov.documento_nombre,
                             DocumentoNro=rg.mov.documento,
                             DocumentoTipo=rg.mov.tipo,
                             Fecha=rg.det.fecha,
                             Hora=rg.mov.hora,
                             Nota=rg.mov.nota,
                             Signo=rg.det.signo,
                        };
                        listInventario.Add(nr);
                    }

                    var listKardex = new List<DTO.Inventario.Movimiento.Kardex>();
                    foreach (var rg in entListKardex)
                    {
                        var nr = new DTO.Inventario.Movimiento.Kardex()
                        {
                            autoCocepto=rg.kardex.auto_concepto,
                            autoDeposito=rg.kardex.auto_deposito,
                            autoDocumento=rg.kardex.auto_documento,
                            ConceptoCodigo=rg.concepto.codigo,
                            ConceptoNombre=rg.concepto.nombre,
                            DepositoCodigo=rg.kardex.empresa_depositos.codigo,
                            DepositoNombre=rg.kardex.empresa_depositos.nombre,
                            DocumentoModulo=rg.kardex.modulo,
                            DocumentoNro=rg.kardex.documento,
                            DocumentoCodigo=rg.kardex.codigo,
                            DocumentoSiglas=rg.kardex.siglas,
                            Entidad=rg.kardex.entidad,
                            Fecha=rg.kardex.fecha,
                            Hora=rg.kardex.hora,
                            Cantidad=rg.kardex.cantidad_und,
                            Signo=rg.kardex.signo,
                        };
                        listKardex.Add(nr);
                    }

                    var ficha = new DTO.Inventario.Movimiento.Ficha()
                    {
                        autoProducto = entPrd.auto,
                        codigProducto = entPrd.codigo,
                        descripcionProducto = entPrd.nombre,
                        isPesado=entPrd.estatus_pesado.Trim().ToUpper()=="1"?true:false,
                    };
                    ficha.ExistenciaAntesFecha = existenciaAntesFecha;
                    ficha.Depositos = listDep;
                    ficha.MovVentas = listVenta;
                    ficha.MovCompra = listCompra;
                    ficha.MovInventario = listInventario;
                    ficha.Kardex = listKardex;

                    result.MyEntidad=ficha ;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Resultado.Enumerados.EnumResult.isError ;
            }

            return result;
        }

    }

}
