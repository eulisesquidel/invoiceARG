namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormDetalleDeEnvioArhivoAWeb
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
            this.components = new System.ComponentModel.Container();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabDetalleDeArchivos = new System.Windows.Forms.TabPage();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gridArchivos = new System.Windows.Forms.DataGridView();
            this.bsDetalleArchivosWeb = new System.Windows.Forms.BindingSource(this.components);
            this.tabLogCorrida = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcesadoOK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs.SuspendLayout();
            this.tabDetalleDeArchivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArchivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalleArchivosWeb)).BeginInit();
            this.tabLogCorrida.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(117, 9);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(75, 13);
            this.lblIdentificador.TabIndex = 25;
            this.lblIdentificador.Text = "lblIdentificador";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "# Envío:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(117, 31);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 13);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "lblFecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fecha:";
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabDetalleDeArchivos);
            this.tabs.Controls.Add(this.tabLogCorrida);
            this.tabs.Location = new System.Drawing.Point(0, 62);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1085, 662);
            this.tabs.TabIndex = 26;
            // 
            // tabDetalleDeArchivos
            // 
            this.tabDetalleDeArchivos.AutoScroll = true;
            this.tabDetalleDeArchivos.Controls.Add(this.btnExportar);
            this.tabDetalleDeArchivos.Controls.Add(this.gridArchivos);
            this.tabDetalleDeArchivos.Location = new System.Drawing.Point(4, 22);
            this.tabDetalleDeArchivos.Name = "tabDetalleDeArchivos";
            this.tabDetalleDeArchivos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetalleDeArchivos.Size = new System.Drawing.Size(1077, 636);
            this.tabDetalleDeArchivos.TabIndex = 0;
            this.tabDetalleDeArchivos.Text = "Detalle de Archivos";
            this.tabDetalleDeArchivos.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.exportToFile16x16;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(1823, 1222);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(133, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // gridArchivos
            // 
            this.gridArchivos.AllowUserToAddRows = false;
            this.gridArchivos.AllowUserToDeleteRows = false;
            this.gridArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridArchivos.AutoGenerateColumns = false;
            this.gridArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreArchivo,
            this.Id,
            this.ProcesadoOK,
            this.Mensaje});
            this.gridArchivos.DataSource = this.bsDetalleArchivosWeb;
            this.gridArchivos.Location = new System.Drawing.Point(6, 6);
            this.gridArchivos.Name = "gridArchivos";
            this.gridArchivos.ReadOnly = true;
            this.gridArchivos.RowHeadersVisible = false;
            this.gridArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridArchivos.Size = new System.Drawing.Size(1063, 622);
            this.gridArchivos.TabIndex = 0;
            // 
            // bsDetalleArchivosWeb
            // 
            this.bsDetalleArchivosWeb.DataSource = typeof(FacturaElectronica.Common.Contracts.CorridaSubidaArchivoDto);
            // 
            // tabLogCorrida
            // 
            this.tabLogCorrida.Controls.Add(this.btnRefresh);
            this.tabLogCorrida.Controls.Add(this.label4);
            this.tabLogCorrida.Controls.Add(this.LogTextBox);
            this.tabLogCorrida.Location = new System.Drawing.Point(4, 22);
            this.tabLogCorrida.Name = "tabLogCorrida";
            this.tabLogCorrida.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogCorrida.Size = new System.Drawing.Size(1077, 636);
            this.tabLogCorrida.TabIndex = 4;
            this.tabLogCorrida.Text = "Log de Ejecución";
            this.tabLogCorrida.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.repetir;
            this.btnRefresh.Location = new System.Drawing.Point(107, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 21);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Log de Ejecución:";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(3, 24);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(1024, 462);
            this.LogTextBox.TabIndex = 6;
            // 
            // NombreArchivo
            // 
            this.NombreArchivo.DataPropertyName = "NombreArchivo";
            this.NombreArchivo.HeaderText = "Nombre de Archivo";
            this.NombreArchivo.Name = "NombreArchivo";
            this.NombreArchivo.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ProcesadoOK
            // 
            this.ProcesadoOK.DataPropertyName = "ProcesadoOK";
            this.ProcesadoOK.HeaderText = "Procesado OK?";
            this.ProcesadoOK.Name = "ProcesadoOK";
            this.ProcesadoOK.ReadOnly = true;
            // 
            // Mensaje
            // 
            this.Mensaje.DataPropertyName = "Mensaje";
            this.Mensaje.HeaderText = "Mensaje";
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            this.Mensaje.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mensaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormDetalleDeEnvioArhivoAWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 724);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.lblIdentificador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label1);
            this.Name = "FormDetalleDeEnvioArhivoAWeb";
            this.Text = "Detalle de Archivos Subidos a la Web";
            this.Load += new System.EventHandler(this.FormDetalleDeEnvioArhivoAWeb_Load);
            this.tabs.ResumeLayout(false);
            this.tabDetalleDeArchivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArchivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalleArchivosWeb)).EndInit();
            this.tabLogCorrida.ResumeLayout(false);
            this.tabLogCorrida.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabDetalleDeArchivos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView gridArchivos;
        private System.Windows.Forms.TabPage tabLogCorrida;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.BindingSource bsDetalleArchivosWeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProcesadoOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensaje;
    }
}