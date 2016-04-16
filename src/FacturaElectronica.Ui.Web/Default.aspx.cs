using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using System.Configuration;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Web
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.BaseMaster.EsCliente)
                {
                    CargarMensajes();
                    CargarEstadoComprobantes();
                }
            }
        }

        private void CargarMensajes()
        {
            IMensajeService svc = ServiceFactory.GetMensajeService();
            MensajeCriteria criteria = new MensajeCriteria();
            criteria.ClienteId = this.BaseMaster.ClienteId;
            criteria.Leido = false;
            List<MensajeDto> mensajes = svc.ObtenerMensajes(criteria);
            int cantidad = mensajes.Count;
            if (mensajes.Count > 0)
            {
                this.lblCantMensajesTitulo.Text = cantidad.ToString();
                this.lblCantMensajesDesc.Text = cantidad.ToString();
                this.pnlMensajeSinLeer.Visible = true;
            }
            else
                this.pnlMensajeSinLeer.Visible = false;

        }

        private void CargarEstadoComprobantes()
        {
            IComprobanteService svc = ServiceFactory.GetComprobanteService();
            EstadoComprobantesDto dto = svc.ObtenerEstadoComprobantes(this.BaseMaster.ClienteId);
            this.CargarEstados(dto);
            this.pnlEstadoComprobantes.Visible = true;
        }

        private void CargarEstados(EstadoComprobantesDto dto)
        {
            this.lblFechaActual.Text = DateTime.Now.ToShortDateString();
            this.lblTotalComprobantes.Text = dto.TotalComprobantes.ToString();
            this.lblVisualizados.Text = dto.Visualizados.ToString();
            this.lblNoVisualizados.Text = dto.NoVisualizados.ToString();
            this.lblNoVisualizadosVencidos.Text = dto.NoVisualizadosVencidos.ToString();
        }

        protected void lnkEndesa_Click(object sender, EventArgs e)
        {
            this.SignOut();
            this.Response.Redirect(ConfigurationManager.AppSettings["siteCompany"]);            
        }
    }
}
