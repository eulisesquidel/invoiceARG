using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Ui.Web.Pages
{
    public partial class TestGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            UsuarioDto user1 = new UsuarioDto() { Id = 1, NombreUsuario = "test 1" };
            UsuarioDto user2 = new UsuarioDto() { Id = 1, NombreUsuario = "test 1" };
            usuarios.Add(user1);
            usuarios.Add(user2);
            this.GridCustomer.DataSource = usuarios;
            this.GridCustomer.DataBind();

        }

        protected void CustomerObjectDs_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
        }

        protected void GridCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void GridCustomer_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
        }

        protected void GridCustomer_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void GridCustomer_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        protected void GridCustomer_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }
    }
}