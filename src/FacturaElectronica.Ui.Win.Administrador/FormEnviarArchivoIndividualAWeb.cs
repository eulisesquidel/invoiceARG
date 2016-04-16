using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Ui.Win.Administrador.Code;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts.Search;
using System.Configuration;
using System.Threading;
using FacturaElectronica.Ui.Win.Administrador.Code.Ejecucion;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormEnviarArchivoIndividualAWeb : Form
    {
        private ISubidaArchivoService SubidaArchivoService = ServiceFactory.GetSubidaArchivoService();
        private IComprobanteService ComprobanteService = ServiceFactory.GetComprobanteService();

        private DateTime fechaLog = DateTime.MinValue;
        private long lastLogId = 0;

        public FormEnviarArchivoIndividualAWeb()
        {
            InitializeComponent();
        }

        private void FormEnviarArchivosAWeb_Load(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialogPdfFactura.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                LoadCbo();
                datFechaDeVencimiento_ValueChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCbo()
        {
            List<TipoContratoDto> tiposDeContrato = ComprobanteService.ObtenerTiposContrato();
            this.cboTipoContrato.DataSource = tiposDeContrato;
            this.cboTipoContrato.ValueMember = "Codigo";
            this.cboTipoContrato.DisplayMember = "ShowDescription";

            if (tiposDeContrato.Where(t => t.Codigo == "OTROS").Count() > 0)
            {
                cboTipoContrato.SelectedValue = "OTROS";
            }

            List<TipoComprobanteDto> tiposDeComprobatne = ComprobanteService.ObtenerTiposComprobantes();
            this.cboTipoComprobante.DataSource = tiposDeComprobatne;
            this.cboTipoComprobante.ValueMember = "Codigo";
            this.cboTipoComprobante.DisplayMember = "ShowDescription";

            if (tiposDeComprobatne.Where(c => c.Codigo == "FCE").Count() > 0)
            {
                this.cboTipoComprobante.SelectedValue = "FCE";
            }
        }

        private void timerLog_Tick(object sender, EventArgs e)
        {
            try
            {
                MostrarLog();
            }
            catch (Exception ex)
            {
                timerLog.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogPdfFactura.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtDirectorio.Text = openFileDialogPdfFactura.FileName;
                    this.ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetForm()
        {
            this.LogTextBox.Clear();
            this.txtNroCorrida.Text = string.Empty;
            this.btnVerDetalleCorrida.Enabled = false;
            lastLogId = 0;
            this.fechaLog = DateTime.MinValue;
            this.txtNroCorrida.Text = string.Empty;
        }

        private CorridaSubidaArchivoDto CorridaSubidaArchivo = new CorridaSubidaArchivoDto();

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                timerLog.Stop();
                this.LogTextBox.Clear();
                string sourceDirectory = this.txtDirectorio.Text;
                List<string> fileList = new List<string>();
                this.btnVerDetalleCorrida.Enabled = false;
                lastLogId = 0;
                this.fechaLog = DateTime.MinValue;
                this.txtNroCorrida.Text = string.Empty;

                if (File.Exists(sourceDirectory))
                {
                    EjecutarCorridaSubidaArchivo corrida = new EjecutarCorridaSubidaArchivo();

                    // Obtengo los archivos a procesar
                    fileList.Add(sourceDirectory);

                    // Asigno lo valores de la pantalla al objeto corrida
                    if (AsignarValoresEnPantallaACorrida(corrida))
                    {
                        if (fileList.Count > 0)
                        {
                            // Genero una corrida
                            MostrarMensajeEnLog("Creando Corrida...");
                            CorridaSubidaArchivo = SubidaArchivoService.CrearNuevaCorrida();

                            this.txtNroCorrida.Text = CorridaSubidaArchivo.Id.ToString();

                            // Copio los archivos al server de telefónica
                            MostrarMensajeEnLog("Copiando Archivos al Servidor...");

                            this.Refresh();

                            //fileList = CopiarArchivosParaProcesar(fileList);
                            fileList = CopiarArchivosParaProcesarPorFTP(fileList);

                            // Ejecuto
                            MostrarMensajeEnLog("Enviando mensaje de ejecución asincrónica...");

                            corrida.CorridaId = CorridaSubidaArchivo.Id;
                            corrida.FileNames = fileList;
                            corrida.ForzarDatosCliente = true;

                            // Asigno los datos de la pantalla;

                            // Activo el timer porque a veces no retorna la siguiente llamada
                            fechaLog = DateTime.MinValue;
                            timerLog.Interval = 3000;
                            timerLog.Start();

                            ThreadPool.QueueUserWorkItem(new WaitCallback(EjecutarCorridaCallBack), corrida);
                        }
                    }
                }
                else
                {
                    errorProviderCargaDeDatos.SetError(this.txtDirectorio, "Debe seleccionar un archivo");
                }
            }
            catch (Exception ex)
            {
                string message = GetExceptionMessage(ex) + GetExceptionStackTrace(ex);
                MessageBox.Show(message);
            }
        }

        private bool AsignarValoresEnPantallaACorrida(EjecutarCorridaSubidaArchivo corrida)
        {
            bool validadoOk = false;
            errorProviderCargaDeDatos.Clear();
            bool validoCUIT = ValidarCUIT();
            bool validoCAE = ValidarCAE();
            bool validoMonto = ValidarMonto();
            bool validoNroComprobante = ValidarNroComprobante();
            bool validoPeriodoFacturacion = ValidarPeriodoDeFacturacion();
            bool validoPuntoDeVenta = ValidarPuntoDeVenta();
            bool diasDeVto = ValidarDiasDeVto();

            validadoOk = validoCUIT && validoCAE && validoMonto && validoNroComprobante && validoPeriodoFacturacion && validoPuntoDeVenta && diasDeVto;

            if (validadoOk)
            {
                // Asignar los valores en pantalla (luego hacer el servicio y listo liston
                corrida.Cuit = this.mskCUIT.Text.Trim();
                corrida.CAE = this.txtCAE.Text.Trim();
                if (this.datFechaVtoCAE.Checked)
                {
                    corrida.FechaVencimientoCAE = this.datFechaVtoCAE.Value;
                }

                corrida.TipoDeComprobanteCodigo = Convert.ToString(this.cboTipoComprobante.SelectedValue);
                corrida.NroComprobante = Convert.ToInt64(this.mskNroComprobante.Text);

                corrida.FechaComprobante = datFechaDelComprobante.Value;

                corrida.PeriodoDeFacturacion = this.mskPeriodoDeFacturacion.Text.Trim();

                if (this.datFechaDeVencimiento.Checked)
                {
                    corrida.FechaDeVencimiento = this.datFechaDeVencimiento.Value;
                }
                else
                {
                    corrida.DiasDeVencimiento = Convert.ToInt32(this.mskDiasVto.Text.Trim());
                }

                corrida.PuntoDeVenta = Convert.ToInt32(this.mskPtoVta.Text.Trim());

                corrida.MontoTotal = this.mskMonto.Text.Trim().Replace(",", "."); // ya está validado de antes               

                corrida.TipoContratoCodigo = this.cboTipoContrato.SelectedValue.ToString();

                
            }

            return validadoOk;
        }

        public string GetExceptionMessage(Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            Exception current = ex;
            while (current != null)
            {
                builder.Append(current.Message);
                current = current.InnerException;
            }

            return builder.ToString();
        }

        public string GetExceptionStackTrace(Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            Exception current = ex;
            while (current != null)
            {
                builder.Append(current.StackTrace);
                current = current.InnerException;
            }

            return builder.ToString();
        }

        private void EjecutarCorridaCallBack(object state)
        {
            EjecutarCorridaSubidaArchivo corrida = (EjecutarCorridaSubidaArchivo)state;
            SubidaArchivoService.EjecutarCorrida(corrida);
        }

        private const int bufferLength = 2048;

        private List<string> CopiarArchivosParaProcesarPorFTP(List<string> fileList)
        {
            List<string> filesInServerList = new List<string>();

            FtpClient ftpClient = new FtpClient();
            ftpClient.LoadFromConfig();

            List<string> folders = ftpClient.GetFolders(ftpClient.FTPAddress);

            if (folders.Where(f => f.Contains("ArchivosPDF")).Count() == 0)
            {
                ftpClient.CreateDirectory(ftpClient.FTPAddress + "ArchivosPDF");
            }

            ftpClient.CreateDirectory(ftpClient.FTPAddress + "ArchivosPDF/" + CorridaSubidaArchivo.Id.ToString());

            string addressForCorrida = ftpClient.FTPAddress + "ArchivosPDF/" + CorridaSubidaArchivo.Id.ToString() + "/AProcesar/";

            ftpClient.Notify += new FtpClient.NotifyDelegate(MostrarMensajeEnLog); // Uno el evento con el metodo de notificar en el log

            ftpClient.CreateDirectory(addressForCorrida);

            // Por cada archivo lo subo a la carpeta en el servidor remoto
            foreach (string file in fileList)
            {
                string fileName = Path.GetFileName(file);

                ftpClient.UploadFile(file, addressForCorrida + fileName);

                filesInServerList.Add(fileName);
            }

            return filesInServerList;
        }

        private void MostrarMensajeEnLog(string text)
        {
            this.LogTextBox.Text += text + Environment.NewLine;
        }

        private void MostrarLog()
        {
            CorridaSubidaArchivoSearch search = new CorridaSubidaArchivoSearch();
            search.CorridaId = CorridaSubidaArchivo.Id;
            search.LoadLog = true;
            search.FechaDesde = fechaLog;

            var corrida = this.SubidaArchivoService.ObtenerCorridas(search).First();
            List<CorridaSubidaArchivoLogDto> logs = corrida.Log;
            if (logs != null && logs.Count() > 0)
            {
                foreach (CorridaSubidaArchivoLogDto log in logs)
                {
                    if (log.FinCorrida)
                    {
                        // Si solo quedan los emails, pooleo en menos tiempo
                        this.timerLog.Interval = this.timerLog.Interval * 7;
                        //.Stop();
                        //fechaLog = DateTime.MinValue;
                        this.btnVerDetalleCorrida.Enabled = true;
                        //break;
                    }

                    if (log.Id > lastLogId)
                    {
                        this.LogTextBox.Text += log.Mensaje + Environment.NewLine;
                    }
                }

                var lastLog = logs.Last();
                lastLogId = lastLog.Id;
                fechaLog = lastLog.Fecha;
            }
        }

        private void btnVerDetalleCorrida_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CorridaSubidaArchivo != null && this.CorridaSubidaArchivo.Id != 0)
                {
                    FormDetalleDeEnvioArhivoAWeb frmDetalle = new FormDetalleDeEnvioArhivoAWeb();
                    frmDetalle.CorridaId = this.CorridaSubidaArchivo.Id;
                    frmDetalle.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("El envío no está completo para ver su detalle.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CorridaSubidaArchivo != null && this.CorridaSubidaArchivo.Id != 0)
                {
                    MostrarLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mskCUIT_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarCUIT();
        }

        private bool ValidarCUIT()
        {
            bool valid = true;
            if (String.IsNullOrEmpty(this.mskCUIT.Text.Trim()))
            {
                errorProviderCargaDeDatos.SetError(mskCUIT, "El CUIT está vacío");
                valid = false;
            }
            else if (!this.mskCUIT.MaskFull)
            {
                errorProviderCargaDeDatos.SetError(mskCUIT, "Debe completar el CUIT");
                valid = false;
            }

            return valid;
        }

        private void txtCAE_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarCAE();
        }

        private bool ValidarCAE()
        {
            bool valid = true;

            if (String.IsNullOrEmpty(this.txtCAE.Text))
            {
                errorProviderCargaDeDatos.SetError(this.txtCAE, "Debe completar el CAE");
                valid = false;
            }

            return valid;
        }

        private void mskNroComprobante_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarNroComprobante();
        }

        public bool ValidarNroComprobante()
        {
            bool valid = true;

            long dummy;
            if (String.IsNullOrEmpty(this.mskNroComprobante.Text.Trim()))
            {
                errorProviderCargaDeDatos.SetError(this.mskNroComprobante, "Debe completar el numero de comprobante");
                valid = false;
            }
            else if (!Int64.TryParse(this.mskNroComprobante.Text.Trim(), out dummy))
            {
                errorProviderCargaDeDatos.SetError(this.mskNroComprobante, "Debe completar el numero de comprobante con un número entero");
                valid = false;
            }

            return valid;
        }

        private void mskPeriodoDeFacturacion_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarPeriodoDeFacturacion();
        }

        private bool ValidarPeriodoDeFacturacion()
        {
            bool valid = true;

            if (String.IsNullOrEmpty(this.mskPeriodoDeFacturacion.Text.Trim()))
            {
                valid = false;
                errorProviderCargaDeDatos.SetError(this.mskPeriodoDeFacturacion, "Debe completar el periodo de facturación");
            }
            else if (this.mskPeriodoDeFacturacion.Text.Length != 6)
            {
                valid = false;
                errorProviderCargaDeDatos.SetError(this.mskPeriodoDeFacturacion, "Debe completar el periodo de facturación con 6 dígitos");
            }
            else
            {
                int mes;
                int anio;
                if (!int.TryParse(this.mskPeriodoDeFacturacion.Text.Trim().Substring(0, 4), out anio))
                {
                    valid = false;
                    errorProviderCargaDeDatos.SetError(this.mskPeriodoDeFacturacion, "Debe completar el periodo de facturación con un año valido");
                }

                if (!int.TryParse(this.mskPeriodoDeFacturacion.Text.Trim().Substring(4, 2), out mes))
                {
                    valid = false;
                    errorProviderCargaDeDatos.SetError(this.mskPeriodoDeFacturacion, "Debe completar el periodo de facturación con un mes valido");
                }
                else
                {
                    if (mes > 12 || mes == 0)
                    {
                        valid = false;
                        errorProviderCargaDeDatos.SetError(this.mskPeriodoDeFacturacion, "Debe completar el periodo de facturación con un mes valido");
                    }
                }
            }

            return valid;
        }

        private void mskPtoVta_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarPuntoDeVenta();
        }

        private bool ValidarPuntoDeVenta()
        {
            bool valid = true;

            int pto;
            if (String.IsNullOrEmpty(this.mskPtoVta.Text.Trim()))
            {
                valid = false;
                errorProviderCargaDeDatos.SetError(this.mskPtoVta, "Debe completar el punto de venta");
            }
            else if (!int.TryParse(this.mskPtoVta.Text.Trim(), out pto))
            {
                valid = false;
                errorProviderCargaDeDatos.SetError(this.mskPtoVta, "Debe completar el punto de venta con un número entero");
            }

            return valid;
        }

        private void mskMonto_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarMonto();
        }

        private bool ValidarMonto()
        {
            bool valid = true;

            if (String.IsNullOrEmpty(this.mskMonto.Text.Trim().Replace(".", "").Replace(",", "")))
            {
                valid = false;
                errorProviderCargaDeDatos.SetError(this.mskMonto, "Debe completar el monto");
            }

            return valid;
        }

        private void mskDiasVto_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidarDiasDeVto();
        }

        private bool ValidarDiasDeVto()
        {
            bool valid = true;

            if (!datFechaDeVencimiento.Checked)
            {
                int dummy;
                if (String.IsNullOrEmpty(this.mskDiasVto.Text.Trim()))
                {
                    valid = false;
                    errorProviderCargaDeDatos.SetError(mskDiasVto, "Debe cargar los dias de vencimiento si no seleccionó una fecha");
                }
                else if(!int.TryParse(this.mskDiasVto.Text, out dummy))
                {
                    valid = false;
                    errorProviderCargaDeDatos.SetError(mskDiasVto, "Debe cargar los dias de vencimiento si no seleccionó una fecha y cargar un número entero");
                }
            }

            return valid;
        }

        private void datFechaDeVencimiento_ValueChanged(object sender, EventArgs e)
        {
            this.lblDiasVto.Visible =
            this.mskDiasVto.Visible = !datFechaDeVencimiento.Checked;
        }       
    }
}
