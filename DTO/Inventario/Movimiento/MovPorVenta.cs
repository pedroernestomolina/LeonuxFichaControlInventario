using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Inventario.Movimiento
{
    
    public class MovPorVenta
    {

        public string autoVenta { get; set; }
        public string autoDeposito { get; set; }
        public string DocumentoNro { get; set; }
        public string DocumentoNombre { get; set; }
        public string DocumentoTipo { get; set; }
        public string DocumentoCodigo{ get; set; }
        public string CodigoSucursal { get; set; }
        public string Entidad { get; set; }
        public string CiRif { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Cantidad { get; set; }
        public int Signo { get; set; }
        public string CodigoDeposito { get; set; }
        public string NombreDeposito { get; set; }

    }

}