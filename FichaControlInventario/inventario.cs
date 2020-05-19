using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FichaControlInventario
{
    
    public class inventario
    {

        public OOB.Inventario.Movimiento.MovPorInventario Ficha { get; set; }


        public string FechaHora
        {
            get
            {
                var rt = Ficha.Fecha.ToShortDateString() + ", ";
                rt += Ficha.Hora;
                return rt;
            }
        }

        public string Documento
        {
            get
            {
                return Ficha.DocumentoNro;
            }
        }

        public string TipoConcepto
        {
            get
            {
                return Ficha.DocumentoNombre.Trim()+"/ "+Ficha.ConceptoNombre.Trim();
            }
        }

        public string Origen
        {
            get
            {
                return Ficha.DepositoOrigenNombre.Trim();
            }
        }

        public string Destino
        {
            get
            {
                return Ficha.DepositoDestinoNombre.Trim();
            }
        }

        public decimal Cantidad
        {
            get
            {
                return Math.Abs(Ficha.Cantidad*Ficha.Signo);
            }
        }

    }

}