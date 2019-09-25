using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Unity;

namespace Host
{
    public class UnityServiceBahavior : IInstanceProvider, IContractBehavior
    {
        private readonly IUnityContainer container;

        public UnityServiceBahavior(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            var serviceType = instanceContext.Host.Description.ServiceType;
            return container.Resolve(serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
}
