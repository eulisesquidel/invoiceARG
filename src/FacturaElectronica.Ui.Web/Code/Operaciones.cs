using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaElectronica.Ui.Web.Code
{
    public enum Operaciones
    {
        Home,
        CambiarPassVariosUsuarios, // NOTE: esta pagina es para permitir cambio de pass a varios users
        ClienteListado,
        ClienteDetalle,
        UsuarioListado,
        UsuarioDetalle,
        ComprobanteListado,
        ReporteComprobantes,
        Contacto,
        MensajesAlertasListado,
        MensajesAlertasDetalle,
        MensajesAlertasClientes
    }
}