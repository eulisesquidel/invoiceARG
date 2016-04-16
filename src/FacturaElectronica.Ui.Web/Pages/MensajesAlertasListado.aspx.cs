using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class MensajesAlertasListado : BasePage
    {
        private const string pagDetalle = "MensajesAlertasDetalle.aspx";
        private const string pagClientes = "MensajesAlertasClientes.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HasPermissionToSeeMe(Operaciones.MensajesAlertasListado);
                this.btnBuscar.Attributes.Add("aspnetid", this.btnBuscar.ClientID);
                if (!this.IsPostBack)
                {
                    if (this.Master.EsCliente)
                    {
                        this.Grid.Columns[4].Visible = false;
                        this.Grid.Columns[5].Visible = false;
                        this.Grid.Columns[7].Visible = false;
                        this.btnAgregarNuevo.Visible = false;
                    }
                    else if (this.Master.EsAdministrador)
                    {
                        this.Grid.Columns[3].Visible = false;
                    }
                    this.Buscar();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void Buscar()
        {
            // cargo los filtros
            MensajeCriteria criteria = new MensajeCriteria();
            CargarCriteria(criteria);

            List<MensajeDto> list = ServiceFactory.GetMensajeService().ObtenerMensajes(criteria);
            this.lblCantReg.Text = string.Format(" ({0})", list.Count);
            this.Grid.DataSource = list;
            this.Grid.DataBind();
        }

        private void CargarCriteria(MensajeCriteria criteria)
        {
            criteria.ClienteId = this.Master.EsCliente ? this.Master.ClienteId : default(long?);
            criteria.FechaDeCargaDesde = UIHelper.GetDateTimeFromInputText(this.txtFechaDeCargaDesde.Text);
            criteria.FechaDeCargaHasta = UIHelper.GetDateTimeFromInputText(this.txtFechaDeCargaHasta.Text);
            if (criteria.FechaDeCargaHasta.HasValue)
            {
                criteria.FechaDeCargaHasta = criteria.FechaDeCargaHasta.Value.AddDays(1).AddSeconds(-1);
            }
            criteria.Asunto = this.txtAsunto.Text.Trim();
            //criteria.NombreDeArchivo = this.txtNombreArchivo.Text.Trim();
            if(!this.IsPostBack && this.BaseMaster.EsCliente && this.Request.Params["Id"] != null && this.Request.Params["Id"] == "NL")
            {
                criteria.Leido = false;
            }
            
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            if (e.CommandName == "ver" || e.CommandName == "eliminar" || e.CommandName == "clientes")
            {
                try
                {
                    long mensajeId = Convert.ToInt64(this.Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                    if (e.CommandName == "ver")
                    {
                        this.Response.Redirect(string.Format("{0}?Id={1}", pagDetalle, mensajeId), true);
                    }
                    else if (e.CommandName == "clientes")
                    {
                        this.Response.Redirect(string.Format("{0}?Id={1}", pagClientes, mensajeId), true);
                    }
                    else if (e.CommandName == "eliminar")
                    {

                        if (!ServiceFactory.GetMensajeService().EliminarMensaje(mensajeId))
                        {
                            throw new Exception("El mensaje no se puede eliminar dado que ha sido leido por al menos un cliente");
                        }
                        Buscar();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.Instance.HandleException(ex);
                }
            }
        }

        protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.Grid.PageIndex = e.NewPageIndex;
                Buscar();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    MensajeDto dataItem = e.Row.DataItem as MensajeDto;
                    // Mensaje
                    e.Row.Cells[2].Text = dataItem.Texto.Length > 11 ? dataItem.Texto.Substring(0, 10) + "..." : dataItem.Texto;

                    if (this.Master.EsAdministrador)
                    {
                        e.Row.Cells[4].Text = string.Format("{0}/{1}", dataItem.MensajesLeidos, dataItem.CantClientes);
                    }
                    else if (this.Master.EsCliente)
                    {
                        string leido = string.Empty;
                        if (dataItem.Leido)
                        {
                            leido = "Si";
                            e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            leido = "No";
                            e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                        }

                        e.Row.Cells[3].Text = leido;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect(pagDetalle, true);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Buscar();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtFechaDeCargaDesde.Text = string.Empty;
                this.txtFechaDeCargaHasta.Text = string.Empty;
                this.txtAsunto.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
            //this.txtNombreArchivo.Text = string.Empty;
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //  exporto la grilla
                GridViewExportUtil.Export("MensajesAlertas.xls", this.Grid);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }
    }
}