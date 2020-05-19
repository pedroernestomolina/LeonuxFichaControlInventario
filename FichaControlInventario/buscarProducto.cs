using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaControlInventario
{

    class buscarProducto
    {

        public bool IsOk { get; set; }
        public string AutoProducto { get; set; }
        public string NombreProducto { get; set; }


        public buscarProducto() 
        {
            Limpiar();
        }


        Producto.Buscar.BuscarFrm _frm;
        public void Buscar() 
        {
            Limpiar();

            _frm = new Producto.Buscar.BuscarFrm();
            _frm.ProductoOK+=_frm_ProductoOK;
            _frm.ShowDialog();
        }

        private void Limpiar()
        {
            IsOk = false;
            AutoProducto = "";
            NombreProducto = "";
        }

        private void _frm_ProductoOK(object sender, Producto.Buscar.productoSelected e)
        {
            if (!e.isActivo) 
            {
                Helpers.Msg.Alerta("PRODUCTO EN ESTADO INACTIVO, VERIFIQUE POR FAVOR");
                return;
            }

            IsOk = true;
            AutoProducto = e.autoProducto;
            NombreProducto = e.nombreProducto;
            _frm.Close();
        }

    }

}