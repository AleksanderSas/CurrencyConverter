using CurrencyService;
using CurrencyService.DependencyInjection;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Unity;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/services/");
            IUnityContainer container = CreateContainer();

            ServiceHost selfHost = new UnityServiceHost(typeof(CurrencyConverter), container,  baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ICurrencyConverter), new WSHttpBinding(), "CurrencyService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }

        private static IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.LoadModule();
            return container;
        }
    }
}
