using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Presentation.Forms
{
    public partial class ClienteForm : Form
    {
        private readonly ILogger<ClienteForm>? _logger;

        // Constructor sin parámetros para cuando se crea sin DI
        public ClienteForm()
        {
            InitializeComponent();
        }

        // Constructor con logger para inyección de dependencias
        public ClienteForm(ILogger<ClienteForm> logger)
        {
            _logger = logger;
            InitializeComponent();
        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            try
            {
                _logger?.LogInformation("Inicializando formulario de Cliente");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error al inicializar formulario de Cliente");
                MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre del cliente es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                {
                    MessageBox.Show("La identificación del cliente es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Aquí iría la lógica para guardar el cliente
                _logger?.LogInformation("Guardando nuevo cliente: {Nombre}", txtNombre.Text);

                // Devolver resultado OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error al guardar cliente");
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}