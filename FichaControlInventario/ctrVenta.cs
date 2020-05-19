using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{

    class ctrVenta
    {

        private List<venta> _lista;
        private BindingSource _source;
        private BindingList<venta> _bl;


        public decimal PorVenta 
        {
            get 
            {
                return _lista.Sum(s => s.PorVenta);
            }
        }

        public decimal PorDevolucion
        {
            get
            {
                return _lista.Sum(s => s.PorDevolucion);
            }
        }

        public int TotalItems
        {
            get
            {
                return _lista.Count;
            }
        }


        public BindingSource Source
        {
            get
            {
                return _source;
            }
        }

        
        public ctrVenta() 
        {
            _lista = new List<venta>();
            _bl = new BindingList<venta>(_lista);
            _source = new BindingSource();
            _source.DataSource = _bl;
        }


        public void setData(List<OOB.Inventario.Movimiento.MovPorVenta> ven)
        {
            _bl.Clear();
            foreach (var rg in ven.OrderBy(o => o.autoVenta).ToList())
            {
                var item = new venta()
                {
                    Ficha = rg,
                };
                _bl.Add(item);
            }
        }

        public void Limpiar()
        {
            _bl.Clear();
        }

        public void filtrarPorSalidas()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoCodigo=="01");
                }
            }
        }

        public void filtrarPorDevoluciones ()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoCodigo=="03");
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