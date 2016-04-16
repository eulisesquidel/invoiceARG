using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Common.Services
{
    public interface ISeguridadService
    {
        bool AutenticarUsuario(string nombreUsuario, string password);

        UsuarioDto CrearUsuario(UsuarioDto usuarioDto);

        UsuarioDto EditarUsuario(UsuarioDto usuarioDto);

        bool EliminarUsuario(long usuarioId);

        bool CambiarPassword(long usuarioId, string passwordNueva);

        bool CambiarPassword(string nombreUsuario, string passwordActual, string passwordNueva);

        UsuarioDto ObtenerUsuario(long usuarioId);

        UsuarioDto ObtenerUsuario(string nombreUsuario);

        List<UsuarioDto> ObtenerUsuarios(string nombreUsuario);

        List<UsuarioDto> ObtenerUsuarios(UsuarioCriteria criteria);

        RolDto ObtenerRol(int rolId);

        List<RolDto> ObtenerRoles();
    }
}
