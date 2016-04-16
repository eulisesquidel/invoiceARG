namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormCorridas
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
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gridCorridas = new System.Windows.Forms.DataGridView();
            this.bsCorridas = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCantidadReg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDeArchivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathArchivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCorridas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorridas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "";
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(92, 46);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(83, 20);
            this.dtpFechaDesde.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Desde:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(285, 46);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(83, 20);
            this.dtpFechaHasta.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha Hasta:";
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
            this.fechaDataGridViewTextBoxColumn,
            this.nombreDeArchivoDataGridViewTextBoxColumn,
            this.pathArchivoDataGridViewTextBoxColumn});
            this.gridCorridas.DataSource = this.bsCorridas;
            this.gridCorridas.Location = new System.Drawing.Point(12, 93);
            this.gridCorridas.MultiSelect = false;
            this.gridCorridas.Name = "gridCorridas";
            this.gridCorridas.ReadOnly = true;
            this.gridCorridas.RowHeadersVisible = false;
            this.gridCorridas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCorridas.Size = new System.Drawing.Size(860, 410);
            this.gridCorridas.TabIndex = 10;
            this.gridCorridas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCorridas_CellDoubleClick);
            // 
            // bsCorridas
            // 
            this.bsCorridas.DataSource = typeof(FacturaElectronica.Common.Contracts.CorridaAutorizacionDto);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Solicitudes de Autorizacion:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.search16x16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(765, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(13, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cantidad Registros:";
            // 
            // lblCantidadReg
            // 
            this.lblCantidadReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadReg.AutoSize = true;
            this.lblCantidadReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadReg.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCantidadReg.Location = new System.Drawing.Point(137, 508);
            this.lblCantidadReg.Name = "lblCantidadReg";
            this.lblCantidadReg.Size = new System.Drawing.Size(93, 13);
            this.lblCantidadReg.TabIndex = 14;
            this.lblCantidadReg.Text = "lblCantidadReg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "# Ejecución:";
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(92, 16);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(160, 20);
            this.txtIdentificador.TabIndex = 16;
            this.txtIdentificador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificador_KeyPress);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 60.91371F;
            this.Id.HeaderText = "# Ejecución";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.FillWeight = 64.08591F;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDeArchivoDataGridViewTextBoxColumn
            // 
            this.nombreDeArchivoDataGridViewTextBoxColumn.DataPropertyName = "NombreDeArchivo";
            this.nombreDeArchivoDataGridViewTextBoxColumn.FillWeight = 102.8753F;
            this.nombreDeArchivoDataGridViewTextBoxColumn.HeaderText = "Nombre de Archivo";
            this.nombreDeArchivoDataGridViewTextBoxColumn.Name = "nombreDeArchivoDataGridViewTextBoxColumn";
            this.nombreDeArchivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathArchivoDataGridViewTextBoxColumn
            // 
            this.pathArchivoDataGridViewTextBoxColumn.DataPropertyName = "PathArchivo";
            this.pathArchivoDataGridViewTextBoxColumn.FillWeight = 172.1251F;
            this.pathArchivoDataGridViewTextBoxColumn.HeaderText = "Path Archivo";
            this.pathArchivoDataGridViewTextBoxColumn.Name = "pathArchivoDataGridViewTextBoxColumn";
            this.pathArchivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormCorridas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 530);
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
            this.Name = "FormCorridas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitudes de Autorizacion";
            ((System.ComponentModel.ISupportInitialize)(this.gridCorridas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorridas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridCorridas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bsCorridas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantidadReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDeArchivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathArchivoDataGridViewTextBoxColumn;
    }
}