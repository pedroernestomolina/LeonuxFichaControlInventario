using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{
    
    class ctrKardex
    {

        private List<kardex> _lista;
        private BindingSource _source;
        private BindingList<kardex> _bl;
        private decimal _existenciaInicial;
        private decimal _existenciaFinal;


        public decimal Entradas 
        {
            get 
            {
                var rt = 0.0m;
                rt = _lista.Sum(s => s.Entrada);
                return rt;
            }
        }

        public decimal Salidas
        {
            get
            {
                var rt = 0.0m;
                rt = _lista.Sum(s => s.Salida);
                return rt;
            }
        }

        public decimal ExistenciaInicial
        {
            get
            {
                var rt = 0.0m;
                rt = _existenciaInicial;
                return rt;
            }
        }

        public decimal ExistenciaFinal
        {
            get
            {
                var rt = 0.0m;
                rt = _existenciaFinal;
                return rt;
            }
        }

        public int TotalItems
        {
            get
            {
                var rt = 0;
                rt = _lista.Count;
                return rt;
            }
        }


        public BindingSource Source 
        {
            get 
            {
                return _source;
            }
        }


        public ctrKardex() 
        {
            _lista = new List<kardex>();
            _bl = new BindingList<kardex>(_lista);
            _source = new BindingSource();
            _source.DataSource = _bl;
        }


        public void setData(List<OOB.Inventario.Movimiento.Kardex> mov, decimal exAntes) 
        {
            _existenciaInicial = exAntes; 
            _bl.Clear();
            var saldo = exAntes;
            foreach (var rg in mov.OrderBy(o=>o.Fecha).ToList()) 
            {
                var e=0.0m;
                var s=0.0m;
                if ((rg.Cantidad * rg.Signo) > 0)
                {
                    e=rg.Cantidad;
                    saldo += e;
                }
                else 
                {
                    s = rg.Cantidad;
                    saldo -= s;
                }

                var item = new kardex() 
                {
                    Ficha=rg,
                    Entrada=e,
                    Salida=s,
                    Saldo=saldo,
                };
                _bl.Add(item);
            }
            _existenciaFinal = saldo;
        }

        public void Limpiar()
        {
            _bl.Clear();
        }

        public void filtrarPorEntradas() 
        {
            if (_bl != null) 
            {
                if (_bl.Count > 0) 
                {
                    _source.DataSource = _bl.Where(f => f.Entrada > 0);
                }
            }
        }

        public void filtrarPorSalidas()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Salida > 0);
                }
            }
        }

        public void filtrarPorMovimientos()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl;
                }
            }
        }

    }

}