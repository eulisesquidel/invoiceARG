namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormEnviarArchivoIndividualAWeb
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
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerLog = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCAE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mskCUIT = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroCorrida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVerDetalleCorrida = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialogPdfFactura = new System.Windows.Forms.OpenFileDialog();
            this.errorProviderCargaDeDatos = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.datFechaVtoCAE = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.mskNroComprobante = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.datFechaDelComprobante = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.mskPeriodoDeFacturacion = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.datFechaDeVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.mskPtoVta = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.mskMonto = new System.Windows.Forms.MaskedTextBox();
            this.cboTipoContrato = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDiasVto = new System.Windows.Forms.Label();
            this.mskDiasVto = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCargaDeDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.openfile;
            this.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminar.Location = new System.Drawing.Point(688, 10);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(127, 23);
            this.btnExaminar.TabIndex = 16;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectorio.Location = new System.Drawing.Point(82, 12);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(566, 20);
            this.txtDirectorio.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Archivo:";
            // 
            // timerLog
            // 
            this.timerLog.Interval = 3000;
            this.timerLog.Tick += new System.EventHandler(this.timerLog_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mskDiasVto);
            this.splitContainer1.Panel1.Controls.Add(this.lblDiasVto);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.cboTipoContrato);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.mskMonto);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.mskPtoVta);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.datFechaDeVencimiento);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.mskPeriodoDeFacturacion);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.datFechaDelComprobante);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.mskNroComprobante);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.cboTipoComprobante);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.datFechaVtoCAE);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtCAE);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.mskCUIT);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnEnviar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtNroCorrida);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.btnVerDetalleCorrida);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar);
            this.splitContainer1.Panel2.Controls.Add(this.LogTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(821, 441);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 22;
            // 
            // txtCAE
            // 
            this.txtCAE.Location = new System.Drawing.Point(138, 75);
            this.txtCAE.MaxLength = 14;
            this.txtCAE.Name = "txtCAE";
            this.txtCAE.Size = new System.Drawing.Size(219, 20);
            this.txtCAE.TabIndex = 22;
            this.txtCAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCAE.Validating += new System.ComponentModel.CancelEventHandler(this.txtCAE_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "CAE";
            // 
            // mskCUIT
            // 
            this.mskCUIT.Location = new System.Drawing.Point(136, 42);
            this.mskCUIT.Mask = "00-00000000-0";
            this.mskCUIT.Name = "mskCUIT";
            this.mskCUIT.Size = new System.Drawing.Size(93, 20);
            this.mskCUIT.TabIndex = 20;
            this.mskCUIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskCUIT.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskCUIT.Validating += new System.ComponentModel.CancelEventHandler(this.mskCUIT_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "CUIT";
            // 
            // btnEnviar
            // 
            this.btnEnviar.CausesValidation = false;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(227, 403);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(149, 23);
            this.btnEnviar.TabIndex = 18;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.repetir;
            this.btnRefresh.Location = new System.Drawing.Point(77, 38);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 21);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Log Proceso:";
            // 
            // txtNroCorrida
            // 
            this.txtNroCorrida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroCorrida.Location = new System.Drawing.Point(274, 42);
            this.txtNroCorrida.Name = "txtNroCorrida";
            this.txtNroCorrida.ReadOnly = true;
            this.txtNroCorrida.Size = new System.Drawing.Size(133, 20);
            this.txtNroCorrida.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "# Envío:";
            // 
            // btnVerDetalleCorrida
            // 
            this.btnVerDetalleCorrida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalleCorrida.Enabled = false;
            this.btnVerDetalleCorrida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalleCorrida.Location = new System.Drawing.Point(3, 403);
            this.btnVerDetalleCorrida.Name = "btnVerDetalleCorrida";
            this.btnVerDetalleCorrida.Size = new System.Drawing.Size(404, 23);
            this.btnVerDetalleCorrida.TabIndex = 16;
            this.btnVerDetalleCorrida.Text = "Ver Detalle Corrida";
            this.btnVerDetalleCorrida.UseVisualStyleBackColor = true;
            this.btnVerDetalleCorrida.Click += new System.EventHandler(this.btnVerDetalleCorrida_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 68);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(404, 23);
            this.progressBar.TabIndex = 15;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(3, 100);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(404, 286);
            this.LogTextBox.TabIndex = 14;
            // 
            // openFileDialogPdfFactura
            // 
            this.openFileDialogPdfFactura.DefaultExt = "pdf";
            this.openFileDialogPdfFactura.RestoreDirectory = true;
            this.openFileDialogPdfFactura.Title = "Seleccione el archivo de factura a enviar";
            // 
            // errorProviderCargaDeDatos
            // 
            this.errorProviderCargaDeDatos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCargaDeDatos.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Fecha Vto CAE";
            // 
            // datFechaVtoCAE
            // 
            this.datFechaVtoCAE.CustomFormat = "dd/MM/yyyy";
            this.datFechaVtoCAE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datFechaVtoCAE.Location = new System.Drawing.Point(136, 109);
            this.datFechaVtoCAE.Name = "datFechaVtoCAE";
            this.datFechaVtoCAE.ShowCheckBox = true;
            this.datFechaVtoCAE.Size = new System.Drawing.Size(112, 20);
            this.datFechaVtoCAE.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Tipo de Comprobante";
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(138, 135);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(238, 21);
            this.cboTipoComprobante.TabIndex = 26;
            // 
            // mskNroComprobante
            // 
            this.mskNroComprobante.Location = new System.Drawing.Point(136, 167);
            this.mskNroComprobante.Mask = "99999999999999999999999";
            this.mskNroComprobante.Name = "mskNroComprobante";
            this.mskNroComprobante.Size = new System.Drawing.Size(147, 20);
            this.mskNroComprobante.TabIndex = 28;
            this.mskNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskNroComprobante.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskNroComprobante.Validating += new System.ComponentModel.CancelEventHandler(this.mskNroComprobante_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Nro Comprobante";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Fecha del Comprobante";
            // 
            // datFechaDelComprobante
            // 
            this.datFechaDelComprobante.CustomFormat = "dd/MM/yyyy";
            this.datFechaDelComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datFechaDelComprobante.Location = new System.Drawing.Point(136, 202);
            this.datFechaDelComprobante.Name = "datFechaDelComprobante";
            this.datFechaDelComprobante.Size = new System.Drawing.Size(112, 20);
            this.datFechaDelComprobante.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 26);
            this.label10.TabIndex = 31;
            this.label10.Text = "Período de Facturación\r\n(yyyyMM)";
            // 
            // mskPeriodoDeFacturacion
            // 
            this.mskPeriodoDeFacturacion.Location = new System.Drawing.Point(136, 235);
            this.mskPeriodoDeFacturacion.Mask = "000000";
            this.mskPeriodoDeFacturacion.Name = "mskPeriodoDeFacturacion";
            this.mskPeriodoDeFacturacion.Size = new System.Drawing.Size(44, 20);
            this.mskPeriodoDeFacturacion.TabIndex = 32;
            this.mskPeriodoDeFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskPeriodoDeFacturacion.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskPeriodoDeFacturacion.Validating += new System.ComponentModel.CancelEventHandler(this.mskPeriodoDeFacturacion_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Fecha de Vencimiento";
            // 
            // datFechaDeVencimiento
            // 
            this.datFechaDeVencimiento.Checked = false;
            this.datFechaDeVencimiento.CustomFormat = "dd/MM/yyyy";
            this.datFechaDeVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datFechaDeVencimiento.Location = new System.Drawing.Point(136, 263);
            this.datFechaDeVencimiento.Name = "datFechaDeVencimiento";
            this.datFechaDeVencimiento.ShowCheckBox = true;
            this.datFechaDeVencimiento.Size = new System.Drawing.Size(112, 20);
            this.datFechaDeVencimiento.TabIndex = 34;
            this.datFechaDeVencimiento.ValueChanged += new System.EventHandler(this.datFechaDeVencimiento_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 298);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Punto de Venta";
            // 
            // mskPtoVta
            // 
            this.mskPtoVta.Location = new System.Drawing.Point(136, 291);
            this.mskPtoVta.Mask = "9999999999";
            this.mskPtoVta.Name = "mskPtoVta";
            this.mskPtoVta.Size = new System.Drawing.Size(67, 20);
            this.mskPtoVta.TabIndex = 36;
            this.mskPtoVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskPtoVta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskPtoVta.Validating += new System.ComponentModel.CancelEventHandler(this.mskPtoVta_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Monto Total";
            // 
            // mskMonto
            // 
            this.mskMonto.Location = new System.Drawing.Point(136, 323);
            this.mskMonto.Mask = "999999999999.99";
            this.mskMonto.Name = "mskMonto";
            this.mskMonto.Size = new System.Drawing.Size(103, 20);
            this.mskMonto.TabIndex = 38;
            this.mskMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskMonto.Validating += new System.ComponentModel.CancelEventHandler(this.mskMonto_Validating);
            // 
            // cboTipoContrato
            // 
            this.cboTipoContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoContrato.FormattingEnabled = true;
            this.cboTipoContrato.Location = new System.Drawing.Point(138, 349);
            this.cboTipoContrato.Name = "cboTipoContrato";
            this.cboTipoContrato.Size = new System.Drawing.Size(238, 21);
            this.cboTipoContrato.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 352);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Tipo de Contrato";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(241, 17);
            this.label15.TabIndex = 41;
            this.label15.Text = "Datos del archivo que incorpora";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 17);
            this.label16.TabIndex = 42;
            this.label16.Text = "Progreso";
            // 
            // lblDiasVto
            // 
            this.lblDiasVto.AutoSize = true;
            this.lblDiasVto.Location = new System.Drawing.Point(255, 269);
            this.lblDiasVto.Name = "lblDiasVto";
            this.lblDiasVto.Size = new System.Drawing.Size(28, 13);
            this.lblDiasVto.TabIndex = 42;
            this.lblDiasVto.Text = "Dias";
            // 
            // mskDiasVto
            // 
            this.mskDiasVto.Location = new System.Drawing.Point(289, 263);
            this.mskDiasVto.Mask = "99";
            this.mskDiasVto.Name = "mskDiasVto";
            this.mskDiasVto.Size = new System.Drawing.Size(37, 20);
            this.mskDiasVto.TabIndex = 43;
            this.mskDiasVto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskDiasVto.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskDiasVto.Validating += new System.ComponentModel.CancelEventHandler(this.mskDiasVto_Validating);
            // 
            // FormEnviarArchivoIndividualAWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 499);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtDirectorio);
            this.Controls.Add(this.label1);
            this.Name = "FormEnviarArchivoIndividualAWeb";
            this.Text = "Enviar Archivos a la Web";
            this.Load += new System.EventHandler(this.FormEnviarArchivosAWeb_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCargaDeDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroCorrida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVerDetalleCorrida;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialogPdfFactura;
        private System.Windows.Forms.MaskedTextBox mskCUIT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCAE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProviderCargaDeDatos;
        private System.Windows.Forms.DateTimePicker datFechaVtoCAE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskNroComprobante;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datFechaDelComprobante;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskPeriodoDeFacturacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker datFechaDeVencimiento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mskPtoVta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox mskMonto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTipoContrato;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox mskDiasVto;
        private System.Windows.Forms.Label lblDiasVto;
    }
}