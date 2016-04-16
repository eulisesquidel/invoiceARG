using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;

namespace FacturaElectronica.Common.Services
{
    public interface IClienteService
    {
        ClienteDto CrearCliente(ClienteDto clienteDto);

        ClienteDto EditarCliente(ClienteDto clienteDto);

        bool EliminarCliente(long clienteId);

        ClienteDto ObtenerCliente(long clienteId);

        List<ClienteDto> ObtenerClientes(ClienteCriteria criteria);

        ClienteDto ObtenerClientePorCuit(long cuit);

        List<RegistroAuditoria> ObtenerAuditoriaCliente(long clienteId);
    }
}
