using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Ui.Web.Code;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using System.Configuration;
using System.IO;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class MensajesAlertasDetalle : BasePage
    {
        private const string pagListado = "MensajesAlertasListado.aspx";
        private const string pagHandler = "../Handlers/FileHandler.ashx";

        #region Propiedades

        private List<ClienteDto> Clientes
        {
            get
            {
                return (List<ClienteDto>)ViewState["Clientes"];
            }
            set
            {
                ViewState["Clientes"] = value;
            }            
        }

        private List<ClienteDto> ClientesSeleccionados
        {
            get
            {
                return (List<ClienteDto>)ViewState["ClientesSeleccionados"];
            }
            set
            {
                ViewState["ClientesSeleccionados"] = value;
            }
        }

        public MensajeDto mensajeCurrent
        {
            get
            {
                return (MensajeDto)ViewState["Mensaje"];
            }
            set
            {
                ViewState["Mensaje"] = value;
            }
        }

        #endregion Propiedades

        protected void Page_Load(object sender, EventArgs e)
        {
            this.HasPermissionToSeeMe(Operaciones.MensajesAlertasDetalle);
            try
            {
                IMensajeService mensajeService = ServiceFactory.GetMensajeService();

                if (!this.IsPostBack)
                {
                    if (this.BaseMaster.EsCliente)
                    {
                        this.pnlAsignacionClientes.Visible = false;
                    }
                    
                    if (this.Request.QueryString["Id"] == null)
                    {
                        this.ClientesSeleccionados = new List<ClienteDto>();
                        mensajeCurrent = new MensajeDto();
                        this.CargarClientes();
                    }
                    else
                    {
                        this.btnAceptar.Visible = 
                        this.btnCancelar.Visible =
                        this.pnlBotones.Visible = 
                        this.pnlClientes.Visible = false;
                        this.btnVolver.Visible = true;
                        mensajeCurrent = mensajeService.ObtenerMensaje(Convert.ToInt64(this.Request.QueryString["Id"]));
                    }
                    Bindear();
                    if (this.BaseMaster.EsCliente && !mensajeCurrent.Leido)
                    {
                        this.MarcarMensajeComoLeido();
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void MarcarMensajeComoLeido()
        {
            IMensajeService mensajeSvc = ServiceFactory.GetMensajeService();
            mensajeSvc.MarcarComoLeido(mensajeCurrent.Id, this.BaseMaster.ClienteId);

        }

        private void CargarClientes()
        {
            IClienteService svc = ServiceFactory.GetClienteService();
            List<ClienteDto> clientes = svc.ObtenerClientes(new ClienteCriteria());
            this.Clientes = clientes.OrderBy(c => c.RazonSocial).ToList();

            CargarListBox(lbxClientes, this.Clientes);
        }

        private void CargarListBox(ListBox listBox, List<ClienteDto> clientes)
        {
            listBox.Items.Clear();
            foreach (var cliente in clientes)
            {
                listBox.Items.Add(new ListItem(string.Format("{0}-{1}", cliente.CUIT, cliente.RazonSocial), cliente.Id.ToString()));
            }
        }

        private List<ClienteDto> OrderLista(List<ClienteDto> clientes)
        {
            if (rblOrden.SelectedItem == null || rblOrden.SelectedValue == "RAZSOC")
            {
                return clientes.OrderBy(c => c.RazonSocial).ToList();
            }
            else
            {
                return clientes.OrderBy(c => c.CUIT).ToList();
            }            
        }

        private void OrderyCargarListBoxes()
        {
            this.Clientes = this.OrderLista(this.Clientes);
            this.ClientesSeleccionados = this.OrderLista(this.ClientesSeleccionados);
            this.CargarListBox(this.lbxClientes, this.Clientes);
            this.CargarListBox(this.lbxClientesSeleccionados, this.ClientesSeleccionados);
        }

        private void Bindear()
        {
            if (mensajeCurrent.Id != 0)
            {
                this.txtAsunto.Text = mensajeCurrent.Asunto;
                this.txtMensaje.Text = mensajeCurrent.Texto;
                this.fileUpload.Visible = false;
                this.lblNombreArchivo.Visible = !string.IsNullOrEmpty(mensajeCurrent.NombreArchivo);
                this.lblNoAdjunto.Visible = !this.lblNombreArchivo.Visible;
                
                if (!string.IsNullOrEmpty(mensajeCurrent.NombreArchivo))
                {
                    this.lblNombreArchivo.NavigateUrl = string.Format("{0}?file={1}", pagHandler, mensajeCurrent.Id);
                }
                else
                {
                    this.lblNombreArchivo.NavigateUrl = "#";
                    this.lblNombreArchivo.Text = "--";
                }
                
                this.CargarListBox(this.lbxClientesSeleccionados, this.OrderLista(mensajeCurrent.Clientes));

                // Disabled controls
                this.txtAsunto.Enabled = false;
                this.txtMensaje.Enabled = false;
            }
        }

        private void SetData()
        {
            mensajeCurrent.Asunto = this.txtAsunto.Text.Trim();
            mensajeCurrent.Texto = this.txtMensaje.Text.Trim();
            mensajeCurrent.Clientes = this.ClientesSeleccionados;
        }

        private void CargarArchivo()
        {
            if (this.fileUpload.HasFile)
            {
                string path = Path.Combine(ConfigurationManager.AppSettings["pathMensajesYAlertas"],this.fileUpload.FileName);
                this.fileUpload.SaveAs(path);
                this.mensajeCurrent.Path = path;
                this.mensajeCurrent.NombreArchivo = this.fileUpload.FileName;
            }
        }

        private void Save()
        {
            IMensajeService mensajeSvc = ServiceFactory.GetMensajeService();
            if (mensajeCurrent.Id == 0)
            {
                mensajeCurrent = mensajeSvc.CrearMensaje(mensajeCurrent);
            }
        }

        private bool Validar()
        {
            return true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SetData();
                    if (Validar())
                    {
                        CargarArchivo();
                        Save();
                    }
                    if (this.BaseMaster.EsCliente)
                    {
                        ShowMessage("Los datos fueron grabados con éxito", WebMessageType.Notification);
                    }
                    else
                    {
                        this.RedirectToPagListado();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.Instance.HandleException(ex);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                RedirectToPagListado();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        private void RedirectToPagListado()
        {
            try
            {
                Response.Redirect(pagListado, true);
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        #region ListBox
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.lbxClientes.SelectedIndex > -1)
            {
                foreach (ListItem item in lbxClientes.Items)
                {
                    if (item.Selected)
                    {
                        ClienteDto dto = this.Clientes.Where(c => c.Id == long.Parse(item.Value)).Single();
                        this.ClientesSeleccionados.Add(dto);
                        this.Clientes.Remove(dto);                    
                    }
                }
                this.OrderyCargarListBoxes();
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            if (lbxClientesSeleccionados.SelectedIndex > -1)
            {
                foreach (ListItem item in lbxClientesSeleccionados.Items)
                {
                    if (item.Selected)
                    {

                        ClienteDto dto = this.ClientesSeleccionados.Where(c => c.Id == long.Parse(item.Value)).Single();
                        this.Clientes.Add(dto);
                        this.ClientesSeleccionados.Remove(dto);
                    }
                }
                this.OrderyCargarListBoxes();
            }
        }

        protected void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            this.ClientesSeleccionados.AddRange(this.Clientes);
            this.Clientes.Clear();
            this.OrderyCargarListBoxes();
        }

        protected void btnRemoverTodos_Click(object sender, EventArgs e)
        {
            this.Clientes.AddRange(this.ClientesSeleccionados);
            this.ClientesSeleccionados.Clear();
            this.OrderyCargarListBoxes();
        }

        #endregion ListBox

        protected void rblOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.OrderyCargarListBoxes();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                RedirectToPagListado();
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.HandleException(ex);
            }
        }
    }
}