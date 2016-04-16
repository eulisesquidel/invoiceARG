using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacturaElectronica.Common.Contracts;
using System.ServiceModel;

namespace FacturaElectronica.Common.Services
{
    [ServiceContract]
    public interface IMensajeService 
    {
        [OperationContract]
        MensajeDto CrearMensaje(MensajeDto mensajeDto);

        [OperationContract]
        bool EliminarMensaje(long mensajeId);

        [OperationContract]
        MensajeDto ObtenerMensaje(long mensajeId);

        [OperationContract]
        List<MensajeDto> ObtenerMensajes(MensajeCriteria criteria);

        [OperationContract]
        void MarcarComoLeido(long mensajeId, long clienteId);

        [OperationContract]
        List<MensajeClienteDto> ObtenerClientesEstados(MensajeClienteCriteria criteria);
    }
}
