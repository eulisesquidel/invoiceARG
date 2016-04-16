namespace FacturaElectronica.Ui.Win.Administrador
{
    partial class FormConsultaWebServicesAFIP
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbWebService = new System.Windows.Forms.ComboBox();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.panelMoneda = new System.Windows.Forms.Panel();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResultados = new System.Windows.Forms.Label();
            this.panelUltimoCbte = new System.Windows.Forms.Panel();
            this.cbTiposCbte = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPtoVta = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gridResultados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescripcionWs = new System.Windows.Forms.Label();
            this.lblNombreWs = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.panelGetComprobanteFex = new System.Windows.Forms.Panel();
            this.cbPtosVtaFex = new System.Windows.Forms.ComboBox();
            this.txtNroCbteFex = new System.Windows.Forms.MaskedTextBox();
            this.cbTiposCbteFex = new System.Windows.Forms.ComboBox();
            this.lblNroCbteFex = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMoneda.SuspendLayout();
            this.panelUltimoCbte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelGetComprobanteFex.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Web Service:";
            // 
            // cbWebService
            // 
            this.cbWebService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWebService.FormattingEnabled = true;
            this.cbWebService.Location = new System.Drawing.Point(90, 68);
            this.cbWebService.Name = "cbWebService";
            this.cbWebService.Size = new System.Drawing.Size(496, 21);
            this.cbWebService.TabIndex = 1;
            this.cbWebService.SelectedIndexChanged += new System.EventHandler(this.cbWebService_SelectedIndexChanged);
            // 
            // txtResultados
            // 
            this.txtResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultados.Location = new System.Drawing.Point(15, 493);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.Size = new System.Drawing.Size(802, 124);
            this.txtResultados.TabIndex = 2;
            // 
            // panelMoneda
            // 
            this.panelMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMoneda.Controls.Add(this.cbMoneda);
            this.panelMoneda.Controls.Add(this.label2);
            this.panelMoneda.Location = new System.Drawing.Point(17, 95);
            this.panelMoneda.Name = "panelMoneda";
            this.panelMoneda.Size = new System.Drawing.Size(802, 46);
            this.panelMoneda.TabIndex = 3;
            // 
            // cbMoneda
            // 
            this.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(127, 8);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(207, 21);
            this.cbMoneda.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Moneda:";
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(17, 477);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(63, 13);
            this.lblResultados.TabIndex = 4;
            this.lblResultados.Text = "Resultados:";
            // 
            // panelUltimoCbte
            // 
            this.panelUltimoCbte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUltimoCbte.Controls.Add(this.cbTiposCbte);
            this.panelUltimoCbte.Controls.Add(this.label5);
            this.panelUltimoCbte.Controls.Add(this.txtPtoVta);
            this.panelUltimoCbte.Controls.Add(this.label4);
            this.panelUltimoCbte.Location = new System.Drawing.Point(15, 147);
            this.panelUltimoCbte.Name = "panelUltimoCbte";
            this.panelUltimoCbte.Size = new System.Drawing.Size(802, 64);
            this.panelUltimoCbte.TabIndex = 5;
            // 
            // cbTiposCbte
            // 
            this.cbTiposCbte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTiposCbte.FormattingEnabled = true;
            this.cbTiposCbte.Location = new System.Drawing.Point(162, 31);
            this.cbTiposCbte.Name = "cbTiposCbte";
            this.cbTiposCbte.Size = new System.Drawing.Size(286, 21);
            this.cbTiposCbte.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tipo Cbte.:";
            // 
            // txtPtoVta
            // 
            this.txtPtoVta.Location = new System.Drawing.Point(162, 5);
            this.txtPtoVta.Mask = "9999";
            this.txtPtoVta.Name = "txtPtoVta";
            this.txtPtoVta.Size = new System.Drawing.Size(41, 20);
            this.txtPtoVta.TabIndex = 2;
            this.txtPtoVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPtoVta.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Punto de Venta:";
            // 
            // gridResultados
            // 
            this.gridResultados.AllowUserToAddRows = false;
            this.gridResultados.AllowUserToDeleteRows = false;
            this.gridResultados.AllowUserToResizeRows = false;
            this.gridResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultados.Location = new System.Drawing.Point(15, 493);
            this.gridResultados.MultiSelect = false;
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.ReadOnly = true;
            this.gridResultados.RowHeadersVisible = false;
            this.gridResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResultados.Size = new System.Drawing.Size(802, 124);
            this.gridResultados.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblDescripcionWs);
            this.panel1.Controls.Add(this.lblNombreWs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 62);
            this.panel1.TabIndex = 8;
            // 
            // lblDescripcionWs
            // 
            this.lblDescripcionWs.AutoSize = true;
            this.lblDescripcionWs.Location = new System.Drawing.Point(27, 34);
            this.lblDescripcionWs.Name = "lblDescripcionWs";
            this.lblDescripcionWs.Size = new System.Drawing.Size(89, 13);
            this.lblDescripcionWs.TabIndex = 1;
            this.lblDescripcionWs.Text = "lblDescripcionWs";
            // 
            // lblNombreWs
            // 
            this.lblNombreWs.AutoSize = true;
            this.lblNombreWs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreWs.Location = new System.Drawing.Point(27, 9);
            this.lblNombreWs.Name = "lblNombreWs";
            this.lblNombreWs.Size = new System.Drawing.Size(81, 13);
            this.lblNombreWs.TabIndex = 0;
            this.lblNombreWs.Text = "lblNombreWs";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Image = global::FacturaElectronica.Ui.Win.Administrador.Properties.Resources.search16x16;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(696, 464);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(121, 23);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // panelGetComprobanteFex
            // 
            this.panelGetComprobanteFex.Controls.Add(this.cbPtosVtaFex);
            this.panelGetComprobanteFex.Controls.Add(this.txtNroCbteFex);
            this.panelGetComprobanteFex.Controls.Add(this.cbTiposCbteFex);
            this.panelGetComprobanteFex.Controls.Add(this.lblNroCbteFex);
            this.panelGetComprobanteFex.Controls.Add(this.label6);
            this.panelGetComprobanteFex.Controls.Add(this.label3);
            this.panelGetComprobanteFex.Location = new System.Drawing.Point(15, 217);
            this.panelGetComprobanteFex.Name = "panelGetComprobanteFex";
            this.panelGetComprobanteFex.Size = new System.Drawing.Size(802, 89);
            this.panelGetComprobanteFex.TabIndex = 5;
            // 
            // cbPtosVtaFex
            // 
            this.cbPtosVtaFex.FormattingEnabled = true;
            this.cbPtosVtaFex.Location = new System.Drawing.Point(232, 35);
            this.cbPtosVtaFex.Name = "cbPtosVtaFex";
            this.cbPtosVtaFex.Size = new System.Drawing.Size(260, 21);
            this.cbPtosVtaFex.TabIndex = 6;
            // 
            // txtNroCbteFex
            // 
            this.txtNroCbteFex.Location = new System.Drawing.Point(233, 61);
            this.txtNroCbteFex.Mask = "99999999";
            this.txtNroCbteFex.Name = "txtNroCbteFex";
            this.txtNroCbteFex.Size = new System.Drawing.Size(60, 20);
            this.txtNroCbteFex.TabIndex = 5;
            // 
            // cbTiposCbteFex
            // 
            this.cbTiposCbteFex.FormattingEnabled = true;
            this.cbTiposCbteFex.Location = new System.Drawing.Point(232, 8);
            this.cbTiposCbteFex.Name = "cbTiposCbteFex";
            this.cbTiposCbteFex.Size = new System.Drawing.Size(260, 21);
            this.cbTiposCbteFex.TabIndex = 3;
            // 
            // lblNroCbteFex
            // 
            this.lblNroCbteFex.AutoSize = true;
            this.lblNroCbteFex.Location = new System.Drawing.Point(133, 63);
            this.lblNroCbteFex.Name = "lblNroCbteFex";
            this.lblNroCbteFex.Size = new System.Drawing.Size(93, 13);
            this.lblNroCbteFex.TabIndex = 2;
            this.lblNroCbteFex.Text = "Nro Comprobante:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pto de Vta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo Comprobante:";
            // 
            // FormConsultaWebServicesAFIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 627);
            this.Controls.Add(this.panelGetComprobanteFex);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridResultados);
            this.Controls.Add(this.panelUltimoCbte);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.panelMoneda);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.txtResultados);
            this.Controls.Add(this.cbWebService);
            this.Controls.Add(this.label1);
            this.Name = "FormConsultaWebServicesAFIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta Web Services AFIP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMoneda.ResumeLayout(false);
            this.panelMoneda.PerformLayout();
            this.panelUltimoCbte.ResumeLayout(false);
            this.panelUltimoCbte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelGetComprobanteFex.ResumeLayout(false);
            this.panelGetComprobanteFex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWebService;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.Panel panelMoneda;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Panel panelUltimoCbte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtPtoVta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTiposCbte;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView gridResultados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescripcionWs;
        private System.Windows.Forms.Label lblNombreWs;
        private System.Windows.Forms.Panel panelGetComprobanteFex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTiposCbteFex;
        private System.Windows.Forms.Label lblNroCbteFex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtNroCbteFex;
        private System.Windows.Forms.ComboBox cbPtosVtaFex;
    }
}