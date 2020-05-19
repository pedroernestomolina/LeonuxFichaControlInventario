using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{

    class ctrCompra
    {
        
        private List<compra> _lista;
        private BindingSource _source;
        private BindingList<compra> _bl;


        public BindingSource Source
        {
            get
            {
                return _source;
            }
        }

        public decimal PorCompra
        {
            get
            {
                return _lista.Sum(s => s.PorCompra);
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

        
        public ctrCompra() 
        {
            _lista = new List<compra>();
            _bl = new BindingList<compra>(_lista);
            _source = new BindingSource();
            _source.DataSource = _bl;
        }


        public void setData(List<OOB.Inventario.Movimiento.MovPorCompra> ven)
        {
            _bl.Clear();
            foreach (var rg in ven.OrderBy(o => o.autoCompra).ToList())
            {
                var item = new compra()
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

        public void filtrarPorEntrada()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoCodigo == "01");
                }
            }
        }

        public void filtrarPorDevolucion()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoCodigo == "03");
                }
            }
        }

        public void filtrarPorMovimiento()
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