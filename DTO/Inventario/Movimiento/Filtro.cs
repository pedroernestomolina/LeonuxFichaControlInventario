using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Inventario.Movimiento
{
    
    public class Filtro
    {

        public string AutoProducto { get; set; }
        public string AutoDeposito { get; set; }
        public DateTime? DesdeFecha { get; set; }
        public DateTime? HastaFecha { get; set; }

    }

}
