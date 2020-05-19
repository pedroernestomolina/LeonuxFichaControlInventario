using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FichaControlInventario
{

    public class deposito
    {

        public OOB.Inventario.Movimiento.DepositoExistencia Ficha { get; set; }


        public string Codigo { get { return Ficha.DepositoCodigo; } }
        public string Nombre { get { return Ficha.DepositoDescripcion; } }
        public decimal Existencia { get { return Ficha.ExFisica; } }

    }

}