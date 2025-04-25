using Caprim.Files.Update.Core.Ports.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Caprim.Files.Update.Presentation.Forms
{
    public partial class PrincipalForm : Form
    {
        private readonly IFileImportUseCase _fileImportUseCase;
        private readonly Dictionary<string, string> _tipoArchivoMapping;
        private readonly IServiceProvider _serviceProvider;

        public PrincipalForm(IFileImportUseCase fileImportUseCase, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _fileImportUseCase = fileImportUseCase;
            _serviceProvider = serviceProvider;

            _tipoArchivoMapping = new Dictionary<string, string>
            {
                { "P2P", "binancep2p" },
                { "OrderSpot", "binanceorderspot" }
            };
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
        }

        private void btnProcesarArchivos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del segundo formulario
            ProcesarArchivosForm CargaDeArchivos = new ProcesarArchivosForm(_fileImportUseCase);

            // Muestra el segundo formulario
            CargaDeArchivos.Show();
        }

        private void btnPagosExternos_Click(object sender, EventArgs e)
        {
            // Obtener la instancia del formulario desde el contenedor de DI
            var form = _serviceProvider.GetRequiredService<ExternalPayForm>();

            // Muestra el formulario
            form.Show();
        }
    }
}