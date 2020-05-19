using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Inventario.Movimiento
{

    public class DepositoExistencia
    {

        public string autoDeposito { get; set; }
        public string DepositoCodigo { get; set; }
        public string DepositoDescripcion { get; set; }
        public decimal ExFisica  { get; set; }

    }

}
