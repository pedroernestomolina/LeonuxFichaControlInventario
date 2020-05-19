using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FichaControlInventario
{

    public partial class Form1 : Form
    {

        private ctrKardex _kardex;
        private ctrDeposito _deposito;
        private ctrVenta _venta;
        private ctrCompra _compra;
        private ctrInventario _inventario;
        private buscarProducto _buscadorPrd;
        private List<OOB.Inventario.Deposito.Ficha> _depositos;
        private string _formato;
        private string _autoProducto;


        public Form1()
        {
            InitializeComponent();
            _kardex = new ctrKardex();
            _deposito = new ctrDeposito();
            _venta = new ctrVenta();
            _compra= new ctrCompra();
            _inventario=new ctrInventario();
            _buscadorPrd = new buscarProducto();
            _formato = "n0";

            InicializarDGV_Kardex();
            InicializarDGV_Depositos();
            InicializarDGV_Ventas();
            InicializarDGV_Compras();
            InicializarDGV_Inventario();
        }

        public bool CargarData() 
        {
            var result=true;

            var r01 = Program.MyData.DepoistoLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                MessageBox.Show(r01.Mensaje, "*** ERROR ***", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            _depositos = r01.MyLista.OrderBy(o => o.Codigo).ToList();
            return result;
        }

        private void InicializarDGV_Inventario()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_INVENTARIO.AllowUserToAddRows = false;
            DGV_INVENTARIO.AllowUserToDeleteRows = false;
            DGV_INVENTARIO.AutoGenerateColumns = false;
            DGV_INVENTARIO.AllowUserToResizeRows = false;
            DGV_INVENTARIO.AllowUserToResizeColumns = false;
            DGV_INVENTARIO.AllowUserToOrderColumns = false;
            DGV_INVENTARIO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_INVENTARIO.MultiSelect = false;
            DGV_INVENTARIO.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Documento";
            c3.HeaderText = "Documento";
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "TipoConcepto";
            c2.HeaderText = "Tipo/Concepto";
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Origen";
            c4.HeaderText = "Origen";
            c4.MinimumWidth = 120;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Destino";
            c5.HeaderText = "Destino";
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Cantidad";
            c6.Name = "Cantidad";
            c6.HeaderText = "Cant";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 80;
            c6.DefaultCellStyle.Format = _formato;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV_INVENTARIO.Columns.Add(c1);
            DGV_INVENTARIO.Columns.Add(c3);
            DGV_INVENTARIO.Columns.Add(c2);
            DGV_INVENTARIO.Columns.Add(c4);
            DGV_INVENTARIO.Columns.Add(c5);
            DGV_INVENTARIO.Columns.Add(c6);
        }

        private void InicializarDGV_Compras()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_COMPRA.AllowUserToAddRows = false;
            DGV_COMPRA.AllowUserToDeleteRows = false;
            DGV_COMPRA.AutoGenerateColumns = false;
            DGV_COMPRA.AllowUserToResizeRows = false;
            DGV_COMPRA.AllowUserToResizeColumns = false;
            DGV_COMPRA.AllowUserToOrderColumns = false;
            DGV_COMPRA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_COMPRA.MultiSelect = false;
            DGV_COMPRA.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Documento";
            c3.HeaderText = "Documento";
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Tipo";
            c2.HeaderText = "Tipo";
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Entidad";
            c4.HeaderText = "Entidad";
            c4.MinimumWidth = 120;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "SucursalDeposito";
            c5.HeaderText = "Suc/Deposito";
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Cantidad";
            c6.Name = "Cantidad";
            c6.HeaderText = "Cant";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 80;
            c6.DefaultCellStyle.Format = _formato;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Signo";
            c7.Name = "Signo";
            c7.Visible = false;
            c7.HeaderText = "";
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.Width = 10;

            DGV_COMPRA.Columns.Add(c1);
            DGV_COMPRA.Columns.Add(c3);
            DGV_COMPRA.Columns.Add(c2);
            DGV_COMPRA.Columns.Add(c4);
            DGV_COMPRA.Columns.Add(c5);
            DGV_COMPRA.Columns.Add(c6);
            DGV_COMPRA.Columns.Add(c7);
        }

        private void InicializarDGV_Ventas()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_VENTA.AllowUserToAddRows = false;
            DGV_VENTA.AllowUserToDeleteRows = false;
            DGV_VENTA.AutoGenerateColumns = false;
            DGV_VENTA.AllowUserToResizeRows = false;
            DGV_VENTA.AllowUserToResizeColumns = false;
            DGV_VENTA.AllowUserToOrderColumns = false;
            DGV_VENTA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_VENTA.MultiSelect = false;
            DGV_VENTA.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Documento";
            c3.HeaderText = "Documento";
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Tipo";
            c2.HeaderText = "Tipo";
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
     
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Entidad";
            c4.HeaderText = "Entidad";
            c4.MinimumWidth = 120;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "SucursalDeposito";
            c5.HeaderText = "Suc/Deposito";
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Cantidad";
            c6.Name = "Cantidad";
            c6.HeaderText = "Cant";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 80;
            c6.DefaultCellStyle.Format = _formato;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Signo";
            c7.Name = "Signo";
            c7.Visible = false;
            c7.HeaderText = "";
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.Width = 10;


            DGV_VENTA.Columns.Add(c1);
            DGV_VENTA.Columns.Add(c3);
            DGV_VENTA.Columns.Add(c2);
            DGV_VENTA.Columns.Add(c4);
            DGV_VENTA.Columns.Add(c5);
            DGV_VENTA.Columns.Add(c6);
            DGV_VENTA.Columns.Add(c7);
        }

        private void InicializarDGV_Depositos()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_DEPOSITO.AllowUserToAddRows = false;
            DGV_DEPOSITO.AllowUserToDeleteRows = false;
            DGV_DEPOSITO.AutoGenerateColumns = false;
            DGV_DEPOSITO.AllowUserToResizeRows = false;
            DGV_DEPOSITO.AllowUserToResizeColumns = false;
            DGV_DEPOSITO.AllowUserToOrderColumns = false;
            DGV_DEPOSITO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DEPOSITO.MultiSelect = false;
            DGV_DEPOSITO.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Nombre";
            c2.HeaderText = "Nombre";
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Existencia";
            c3.Name= "Existencia";
            c3.HeaderText = "Existencia";
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Format = _formato;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGV_DEPOSITO.Columns.Add(c1);
            DGV_DEPOSITO.Columns.Add(c2);
            DGV_DEPOSITO.Columns.Add(c3);
        }

        private void InicializarDGV_Kardex()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_KARDEX.AllowUserToAddRows = false;
            DGV_KARDEX.AllowUserToDeleteRows = false;
            DGV_KARDEX.AutoGenerateColumns = false;
            DGV_KARDEX.AllowUserToResizeRows = false;
            DGV_KARDEX.AllowUserToResizeColumns = false;
            DGV_KARDEX.AllowUserToOrderColumns = false;
            DGV_KARDEX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_KARDEX.MultiSelect = false;
            DGV_KARDEX.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "OrigenTipo";
            c2.HeaderText = "Origen/Tipo";
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Documento";
            c3.HeaderText = "Documento";
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Entidad";
            c4.HeaderText = "Entidad";
            c4.MinimumWidth = 120;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Deposito";
            c5.HeaderText = "Deposito";
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;

            var c6 = new DataGridViewTextBoxColumn();  
            c6.DataPropertyName = "Cantidad";
            c6.HeaderText = "Cant";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 80;
            c6.DefaultCellStyle.Format = _formato;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();  
            c7.DataPropertyName = "Entrada";
            c7.Name = "Entrada";
            c7.HeaderText = "Entrada";
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.Width = 80;
            c7.DefaultCellStyle.Format = _formato;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c8 = new DataGridViewTextBoxColumn();  
            c8.DataPropertyName = "Salida";
            c8.Name = "Salida";
            c8.HeaderText = "Salida";
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.Width = 80;
            c8.DefaultCellStyle.Format = _formato;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c9 = new DataGridViewTextBoxColumn();  
            c9.DataPropertyName = "Saldo";
            c9.Name = "Saldo";
            c9.HeaderText = "Saldo";
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.Width = 80;
            c9.DefaultCellStyle.Format = _formato;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c10 = new DataGridViewTextBoxColumn();
            c10.DataPropertyName = "Signo";
            c10.Name = "Signo";
            c10.Visible = false;
            c10.HeaderText = "Signo";
            c10.HeaderCell.Style.Font = f;
            c10.DefaultCellStyle.Font = f1;
            c10.Width = 10;


            DGV_KARDEX.Columns.Add(c1);
            DGV_KARDEX.Columns.Add(c2);
            DGV_KARDEX.Columns.Add(c3);
            DGV_KARDEX.Columns.Add(c4);
            DGV_KARDEX.Columns.Add(c5);
            DGV_KARDEX.Columns.Add(c7);
            DGV_KARDEX.Columns.Add(c8);
            DGV_KARDEX.Columns.Add(c9);
            DGV_KARDEX.Columns.Add(c10);
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            var dep=CB_DEPOSITO.SelectedValue.ToString();
            if (_autoProducto == "") { return; }

            var filtro = new OOB.Inventario.Movimiento.Filtro()
            {
                AutoDeposito = dep, 
                AutoProducto = _autoProducto,
                DesdeFecha = DTP_DESDE.Value.Date ,
                HastaFecha = DTP_HASTA.Value.Date,
            };
            var r01= Program.MyData.MovimientoFicha(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Limpieza();
            if (r01.MyEntidad.isPesado) 
            {
                _formato = "n3";
            }

            _kardex.setData(r01.MyEntidad.Kardex, r01.MyEntidad.ExistenciaAntesFecha);
            _deposito.setData(r01.MyEntidad.Depositos);
            _venta.setData(r01.MyEntidad.MovVentas);
            _compra.setData(r01.MyEntidad.MovCompra);
            _inventario.setData(r01.MyEntidad.MovInventario);
            _inventario.setDeposito(dep);

            L_PRODUCTO.Text = r01.MyEntidad.Producto;
            L_PRODUCTO_EXISTENCIA.Text = "EXISTENCIA TOTAL: "+r01.MyEntidad.Existencia.ToString(_formato);

            L_COMPRA_ENT.Text = _compra.PorCompra.ToString(_formato);
            L_COMPRA_DEV.Text = _compra.PorDevolucion.ToString(_formato);
            L_COMPRA_MOV.Text = _compra.TotalItems.ToString("n0");

            L_VENTA_CANT_ITEM.Text = _venta.TotalItems.ToString("n0");
            L_VENTA_CANT_POR_VENTA.Text = _venta.PorVenta.ToString(_formato);
            L_VENTA_CANT_POR_DEV.Text = _venta.PorDevolucion.ToString(_formato);

            L_KARDEX_EX_INICIAL.Text = "Inicia Con: "+_kardex.ExistenciaInicial.ToString(_formato);
            L_KARDEX_MOV.Text = _kardex.TotalItems.ToString("n0");;
            L_KARDEX_MOV_ENTRADA.Text = _kardex.Entradas.ToString(_formato);
            L_KARDEX_MOV_SALIDA.Text = _kardex.Salidas.ToString(_formato);
            L_KARDEX_EX_FINAL.Text = _kardex.ExistenciaFinal.ToString(_formato);

            L_INV_CARGO.Text = _inventario.Cargos.ToString(_formato);
            L_INV_DESCARGO.Text = _inventario.DesCargos.ToString(_formato);
            L_INV_TR_ENTRADA.Text = _inventario.TrEntradas.ToString(_formato);
            L_INV_TR_SALIDA.Text = _inventario.TrSalidas.ToString(_formato);
            L_INV_AJUSTE.Text = _inventario.Ajustes.ToString(_formato);
            L_INV_MOV.Text = _inventario.Movimientos.ToString("n0");
        }

        private void Limpieza()
        {
            Limpiar();
            ItemsLimpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DGV_KARDEX.DataSource = _kardex.Source;
            DGV_KARDEX.Refresh();

            DGV_DEPOSITO.DataSource = _deposito.Source;
            DGV_DEPOSITO.Refresh();

            DGV_VENTA.DataSource = _venta.Source;
            DGV_VENTA.Refresh();

            DGV_COMPRA.DataSource = _compra.Source;
            DGV_COMPRA.Refresh();

            DGV_INVENTARIO.DataSource = _inventario.Source;
            DGV_INVENTARIO.Refresh();

            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_DEPOSITO.DataSource = _depositos;

            Limpiar();

            L_VERSION.Text= "Ver. " + Application.ProductVersion;
        }

        private void DGV_DEPOSITO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_DEPOSITO.Rows)
            {
                var ccnt = row.Cells["Existencia"];
                ccnt.Style.Format = _formato;
            }
        }

        private void DGV_INVENTARIO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_INVENTARIO.Rows)
            {
                var ccnt = row.Cells["Cantidad"];
                ccnt.Style.Format = _formato;
            }
        }

        private void DGV_VENTA_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_VENTA.Rows)
            {
                try
                {
                    row.DefaultCellStyle.ForeColor = (int)row.Cells["Signo"].Value == -1 ? Color.Red : Color.Black;
                }
                catch (Exception)
                {
                }

                var ccnt = row.Cells["Cantidad"];
                ccnt.Style.Format = _formato;
            }
        }

        private void DGV_KARDEX_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_KARDEX.Rows)
            {
                row.DefaultCellStyle.ForeColor = (int)row.Cells["Signo"].Value == 1 ? Color.Blue : Color.Black;
                var cent=row.Cells["Entrada"];
                cent.Style.Format = _formato;
                var csalida= row.Cells["Salida"];
                csalida.Style.Format = _formato;
                var csaldo= row.Cells["Saldo"];
                csaldo.Style.Format = _formato;
            }
        }

        private void DGV_COMPRA_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_COMPRA.Rows)
            {
                try
                {
                    row.DefaultCellStyle.ForeColor = (int)row.Cells["Signo"].Value == -1 ? Color.Red : Color.Black;
                }
                catch (Exception)
                {
                }
                var ccnt = row.Cells["Cantidad"];
                ccnt.Style.Format = _formato;
            }
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpieza();
        }

        private void ItemsLimpiar()
        {
            _inventario.Limpiar();
            _compra.Limpiar();
            _venta.Limpiar();
            _deposito.Limpiar();
            _kardex.Limpiar();
        }

        private void Limpiar()
        {
            _formato = "n0";
            _autoProducto = "";
            TB_PRODUCTO.Text = "";

            L_PRODUCTO.Text = "";
            L_PRODUCTO_EXISTENCIA.Text = "EXISTENCIA TOTAL: 0.0";

            L_COMPRA_ENT.Text = "0.0";
            L_COMPRA_DEV.Text = "0.0";
            L_COMPRA_MOV.Text = "0";

            L_VENTA_CANT_ITEM.Text = "0";
            L_VENTA_CANT_POR_VENTA.Text = "0.0";
            L_VENTA_CANT_POR_DEV.Text = "0.0";

            L_KARDEX_EX_INICIAL.Text = "Inicia Con: 0.0";
            L_KARDEX_MOV.Text = "0";
            L_KARDEX_MOV_ENTRADA.Text = "0.0";
            L_KARDEX_MOV_SALIDA.Text = "0.0";
            L_KARDEX_EX_FINAL.Text = "0.0";

            L_INV_CARGO.Text = "0.0";
            L_INV_DESCARGO.Text = "0.0";
            L_INV_TR_ENTRADA.Text = "0.0";
            L_INV_TR_SALIDA.Text = "0.0";
            L_INV_AJUSTE.Text = "0.0";
            L_INV_MOV.Text = "0";

            DTP_DESDE.Value = DateTime.Now.Date;
            DTP_HASTA.Value = DateTime.Now.Date;
            CB_DEPOSITO.SelectedIndex = 0;
        }

        private void BT_BUSCAR_PRD_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            _buscadorPrd.Buscar();
            if (_buscadorPrd.IsOk) 
            {
                Limpieza();
                _autoProducto = _buscadorPrd.AutoProducto;
                TB_PRODUCTO.Text = _buscadorPrd.NombreProducto;
            };
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void L_KARDEX_ENTRADA_FILTRO_Click(object sender, EventArgs e)
        {
            _kardex.filtrarPorEntradas();
            DGV_KARDEX.DataSource = _kardex.Source;
        }

        private void L_KARDEX_SALIDA_FILTRO_Click(object sender, EventArgs e)
        {
            _kardex.filtrarPorSalidas();
            DGV_KARDEX.DataSource = _kardex.Source;
        }

        private void L_KARDEX_MOVIMIENTO_FILTRO_Click(object sender, EventArgs e)
        {
            _kardex.filtrarPorMovimientos();
            DGV_KARDEX.DataSource = _kardex.Source;
        }

        private void L_VENTA_SALIDA_FILTRO_Click(object sender, EventArgs e)
        {
            _venta.filtrarPorSalidas();
            DGV_VENTA.DataSource = _venta.Source;
        }

        private void L_VENTA_DEVO_FILTRO_Click(object sender, EventArgs e)
        {
            _venta.filtrarPorDevoluciones();
            DGV_VENTA.DataSource = _venta.Source;
        }

        private void L_VENTA_MOV_FILTRO_Click(object sender, EventArgs e)
        {
            _venta.filtrarPorMovimientos();
            DGV_VENTA.DataSource = _venta.Source;
        }

        private void L_COMPRA_ENTRADA_FILTRO_Click(object sender, EventArgs e)
        {
            _compra.filtrarPorEntrada();
            DGV_COMPRA.DataSource = _compra.Source;
        }

        private void L_COMPRA_DEV_FILTRO_Click(object sender, EventArgs e)
        {
            _compra.filtrarPorDevolucion();
            DGV_COMPRA.DataSource = _compra.Source;
        }

        private void L_COMPRA_MOV_FILTRO_Click(object sender, EventArgs e)
        {
            _compra.filtrarPorMovimiento();
            DGV_COMPRA.DataSource = _compra.Source;
        }

        private void L_INV_CARGO_FILTRO_Click(object sender, EventArgs e)
        {
            _inventario.filtrarPorCargo();
            DGV_INVENTARIO.DataSource = _inventario.Source;
        }

        private void L_INV_DESCARGO_FILTRO_Click(object sender, EventArgs e)
        {
            _inventario.filtrarPorDescargo();
            DGV_INVENTARIO.DataSource = _inventario.Source;
        }

        private void L_INV_AJUSTE_FILTRO_Click(object sender, EventArgs e)
        {
            _inventario.filtrarPorAjuste();
            DGV_INVENTARIO.DataSource = _inventario.Source;
        }

        private void L_INV_MOVIMIENTO_FILTRO_Click(object sender, EventArgs e)
        {
            _inventario.filtrarPorMovimiento();
            DGV_INVENTARIO.DataSource = _inventario.Source;
        }

        private void L_INV_TRENTRADA_FILTRO_Click(object sender, EventArgs e)
        {
            _inventario.filtrarPorTrPorEntrada();
            DGV_INVENTARIO.DataSource = _inventario.Source;
        }

        private void L_INV_TRSALIDA_FILTRO_Click(object sender, EventArgs e)
        {
            _inventario.filtrarPorTrPorSalida();
            DGV_INVENTARIO.DataSource = _inventario.Source;
        }
     
    }

}