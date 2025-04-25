namespace Caprim.Files.Update.Presentation.Forms
{
    partial class PrincipalForm
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
            btnProcesarArchivos = new Button();
            btnPagosExternos = new Button();
            SuspendLayout();
            // 
            // btnProcesarArchivos
            // 
            btnProcesarArchivos.Location = new Point(12, 12);
            btnProcesarArchivos.Name = "btnProcesarArchivos";
            btnProcesarArchivos.Size = new Size(137, 23);
            btnProcesarArchivos.TabIndex = 0;
            btnProcesarArchivos.Text = "Procesar Archivos";
            btnProcesarArchivos.UseVisualStyleBackColor = true;
            btnProcesarArchivos.Click += btnProcesarArchivos_Click;
            // 
            // btnPagosExternos
            // 
            btnPagosExternos.Location = new Point(12, 41);
            btnPagosExternos.Name = "btnPagosExternos";
            btnPagosExternos.Size = new Size(137, 23);
            btnPagosExternos.TabIndex = 1;
            btnPagosExternos.Text = "Pagos Externos";
            btnPagosExternos.UseVisualStyleBackColor = true;
            btnPagosExternos.Click += btnPagosExternos_Click;
            // 
            // PrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPagosExternos);
            Controls.Add(btnProcesarArchivos);
            Name = "PrincipalForm";
            Text = "PrincipalForm";
            Load += PrincipalForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnProcesarArchivos;
        private Button btnPagosExternos;
    }
}