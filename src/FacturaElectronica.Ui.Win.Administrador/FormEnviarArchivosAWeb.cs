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
    public partial class FormEnviarArchivosAWeb : Form
    {
        private ISubidaArchivoService SubidaArchivoService = ServiceFactory.GetSubidaArchivoService();
        private DateTime fechaLog = DateTime.MinValue;
        private long lastLogId = 0;

        public FormEnviarArchivosAWeb()
        {
            InitializeComponent();
        }

        private void FormEnviarArchivosAWeb_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (folderBrowserDialogFilesForUpLoad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtDirectorio.Text = folderBrowserDialogFilesForUpLoad.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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


                if (Directory.Exists(sourceDirectory))
                {
                    // Obtengo los archivos a procesar
                    fileList.AddRange(Directory.GetFiles(sourceDirectory, "*.*", SearchOption.TopDirectoryOnly).ToList());

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

                        EjecucionSubidaArchivos ejecucionData = new EjecucionSubidaArchivos();
                        ejecucionData.CorridaId = CorridaSubidaArchivo.Id;
                        ejecucionData.FileList = fileList;

                        // Activo el timer porque a veces no retorna la siguiente llamada
                        fechaLog = DateTime.MinValue;
                        timerLog.Interval = 3000;
                        timerLog.Start();

                        ThreadPool.QueueUserWorkItem(new WaitCallback(EjecutarCorridaCallBack), ejecucionData);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = GetExceptionMessage(ex) + GetExceptionStackTrace(ex);
                MessageBox.Show(message);
            }
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
            EjecucionSubidaArchivos ejecucionData = (EjecucionSubidaArchivos)state;
            EjecutarCorridaSubidaArchivo corrida = new EjecutarCorridaSubidaArchivo();
            corrida.CorridaId = ejecucionData.CorridaId;
            corrida.FileNames = ejecucionData.FileList;
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
    }
}
