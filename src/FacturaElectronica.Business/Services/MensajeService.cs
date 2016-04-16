using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using FacturaElectronica.Common.Services;
using System.Transactions;
using FacturaElectronica.Data;
using WebFramework.Mapper;
using System.IO;

namespace FacturaElectronica.Business.Services
{    
    public class MensajeService : IMensajeService
    {
        public MensajeDto CrearMensaje(MensajeDto mensajeDto)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var ctx = new FacturaElectronicaEntities())
                {
                    Mensaje mensaje = new Mensaje();
                    ToMensaje(mensajeDto, mensaje);
                    MensajeCliente mensajeCliente = null;
                    foreach (var clienteDto in mensajeDto.Clientes)
                    {
                        Cliente cliente = this.ObtenerCliente(ctx, clienteDto.Id);
                         mensajeCliente = new MensajeCliente()
                        {
                            Mensaje = mensaje,
                            Cliente = cliente,
                            Leido = false
                        };
                        mensaje.MensajeClientes.Add(mensajeCliente);
                    }
                    mensaje.FechaDeCarga = DateTime.Now;
                    ctx.Mensajes.AddObject(mensaje);
                    ctx.SaveChanges();
                    ts.Complete();
                    mensajeDto.Id = mensaje.Id;
                }
                return mensajeDto;
            }
        }

        public bool EliminarMensaje(long mensajeId)
        {
            int result = 0;
            using (var ctx = new FacturaElectronicaEntities())
            {
                Mensaje mensaje = this.ObtenerMensaje(ctx, mensajeId);
                bool leido = false;
                foreach (MensajeCliente mensajeCliente in mensaje.MensajeClientes)
                {
                    if (mensajeCliente.Leido)
                    {
                        leido = true;
                        break;
                    }
                }
                if (!leido)
                {
                    string path = mensaje.Path;
                    using (TransactionScope ts = new TransactionScope())
                    {                        
                        List<long> mensajeClienteIds = (from m in mensaje.MensajeClientes
                                                        select m.Id).ToList();
                        foreach (var id in mensajeClienteIds)
                        {
                            ctx.MensajeClientes.DeleteObject(mensaje.MensajeClientes.Where(mc => mc.Id == id).Single());
                        }
                        ctx.Mensajes.DeleteObject(mensaje);
                        result = ctx.SaveChanges();
                        ts.Complete();
                    }
                    if (result > 0 && !string.IsNullOrEmpty(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            return result > 0;
        }

        public MensajeDto ObtenerMensaje(long mensajeId)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                return ToMensajeDto(this.ObtenerMensaje(ctx,mensajeId));
            }
        }

        public List<MensajeDto> ObtenerMensajes(MensajeCriteria criteria)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                var query = from m in ctx.Mensajes
                            join mc in ctx.MensajeClientes on m.Id equals mc.MensajeId
                            where 
                            // ClienteId
                            (!criteria.ClienteId.HasValue ||  mc.ClienteId == criteria.ClienteId.Value) &&
                            // Fecha De Carga Desde
                            (!criteria.FechaDeCargaDesde.HasValue || criteria.FechaDeCargaDesde.Value <= m.FechaDeCarga) &&
                            (!criteria.FechaDeCargaHasta.HasValue || m.FechaDeCarga <= criteria.FechaDeCargaHasta.Value ) &&
                            // Titulo
                            (string.IsNullOrEmpty(criteria.Asunto) || m.Asunto.ToUpper().Contains(criteria.Asunto.ToUpper())) &&
                            // Nombre de Archivo
                            (string.IsNullOrEmpty(criteria.NombreDeArchivo) || m.NombreArchivo.ToUpper().Contains(criteria.NombreDeArchivo.ToUpper())) &&
                            // Leido
                            (!criteria.Leido.HasValue || mc.Leido == criteria.Leido.Value)
                            select m;                

                return ToMensajeDtoList(query.Distinct().ToList(), criteria.ClienteId);
            }
        }

        private Mensaje ObtenerMensaje(FacturaElectronicaEntities ctx, long mensajeId)
        {
            return ctx.Mensajes.Where(m => m.Id == mensajeId).SingleOrDefault();
        }

        private Cliente ObtenerCliente(FacturaElectronicaEntities ctx, long clienteId)
        {
            return ctx.Clientes.Where(c => c.Id == clienteId).SingleOrDefault();
        }

        public void MarcarComoLeido(long mensajeId, long clienteId)
        {
            using (var ctx = new FacturaElectronicaEntities())
            {
                MensajeCliente mensajeCliente = ctx.MensajeClientes.Where(mc => mc.MensajeId == mensajeId && mc.ClienteId == clienteId).Single();
                mensajeCliente.Leido = true;
                ctx.SaveChanges();
            }

        }

        public List<MensajeClienteDto> ObtenerClientesEstados(MensajeClienteCriteria criteria)
        { 
            using (var ctx = new FacturaElectronicaEntities())
            {
                var result = from mc in ctx.MensajeClientes
                             where (!criteria.Leido.HasValue || mc.Leido.Equals(criteria.Leido.Value))
                                && (string.IsNullOrEmpty(criteria.RazonSocial) || mc.Cliente.RazonSocial.Contains(criteria.RazonSocial))
                                && (!criteria.CuitDesde.HasValue || criteria.CuitDesde.Value <= mc.Cliente.CUIT)
                                && (!criteria.CuitHasta.HasValue || mc.Cliente.CUIT <= criteria.CuitHasta.Value)
                                && (mc.MensajeId == criteria.MensajeId)
                             select new MensajeClienteDto()
                             {
                                Cuit = mc.Cliente.CUIT,
                                ClienteId = mc.Cliente.Id,
                                Leido = mc.Leido,
                                RazonSocial = mc.Cliente.RazonSocial,

                             };
                return result.ToList();
            }
        }

        #region [Conversion]

        private static void ToMensaje(MensajeDto mensajeDto, Mensaje mensaje)
        {
            EntityMapper.Map(mensajeDto, mensaje);
        }

        private static MensajeDto ToMensajeDto(Mensaje entity, bool cargarClientes = true, long? clienteId = null)
        {
            if (entity == null) return null;

            MensajeDto dto = new MensajeDto();

            EntityMapper.Map(entity, dto);

            if (clienteId.HasValue)
            {
                dto.Leido = entity.MensajeClientes.Where(mc => mc.ClienteId == clienteId).Single().Leido;
            }
            else
            {
                dto.MensajesLeidos = entity.MensajeClientes.Where(mc => mc.Leido).Count();
                dto.CantClientes = entity.MensajeClientes.Count();
            }

            if (cargarClientes && entity.MensajeClientes.Count > 0)
            {
                dto.Clientes = new List<ClienteDto>();
                ClienteDto clienteDto = null;
                foreach (var mensajeCliente in entity.MensajeClientes)
                {
                    clienteDto = new ClienteDto();
                    clienteDto.CUIT = mensajeCliente.Cliente.CUIT;
                    clienteDto.RazonSocial = mensajeCliente.Cliente.RazonSocial;
                    dto.Clientes.Add(clienteDto);
                }
            }

            return dto;
        }

        private static List<MensajeDto> ToMensajeDtoList(List<Mensaje> mensajeList, long? clienteId)
        {
            List<MensajeDto> dtoList = new List<MensajeDto>();
            if (mensajeList.Count > 0)
            {
                foreach (var mensaje in mensajeList)
                {
                    dtoList.Add(ToMensajeDto(mensaje, false, clienteId));
                }
            }
            return dtoList;
        }

        #endregion [Conversion]
    }
}
