namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormEnviarArchivosAWeb
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
            this.btnVerDetalleCorrida = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.txtNroCorrida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerLog = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialogFilesForUpLoad = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerDetalleCorrida
            // 
            this.btnVerDetalleCorrida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalleCorrida.Enabled = false;
            this.btnVerDetalleCorrida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalleCorrida.Location = new System.Drawing.Point(15, 446);
            this.btnVerDetalleCorrida.Name = "btnVerDetalleCorrida";
            this.btnVerDetalleCorrida.Size = new System.Drawing.Size(704, 23);
            this.btnVerDetalleCorrida.TabIndex = 13;
            this.btnVerDetalleCorrida.Text = "Ver Detalle Corrida";
            this.btnVerDetalleCorrida.UseVisualStyleBackColor = true;
            this.btnVerDetalleCorrida.Click += new System.EventHandler(this.btnVerDetalleCorrida_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 395);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(704, 23);
            this.progressBar.TabIndex = 12;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(15, 120);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(704, 259);
            this.LogTextBox.TabIndex = 10;
            // 
            // txtNroCorrida
            // 
            this.txtNroCorrida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroCorrida.Location = new System.Drawing.Point(586, 94);
            this.txtNroCorrida.Name = "txtNroCorrida";
            this.txtNroCorrida.ReadOnly = true;
            this.txtNroCorrida.Size = new System.Drawing.Size(133, 20);
            this.txtNroCorrida.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "# Envío:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Log Proceso:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(12, 55);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(707, 23);
            this.btnEnviar.TabIndex = 17;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.openfile;
            this.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminar.Location = new System.Drawing.Point(592, 10);
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
            this.txtDirectorio.Size = new System.Drawing.Size(504, 20);
            this.txtDirectorio.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Directorio:";
            // 
            // timerLog
            // 
            this.timerLog.Interval = 3000;
            this.timerLog.Tick += new System.EventHandler(this.timerLog_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.repetir;
            this.btnRefresh.Location = new System.Drawing.Point(82, 94);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 21);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormEnviarArchivosAWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 478);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtNroCorrida);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtDirectorio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerDetalleCorrida);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.LogTextBox);
            this.Name = "FormEnviarArchivosAWeb";
            this.Text = "Enviar Archivos a la Web";
            this.Load += new System.EventHandler(this.FormEnviarArchivosAWeb_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerDetalleCorrida;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TextBox txtNroCorrida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerLog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogFilesForUpLoad;
        private System.Windows.Forms.Button btnRefresh;
    }
}