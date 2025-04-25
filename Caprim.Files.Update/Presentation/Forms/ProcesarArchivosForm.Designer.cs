namespace Caprim.Files.Update
{
    partial class ProcesarArchivosForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSourcePath = new Button();
            txtCarpeta = new TextBox();
            cboTipoArchivo = new ComboBox();
            lblTipoArchivo = new Label();
            txtProceso = new TextBox();
            btnProcesar = new Button();
            SuspendLayout();
            // 
            // btnSourcePath
            // 
            btnSourcePath.Location = new Point(12, 12);
            btnSourcePath.Name = "btnSourcePath";
            btnSourcePath.Size = new Size(75, 23);
            btnSourcePath.TabIndex = 0;
            btnSourcePath.Text = "Carpeta";
            btnSourcePath.UseVisualStyleBackColor = true;
            btnSourcePath.Click += btnSourcePath_Click;
            // 
            // txtCarpeta
            // 
            txtCarpeta.Location = new Point(114, 13);
            txtCarpeta.Name = "txtCarpeta";
            txtCarpeta.Size = new Size(456, 23);
            txtCarpeta.TabIndex = 1;
            txtCarpeta.Text = "C:\\Users\\diego\\OneDrive\\Documentos\\CaprimDB\\Files\\P2P";
            // 
            // cboTipoArchivo
            // 
            cboTipoArchivo.FormattingEnabled = true;
            cboTipoArchivo.Items.AddRange(new object[] { "P2P", "OrderSpot" });
            cboTipoArchivo.Location = new Point(114, 53);
            cboTipoArchivo.Name = "cboTipoArchivo";
            cboTipoArchivo.Size = new Size(176, 23);
            cboTipoArchivo.TabIndex = 2;
            cboTipoArchivo.Text = "P2P";
            // 
            // lblTipoArchivo
            // 
            lblTipoArchivo.AutoSize = true;
            lblTipoArchivo.Location = new Point(12, 56);
            lblTipoArchivo.Name = "lblTipoArchivo";
            lblTipoArchivo.Size = new Size(96, 15);
            lblTipoArchivo.TabIndex = 3;
            lblTipoArchivo.Text = "Tipo de Archivos";
            // 
            // txtProceso
            // 
            txtProceso.Location = new Point(8, 162);
            txtProceso.Multiline = true;
            txtProceso.Name = "txtProceso";
            txtProceso.Size = new Size(780, 276);
            txtProceso.TabIndex = 4;
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(12, 133);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(75, 23);
            btnProcesar.TabIndex = 5;
            btnProcesar.Text = "Procesar";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProcesar);
            Controls.Add(txtProceso);
            Controls.Add(lblTipoArchivo);
            Controls.Add(cboTipoArchivo);
            Controls.Add(txtCarpeta);
            Controls.Add(btnSourcePath);
            Name = "Form1";
            Text = "Procesador de Archivos";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSourcePath;
        private TextBox txtCarpeta;
        private ComboBox cboTipoArchivo;
        private Label lblTipoArchivo;
        private TextBox txtProceso;
        private Button btnProcesar;
    }
}
