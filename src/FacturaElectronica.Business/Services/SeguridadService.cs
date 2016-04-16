using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Data;
using System.Transactions;
using FacturaElectronica.Common.Services;
using System.Data.Objects;
using FacturaElectronica.Core.Helpers;

namespace FacturaElectronica.Business.Services
{
    public class SeguridadService : ISeguridadService
    {              
        #region [Basic Operations]

        public bool AutenticarUsuario(string nombreUsuario, string password)
        {
            bool usuarioValido = false;
            using (var ctx = new FacturaElectronicaEntities())
            {
                Usuario usuario = this.ObtenerUsuario(ctx, nombreUsuario);                
                
                if (usuario != null)                
                {
                    string hashedPwd = HashPassword(usuario, password);
                    if (usuario.Password == hashedPwd)
                    {
                        usuarioValido = true;
                    }
                }
            }
            return usuarioValido;
        }

        private static string HashPassword(Usuario usuario, string password)
        {
            string salt = usuario.Password.Substring(usuario.Password.Length - 40);
            return SecurityHelper.CreatePasswordHash(password, salt);
        }

        public UsuarioDto CrearUsuario(UsuarioDto usuarioDto)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var ctx = new FacturaElectronicaEntities())
                {
                    if (this.ObtenerUsuario(ctx, usuarioDto.NombreUsuario) != null)
                        throw new Exception("El usuario ya existe");
                    Usuario usuario = new Usuario();
                    ToUsuario(usuarioDto, usuario);
                    if (usuarioDto.Roles != null &&
                       usuarioDto.Roles.Count() > 0)
                    {
                        foreach (RolDto rolDto in usuarioDto.Roles)
                        {
                            Rol rol = this.ObtenerRol(ctx, rolDto.Id);
                            if (rol != null)
                            {
                                usuario.Roles.Add(rol);
                            }
                        }
                    }
                    ctx.Usuarios.AddObject(usuario);
                    ctx.SaveChanges();
                    ts.Complete();
                    usuarioDto.Id = usuario.Id;
                }                               
                return usuarioDto;

            }
        }

        public UsuarioDto EditarUsuario(UsuarioDto usuarioDto)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var ctx = new FacturaElectronicaEntities())
                {
                    Usuario usuario = this.ObtenerUsuario(ctx, usuarioDto.Id);
                    string pass = usuario.Password;
                    ToUsuario(usuarioDto, usuario);
                    usuario.Password = pass;
                    if (usuarioDto.Roles != null &&
                       usuarioDto.Roles.Count() > 0)
                    {
                        usuario.Roles.Clear();
                        foreach (RolDto rolDto in usuarioDto.Roles)
                        {
                            Rol rol = this.ObtenerRol(ctx, rolDto.Id);
                            if (rol != null)
                            {
                                usuario.Roles.Add(rol);
                            }
                        }
                    }
                    ctx.SaveChanges();

                    ts.Complete();
                }
                
                return usuarioDto;
            }
        }

        public bool EliminarUsuario(long usuarioId)
        {
            int result = 0;
            using (var ctx = new FacturaElectronicaEntities())
            {
                Usuario usuario = this.ObtenerUsuario(ctx, usuarioId);
                usuario.Roles.Clear();
                ctx.Usuarios.DeleteObject(usuario);
                result = ctx.SaveChanges();
            }
            return result > 0;
        }

        public bool CambiarPassword(long usuarioId, string passwordNueva)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                Usuario usuario = this.ObtenerUsuario(ctx, usuarioId);
                bool cambioPass = false;
                if (usuario != null)
                {
                    usuario.Password = SecurityHelper.CreatePasswordHash(passwordNueva, SecurityHelper.CreateSalt(30));
                    cambioPass = ctx.SaveChanges() > 0;
                }
                return cambioPass;
            }
        }

        private static bool CambiaPassword(FacturaElectronicaEntities ctx, Usuario usuario, string passwordActual, string passwordNueva)
        {
            bool cambioPass = false;
            if (usuario != null)
            {

                if (usuario.Password != HashPassword(usuario,passwordActual))
                    throw new Exception("La Contraseña Anterior ingresada es incorrecta.");

                usuario.Password =SecurityHelper.CreatePasswordHash(passwordNueva, SecurityHelper.CreateSalt(30));
                cambioPass = ctx.SaveChanges() > 0;
            }
            return cambioPass;
        }

        public bool CambiarPassword(string nombreUsuario, string passwordActual, string passwordNueva)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                Usuario usuario = ctx.Usuarios.Where(u => u.NombreUsuario == nombreUsuario).FirstOrDefault();
                return CambiaPassword(ctx, usuario, passwordActual, passwordNueva);
            }            
        }

        public UsuarioDto ObtenerUsuario(long usuarioId)
        {
            if (usuarioId == 0)
                return null;

            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToUsuarioDto(this.ObtenerUsuario(ctx,usuarioId));
            }
        }

        public UsuarioDto ObtenerUsuario(string nombreUsuario)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToUsuarioDto(this.ObtenerUsuario(ctx, nombreUsuario));
            }
        }

        public List<UsuarioDto> ObtenerUsuarios(string nombreUsuario)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToUsuarioDtoList(ctx.Usuarios.Where(u=>u.NombreUsuario.Contains(nombreUsuario)).ToList());
            }
        }

        public List<UsuarioDto> ObtenerUsuarios(UsuarioCriteria criteria)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                IQueryable<Usuario> query = ctx.Usuarios;
                if (!string.IsNullOrEmpty(criteria.NombreUsuario))
                {
                    query = query.Where(u => u.NombreUsuario.Contains(criteria.NombreUsuario));
                }
                if (criteria.RolId.HasValue)
                {
                    query = query.Where(u => u.Roles.Count> 0 &&  u.Roles.FirstOrDefault().Id == criteria.RolId);
                }
                if (!string.IsNullOrEmpty(criteria.RazonSocial))
                {
                    query = query.Where(u => u.Cliente != null && u.Cliente.RazonSocial.Contains(criteria.RazonSocial));
                }
                if (criteria.Cuit.HasValue)
                {
                    query = query.Where(u => u.Cliente.CUIT == criteria.Cuit.Value);
                }
                return ToUsuarioDtoList(query.ToList());
            }        
        }

        public RolDto ObtenerRol(int rolId)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToRolDto(this.ObtenerRol(ctx, rolId));
            }
        }

        public List<RolDto> ObtenerRoles()
        {
            using(var ctx = new FacturaElectronicaEntities())
            {
                return ToRolDtoList(ctx.Rols.ToList());
            }
            
        }

        private Rol ObtenerRol(FacturaElectronicaEntities ctx, int rolId)
        {
            return ctx.Rols.Where(r => r.Id == rolId).SingleOrDefault();
        }

        private Usuario ObtenerUsuario(FacturaElectronicaEntities ctx, long usuarioId)
        {
            return ctx.Usuarios.Where(u => u.Id == usuarioId).SingleOrDefault();
        }

        private Usuario ObtenerUsuario(FacturaElectronicaEntities ctx, string nombreUsuario)
        {
            return ctx.Usuarios.Where(u => u.NombreUsuario == nombreUsuario).SingleOrDefault();
        }

        #endregion [Basic Operations]

        #region [Conversion]

        private static void ToUsuario(UsuarioDto usuarioDto, Usuario usuario)
        {
            usuario.ClienteId = usuarioDto.ClienteId;
            usuario.NombreUsuario = usuarioDto.NombreUsuario;
            usuario.Password = usuarioDto.Password;
        }

        private static UsuarioDto ToUsuarioDto(Usuario usuario)
        {
            UsuarioDto dto = new UsuarioDto();
            dto.Id = usuario.Id;
            dto.NombreUsuario = usuario.NombreUsuario;
            if (usuario.Cliente != null)
            {
                dto.ClienteId = usuario.ClienteId;
                dto.ClienteRazonSocial = usuario.Cliente.RazonSocial;
                dto.ClienteCuit = usuario.Cliente.CUIT;
            }
            // Roles
            if (usuario.Roles.Count > 0)
            {
                dto.Roles = ToRolDtoList(usuario.Roles.ToList());
                dto.RolNombre = usuario.Roles.First().Nombre;
            }

            return dto;
        }

        private static List<UsuarioDto> ToUsuarioDtoList(List<Usuario> usuarioList)
        {
            List<UsuarioDto> usuarioDtoList = new List<UsuarioDto>();
            if (usuarioList.Count > 0)
            {
                foreach (var usuario in usuarioList)
                {
                    usuarioDtoList.Add(ToUsuarioDto(usuario));
                }
            }
            return usuarioDtoList;
        }

        private static RolDto ToRolDto(Rol rol)
        {
            RolDto dto = new RolDto();
            dto.Id = rol.Id;
            dto.Codigo = rol.Codigo;
            dto.Nombre = rol.Nombre;

            return dto;
        }

        private static List<RolDto> ToRolDtoList(List<Rol> rolList)
        {
            List<RolDto> rolDtoList = new List<RolDto>();
            if (rolList.Count > 0)
            {
                foreach (var rol in rolList)
                {
                    rolDtoList.Add(ToRolDto(rol));
                }
            }
            return rolDtoList;
        }


        #endregion [Conversion]
    }
}
