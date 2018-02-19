using Pheko.Common.ErrorLogging;

using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Pheko.Service
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ErrorHandlerAttribute : Attribute, IErrorHandler, IServiceBehavior
    {
        bool IErrorHandler.HandleError(Exception exception)
        {
            ErrorLogger errorHandler = new ErrorLogger("Pheko.Serivce", "Pheko");

            errorHandler.WriteToEventLog(exception);

            return true;
        }

        void IErrorHandler.ProvideFault(Exception exception, MessageVersion messageVersion, ref Message fault)
        {
            // Shield the unknown exception
            FaultException faultException = new FaultException(string.Format("Server error encountered with the following message \"{0}\". All details have been logged in the event log.", exception.Message));
            MessageFault messageFault = faultException.CreateMessageFault();

            fault = Message.CreateMessage(messageVersion, messageFault, faultException.Action);
        }

        //IServiceBehavior implementation"

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase host)
        {
            //attach the object implementing the IErrorHandler interface(this class itself) to each ChannelDisp

            foreach (ChannelDispatcher dispatcher in host.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(this);
            }
        }

        void IServiceBehavior.Validate(ServiceDescription description, ServiceHostBase host)
        {
            //implementation not required at present. Can be added later if required.
        }

        void IServiceBehavior.AddBindingParameters(ServiceDescription description, ServiceHostBase host, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
        {
            //implementation not required at present. Can be added later if required.
        }

    }
}