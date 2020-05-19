using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{

    class ctrDeposito
    {

        private List<deposito> _lista;
        private BindingSource _source;
        private BindingList<deposito> _bl;


        public BindingSource Source
        {
            get
            {
                return _source;
            }
        }


        public ctrDeposito() 
        {
            _lista = new List<deposito>();
            _bl = new BindingList<deposito>(_lista);
            _source = new BindingSource();
            _source.DataSource = _bl;
        }


        public void setData(List<OOB.Inventario.Movimiento.DepositoExistencia> dep)
        {
            _bl.Clear();
            foreach (var rg in dep.OrderBy(o => o.DepositoCodigo).ToList())
            {
                var item = new deposito()
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

    }

}