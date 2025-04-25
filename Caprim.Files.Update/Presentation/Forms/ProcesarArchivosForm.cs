using Caprim.Files.Update.Core.Ports.Input;

namespace Caprim.Files.Update
{
    public partial class ProcesarArchivosForm : Form
    {
        private readonly IFileImportUseCase _fileImportUseCase;
        private readonly Dictionary<string, string> _tipoArchivoMapping;

        public ProcesarArchivosForm(IFileImportUseCase fileImportUseCase)
        {
            InitializeComponent();
            _fileImportUseCase = fileImportUseCase;

            _tipoArchivoMapping = new Dictionary<string, string>
            {
                { "P2P", "binancep2p" },
                { "OrderSpot", "binanceorderspot" }
            };

            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            // Configurar el TextBox de proceso para que sea de solo lectura y tenga scroll
            txtProceso.ReadOnly = true;
            txtProceso.ScrollBars = ScrollBars.Vertical;

            // Asegurar que el ComboBox tenga un valor seleccionado
            if (cboTipoArchivo.SelectedIndex == -1)
                cboTipoArchivo.SelectedIndex = 0;
        }

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog
            {
                Description = "Seleccione la carpeta con los archivos"
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtCarpeta.Text = folderDialog.SelectedPath;
            }
        }

        private async void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas())
                return;

            try
            {
                ToggleControles(false);
                await ProcesarArchivosAsync();
            }
            catch (Exception ex)
            {
                MostrarError($"Error durante el procesamiento: {ex.Message}");
            }
            finally
            {
                ToggleControles(true);
            }
        }

        private void ToggleControles(bool enabled)
        {
            btnProcesar.Enabled = enabled;
            btnSourcePath.Enabled = enabled;
            cboTipoArchivo.Enabled = enabled;
            txtCarpeta.Enabled = enabled;
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrEmpty(txtCarpeta.Text))
            {
                MostrarError("Por favor seleccione una carpeta");
                return false;
            }

            if (!Directory.Exists(txtCarpeta.Text))
            {
                MostrarError("La carpeta seleccionada no existe");
                return false;
            }

            if (string.IsNullOrEmpty(cboTipoArchivo.Text))
            {
                MostrarError("Por favor seleccione un tipo de archivo");
                return false;
            }

            if (!_tipoArchivoMapping.ContainsKey(cboTipoArchivo.Text))
            {
                MostrarError("Tipo de archivo no válido");
                return false;
            }

            return true;
        }

        private async Task ProcesarArchivosAsync()
        {
            string tipoArchivo = _tipoArchivoMapping[cboTipoArchivo.Text];

            AgregarLog($"Iniciando procesamiento de archivos {cboTipoArchivo.Text}...");

            var resultado = await _fileImportUseCase.ProcessDirectoryAsync(txtCarpeta.Text, tipoArchivo);

            if (resultado.Success)
            {
                AgregarLog($"Éxito: {resultado.Message}");
            }
            else
            {
                AgregarLog($"Error: {resultado.Message}");
                MostrarError(resultado.Message);
            }

            AgregarLog("Proceso completado.");
        }

        private void AgregarLog(string mensaje)
        {
            if (txtProceso.InvokeRequired)
            {
                txtProceso.Invoke(new Action(() => AgregarLog(mensaje)));
                return;
            }

            txtProceso.AppendText($"[{DateTime.Now:HH:mm:ss}] {mensaje}{Environment.NewLine}");
            txtProceso.ScrollToCaret();
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}