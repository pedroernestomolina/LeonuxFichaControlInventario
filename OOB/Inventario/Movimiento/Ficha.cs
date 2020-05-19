using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Inventario.Movimiento
{

    public class Ficha
    {

        public string autoProducto { get; set; }
        public string codigProducto { get; set; }
        public string descripcionProducto { get; set; }
        public bool isPesado { get; set; }

        public decimal ExistenciaAntesFecha { get; set; }
        public List<DepositoExistencia> Depositos { get; set; }
        public List<MovPorVenta> MovVentas { get; set; }
        public List<MovPorCompra> MovCompra { get; set; }
        public List<MovPorInventario> MovInventario { get; set; }
        public List<Kardex> Kardex { get; set; }

        public string Producto 
        {
            get 
            {
                var rt = "";
                rt += codigProducto.Trim() + Environment.NewLine + descripcionProducto.Trim();
                return rt;
            }
        }

        public decimal Existencia 
        {
            get 
            {
                var rt = 0.0m;
                rt = Depositos.Sum(s => s.ExFisica);
                return rt;
            }
        }

    }

}