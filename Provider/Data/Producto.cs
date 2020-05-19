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

        public DTO.Resultado.Lista<DTO.Inventario.Producto.Resumen> ProductoLista(DTO.Inventario.Producto.Filtro filtro)
        {
            var result = new DTO.Resultado.Lista<DTO.Inventario.Producto.Resumen>();

            try
            {
                using (var cnn = new leonuxEntities(_cn.ConnectionString))
                {
                    var q = cnn.productos.ToList();
                    if (filtro.cadena != "")
                    {
                        if (filtro.preferenciaBusqueda ==  DTO.Inventario.Producto.Eumerados.enumPreferenciaBusqueda.Codigo)
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                q = q.Where(w => w.codigo.Contains(cad)).ToList();
                            }
                            else
                            {
                                q = q.Where(w =>
                                {
                                    var r = w.codigo.Trim().ToUpper();
                                    if (r.Length >= cad.Length && r.Substring(0, cad.Length) == cad)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }).ToList();
                            }
                        }
                        if (filtro.preferenciaBusqueda == DTO.Inventario.Producto.Eumerados.enumPreferenciaBusqueda.Nombre )
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                q = q.Where(w => w.nombre.Contains(cad)).ToList();
                            }
                            else
                            {
                                q = q.Where(w =>
                                {
                                    var r = w.nombre.Trim().ToUpper();
                                    if (r.Length >= cad.Length && r.Substring(0, cad.Length) == cad)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }).ToList();
                            }
                        }
                        if (filtro.preferenciaBusqueda == DTO.Inventario.Producto.Eumerados.enumPreferenciaBusqueda.Referencia )
                        {
                            var cad = filtro.cadena.Trim().ToUpper();
                            if (cad.Substring(0, 1) == "*")
                            {
                                cad = cad.Substring(1);
                                q = q.Where(w => w.referencia.Contains(cad)).ToList();
                            }
                            else
                            {
                                q = q.Where(w =>
                                {
                                    var r = w.referencia.Trim().ToUpper();
                                    if (r.Length >= cad.Length && r.Substring(0, cad.Length) == cad)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }).ToList();
                            }
                        }
                    }

                    var list = new List<DTO.Inventario.Producto.Resumen>();
                    if (q != null)
                    {
                        if (q.Count() > 0)
                        {
                            result.MyLista = q.Select(s =>
                            {
                                var isActivo = s.estatus.Trim().ToUpper() == "ACTIVO" ? true : false;
                                var r = new DTO.Inventario.Producto.Resumen()
                                {
                                    Auto = s.auto,
                                    CodigoPrd = s.codigo,
                                    NombrePrd = s.nombre,
                                    DescripcionPrd = s.nombre,
                                    ReferenciaPrd = s.referencia,
                                    IsActivo = isActivo,
                                };
                                return r;
                            }).ToList();
                        }
                        else
                        {
                            result.MyLista = list;
                        }
                    }
                    else
                    {
                        result.MyLista = list;
                    }
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