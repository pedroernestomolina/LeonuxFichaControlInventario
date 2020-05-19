using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FichaControlInventario
{

    public class kardex
    {

        public OOB.Inventario.Movimiento.Kardex Ficha { get; set; }
        public decimal Entrada { get; set; }
        public decimal Salida { get; set; }
        public decimal Saldo { get; set; }

        
        public int Signo 
        {
            get 
            {
                return Ficha.Signo;
            }
        }

        public string Deposito 
        {
            get 
            {
                return Ficha.DepositoNombre.Trim();
            }
        }

        public string FechaHora
        {
            get
            {
                var rt = Ficha.Fecha.ToShortDateString()+", "; 
                rt+=Ficha.Hora;
                return rt;
            }
        }

        public string OrigenTipo 
        {
            get 
            {
                return Ficha.DocumentoModulo.Trim() + "/" + Ficha.DocumentoSiglas;
            }
        }

        public string Documento
        {
            get
            {
                return Ficha.DocumentoNro.Trim() ;
            }
        }

        public string Entidad
        {
            get
            {
                return Ficha.Entidad.Trim();
            }
        }

    }

}
