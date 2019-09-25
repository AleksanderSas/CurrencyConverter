using Server.Services;
using Unity;

namespace Server.DependencyInjection
{
    public static class UnityModule
    {
        public static void LoadModule(this IUnityContainer container)
        {
            container.RegisterType<ILogger, Log4NetAdapter>();
            container.RegisterType<ICurrencyConverterService, CurrencyConverterService>();
        }
    }
}
