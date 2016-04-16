namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormAutorizador
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtNroCorrida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVerDetalleCorrida = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEventos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblComprobantesConObs = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblErroresEncontrados = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblComprobantesAutorizados = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerAutorizacion = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.txtNroCorrida);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnVerDetalleCorrida);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.LogTextBox);
            this.panel2.Controls.Add(this.btnAutorizar);
            this.panel2.Controls.Add(this.btnExaminar);
            this.panel2.Controls.Add(this.FileTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 586);
            this.panel2.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.repetir;
            this.btnRefresh.Location = new System.Drawing.Point(79, 98);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 21);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtNroCorrida
            // 
            this.txtNroCorrida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroCorrida.Location = new System.Drawing.Point(480, 95);
            this.txtNroCorrida.Name = "txtNroCorrida";
            this.txtNroCorrida.ReadOnly = true;
            this.txtNroCorrida.Size = new System.Drawing.Size(119, 20);
            this.txtNroCorrida.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ejecución #:";
            // 
            // btnVerDetalleCorrida
            // 
            this.btnVerDetalleCorrida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalleCorrida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalleCorrida.Location = new System.Drawing.Point(12, 537);
            this.btnVerDetalleCorrida.Name = "btnVerDetalleCorrida";
            this.btnVerDetalleCorrida.Size = new System.Drawing.Size(592, 23);
            this.btnVerDetalleCorrida.TabIndex = 9;
            this.btnVerDetalleCorrida.Text = "Ver Detalle Corrida";
            this.btnVerDetalleCorrida.UseVisualStyleBackColor = true;
            this.btnVerDetalleCorrida.Click += new System.EventHandler(this.btnVerDetalleCorrida_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 409);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(592, 23);
            this.progressBar.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblEventos);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblComprobantesConObs);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblErroresEncontrados);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblComprobantesAutorizados);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 438);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado";
            // 
            // lblEventos
            // 
            this.lblEventos.AutoSize = true;
            this.lblEventos.Location = new System.Drawing.Point(413, 58);
            this.lblEventos.Name = "lblEventos";
            this.lblEventos.Size = new System.Drawing.Size(49, 13);
            this.lblEventos.TabIndex = 14;
            this.lblEventos.Text = "Cantidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Eventos Encontrados:";
            // 
            // lblComprobantesConObs
            // 
            this.lblComprobantesConObs.AutoSize = true;
            this.lblComprobantesConObs.Location = new System.Drawing.Point(197, 58);
            this.lblComprobantesConObs.Name = "lblComprobantesConObs";
            this.lblComprobantesConObs.Size = new System.Drawing.Size(49, 13);
            this.lblComprobantesConObs.TabIndex = 12;
            this.lblComprobantesConObs.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Comprobantes Con Observaciones:";
            // 
            // lblErroresEncontrados
            // 
            this.lblErroresEncontrados.AutoSize = true;
            this.lblErroresEncontrados.Location = new System.Drawing.Point(413, 28);
            this.lblErroresEncontrados.Name = "lblErroresEncontrados";
            this.lblErroresEncontrados.Size = new System.Drawing.Size(49, 13);
            this.lblErroresEncontrados.TabIndex = 10;
            this.lblErroresEncontrados.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Errores Encontrados:";
            // 
            // lblComprobantesAutorizados
            // 
            this.lblComprobantesAutorizados.AutoSize = true;
            this.lblComprobantesAutorizados.Location = new System.Drawing.Point(197, 28);
            this.lblComprobantesAutorizados.Name = "lblComprobantesAutorizados";
            this.lblComprobantesAutorizados.Size = new System.Drawing.Size(49, 13);
            this.lblComprobantesAutorizados.TabIndex = 8;
            this.lblComprobantesAutorizados.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Comprobantes Autorizados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Log Proceso:";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(12, 121);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(592, 282);
            this.LogTextBox.TabIndex = 5;
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutorizar.Location = new System.Drawing.Point(15, 56);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(589, 23);
            this.btnAutorizar.TabIndex = 4;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.AutorizarButton_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.openfile;
            this.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminar.Location = new System.Drawing.Point(477, 12);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(127, 23);
            this.btnExaminar.TabIndex = 2;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.ExaminarButton_Click);
            // 
            // FileTextBox
            // 
            this.FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTextBox.Location = new System.Drawing.Point(100, 13);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.ReadOnly = true;
            this.FileTextBox.Size = new System.Drawing.Size(371, 20);
            this.FileTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo Xml:";
            // 
            // timerAutorizacion
            // 
            this.timerAutorizacion.Interval = 3500;
            this.timerAutorizacion.Tick += new System.EventHandler(this.timerAutorizacion_Tick);
            // 
            // FormAutorizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 586);
            this.Controls.Add(this.panel2);
            this.Name = "FormAutorizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizador de Comprobantes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblErroresEncontrados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblComprobantesAutorizados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timerAutorizacion;
        private System.Windows.Forms.Label lblEventos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblComprobantesConObs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVerDetalleCorrida;
        private System.Windows.Forms.TextBox txtNroCorrida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
    }
}