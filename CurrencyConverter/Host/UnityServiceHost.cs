using System;
using System.ServiceModel;
using Unity;

namespace Host
{
    internal class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(Type serviceType, IUnityContainer container, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            
            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new UnityServiceBahavior(container));
            }
        }
    }
}
