using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Inventario.Movimiento
{
    
    public class Kardex
    {

        public string autoDeposito { get; set; }
        public string autoCocepto { get; set; }
        public string autoDocumento { get; set; }

        public string DepositoCodigo { get; set; }
        public string DepositoNombre { get; set; }
        public string ConceptoCodigo { get; set; }
        public string ConceptoNombre { get; set; }

        public string DocumentoNro { get; set; }
        public string DocumentoModulo { get; set; }
        public string DocumentoCodigo { get; set; }
        public string DocumentoSiglas { get; set; }

        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Entidad { get; set; }

        public decimal Cantidad { get; set; }
        public int Signo { get; set; }

    }

}
