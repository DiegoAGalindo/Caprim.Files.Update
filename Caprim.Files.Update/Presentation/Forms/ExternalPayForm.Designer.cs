namespace Caprim.Files.Update.Presentation.Forms
{
    partial class ExternalPayForm
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
            this.pnlClienteFilter = new System.Windows.Forms.Panel();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pnlDateFilter = new System.Windows.Forms.Panel();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.rbRangoPersonalizado = new System.Windows.Forms.RadioButton();
            this.rbUltimoMes = new System.Windows.Forms.RadioButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblRangoFechas = new System.Windows.Forms.Label();
            this.pnlListaPagos = new System.Windows.Forms.Panel();
            this.btnNuevoPago = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvPagosExternos = new System.Windows.Forms.DataGridView();
            this.colPagoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPagoExterno = new System.Windows.Forms.Panel();
            this.btnVolverLista = new System.Windows.Forms.Button();
            this.btnGuardarPago = new System.Windows.Forms.Button();
            this.txtTotalCop = new System.Windows.Forms.TextBox();
            this.lblTotalCop = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.lblTasa = new System.Windows.Forms.Label();
            this.txtUsdt = new System.Windows.Forms.TextBox();
            this.lblUsdt = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.cmbClientePago = new System.Windows.Forms.ComboBox();
            this.lblClientePago = new System.Windows.Forms.Label();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.lblDetallesPago = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.colDetalleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalleFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalleMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDistribucion = new System.Windows.Forms.Panel();
            this.lblDistribucion = new System.Windows.Forms.Label();
            this.dgvDistribucion = new System.Windows.Forms.DataGridView();
            this.colDistribucionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistribucionPagoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistribucionCuentaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistribucionMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlClienteFilter.SuspendLayout();
            this.pnlDateFilter.SuspendLayout();
            this.pnlPagoExterno.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.pnlDistribucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucion)).BeginInit();
            this.pnlListaPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosExternos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClienteFilter
            // 
            this.pnlClienteFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClienteFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlClienteFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClienteFilter.Controls.Add(this.btnNuevoCliente);
            this.pnlClienteFilter.Controls.Add(this.cmbClientes);
            this.pnlClienteFilter.Controls.Add(this.lblCliente);
            this.pnlClienteFilter.Location = new System.Drawing.Point(12, 12);
            this.pnlClienteFilter.Name = "pnlClienteFilter";
            this.pnlClienteFilter.Size = new System.Drawing.Size(425, 100);
            this.pnlClienteFilter.TabIndex = 0;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.DarkBlue;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNuevoCliente.Location = new System.Drawing.Point(344, 13);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(75, 26);
            this.btnNuevoCliente.TabIndex = 3;
            this.btnNuevoCliente.Text = "Nuevo";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(94, 14);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(244, 23);
            this.cmbClientes.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCliente.Location = new System.Drawing.Point(11, 17);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(49, 15);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // pnlDateFilter
            // 
            this.pnlDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDateFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDateFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateFilter.Controls.Add(this.btnAplicarFiltro);
            this.pnlDateFilter.Controls.Add(this.dtpEndDate);
            this.pnlDateFilter.Controls.Add(this.lblTo);
            this.pnlDateFilter.Controls.Add(this.dtpStartDate);
            this.pnlDateFilter.Controls.Add(this.rbRangoPersonalizado);
            this.pnlDateFilter.Controls.Add(this.rbUltimoMes);
            this.pnlDateFilter.Controls.Add(this.lblRangoFechas);
            this.pnlDateFilter.Location = new System.Drawing.Point(443, 12);
            this.pnlDateFilter.Name = "pnlDateFilter";
            this.pnlDateFilter.Size = new System.Drawing.Size(345, 100);
            this.pnlDateFilter.TabIndex = 1;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltro.Location = new System.Drawing.Point(249, 69);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(91, 26);
            this.btnAplicarFiltro.TabIndex = 6;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(249, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(91, 23);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(223, 44);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 15);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "Al:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(125, 40);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(92, 23);
            this.dtpStartDate.TabIndex = 3;
            // 
            // rbRangoPersonalizado
            // 
            this.rbRangoPersonalizado.AutoSize = true;
            this.rbRangoPersonalizado.Location = new System.Drawing.Point(188, 14);
            this.rbRangoPersonalizado.Name = "rbRangoPersonalizado";
            this.rbRangoPersonalizado.Size = new System.Drawing.Size(138, 19);
            this.rbRangoPersonalizado.TabIndex = 2;
            this.rbRangoPersonalizado.Text = "Rango Personalizado";
            this.rbRangoPersonalizado.UseVisualStyleBackColor = true;
            // 
            // rbUltimoMes
            // 
            this.rbUltimoMes.AutoSize = true;
            this.rbUltimoMes.Checked = true;
            this.rbUltimoMes.Location = new System.Drawing.Point(97, 14);
            this.rbUltimoMes.Name = "rbUltimoMes";
            this.rbUltimoMes.Size = new System.Drawing.Size(85, 19);
            this.rbUltimoMes.TabIndex = 1;
            this.rbUltimoMes.TabStop = true;
            this.rbUltimoMes.Text = "Último Mes";
            this.rbUltimoMes.UseVisualStyleBackColor = true;
            // 
            // lblRangoFechas
            // 
            this.lblRangoFechas.AutoSize = true;
            this.lblRangoFechas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRangoFechas.Location = new System.Drawing.Point(9, 16);
            this.lblRangoFechas.Name = "lblRangoFechas";
            this.lblRangoFechas.Size = new System.Drawing.Size(81, 15);
            this.lblRangoFechas.TabIndex = 0;
            this.lblRangoFechas.Text = "Filtrar Fechas:";
            // 
            // pnlListaPagos
            // 
            this.pnlListaPagos.Controls.Add(this.dgvPagosExternos);
            this.pnlListaPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaPagos.Location = new System.Drawing.Point(0, 0);
            this.pnlListaPagos.Name = "pnlListaPagos";
            this.pnlListaPagos.Size = new System.Drawing.Size(800, 428);
            this.pnlListaPagos.TabIndex = 6;
            this.pnlListaPagos.Visible = true;
            // 
            // btnNuevoPago
            // 
            this.btnNuevoPago.BackColor = System.Drawing.Color.DarkBlue;
            this.btnNuevoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPago.ForeColor = System.Drawing.Color.White;
            this.btnNuevoPago.Location = new System.Drawing.Point(581, 68);
            this.btnNuevoPago.Name = "btnNuevoPago";
            this.btnNuevoPago.Size = new System.Drawing.Size(91, 27);
            this.btnNuevoPago.TabIndex = 9;
            this.btnNuevoPago.Text = "Nuevo";
            this.btnNuevoPago.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 392);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(148, 15);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Mostrando último mes: OK";
            // 
            // dgvPagosExternos
            // 
            this.dgvPagosExternos.AllowUserToAddRows = false;
            this.dgvPagosExternos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPagosExternos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagosExternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagosExternos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPagoId,
            this.colFecha,
            this.colCliente,
            this.colUsdt,
            this.colTasa,
            this.colTotalCop});
            this.dgvPagosExternos.Location = new System.Drawing.Point(12, 112);
            this.dgvPagosExternos.MultiSelect = false;
            this.dgvPagosExternos.Name = "dgvPagosExternos";
            this.dgvPagosExternos.ReadOnly = true;
            this.dgvPagosExternos.RowTemplate.Height = 25;
            this.dgvPagosExternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagosExternos.Size = new System.Drawing.Size(776, 304);
            this.dgvPagosExternos.TabIndex = 0;
            // 
            // colPagoId
            // 
            this.colPagoId.HeaderText = "ID";
            this.colPagoId.Name = "colPagoId";
            this.colPagoId.ReadOnly = true;
            this.colPagoId.Width = 50;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 120;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 200;
            // 
            // colUsdt
            // 
            this.colUsdt.HeaderText = "USDT";
            this.colUsdt.Name = "colUsdt";
            this.colUsdt.ReadOnly = true;
            this.colUsdt.Width = 100;
            // 
            // colTasa
            // 
            this.colTasa.HeaderText = "Tasa";
            this.colTasa.Name = "colTasa";
            this.colTasa.ReadOnly = true;
            this.colTasa.Width = 100;
            // 
            // colTotalCop
            // 
            this.colTotalCop.HeaderText = "Total COP";
            this.colTotalCop.Name = "colTotalCop";
            this.colTotalCop.ReadOnly = true;
            this.colTotalCop.Width = 150;
            // 
            // btnVolverLista
            // 
            this.btnVolverLista.BackColor = System.Drawing.Color.DarkBlue;
            this.btnVolverLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverLista.ForeColor = System.Drawing.Color.White;
            this.btnVolverLista.Location = new System.Drawing.Point(12, 392);
            this.btnVolverLista.Name = "btnVolverLista";
            this.btnVolverLista.Size = new System.Drawing.Size(91, 27);
            this.btnVolverLista.TabIndex = 11;
            this.btnVolverLista.Text = "Volver";
            this.btnVolverLista.UseVisualStyleBackColor = false;
            // 
            // pnlPagoExterno
            // 
            this.pnlPagoExterno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPagoExterno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPagoExterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPagoExterno.Controls.Add(this.btnGuardarPago);
            this.pnlPagoExterno.Controls.Add(this.btnNuevoPago);
            this.pnlPagoExterno.Controls.Add(this.txtTotalCop);
            this.pnlPagoExterno.Controls.Add(this.lblTotalCop);
            this.pnlPagoExterno.Controls.Add(this.txtTasa);
            this.pnlPagoExterno.Controls.Add(this.lblTasa);
            this.pnlPagoExterno.Controls.Add(this.txtUsdt);
            this.pnlPagoExterno.Controls.Add(this.lblUsdt);
            this.pnlPagoExterno.Controls.Add(this.dtpFechaPago);
            this.pnlPagoExterno.Controls.Add(this.lblFechaPago);
            this.pnlPagoExterno.Controls.Add(this.cmbClientePago);
            this.pnlPagoExterno.Controls.Add(this.lblClientePago);
            this.pnlPagoExterno.Location = new System.Drawing.Point(12, 118);
            this.pnlPagoExterno.Name = "pnlPagoExterno";
            this.pnlPagoExterno.Size = new System.Drawing.Size(776, 100);
            this.pnlPagoExterno.TabIndex = 2;
            // 
            // btnGuardarPago
            // 
            this.btnGuardarPago.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGuardarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPago.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPago.Location = new System.Drawing.Point(678, 68);
            this.btnGuardarPago.Name = "btnGuardarPago";
            this.btnGuardarPago.Size = new System.Drawing.Size(91, 27);
            this.btnGuardarPago.TabIndex = 10;
            this.btnGuardarPago.Text = "Guardar";
            this.btnGuardarPago.UseVisualStyleBackColor = false;
            // 
            // txtTotalCop
            // 
            this.txtTotalCop.Location = new System.Drawing.Point(639, 39);
            this.txtTotalCop.Name = "txtTotalCop";
            this.txtTotalCop.Size = new System.Drawing.Size(130, 23);
            this.txtTotalCop.TabIndex = 8;
            // 
            // lblTotalCop
            // 
            this.lblTotalCop.AutoSize = true;
            this.lblTotalCop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCop.Location = new System.Drawing.Point(573, 42);
            this.lblTotalCop.Name = "lblTotalCop";
            this.lblTotalCop.Size = new System.Drawing.Size(60, 15);
            this.lblTotalCop.TabIndex = 7;
            this.lblTotalCop.Text = "Total COP:";
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(461, 39);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(86, 23);
            this.txtTasa.TabIndex = 6;
            // 
            // lblTasa
            // 
            this.lblTasa.AutoSize = true;
            this.lblTasa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTasa.Location = new System.Drawing.Point(428, 42);
            this.lblTasa.Name = "lblTasa";
            this.lblTasa.Size = new System.Drawing.Size(31, 15);
            this.lblTasa.TabIndex = 5;
            this.lblTasa.Text = "Tasa:";
            // 
            // txtUsdt
            // 
            this.txtUsdt.Location = new System.Drawing.Point(319, 39);
            this.txtUsdt.Name = "txtUsdt";
            this.txtUsdt.Size = new System.Drawing.Size(87, 23);
            this.txtUsdt.TabIndex = 4;
            // 
            // lblUsdt
            // 
            this.lblUsdt.AutoSize = true;
            this.lblUsdt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsdt.Location = new System.Drawing.Point(277, 42);
            this.lblUsdt.Name = "lblUsdt";
            this.lblUsdt.Size = new System.Drawing.Size(36, 15);
            this.lblUsdt.TabIndex = 3;
            this.lblUsdt.Text = "USDT:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(140, 39);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(115, 23);
            this.dtpFechaPago.TabIndex = 2;
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFechaPago.Location = new System.Drawing.Point(97, 42);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(41, 15);
            this.lblFechaPago.TabIndex = 1;
            this.lblFechaPago.Text = "Fecha:";
            // 
            // cmbClientePago
            // 
            this.cmbClientePago.FormattingEnabled = true;
            this.cmbClientePago.Location = new System.Drawing.Point(94, 14);
            this.cmbClientePago.Name = "cmbClientePago";
            this.cmbClientePago.Size = new System.Drawing.Size(244, 23);
            this.cmbClientePago.TabIndex = 1;
            // 
            // lblClientePago
            // 
            this.lblClientePago.AutoSize = true;
            this.lblClientePago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClientePago.Location = new System.Drawing.Point(11, 17);
            this.lblClientePago.Name = "lblClientePago";
            this.lblClientePago.Size = new System.Drawing.Size(49, 15);
            this.lblClientePago.TabIndex = 0;
            this.lblClientePago.Text = "Cliente:";
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDetalles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalles.Controls.Add(this.dgvDetalles);
            this.pnlDetalles.Controls.Add(this.lblDetallesPago);
            this.pnlDetalles.Location = new System.Drawing.Point(12, 224);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(384, 192);
            this.pnlDetalles.TabIndex = 3;
            // 
            // lblDetallesPago
            // 
            this.lblDetallesPago.AutoSize = true;
            this.lblDetallesPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetallesPago.Location = new System.Drawing.Point(11, 14);
            this.lblDetallesPago.Name = "lblDetallesPago";
            this.lblDetallesPago.Size = new System.Drawing.Size(98, 15);
            this.lblDetallesPago.TabIndex = 0;
            this.lblDetallesPago.Text = "Detalles de Pago";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetalleId,
            this.colDetalleFecha,
            this.colDetalleMonto});
            this.dgvDetalles.Location = new System.Drawing.Point(11, 32);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowTemplate.Height = 25;
            this.dgvDetalles.Size = new System.Drawing.Size(358, 145);
            this.dgvDetalles.TabIndex = 1;
            // 
            // colDetalleId
            // 
            this.colDetalleId.HeaderText = "ID";
            this.colDetalleId.Name = "colDetalleId";
            this.colDetalleId.ReadOnly = true;
            this.colDetalleId.Width = 50;
            // 
            // colDetalleFecha
            // 
            this.colDetalleFecha.HeaderText = "Fecha";
            this.colDetalleFecha.Name = "colDetalleFecha";
            this.colDetalleFecha.ReadOnly = true;
            // 
            // colDetalleMonto
            // 
            this.colDetalleMonto.HeaderText = "Valor";
            this.colDetalleMonto.Name = "colDetalleMonto";
            this.colDetalleMonto.ReadOnly = true;
            this.colDetalleMonto.Width = 150;
            // 
            // pnlDistribucion
            // 
            this.pnlDistribucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDistribucion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDistribucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDistribucion.Controls.Add(this.dgvDistribucion);
            this.pnlDistribucion.Controls.Add(this.lblDistribucion);
            this.pnlDistribucion.Location = new System.Drawing.Point(402, 224);
            this.pnlDistribucion.Name = "pnlDistribucion";
            this.pnlDistribucion.Size = new System.Drawing.Size(386, 192);
            this.pnlDistribucion.TabIndex = 4;
            // 
            // lblDistribucion
            // 
            this.lblDistribucion.AutoSize = true;
            this.lblDistribucion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDistribucion.Location = new System.Drawing.Point(12, 14);
            this.lblDistribucion.Name = "lblDistribucion";
            this.lblDistribucion.Size = new System.Drawing.Size(73, 15);
            this.lblDistribucion.TabIndex = 0;
            this.lblDistribucion.Text = "Distribución";
            // 
            // dgvDistribucion
            // 
            this.dgvDistribucion.AllowUserToAddRows = false;
            this.dgvDistribucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDistribucion.BackgroundColor = System.Drawing.Color.White;
            this.dgvDistribucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistribucion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDistribucionId,
            this.colDistribucionPagoId,
            this.colDistribucionCuentaId,
            this.colDistribucionMonto});
            this.dgvDistribucion.Location = new System.Drawing.Point(11, 32);
            this.dgvDistribucion.Name = "dgvDistribucion";
            this.dgvDistribucion.RowTemplate.Height = 25;
            this.dgvDistribucion.Size = new System.Drawing.Size(362, 145);
            this.dgvDistribucion.TabIndex = 2;
            // 
            // colDistribucionId
            // 
            this.colDistribucionId.HeaderText = "ID";
            this.colDistribucionId.Name = "colDistribucionId";
            this.colDistribucionId.ReadOnly = true;
            this.colDistribucionId.Width = 50;
            // 
            // colDistribucionPagoId
            // 
            this.colDistribucionPagoId.HeaderText = "ID Pago";
            this.colDistribucionPagoId.Name = "colDistribucionPagoId";
            this.colDistribucionPagoId.ReadOnly = true;
            this.colDistribucionPagoId.Width = 70;
            // 
            // colDistribucionCuentaId
            // 
            this.colDistribucionCuentaId.HeaderText = "ID Detalle";
            this.colDistribucionCuentaId.Name = "colDistribucionCuentaId";
            this.colDistribucionCuentaId.ReadOnly = true;
            this.colDistribucionCuentaId.Width = 70;
            // 
            // colDistribucionMonto
            // 
            this.colDistribucionMonto.HeaderText = "Valor";
            this.colDistribucionMonto.Name = "colDistribucionMonto";
            this.colDistribucionMonto.ReadOnly = true;
            this.colDistribucionMonto.Width = 120;
            // 
            // ExternalPayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDistribucion);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.pnlPagoExterno);
            this.Controls.Add(this.pnlDateFilter);
            this.Controls.Add(this.pnlClienteFilter);
            this.Controls.Add(this.pnlListaPagos);
            this.Controls.Add(this.btnVolverLista);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnNuevoPago);
            this.Name = "ExternalPayForm";
            this.Text = "Pagos Externos";
            this.Load += new System.EventHandler(this.ExternalPayForm_Load);
            this.pnlClienteFilter.ResumeLayout(false);
            this.pnlClienteFilter.PerformLayout();
            this.pnlDateFilter.ResumeLayout(false);
            this.pnlDateFilter.PerformLayout();
            this.pnlPagoExterno.ResumeLayout(false);
            this.pnlPagoExterno.PerformLayout();
            this.pnlDetalles.ResumeLayout(false);
            this.pnlDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.pnlDistribucion.ResumeLayout(false);
            this.pnlDistribucion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucion)).EndInit();
            this.pnlListaPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosExternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlClienteFilter;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Panel pnlDateFilter;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.RadioButton rbRangoPersonalizado;
        private System.Windows.Forms.RadioButton rbUltimoMes;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblRangoFechas;
        private System.Windows.Forms.Panel pnlListaPagos;
        private System.Windows.Forms.Button btnNuevoPago;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvPagosExternos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCop;
        private System.Windows.Forms.Panel pnlPagoExterno;
        private System.Windows.Forms.Button btnVolverLista;
        private System.Windows.Forms.Button btnGuardarPago;
        private System.Windows.Forms.TextBox txtTotalCop;
        private System.Windows.Forms.Label lblTotalCop;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.Label lblTasa;
        private System.Windows.Forms.TextBox txtUsdt;
        private System.Windows.Forms.Label lblUsdt;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.ComboBox cmbClientePago;
        private System.Windows.Forms.Label lblClientePago;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.Label lblDetallesPago;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalleFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalleMonto;
        private System.Windows.Forms.Panel pnlDistribucion;
        private System.Windows.Forms.Label lblDistribucion;
        private System.Windows.Forms.DataGridView dgvDistribucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistribucionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistribucionPagoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistribucionCuentaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistribucionMonto;
    }
}