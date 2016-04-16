namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormAutorizadorResultados
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPathArchivo = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabAutorizados = new System.Windows.Forms.TabPage();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gridAutorizados = new System.Windows.Forms.DataGridView();
            this.ConceptoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbteDesdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbteHastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbteFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAEFechaVtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAutorizados = new System.Windows.Forms.BindingSource(this.components);
            this.tabConObservaciones = new System.Windows.Forms.TabPage();
            this.gridObservaciones = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsObservaciones = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.gridConObservaciones = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocTipoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbteDesdeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbteHastaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbteFechaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsConObservaciones = new System.Windows.Forms.BindingSource(this.components);
            this.tabErrores = new System.Windows.Forms.TabPage();
            this.gridErrores = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsErrores = new System.Windows.Forms.BindingSource(this.components);
            this.tabEventos = new System.Windows.Forms.TabPage();
            this.gridEventos = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEventos = new System.Windows.Forms.BindingSource(this.components);
            this.tabLogCorrida = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabAutorizados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAutorizados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAutorizados)).BeginInit();
            this.tabConObservaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridObservaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObservaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConObservaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConObservaciones)).BeginInit();
            this.tabErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsErrores)).BeginInit();
            this.tabEventos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEventos)).BeginInit();
            this.tabLogCorrida.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblIdentificador);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblTipoComprobante);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblPathArchivo);
            this.panel1.Controls.Add(this.lblNombreArchivo);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblArchivo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 134);
            this.panel1.TabIndex = 0;
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(117, 9);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(75, 13);
            this.lblIdentificador.TabIndex = 15;
            this.lblIdentificador.Text = "lblIdentificador";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "# Ejecución:";
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Location = new System.Drawing.Point(117, 104);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(13, 13);
            this.lblTipoComprobante.TabIndex = 13;
            this.lblTipoComprobante.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo Comprobante:";
            // 
            // lblPathArchivo
            // 
            this.lblPathArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPathArchivo.AutoSize = true;
            this.lblPathArchivo.Location = new System.Drawing.Point(117, 82);
            this.lblPathArchivo.Name = "lblPathArchivo";
            this.lblPathArchivo.Size = new System.Drawing.Size(75, 13);
            this.lblPathArchivo.TabIndex = 11;
            this.lblPathArchivo.Text = "lblPathArchivo";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(117, 57);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(90, 13);
            this.lblNombreArchivo.TabIndex = 10;
            this.lblNombreArchivo.Text = "lblNombreArchivo";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(117, 31);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 13);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "lblFecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Path Archivo:";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(12, 57);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(86, 13);
            this.lblArchivo.TabIndex = 6;
            this.lblArchivo.Text = "Nombre Archivo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha:";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabAutorizados);
            this.tabs.Controls.Add(this.tabConObservaciones);
            this.tabs.Controls.Add(this.tabErrores);
            this.tabs.Controls.Add(this.tabEventos);
            this.tabs.Controls.Add(this.tabLogCorrida);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 134);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1038, 515);
            this.tabs.TabIndex = 1;
            // 
            // tabAutorizados
            // 
            this.tabAutorizados.Controls.Add(this.btnExportar);
            this.tabAutorizados.Controls.Add(this.gridAutorizados);
            this.tabAutorizados.Location = new System.Drawing.Point(4, 22);
            this.tabAutorizados.Name = "tabAutorizados";
            this.tabAutorizados.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutorizados.Size = new System.Drawing.Size(1030, 489);
            this.tabAutorizados.TabIndex = 0;
            this.tabAutorizados.Text = "Comprobantes Autorizados";
            this.tabAutorizados.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.exportToFile16x16;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(891, 451);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(133, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // gridAutorizados
            // 
            this.gridAutorizados.AllowUserToAddRows = false;
            this.gridAutorizados.AllowUserToDeleteRows = false;
            this.gridAutorizados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAutorizados.AutoGenerateColumns = false;
            this.gridAutorizados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAutorizados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAutorizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConceptoDesc,
            this.DocTipo,
            this.docNroDataGridViewTextBoxColumn,
            this.cbteDesdeDataGridViewTextBoxColumn,
            this.cbteHastaDataGridViewTextBoxColumn,
            this.cbteFechaDataGridViewTextBoxColumn,
            this.cAEDataGridViewTextBoxColumn,
            this.cAEFechaVtoDataGridViewTextBoxColumn});
            this.gridAutorizados.DataSource = this.bsAutorizados;
            this.gridAutorizados.Location = new System.Drawing.Point(11, 6);
            this.gridAutorizados.MultiSelect = false;
            this.gridAutorizados.Name = "gridAutorizados";
            this.gridAutorizados.ReadOnly = true;
            this.gridAutorizados.RowHeadersVisible = false;
            this.gridAutorizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAutorizados.Size = new System.Drawing.Size(1013, 439);
            this.gridAutorizados.TabIndex = 0;
            // 
            // ConceptoDesc
            // 
            this.ConceptoDesc.DataPropertyName = "ConceptoDesc";
            this.ConceptoDesc.HeaderText = "Concepto";
            this.ConceptoDesc.Name = "ConceptoDesc";
            this.ConceptoDesc.ReadOnly = true;
            // 
            // DocTipo
            // 
            this.DocTipo.DataPropertyName = "DocTipoDesc";
            this.DocTipo.HeaderText = "DocTipo";
            this.DocTipo.Name = "DocTipo";
            this.DocTipo.ReadOnly = true;
            // 
            // docNroDataGridViewTextBoxColumn
            // 
            this.docNroDataGridViewTextBoxColumn.DataPropertyName = "DocNro";
            this.docNroDataGridViewTextBoxColumn.HeaderText = "DocNro";
            this.docNroDataGridViewTextBoxColumn.Name = "docNroDataGridViewTextBoxColumn";
            this.docNroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cbteDesdeDataGridViewTextBoxColumn
            // 
            this.cbteDesdeDataGridViewTextBoxColumn.DataPropertyName = "CbteDesde";
            this.cbteDesdeDataGridViewTextBoxColumn.HeaderText = "Cbte. Desde";
            this.cbteDesdeDataGridViewTextBoxColumn.Name = "cbteDesdeDataGridViewTextBoxColumn";
            this.cbteDesdeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cbteHastaDataGridViewTextBoxColumn
            // 
            this.cbteHastaDataGridViewTextBoxColumn.DataPropertyName = "CbteHasta";
            this.cbteHastaDataGridViewTextBoxColumn.HeaderText = "Cbte. Hasta";
            this.cbteHastaDataGridViewTextBoxColumn.Name = "cbteHastaDataGridViewTextBoxColumn";
            this.cbteHastaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cbteFechaDataGridViewTextBoxColumn
            // 
            this.cbteFechaDataGridViewTextBoxColumn.DataPropertyName = "CbteFecha";
            this.cbteFechaDataGridViewTextBoxColumn.HeaderText = "Cbte. Fecha";
            this.cbteFechaDataGridViewTextBoxColumn.Name = "cbteFechaDataGridViewTextBoxColumn";
            this.cbteFechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cAEDataGridViewTextBoxColumn
            // 
            this.cAEDataGridViewTextBoxColumn.DataPropertyName = "CAE";
            this.cAEDataGridViewTextBoxColumn.HeaderText = "CAE";
            this.cAEDataGridViewTextBoxColumn.Name = "cAEDataGridViewTextBoxColumn";
            this.cAEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cAEFechaVtoDataGridViewTextBoxColumn
            // 
            this.cAEFechaVtoDataGridViewTextBoxColumn.DataPropertyName = "CAEFechaVto";
            this.cAEFechaVtoDataGridViewTextBoxColumn.HeaderText = "CAE Fecha Vto.";
            this.cAEFechaVtoDataGridViewTextBoxColumn.Name = "cAEFechaVtoDataGridViewTextBoxColumn";
            this.cAEFechaVtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsAutorizados
            // 
            this.bsAutorizados.DataSource = typeof(FacturaElectronica.Common.Contracts.DetalleComprobanteDto);
            // 
            // tabConObservaciones
            // 
            this.tabConObservaciones.Controls.Add(this.gridObservaciones);
            this.tabConObservaciones.Controls.Add(this.label3);
            this.tabConObservaciones.Controls.Add(this.gridConObservaciones);
            this.tabConObservaciones.Location = new System.Drawing.Point(4, 22);
            this.tabConObservaciones.Name = "tabConObservaciones";
            this.tabConObservaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabConObservaciones.Size = new System.Drawing.Size(1030, 489);
            this.tabConObservaciones.TabIndex = 1;
            this.tabConObservaciones.Text = "Comprobantes Con Observaciones";
            this.tabConObservaciones.UseVisualStyleBackColor = true;
            // 
            // gridObservaciones
            // 
            this.gridObservaciones.AllowUserToAddRows = false;
            this.gridObservaciones.AllowUserToDeleteRows = false;
            this.gridObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridObservaciones.AutoGenerateColumns = false;
            this.gridObservaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridObservaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.mensajeDataGridViewTextBoxColumn});
            this.gridObservaciones.DataSource = this.bsObservaciones;
            this.gridObservaciones.Location = new System.Drawing.Point(11, 272);
            this.gridObservaciones.MultiSelect = false;
            this.gridObservaciones.Name = "gridObservaciones";
            this.gridObservaciones.ReadOnly = true;
            this.gridObservaciones.RowHeadersVisible = false;
            this.gridObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridObservaciones.Size = new System.Drawing.Size(1013, 208);
            this.gridObservaciones.TabIndex = 3;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.FillWeight = 30.45685F;
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 154;
            // 
            // mensajeDataGridViewTextBoxColumn
            // 
            this.mensajeDataGridViewTextBoxColumn.DataPropertyName = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn.FillWeight = 169.5432F;
            this.mensajeDataGridViewTextBoxColumn.HeaderText = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn.Name = "mensajeDataGridViewTextBoxColumn";
            this.mensajeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mensajeDataGridViewTextBoxColumn.Width = 856;
            // 
            // bsObservaciones
            // 
            this.bsObservaciones.DataSource = typeof(FacturaElectronica.Common.Contracts.ObservacionComprobanteDto);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Observaciones:";
            // 
            // gridConObservaciones
            // 
            this.gridConObservaciones.AllowUserToAddRows = false;
            this.gridConObservaciones.AllowUserToDeleteRows = false;
            this.gridConObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridConObservaciones.AutoGenerateColumns = false;
            this.gridConObservaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridConObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConObservaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.DocTipoDesc,
            this.docNroDataGridViewTextBoxColumn1,
            this.cbteDesdeDataGridViewTextBoxColumn1,
            this.cbteHastaDataGridViewTextBoxColumn1,
            this.cbteFechaDataGridViewTextBoxColumn1});
            this.gridConObservaciones.DataSource = this.bsConObservaciones;
            this.gridConObservaciones.Location = new System.Drawing.Point(11, 6);
            this.gridConObservaciones.MultiSelect = false;
            this.gridConObservaciones.Name = "gridConObservaciones";
            this.gridConObservaciones.ReadOnly = true;
            this.gridConObservaciones.RowHeadersVisible = false;
            this.gridConObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConObservaciones.Size = new System.Drawing.Size(1011, 247);
            this.gridConObservaciones.TabIndex = 1;
            this.gridConObservaciones.SelectionChanged += new System.EventHandler(this.gridConObservaciones_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ConceptoDesc";
            this.Column1.HeaderText = "Concepto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 168;
            // 
            // DocTipoDesc
            // 
            this.DocTipoDesc.DataPropertyName = "DocTipoDesc";
            this.DocTipoDesc.HeaderText = "DocTipo";
            this.DocTipoDesc.Name = "DocTipoDesc";
            this.DocTipoDesc.ReadOnly = true;
            this.DocTipoDesc.Width = 168;
            // 
            // docNroDataGridViewTextBoxColumn1
            // 
            this.docNroDataGridViewTextBoxColumn1.DataPropertyName = "DocNro";
            this.docNroDataGridViewTextBoxColumn1.HeaderText = "DocNro";
            this.docNroDataGridViewTextBoxColumn1.Name = "docNroDataGridViewTextBoxColumn1";
            this.docNroDataGridViewTextBoxColumn1.ReadOnly = true;
            this.docNroDataGridViewTextBoxColumn1.Width = 168;
            // 
            // cbteDesdeDataGridViewTextBoxColumn1
            // 
            this.cbteDesdeDataGridViewTextBoxColumn1.DataPropertyName = "CbteDesde";
            this.cbteDesdeDataGridViewTextBoxColumn1.HeaderText = "Cbte. Desde";
            this.cbteDesdeDataGridViewTextBoxColumn1.Name = "cbteDesdeDataGridViewTextBoxColumn1";
            this.cbteDesdeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cbteDesdeDataGridViewTextBoxColumn1.Width = 168;
            // 
            // cbteHastaDataGridViewTextBoxColumn1
            // 
            this.cbteHastaDataGridViewTextBoxColumn1.DataPropertyName = "CbteHasta";
            this.cbteHastaDataGridViewTextBoxColumn1.HeaderText = "Cbte. Hasta";
            this.cbteHastaDataGridViewTextBoxColumn1.Name = "cbteHastaDataGridViewTextBoxColumn1";
            this.cbteHastaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cbteHastaDataGridViewTextBoxColumn1.Width = 168;
            // 
            // cbteFechaDataGridViewTextBoxColumn1
            // 
            this.cbteFechaDataGridViewTextBoxColumn1.DataPropertyName = "CbteFecha";
            this.cbteFechaDataGridViewTextBoxColumn1.HeaderText = "Cbte. Fecha";
            this.cbteFechaDataGridViewTextBoxColumn1.Name = "cbteFechaDataGridViewTextBoxColumn1";
            this.cbteFechaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cbteFechaDataGridViewTextBoxColumn1.Width = 168;
            // 
            // bsConObservaciones
            // 
            this.bsConObservaciones.DataSource = typeof(FacturaElectronica.Common.Contracts.DetalleComprobanteDto);
            // 
            // tabErrores
            // 
            this.tabErrores.Controls.Add(this.gridErrores);
            this.tabErrores.Location = new System.Drawing.Point(4, 22);
            this.tabErrores.Name = "tabErrores";
            this.tabErrores.Size = new System.Drawing.Size(1030, 489);
            this.tabErrores.TabIndex = 2;
            this.tabErrores.Text = "Errores";
            this.tabErrores.UseVisualStyleBackColor = true;
            // 
            // gridErrores
            // 
            this.gridErrores.AllowUserToAddRows = false;
            this.gridErrores.AllowUserToDeleteRows = false;
            this.gridErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridErrores.AutoGenerateColumns = false;
            this.gridErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn1,
            this.mensajeDataGridViewTextBoxColumn1});
            this.gridErrores.DataSource = this.bsErrores;
            this.gridErrores.Location = new System.Drawing.Point(11, 6);
            this.gridErrores.MultiSelect = false;
            this.gridErrores.Name = "gridErrores";
            this.gridErrores.ReadOnly = true;
            this.gridErrores.RowHeadersVisible = false;
            this.gridErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridErrores.Size = new System.Drawing.Size(1011, 464);
            this.gridErrores.TabIndex = 1;
            // 
            // codigoDataGridViewTextBoxColumn1
            // 
            this.codigoDataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn1.FillWeight = 30.45685F;
            this.codigoDataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn1.Name = "codigoDataGridViewTextBoxColumn1";
            this.codigoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // mensajeDataGridViewTextBoxColumn1
            // 
            this.mensajeDataGridViewTextBoxColumn1.DataPropertyName = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn1.FillWeight = 169.5432F;
            this.mensajeDataGridViewTextBoxColumn1.HeaderText = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn1.Name = "mensajeDataGridViewTextBoxColumn1";
            this.mensajeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bsErrores
            // 
            this.bsErrores.DataSource = typeof(FacturaElectronica.Common.Contracts.DetalleErrorDto);
            // 
            // tabEventos
            // 
            this.tabEventos.Controls.Add(this.gridEventos);
            this.tabEventos.Location = new System.Drawing.Point(4, 22);
            this.tabEventos.Name = "tabEventos";
            this.tabEventos.Size = new System.Drawing.Size(1030, 489);
            this.tabEventos.TabIndex = 3;
            this.tabEventos.Text = "Eventos";
            this.tabEventos.UseVisualStyleBackColor = true;
            // 
            // gridEventos
            // 
            this.gridEventos.AllowUserToAddRows = false;
            this.gridEventos.AllowUserToDeleteRows = false;
            this.gridEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEventos.AutoGenerateColumns = false;
            this.gridEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEventos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn2,
            this.mensajeDataGridViewTextBoxColumn2});
            this.gridEventos.DataSource = this.bsEventos;
            this.gridEventos.Location = new System.Drawing.Point(11, 6);
            this.gridEventos.Name = "gridEventos";
            this.gridEventos.RowHeadersVisible = false;
            this.gridEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEventos.Size = new System.Drawing.Size(1011, 464);
            this.gridEventos.TabIndex = 2;
            // 
            // codigoDataGridViewTextBoxColumn2
            // 
            this.codigoDataGridViewTextBoxColumn2.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn2.FillWeight = 30.45685F;
            this.codigoDataGridViewTextBoxColumn2.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn2.Name = "codigoDataGridViewTextBoxColumn2";
            // 
            // mensajeDataGridViewTextBoxColumn2
            // 
            this.mensajeDataGridViewTextBoxColumn2.DataPropertyName = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn2.FillWeight = 169.5432F;
            this.mensajeDataGridViewTextBoxColumn2.HeaderText = "Mensaje";
            this.mensajeDataGridViewTextBoxColumn2.Name = "mensajeDataGridViewTextBoxColumn2";
            // 
            // bsEventos
            // 
            this.bsEventos.DataSource = typeof(FacturaElectronica.Common.Contracts.DetalleEventoDto);
            // 
            // tabLogCorrida
            // 
            this.tabLogCorrida.Controls.Add(this.btnRefresh);
            this.tabLogCorrida.Controls.Add(this.label4);
            this.tabLogCorrida.Controls.Add(this.LogTextBox);
            this.tabLogCorrida.Location = new System.Drawing.Point(4, 22);
            this.tabLogCorrida.Name = "tabLogCorrida";
            this.tabLogCorrida.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogCorrida.Size = new System.Drawing.Size(1030, 489);
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // FormAutorizadorResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 649);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panel1);
            this.Name = "FormAutorizadorResultados";
            this.Text = "Resultados Autorización";
            this.Load += new System.EventHandler(this.FormAutorizadorResultados_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabAutorizados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAutorizados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAutorizados)).EndInit();
            this.tabConObservaciones.ResumeLayout(false);
            this.tabConObservaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridObservaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObservaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridConObservaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConObservaciones)).EndInit();
            this.tabErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsErrores)).EndInit();
            this.tabEventos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEventos)).EndInit();
            this.tabLogCorrida.ResumeLayout(false);
            this.tabLogCorrida.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabAutorizados;
        private System.Windows.Forms.DataGridView gridAutorizados;
        private System.Windows.Forms.TabPage tabConObservaciones;
        private System.Windows.Forms.TabPage tabErrores;
        private System.Windows.Forms.TabPage tabEventos;
        private System.Windows.Forms.DataGridView gridObservaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridConObservaciones;
        private System.Windows.Forms.DataGridView gridErrores;
        private System.Windows.Forms.DataGridView gridEventos;
        private System.Windows.Forms.BindingSource bsAutorizados;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsConObservaciones;
        private System.Windows.Forms.BindingSource bsObservaciones;
        private System.Windows.Forms.BindingSource bsErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource bsEventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajeDataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblPathArchivo;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbteDesdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbteHastaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbteFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAEFechaVtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocTipoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbteDesdeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbteHastaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbteFechaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabLogCorrida;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;

    }
}