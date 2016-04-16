using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Services;
using FacturaElectronica.Common.Contracts;
using System.Transactions;
using FacturaElectronica.Data;
using WebFramework.Mapper;

namespace FacturaElectronica.Business.Services
{
    public class ClienteService : IClienteService
    {
        #region IClienteService Members

        public ClienteDto CrearCliente(ClienteDto clienteDto)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var ctx = new FacturaElectronicaEntities())
                {
                    Cliente cliente = new Cliente();

                    if (cliente.CalculaVencimientoConVisualizacionDoc != clienteDto.CalculaVencimientoConVisualizacionDoc)
                    {
                        CrearAuditoria(clienteDto, cliente);
                    }

                    ToCliente(clienteDto, cliente);
                    ctx.Clientes.AddObject(cliente);
                    ctx.SaveChanges();
                    ts.Complete();
                    clienteDto.Id = cliente.Id;
                }
                return clienteDto;

            }
        }

        public ClienteDto EditarCliente(ClienteDto clienteDto)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var ctx = new FacturaElectronicaEntities())
                {
                    Cliente cliente = this.ObtenerCliente(ctx, clienteDto.Id);

                    // Se podrían analizar todos los campos
                    if (cliente.CalculaVencimientoConVisualizacionDoc != clienteDto.CalculaVencimientoConVisualizacionDoc)
                    {
                        CrearAuditoria(clienteDto, cliente);
                    }

                    ToCliente(clienteDto, cliente);
                    
                    ctx.SaveChanges();
                    ts.Complete();
                }

                return clienteDto;
            }
        }

        private static void CrearAuditoria(ClienteDto clienteDto, Cliente cliente)
        {
            Cliente_Auditoria cliente_auditoria = new Cliente_Auditoria();
            cliente.Cliente_Auditoria.Add(cliente_auditoria);
            cliente_auditoria.UsuarioId = clienteDto.Auditoria_UsuarioId;
            cliente_auditoria.CampoModificado = "Calcula Vencimiento Con Visualizacion de Documento";
            cliente_auditoria.ValorAnterior = cliente.CalculaVencimientoConVisualizacionDoc ? "SI" : "NO";
            cliente_auditoria.ValorNuevo = clienteDto.CalculaVencimientoConVisualizacionDoc ? "SI" : "NO";
            cliente_auditoria.Fecha = DateTime.Now;
        }

        public List<RegistroAuditoria> ObtenerAuditoriaCliente(long clienteId)
        {
            List<RegistroAuditoria> registros = new List<RegistroAuditoria>();
            using (var ctx = new FacturaElectronicaEntities())
            {
                foreach (var dbClienteAuditoria in ctx.Cliente_Auditoria.Where(a => a.ClienteId == clienteId).OrderByDescending(a => a.Fecha))
                {
                    RegistroAuditoria ra = new RegistroAuditoria();
                    EntityMapper.Map(dbClienteAuditoria, ra);
                    ra.UsuarioNombre = dbClienteAuditoria.Usuario.NombreUsuario;
                    registros.Add(ra);
                }

                return registros;
            }
        }

        public bool EliminarCliente(long clienteId)
        {
            int result = 0;
            using (var ctx = new FacturaElectronicaEntities())
            {
                Cliente cliente = this.ObtenerCliente(ctx, clienteId);
                if(cliente.Usuarios.Count>0)
                    cliente.Usuarios.Clear();
                ctx.Clientes.DeleteObject(cliente);
                result = ctx.SaveChanges();
            }
            return result > 0;
        }

        public ClienteDto ObtenerCliente(long clienteId)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToClienteDto(this.ObtenerCliente(ctx, clienteId));
            }
        }

        public List<ClienteDto> ObtenerClientes(ClienteCriteria criteria)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                IQueryable<Cliente> query = ctx.Clientes;

                if (!string.IsNullOrEmpty(criteria.RazonSocial))
                {
                    query = query.Where(c => c.RazonSocial.ToUpper().Contains(criteria.RazonSocial.ToUpper()));
                }

                if (criteria.CUIT.HasValue)
                {
                    query = query.Where(c =>  c.CUIT == criteria.CUIT);
                }

                if (!string.IsNullOrEmpty(criteria.NombreContacto))
                {
                    query = query.Where(c => c.NombreContacto.ToUpper().Contains(criteria.NombreContacto.ToUpper()));
                }

                if (!string.IsNullOrEmpty(criteria.ApellidoContacto))
                {
                    query = query.Where(c => c.ApellidoContacto.ToUpper().Contains(criteria.ApellidoContacto.ToUpper()));
                }

                return ToClienteDtoList(query.ToList());
            }

        }

        private Cliente ObtenerCliente(FacturaElectronicaEntities ctx, long clienteId)
        {
            return ctx.Clientes.Where(c => c.Id == clienteId).SingleOrDefault();
        }

        public ClienteDto ObtenerClientePorCuit(long cuit)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToClienteDto(ctx.Clientes.Where(c => c.CUIT == cuit).SingleOrDefault());
            }
        }


        #endregion

        #region [Conversion]

        private static void ToCliente(ClienteDto clienteDto, Cliente cliente)
        {
            cliente.NombreContacto = clienteDto.NombreContacto;
            cliente.NombreContactoSecundario = clienteDto.NombreContactoSecundario;
            cliente.RazonSocial = clienteDto.RazonSocial;
            cliente.ApellidoContacto = clienteDto.ApellidoContacto;
            cliente.ApellidoContactoSecundario = clienteDto.ApellidoContactoSecundario;
            cliente.CUIT = clienteDto.CUIT;
            cliente.EmailContacto = clienteDto.EmailContacto;
            cliente.EmailContactoSecundario = clienteDto.EmailContactoSecundario;
            cliente.CalculaVencimientoConVisualizacionDoc = clienteDto.CalculaVencimientoConVisualizacionDoc;
        }

        private static ClienteDto ToClienteDto(Cliente cliente)
        {
            if (cliente == null) return null;

            ClienteDto clienteDto = new ClienteDto();
            clienteDto.Id = cliente.Id;
            clienteDto.NombreContacto = cliente.NombreContacto;
            clienteDto.NombreContactoSecundario = cliente.NombreContactoSecundario;
            clienteDto.RazonSocial = cliente.RazonSocial;
            clienteDto.ApellidoContacto = cliente.ApellidoContacto;
            clienteDto.ApellidoContactoSecundario = cliente.ApellidoContactoSecundario;
            clienteDto.CUIT = cliente.CUIT;
            clienteDto.EmailContacto = cliente.EmailContacto;
            clienteDto.EmailContactoSecundario = cliente.EmailContactoSecundario;
            clienteDto.CalculaVencimientoConVisualizacionDoc = cliente.CalculaVencimientoConVisualizacionDoc;

            Usuario usuario = cliente.Usuarios.FirstOrDefault();
            if(usuario != null)
            {
                clienteDto.UsuarioId = usuario.Id;
            }

            return clienteDto;
        }

        private static List<ClienteDto> ToClienteDtoList(List<Cliente> clienteList)
        {
            List<ClienteDto> clienteDtoList = new List<ClienteDto>();
            if (clienteList.Count > 0)
            {
                foreach (var cliente in clienteList)
                {
                    clienteDtoList.Add(ToClienteDto(cliente));
                }
            }
            return clienteDtoList;
        }
        
        #endregion [Conversion]
    }
}
