using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacturaElectronica.Ui.Win.Administrador.Code;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Contracts.Search;
using FacturaElectronica.Common.Services;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormDetalleDeEnvioArhivoAWeb : Form
    {
        public long CorridaId { get; set; }

        private ISubidaArchivoService SubidaArchivoService = ServiceFactory.GetSubidaArchivoService();

        public FormDetalleDeEnvioArhivoAWeb()
        {
            InitializeComponent();
        }

        private void FormDetalleDeEnvioArhivoAWeb_Load(object sender, EventArgs e)
        {
            CorridaSubidaArchivoSearch search = new CorridaSubidaArchivoSearch();
            search.CorridaId = CorridaId;
            search.LoadLog = true;
            search.LoadDetalle = true;

            CorridaSubidaArchivoDto corridaDto = SubidaArchivoService.ObtenerCorridas(search).Single();

            this.lblIdentificador.Text = corridaDto.Id.ToString();
            this.lblFecha.Text = corridaDto.FechaProceso.ToString();

            CargarLog(corridaDto);
            CargarDetalleDeArchivos(corridaDto);
        }

        private void CargarDetalleDeArchivos(CorridaSubidaArchivoDto corridaDto)
        {            
            this.bsDetalleArchivosWeb.DataSource = corridaDto.Detalles;
            this.gridArchivos.DataSource = this.bsDetalleArchivosWeb;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.LogTextBox.Clear();
                CorridaSubidaArchivoSearch search = new CorridaSubidaArchivoSearch();
                search.CorridaId = CorridaId;
                search.LoadLog = true; 

                CorridaSubidaArchivoDto corridaDto = SubidaArchivoService.ObtenerCorridas(search).Single();
                CargarLog(corridaDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarLog(CorridaSubidaArchivoDto corridaDto)
        {
            List<CorridaSubidaArchivoLogDto> logs = corridaDto.Log;
            if (logs != null && logs.Count() > 0)
            {
                foreach (CorridaSubidaArchivoLogDto log in logs)
                {
                    if (log.FinCorrida)
                    {
                        continue;
                    }
                    else
                    {
                        this.LogTextBox.Text += log.Mensaje + Environment.NewLine;
                    }
                }
            }
        }       
    }
}
