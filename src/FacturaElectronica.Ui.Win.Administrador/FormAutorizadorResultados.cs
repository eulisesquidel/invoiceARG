using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacturaElectronica.Common.Contracts;
using System.Collections;
using System.IO;
using FacturaElectronica.Ui.Win.Administrador.Code;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts.Search;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormAutorizadorResultados : Form
    {
        CorridaAutorizacionDto corridaDto = null;

        public FormAutorizadorResultados()
        {
            InitializeComponent();
        }

        public FormAutorizadorResultados(CorridaAutorizacionDto corridaDto)
            : this()
        {
            this.corridaDto = corridaDto;
        }

        private void FormAutorizadorResultados_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InicializarSaveFileDialog()
        {
            saveFileDialog.Filter = "CSV files (*.CSV)|*.csv";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.CheckFileExists = false;
        }

        private void CargarDatos()
        {
            this.lblIdentificador.Text = this.corridaDto.Id.ToString();
            this.lblFecha.Text = this.corridaDto.Fecha.ToString();
            this.lblNombreArchivo.Text = this.corridaDto.NombreDeArchivo;
            this.lblPathArchivo.Text = this.corridaDto.PathArchivo;
            this.lblTipoComprobante.Text = this.corridaDto.TipoComprobante;
            this.tabAutorizados.Text = string.Format("Comprobantes Autorizados ({0})", this.corridaDto.ComprobantesAutorizados.Count);
            this.bsAutorizados.DataSource = this.corridaDto.ComprobantesAutorizados;
            this.gridAutorizados.DataSource = this.bsAutorizados;
            this.tabConObservaciones.Text = string.Format("Comprobantes Con Observaciones ({0})", this.corridaDto.ComprobantesConObservaciones.Count);
            this.bsConObservaciones.DataSource = this.corridaDto.ComprobantesConObservaciones;
            this.gridConObservaciones.DataSource = this.bsConObservaciones;
            this.tabErrores.Text = string.Format("Errores ({0})", this.corridaDto.Errores.Count);
            this.bsErrores.DataSource = this.corridaDto.Errores;
            this.gridErrores.DataSource = this.bsErrores;
            this.tabEventos.Text = string.Format("Eventos ({0})", this.corridaDto.Eventos.Count);
            this.bsEventos.DataSource =  this.corridaDto.Eventos;
            this.gridEventos.DataSource = this.bsEventos;
            this.btnExportar.Enabled = false;
            if (this.bsAutorizados.Count > 0)
            {
                this.btnExportar.Enabled = true;
                InicializarSaveFileDialog();
            }

            // Cargo el log de la corrida
            MostrarLog();
        }

        private void MostrarLog()
        {
            this.LogTextBox.Clear();
            IProcesoCorridaService procesoCorridaSvc = ServiceFactory.GetProcesoCorridaService();

            LogSearch search = new LogSearch();
            search.CorridaId = this.corridaDto.Id;
            List<LogCorridaDto> logs = procesoCorridaSvc.ConsultarLog(search);
            if (logs != null && logs.Count() > 0)
            {
                foreach (LogCorridaDto log in logs)
                {
                    if (log.CorridaTerminada)
                    {                       
                        break;
                    }
                    else
                    {
                        this.LogTextBox.Text += log.Mensaje + Environment.NewLine;
                    }
                }                
            }
        }

        private void gridConObservaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (gridConObservaciones.SelectedRows.Count > 0)
            { 
                // mostrar observaciones asociadas
                DetalleComprobanteDto cbteDto = this.gridConObservaciones.SelectedRows[0].DataBoundItem as DetalleComprobanteDto;
                this.bsObservaciones.DataSource = cbteDto.Observaciones;
                this.gridObservaciones.DataSource = this.bsObservaciones;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sbExport = new StringBuilder();
                //Column Heading
                sbExport.AppendLine("Concepto,DocTipo,DocNro,CbteDesde,CbteHasta,CbteFecha,CAE,CAEFechaVto");
                foreach (DetalleComprobanteDto detalleCbte in this.corridaDto.ComprobantesAutorizados)
                {
                    sbExport.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", detalleCbte.Concepto.ToString()
                                                                         , detalleCbte.DocTipo.ToString()
                                                                         , detalleCbte.DocNro.ToString()
                                                                         , detalleCbte.CbteDesde.ToString()
                                                                         , detalleCbte.CbteHasta.ToString()
                                                                         , detalleCbte.CbteFecha.ToString("yyyyMMdd")
                                                                         , detalleCbte.CAE.ToString()
                                                                         , detalleCbte.CAEFechaVto.ToString("yyyyMMdd")));
                }
                //Create a TextWrite object to write to file, select a file name with .csv extention
                System.IO.TextWriter tw = new System.IO.StreamWriter(this.saveFileDialog.FileName);
                //Write the Text to file
                tw.Write(sbExport.ToString());
                //Close the Textwrite
                tw.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
