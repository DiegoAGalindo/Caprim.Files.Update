using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Presentation.Forms
{
    public partial class ExternalPayForm : Form
    {
        private readonly ILogger<ExternalPayForm> _logger;

        // Estado del formulario para controlar el modo (visualización o edición)
        private bool _editMode = false;

        public ExternalPayForm(ILogger<ExternalPayForm> logger)
        {
            _logger = logger;
            InitializeComponent();
        }

        private void ExternalPayForm_Load(object? sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Inicializando formulario de Pagos Externos");
                InitializeDefaultDateFilter();
                //ConfigureEventHandlers();
                //ConfigureInitialLayout();
                //LoadAllExternalPayments();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al inicializar formulario de Pagos Externos");
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDefaultDateFilter()
        {
            // Establece el filtro por defecto al último mes
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            rbUltimoMes.Checked = true;

            // Configurar visibilidad según opción predeterminada
            UpdateDateFilterVisibility();
        }

        private void ConfigureEventHandlers()
        {
            // Configurar eventos para los radio buttons
            rbUltimoMes.CheckedChanged += RadioButton_CheckedChanged;
            rbRangoPersonalizado.CheckedChanged += RadioButton_CheckedChanged;

            // Configurar eventos para los botones
            btnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            btnNuevoCliente.Click += BtnNuevoCliente_Click;
            btnNuevoPago.Click += BtnNuevoPago_Click;
            btnGuardarPago.Click += BtnGuardarPago_Click;

            // Eventos para el grid principal
            dgvPagosExternos.SelectionChanged += DgvPagosExternos_SelectionChanged;

            // Botón para volver a la lista
            btnVolverLista.Click += BtnVolverLista_Click;
        }

        private void ConfigureInitialLayout()
        {
            // Inicialmente mostrar la lista de pagos y ocultar detalles
            pnlListaPagos.Visible = true;
            pnlListaPagos.Dock = DockStyle.Fill;

            pnlDetalles.Visible = false;
            pnlDistribucion.Visible = false;
            pnlPagoExterno.Visible = false;
            btnVolverLista.Visible = false;
        }

        private void LoadAllExternalPayments()
        {
            try
            {
                _logger.LogInformation("Cargando lista de pagos externos");

                // Aquí iría la lógica para cargar todos los pagos externos Por ahora, solo
                // simulamos la carga con datos de prueba

                dgvPagosExternos.Rows.Clear();

                // Datos de prueba
                dgvPagosExternos.Rows.Add(1, DateTime.Now.AddDays(-5).ToShortDateString(), "Cliente A", 500, 4000, 2000000);
                dgvPagosExternos.Rows.Add(2, DateTime.Now.AddDays(-10).ToShortDateString(), "Cliente B", 300, 4050, 1215000);
                dgvPagosExternos.Rows.Add(3, DateTime.Now.AddDays(-15).ToShortDateString(), "Cliente C", 1000, 3950, 3950000);

                lblStatus.Text = $"Mostrando {dgvPagosExternos.Rows.Count} pagos externos";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar pagos externos");
                MessageBox.Show($"Error al cargar pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPagosExternos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPagosExternos.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPagosExternos.SelectedRows[0];
                int idPago = Convert.ToInt32(selectedRow.Cells["colPagoId"].Value);

                _logger.LogInformation("Seleccionado pago ID: {PagoId}", idPago);

                // Cambiar a vista de detalles
                ShowPaymentDetails(idPago);
            }
        }

        private void ShowPaymentDetails(int idPago)
        {
            try
            {
                _logger.LogInformation("Cargando detalles del pago ID: {PagoId}", idPago);

                // Cambiar la vista del formulario
                pnlListaPagos.Visible = false;
                pnlPagoExterno.Visible = true;
                pnlDetalles.Visible = true;
                pnlDistribucion.Visible = true;
                btnVolverLista.Visible = true;

                // Colocar los paneles correctamente
                pnlPagoExterno.Dock = DockStyle.Top;
                pnlDetalles.Dock = DockStyle.Left;
                pnlDetalles.Width = this.Width / 2 - 20;
                pnlDistribucion.Dock = DockStyle.Fill;

                // Simular carga de datos
                if (DateTime.TryParse(dgvPagosExternos.SelectedRows[0].Cells["colFecha"].Value?.ToString(), out DateTime fechaPago))
                {
                    dtpFechaPago.Value = fechaPago;
                }
                else
                {
                    dtpFechaPago.Value = DateTime.Now;
                    _logger.LogWarning("Formato de fecha no válido para el pago ID {PagoId}", idPago);
                }
                txtUsdt.Text = dgvPagosExternos.SelectedRows[0].Cells["colUsdt"].Value?.ToString();
                txtTasa.Text = dgvPagosExternos.SelectedRows[0].Cells["colTasa"].Value?.ToString();
                txtTotalCop.Text = dgvPagosExternos.SelectedRows[0].Cells["colTotalCop"].Value?.ToString();
                cmbClientePago.Text = dgvPagosExternos.SelectedRows[0].Cells["colCliente"].Value?.ToString();

                // Desactivar edición en modo visualización
                SetEditMode(false);

                // Simulación de carga de detalles
                dgvDetalles.Rows.Clear();
                dgvDetalles.Rows.Add(1, dtpFechaPago.Value.AddDays(-1).ToShortDateString(), 500000);
                dgvDetalles.Rows.Add(2, dtpFechaPago.Value.ToShortDateString(), 1500000);

                // Simulación de carga de distribuciones
                dgvDistribucion.Rows.Clear();
                dgvDistribucion.Rows.Add(1, idPago, 1, 500000);
                dgvDistribucion.Rows.Add(2, idPago, 2, 1500000);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar detalles del pago {PagoId}", idPago);
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVolverLista_Click(object? sender, EventArgs e)
        {
            // Volver a la vista de lista de pagos
            BackToList();
        }

        private void SetEditMode(bool editMode)
        {
            _editMode = editMode;

            // Actualizar el botón según el modo
            btnNuevoPago.Text = _editMode ? "Cancelar" : "Editar";
            btnNuevoPago.BackColor = _editMode ? Color.FromArgb(255, 128, 128) : SystemColors.Control;

            // Mostrar u ocultar botón guardar
            btnGuardarPago.Visible = _editMode;

            // Habilitar/deshabilitar controles según el modo
            EnableControls(pnlPagoExterno, _editMode);
            EnableControls(pnlDetalles, _editMode);

            // Actualizar título del panel
            lblDetallesPago.Text = _editMode ? "Edición de Pago Externo" : "Detalles de Pago Externo";
        }

        private void EnableControls(Control container, bool enable)
        {
            foreach (Control c in container.Controls)
            {
                // No deshabilitar etiquetas
                if (!(c is Label))
                {
                    c.Enabled = enable;

                    // Si es un contenedor, aplicar recursivamente
                    if (c.HasChildren)
                    {
                        EnableControls(c, enable);
                    }
                }
            }
        }

        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateDateFilterVisibility();
        }

        private void UpdateDateFilterVisibility()
        {
            bool useCustomRange = rbRangoPersonalizado.Checked;

            // Mostrar controles de rango personalizado
            dtpStartDate.Enabled = useCustomRange;
            dtpEndDate.Enabled = useCustomRange;
            lblTo.Enabled = useCustomRange;

            // Si no es rango personalizado, establecer el rango del último mes
            if (!useCustomRange)
            {
                dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                dtpEndDate.Value = DateTime.Now;
            }
        }

        private void BtnAplicarFiltro_Click(object? sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del día

                _logger.LogInformation("Aplicando filtro de fechas: {StartDate} a {EndDate}", startDate, endDate);

                if (startDate > endDate)
                {
                    MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin", "Error de filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Aquí iría la lógica para filtrar los pagos por fechas Por ahora, solo simulamos
                // un filtrado básico

                lblStatus.Text = $"Filtrando pagos del {startDate.ToShortDateString()} al {endDate.ToShortDateString()}";

                // Ejemplo de filtrado simulado
                LoadAllExternalPayments(); // En una implementación real, pasaríamos las fechas como parámetros
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al aplicar filtro de fechas");
                MessageBox.Show($"Error al aplicar filtro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevoCliente_Click(object? sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Abriendo formulario para crear nuevo cliente");

                // Aquí iría la lógica para abrir un formulario de creación de cliente
                MessageBox.Show("Funcionalidad de Nuevo Cliente en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Después de crear el cliente, actualizaríamos el ComboBox RefreshClientesComboBox();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar crear nuevo cliente");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevoPago_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_editMode)
                {
                    // Si ya estamos en modo edición, cancelar
                    _logger.LogInformation("Cancelando edición de pago externo");

                    SetEditMode(false);

                    // Si estamos editando un pago existente, recargar sus detalles
                    if (dgvPagosExternos.SelectedRows.Count > 0)
                    {
                        int idPago = Convert.ToInt32(dgvPagosExternos.SelectedRows[0].Cells["colPagoId"].Value);
                        ShowPaymentDetails(idPago);
                    }
                }
                else
                {
                    // Entrar en modo edición
                    _logger.LogInformation("Iniciando edición de pago externo");

                    // Si estamos viendo un pago, pasar a modo edición Si estamos en la lista, crear
                    // un nuevo pago
                    if (pnlPagoExterno.Visible)
                    {
                        SetEditMode(true);
                    }
                    else
                    {
                        // Preparar para un nuevo pago
                        pnlListaPagos.Visible = false;
                        pnlPagoExterno.Visible = true;
                        pnlDetalles.Visible = true;
                        pnlDistribucion.Visible = true;
                        btnVolverLista.Visible = true;

                        // Colocar los paneles correctamente
                        pnlPagoExterno.Dock = DockStyle.Top;
                        pnlDetalles.Dock = DockStyle.Left;
                        pnlDetalles.Width = this.Width / 2 - 20;
                        pnlDistribucion.Dock = DockStyle.Fill;

                        // Limpiar formulario y preparar para nuevo pago
                        ResetFormFields();
                        SetEditMode(true);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al iniciar/cancelar edición de pago");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardarPago_Click(object? sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Guardando pago externo");

                // Aquí iría la lógica para validar y guardar el pago
                MessageBox.Show("Pago guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a modo visualización
                SetEditMode(false);

                // Recargar lista de pagos
                LoadAllExternalPayments();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar pago externo");
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackToList()
        {
            // Cambiar vista a la lista
            pnlListaPagos.Visible = true;
            pnlPagoExterno.Visible = false;
            pnlDetalles.Visible = false;
            pnlDistribucion.Visible = false;
            btnVolverLista.Visible = false;

            // Restaurar el panel principal
            pnlListaPagos.Dock = DockStyle.Fill;

            // Resetear los modos de edición
            _editMode = false;

            // Resetear campos del formulario
            ResetFormFields();
        }

        /// <summary>
        /// Restablece los campos del formulario a su estado inicial
        /// </summary>
        private void ResetFormFields()
        {
            // Limpiar campos de texto
            txtUsdt.Text = string.Empty;
            txtTasa.Text = string.Empty;
            txtTotalCop.Text = string.Empty;

            // Resetear fecha
            dtpFechaPago.Value = DateTime.Now;

            // Limpiar combobox
            if (cmbClientePago.Items.Count > 0)
                cmbClientePago.SelectedIndex = 0;

            // Limpiar grids
            dgvDetalles.Rows.Clear();
            dgvDistribucion.Rows.Clear();
        }
    }
}