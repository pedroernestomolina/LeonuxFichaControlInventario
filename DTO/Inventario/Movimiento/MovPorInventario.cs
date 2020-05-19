using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Inventario.Movimiento
{
    
    public class MovPorInventario
    {

        public string autoDocumento { get; set; }
        public string autoConcepto { get; set; }
        public string autoDepositoOrigen { get; set; }
        public string autoDepositoDestino { get; set; }
        public string DocumentoNro { get; set; }
        public string DocumentoTipo { get; set; }
        public string DocumentoNombre { get; set; }
        public string ConceptoCodigo { get; set; }
        public string ConceptoNombre { get; set; }
        public string DepositoOrigenCodigo { get; set; }
        public string DepositoOrigenNombre { get; set; }
        public string DepositoDestinoCodigo { get; set; }
        public string DepositoDestinoNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Cantidad { get; set; }
        public int Signo { get; set; }
        public string Nota { get; set; }

    }

}