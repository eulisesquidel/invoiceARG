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
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Core.Helpers;
using FacturaElectronica.Common.Contracts.Search;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormCorridas : Form
    {
        public FormCorridas()
        {
            InitializeComponent();
            this.lblCantidadReg.Text = "0";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                IProcesoCorridaService svc = ServiceFactory.GetProcesoCorridaService();

                long? corridaId = null;
                bool identificadorValido = true;
                if (this.txtIdentificador.Text.Trim() != string.Empty)
                {
                    try
                    {
                        corridaId = long.Parse(this.txtIdentificador.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("El Identificador es invalido", "Parametro invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtIdentificador.Text = string.Empty;
                        identificadorValido = false;
                    }
                }
                if (identificadorValido)
                {
                    CorridaSearch search = new CorridaSearch();
                    search.CorridaId = corridaId;
                    search.FechaDesde = this.dtpFechaDesde.Value.Date;
                    search.FechaHasta = this.dtpFechaHasta.Value.Date.AddDays(1).AddMilliseconds(-1);

                    this.bsCorridas.DataSource = svc.ObtenerCorridas(search);
                    this.gridCorridas.DataSource = this.bsCorridas;
                    this.lblCantidadReg.Text = this.bsCorridas.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridCorridas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.gridCorridas.SelectedRows.Count > 0)
                {
                    CorridaAutorizacionDto corridaDto = this.gridCorridas.SelectedRows[0].DataBoundItem as CorridaAutorizacionDto;
                    FormAutorizadorResultados frm = new FormAutorizadorResultados(corridaDto);
                    frm.ShowDialog(this);
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
