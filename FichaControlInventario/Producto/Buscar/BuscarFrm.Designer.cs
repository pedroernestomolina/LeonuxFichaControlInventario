namespace FichaControlInventario.Producto.Buscar
{
    partial class BuscarFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_BUSCAR = new System.Windows.Forms.Button();
            this.TB_CADENA = new System.Windows.Forms.TextBox();
            this.RB_CODIGO = new System.Windows.Forms.RadioButton();
            this.RB_NOMBRE = new System.Windows.Forms.RadioButton();
            this.RB_REFERENCIA = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BT_LIMPIAR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_BUSCAR
            // 
            this.BT_BUSCAR.Location = new System.Drawing.Point(333, 28);
            this.BT_BUSCAR.Name = "BT_BUSCAR";
            this.BT_BUSCAR.Size = new System.Drawing.Size(55, 23);
            this.BT_BUSCAR.TabIndex = 5;
            this.BT_BUSCAR.Text = "Buscar";
            this.BT_BUSCAR.UseVisualStyleBackColor = true;
            this.BT_BUSCAR.Click += new System.EventHandler(this.BT_BUSCAR_Click);
            // 
            // TB_CADENA
            // 
            this.TB_CADENA.Location = new System.Drawing.Point(7, 30);
            this.TB_CADENA.Name = "TB_CADENA";
            this.TB_CADENA.Size = new System.Drawing.Size(320, 20);
            this.TB_CADENA.TabIndex = 0;
            // 
            // RB_CODIGO
            // 
            this.RB_CODIGO.AutoSize = true;
            this.RB_CODIGO.Location = new System.Drawing.Point(7, 7);
            this.RB_CODIGO.Name = "RB_CODIGO";
            this.RB_CODIGO.Size = new System.Drawing.Size(58, 17);
            this.RB_CODIGO.TabIndex = 1;
            this.RB_CODIGO.TabStop = true;
            this.RB_CODIGO.Text = "Codigo";
            this.RB_CODIGO.UseVisualStyleBackColor = true;
            this.RB_CODIGO.CheckedChanged += new System.EventHandler(this.RB_CODIGO_CheckedChanged);
            // 
            // RB_NOMBRE
            // 
            this.RB_NOMBRE.AutoSize = true;
            this.RB_NOMBRE.Location = new System.Drawing.Point(71, 7);
            this.RB_NOMBRE.Name = "RB_NOMBRE";
            this.RB_NOMBRE.Size = new System.Drawing.Size(62, 17);
            this.RB_NOMBRE.TabIndex = 2;
            this.RB_NOMBRE.TabStop = true;
            this.RB_NOMBRE.Text = "Nombre";
            this.RB_NOMBRE.UseVisualStyleBackColor = true;
            this.RB_NOMBRE.CheckedChanged += new System.EventHandler(this.RB_NOMBRE_CheckedChanged);
            // 
            // RB_REFERENCIA
            // 
            this.RB_REFERENCIA.AutoSize = true;
            this.RB_REFERENCIA.Location = new System.Drawing.Point(139, 7);
            this.RB_REFERENCIA.Name = "RB_REFERENCIA";
            this.RB_REFERENCIA.Size = new System.Drawing.Size(77, 17);
            this.RB_REFERENCIA.TabIndex = 3;
            this.RB_REFERENCIA.TabStop = true;
            this.RB_REFERENCIA.Text = "Referencia";
            this.RB_REFERENCIA.UseVisualStyleBackColor = true;
            this.RB_REFERENCIA.CheckedChanged += new System.EventHandler(this.RB_REFERENCIA_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.BT_LIMPIAR);
            this.panel1.Controls.Add(this.TB_CADENA);
            this.panel1.Controls.Add(this.RB_REFERENCIA);
            this.panel1.Controls.Add(this.BT_BUSCAR);
            this.panel1.Controls.Add(this.RB_NOMBRE);
            this.panel1.Controls.Add(this.RB_CODIGO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(491, 63);
            this.panel1.TabIndex = 0;
            // 
            // BT_LIMPIAR
            // 
            this.BT_LIMPIAR.Location = new System.Drawing.Point(333, 4);
            this.BT_LIMPIAR.Name = "BT_LIMPIAR";
            this.BT_LIMPIAR.Size = new System.Drawing.Size(55, 23);
            this.BT_LIMPIAR.TabIndex = 4;
            this.BT_LIMPIAR.Text = "Limpiar";
            this.BT_LIMPIAR.UseVisualStyleBackColor = true;
            this.BT_LIMPIAR.Click += new System.EventHandler(this.BT_LIMPIAR_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIDA);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 387);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(491, 34);
            this.panel2.TabIndex = 2;
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIDA.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIDA.Location = new System.Drawing.Point(407, 4);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(80, 26);
            this.BT_SALIDA.TabIndex = 6;
            this.BT_SALIDA.Text = "Salida";
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            this.BT_SALIDA.Click += new System.EventHandler(this.BT_SALIDA_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 63);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(491, 324);
            this.DGV.TabIndex = 1;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGV_DataBindingComplete);
            // 
            // BuscarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_SALIDA;
            this.ClientSize = new System.Drawing.Size(491, 421);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "BuscarFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BuscarFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_BUSCAR;
        private System.Windows.Forms.TextBox TB_CADENA;
        private System.Windows.Forms.RadioButton RB_CODIGO;
        private System.Windows.Forms.RadioButton RB_NOMBRE;
        private System.Windows.Forms.RadioButton RB_REFERENCIA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button BT_LIMPIAR;
        private System.Windows.Forms.Button BT_SALIDA;

    }
}