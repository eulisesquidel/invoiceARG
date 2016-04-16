using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;


namespace Web.Framework.Svc
{
    [DataContract]
    public class WebFrameworkFaultException
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        [DataMember]
        public bool IsBusinessException { get; set; }
    }


    public class WebFrameworkErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion ver, ref Message fault)
        {

            WebFrameworkFaultException webFrameworkFaultException = new WebFrameworkFaultException();
            webFrameworkFaultException.Title = "Ha ocurrido un error en el servidor";
            webFrameworkFaultException.Message = GetExceptionMessage(error);
            webFrameworkFaultException.StackTrace = GetStackTrace(error);
            if (error.GetType() == typeof(SvcBusinessException))
            {
                webFrameworkFaultException.IsBusinessException = true;
                webFrameworkFaultException.Title = "Ha ocurrido un error";
            }

            FaultException<WebFrameworkFaultException> faultException = new FaultException<WebFrameworkFaultException>(webFrameworkFaultException);
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(ver, messageFault, faultException.Action);

        }

        public static string GetExceptionMessage(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            Exception current = ex;
            while (current != null)
            {
                builder.AppendLine(current.Message);
                current = current.InnerException;
            }

            return builder.ToString();
        }

        public static string GetStackTrace(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            Exception current = ex;
            while (current != null)
            {
                builder.AppendLine(current.StackTrace);
                current = current.InnerException;
            }

            return builder.ToString();
        }
    }


    public class WebFrameworkFaultBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler;

            errorHandler = new WebFrameworkErrorHandler();

            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }

    public class WebFrameworkFaultBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(WebFrameworkFaultBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new WebFrameworkFaultBehavior();
        }
    }
}
