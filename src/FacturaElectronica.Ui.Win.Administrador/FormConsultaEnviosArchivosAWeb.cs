using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Ui.Win.Administrador.Code;
using FacturaElectronica.Common.Contracts.Search;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormConsultaEnviosArchivosAWeb : Form
    {
        private ISubidaArchivoService SubidaArchivoService = ServiceFactory.GetSubidaArchivoService();

        public FormConsultaEnviosArchivosAWeb()
        {
            InitializeComponent();
            this.lblCantidadReg.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs())
                {
                    CorridaSubidaArchivoSearch search = new CorridaSubidaArchivoSearch();
                    if (!string.IsNullOrEmpty(this.txtIdentificador.Text))
                    {
                        search.CorridaId = Convert.ToInt64(this.txtIdentificador.Text);
                    }

                    search.NombreArchivoLike = this.txtNombreDeArchivo.Text;
                    search.FechaDesde = dtpFechaDesde.Value;
                    search.FechaHasta = dtpFechaHasta.Value;

                    var searchResult = SubidaArchivoService.ObtenerCorridas(search);
                    this.lblCantidadReg.Text = searchResult.Count.ToString();

                    this.bsCorridaSubidaArchivo.DataSource = searchResult;
                    this.gridCorridas.DataSource = this.bsCorridaSubidaArchivo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarInputs()
        {
            bool validado = true;
            try
            {
                StringBuilder errorBuilder = new StringBuilder();
                if (!Validaciones.IsNumeber(this.txtIdentificador.Text))
                {
                    errorBuilder.AppendLine("El envío debe ser un número.");
                }

                if (errorBuilder.Length > 0)
                {
                    validado = false;
                    MessageBox.Show(errorBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return validado;
        }

        private void gridCorridas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CorridaSubidaArchivoDto corridaDto = this.gridCorridas.SelectedRows[0].DataBoundItem as CorridaSubidaArchivoDto;
                if (corridaDto != null)
                {
                    FormDetalleDeEnvioArhivoAWeb frmDetalle = new FormDetalleDeEnvioArhivoAWeb();
                    frmDetalle.CorridaId = corridaDto.Id;
                    frmDetalle.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtIdentificador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }            
        }
    }
}
