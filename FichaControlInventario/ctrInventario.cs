using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{

    class ctrInventario
    {

        private List<inventario> _lista;
        private BindingSource _source;
        private BindingList<inventario> _bl;
        private string _deposito;


        public BindingSource Source
        {
            get
            {
                return _source;
            }
        }

        public decimal Cargos
        {
            get
            {
                var rt = 0.0m;
                rt = _lista.Where(w => w.Ficha.DocumentoTipo.Trim() == "01").Sum(s => s.Cantidad);
                return Math.Abs(rt);
            }
        }

        public decimal DesCargos
        {
            get
            {
                var rt = 0.0m;
                rt = _lista.Where(w => w.Ficha.DocumentoTipo.Trim() == "02").Sum(s => s.Cantidad);
                return Math.Abs(rt);
            }
        }

        public decimal TrEntradas
        {
            get
            {
                var rt = 0.0m;
                rt = _lista.Where(w => w.Ficha.DocumentoTipo.Trim() == "03" && w.Ficha.autoDepositoDestino==_deposito).Sum(s => s.Cantidad);
                return Math.Abs(rt);
            }
        }

        public decimal TrSalidas
        {
            get
            {
                var rt = 0.0m;
                rt = _lista.Where(w => w.Ficha.DocumentoTipo.Trim() == "03" && w.Ficha.autoDepositoOrigen == _deposito).Sum(s => s.Cantidad);
                return Math.Abs(rt);
            }
        }

        public decimal Ajustes
        {
            get
            {
                var rt = 0.0m;
                rt = _lista.Where(w => w.Ficha.DocumentoTipo.Trim() == "04").Sum(s => s.Cantidad);
                return rt;
            }
        }

        public int Movimientos
        {
            get
            {
                return _lista.Count;
            }
        }

        
        public ctrInventario() 
        {
            _lista = new List<inventario>();
            _bl = new BindingList<inventario>(_lista);
            _source = new BindingSource();
            _source.DataSource = _bl;
        }


        public void setData(List<OOB.Inventario.Movimiento.MovPorInventario> inv)
        {
            _bl.Clear();
            foreach (var rg in inv.OrderBy(o => o.autoDocumento).ToList())
            {
                var item = new inventario()
                {
                    Ficha = rg,
                };
                _bl.Add(item);
            }
        }

        public void setDeposito(string dep)
        {
            _deposito = dep;
        }

        public void Limpiar() 
        {
            _bl.Clear();
        }

        public void filtrarPorCargo()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoTipo.Trim() == "01");
                }
            }
        }

        public void filtrarPorDescargo()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoTipo.Trim() == "02");
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

        public void filtrarPorAjuste()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoTipo.Trim() == "04");
                }
            }
        }

        public void filtrarPorTrPorEntrada()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoTipo.Trim() == "03" && f.Ficha.autoDepositoDestino == _deposito);
                }
            }
        }

        public void filtrarPorTrPorSalida()
        {
            if (_bl != null)
            {
                if (_bl.Count > 0)
                {
                    _source.DataSource = _bl.Where(f => f.Ficha.DocumentoTipo.Trim() == "03" && f.Ficha.autoDepositoOrigen == _deposito);
                }
            }
        }

    }

}