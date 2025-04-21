namespace Caprim.Files.Update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                btnProcesar.Enabled = false;
                btnSourcePath.Enabled = false;
                cboTipoArchivo.Enabled = false;
                txtCarpeta.Enabled = false;
                
                await ProcesarArchivosAsync();
            }
            catch (Exception ex)
            {
                MostrarError($"Error durante el procesamiento: {ex.Message}");
            }
            finally
            {
                btnProcesar.Enabled = true;
                btnSourcePath.Enabled = true;
                cboTipoArchivo.Enabled = true;
                txtCarpeta.Enabled = true;
            }
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

            return true;
        }

        private async Task ProcesarArchivosAsync()
        {
            AgregarLog("Iniciando procesamiento de archivos...");
            
            string[] archivos = Directory.GetFiles(txtCarpeta.Text, "*.*", SearchOption.AllDirectories);
            
            if (archivos.Length == 0)
            {
                AgregarLog("No se encontraron archivos para procesar.");
                return;
            }

            AgregarLog($"Se encontraron {archivos.Length} archivos.");
            
            foreach (string archivo in archivos)
            {
                AgregarLog($"Procesando: {Path.GetFileName(archivo)}");
                await Task.Delay(100); // Simulación de procesamiento
                // TODO: Implementar el procesamiento específico según el tipo de archivo
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
    }
}