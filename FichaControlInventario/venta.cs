using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FichaControlInventario
{

    public class venta
    {

        public OOB.Inventario.Movimiento.MovPorVenta Ficha { get; set; }

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

        public string Tipo
        {
            get
            {
                return Ficha.DocumentoNombre.Trim();
            }
        }

        public string Entidad
        {
            get
            {
                return Ficha.Entidad;
            }
        }

        public string SucursalDeposito
        {
            get
            {
                return Ficha.CodigoSucursal.Trim()+"/"+Ficha.NombreDeposito.Trim() ;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return Ficha.Cantidad;
            }
        }

        public int Signo 
        {
            get
            {
                return Ficha.Signo;
            }
        }

        public decimal PorVenta
        {
            get 
            {
                var rt = 0.0m;
                if (Signo == 1)
                {
                    rt = Cantidad * Signo;
                }
                return rt;
            }
        }

        public decimal PorDevolucion
        {
            get
            {
                var rt = 0.0m;
                if (Signo == -1)
                {
                    rt = Cantidad * Signo;
                }
                return rt;
            }
        }

    }

}