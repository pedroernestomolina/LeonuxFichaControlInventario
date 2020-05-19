using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario.Producto.Buscar
{

    public partial class BuscarFrm : Form
    {

        public event EventHandler<productoSelected> ProductoOK;


        private BindingSource bs;
        private BindingList<OOB.Inventario.Producto.Ficha> bProducto;
        private OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda _preferenciaBusqueda;


        public BuscarFrm()
        {
            InitializeComponent();

            bProducto = new BindingList<OOB.Inventario.Producto.Ficha>();
            bs = new BindingSource();
            bs.DataSource = bProducto;
            RB_NOMBRE.Checked = true;
            _preferenciaBusqueda = OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Nombre;

            InicializarDGV();
            IrFocoPrincipal();
        }

        private void IrFocoPrincipal()
        {
            TB_CADENA.Focus();
        }

        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombrePrd";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.Name = "IsActivo";
            c4.DataPropertyName = "IsActivo";
            c4.Visible = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            var filtro = new OOB.Inventario.Producto.Filtro();
            filtro.cadena = TB_CADENA.Text.Trim();
            filtro.preferenciaBusqueda = _preferenciaBusqueda;
            var r01 = Program.MyData.ProductoLista(filtro);
            if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            };

            bProducto.Clear();
            List<OOB.Inventario.Producto.Ficha> lista = null;
            switch (_preferenciaBusqueda)
            {
                case OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Nombre:
                    lista = r01.MyLista.OrderBy(o => o.NombrePrd).ToList();
                    break;
                case OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Codigo:
                    lista = r01.MyLista.OrderBy(o => o.CodigoPrd).ToList();
                    break;
                case OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Referencia:
                    lista = r01.MyLista.OrderBy(o => o.Referencia).ToList();
                    break;
            }

            bProducto.RaiseListChangedEvents = false;
            foreach (var dt in lista)
            {
                bProducto.Add(dt);
            }
            bProducto.RaiseListChangedEvents = true;
            bProducto.ResetBindings();

            TB_CADENA.Text = "";
            DGV.Focus();
        }

        private void BuscarFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bs;
            LimpiarData();
        }

        private void LimpiarData()
        {
            bProducto.Clear();
            TB_CADENA.Text = "";
            TB_CADENA.Focus();
            IrFocoPrincipal();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }

        private void RB_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_CODIGO.Checked)
                _preferenciaBusqueda = OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Codigo;
            IrFocoPrincipal();
        }

        private void RB_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_NOMBRE.Checked)
                _preferenciaBusqueda = OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Nombre;
            IrFocoPrincipal();
        }

        private void RB_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_REFERENCIA.Checked)
                _preferenciaBusqueda = OOB.Inventario.Producto.Enumerados.enumPreferenciaBusqueda.Referencia;
            IrFocoPrincipal();
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = !(bool)row.Cells["IsActivo"].Value ? Color.Red : Color.Black;
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                EventHandler<productoSelected> handler = ProductoOK;
                if (handler != null)
                {
                    var item = (OOB.Inventario.Producto.Ficha)bs.Current;
                    var ficha = new productoSelected()
                    {
                        autoProducto = item.Auto,
                        nombreProducto=item.NombrePrd,
                        isActivo = item.IsActivo,
                    };
                    handler(this, ficha);
                }
            }
        }
     
    }

}