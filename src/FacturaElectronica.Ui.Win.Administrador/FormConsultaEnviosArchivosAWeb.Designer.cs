namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormConsultaEnviosArchivosAWeb
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
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCantidadReg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridCorridas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procesada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsCorridaSubidaArchivo = new System.Windows.Forms.BindingSource(this.components);
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreDeArchivo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procesadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCorridas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorridaSubidaArchivo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(101, 13);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(160, 20);
            this.txtIdentificador.TabIndex = 27;
            this.txtIdentificador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificador_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "# Envío:";
            // 
            // lblCantidadReg
            // 
            this.lblCantidadReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadReg.AutoSize = true;
            this.lblCantidadReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadReg.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCantidadReg.Location = new System.Drawing.Point(146, 505);
            this.lblCantidadReg.Name = "lblCantidadReg";
            this.lblCantidadReg.Size = new System.Drawing.Size(93, 13);
            this.lblCantidadReg.TabIndex = 25;
            this.lblCantidadReg.Text = "lblCantidadReg";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(22, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cantidad Registros:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Envíos de archivos a la web";
            // 
            // gridCorridas
            // 
            this.gridCorridas.AllowUserToAddRows = false;
            this.gridCorridas.AllowUserToDeleteRows = false;
            this.gridCorridas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCorridas.AutoGenerateColumns = false;
            this.gridCorridas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCorridas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCorridas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FechaProceso,
            this.Procesada,
            this.idDataGridViewTextBoxColumn,
            this.fechaProcesoDataGridViewTextBoxColumn,
            this.procesadaDataGridViewTextBoxColumn});
            this.gridCorridas.DataSource = this.bsCorridaSubidaArchivo;
            this.gridCorridas.Location = new System.Drawing.Point(21, 90);
            this.gridCorridas.Name = "gridCorridas";
            this.gridCorridas.ReadOnly = true;
            this.gridCorridas.RowHeadersVisible = false;
            this.gridCorridas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCorridas.Size = new System.Drawing.Size(860, 410);
            this.gridCorridas.TabIndex = 21;
            this.gridCorridas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCorridas_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 60.91371F;
            this.Id.HeaderText = "# Envío";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // FechaProceso
            // 
            this.FechaProceso.DataPropertyName = "FechaProceso";
            this.FechaProceso.HeaderText = "Fecha de Proceso";
            this.FechaProceso.Name = "FechaProceso";
            this.FechaProceso.ReadOnly = true;
            // 
            // Procesada
            // 
            this.Procesada.DataPropertyName = "Procesada";
            this.Procesada.HeaderText = "Procesada";
            this.Procesada.Name = "Procesada";
            this.Procesada.ReadOnly = true;
            // 
            // bsCorridaSubidaArchivo
            // 
            this.bsCorridaSubidaArchivo.DataSource = typeof(FacturaElectronica.Common.Contracts.CorridaSubidaArchivoDto);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(294, 43);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(83, 20);
            this.dtpFechaHasta.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha Hasta:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "";
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(101, 43);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(83, 20);
            this.dtpFechaDesde.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha Desde:";
            // 
            // txtNombreDeArchivo
            // 
            this.txtNombreDeArchivo.Location = new System.Drawing.Point(405, 12);
            this.txtNombreDeArchivo.Name = "txtNombreDeArchivo";
            this.txtNombreDeArchivo.Size = new System.Drawing.Size(234, 20);
            this.txtNombreDeArchivo.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Nombre de Archivo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.search16x16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(774, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 23);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaProcesoDataGridViewTextBoxColumn
            // 
            this.fechaProcesoDataGridViewTextBoxColumn.DataPropertyName = "FechaProceso";
            this.fechaProcesoDataGridViewTextBoxColumn.HeaderText = "FechaProceso";
            this.fechaProcesoDataGridViewTextBoxColumn.Name = "fechaProcesoDataGridViewTextBoxColumn";
            this.fechaProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // procesadaDataGridViewTextBoxColumn
            // 
            this.procesadaDataGridViewTextBoxColumn.DataPropertyName = "Procesada";
            this.procesadaDataGridViewTextBoxColumn.HeaderText = "Procesada";
            this.procesadaDataGridViewTextBoxColumn.Name = "procesadaDataGridViewTextBoxColumn";
            this.procesadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormConsultaEnviosArchivosAWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 530);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombreDeArchivo);
            this.Controls.Add(this.txtIdentificador);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCantidadReg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridCorridas);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label1);
            this.Name = "FormConsultaEnviosArchivosAWeb";
            this.Text = "Consulta de Archivos Enviados a la Web";
            ((System.ComponentModel.ISupportInitialize)(this.gridCorridas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorridaSubidaArchivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCantidadReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridCorridas;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreDeArchivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bsCorridaSubidaArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProceso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Procesada;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn procesadaDataGridViewTextBoxColumn;
    }
}