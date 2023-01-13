using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.MTGJson;
using Unity;

namespace MTGDeckBuilder.Fetcher
{
    internal static class IoCBootstrapper
    {
        public static IUnityContainer BootstrapIoC()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMTGConfiguration, MTGFetcherConfiguration>(TypeLifetime.Hierarchical);
            container.RegisterType<IMTGJsonParser, MTGJsonParser>(TypeLifetime.Hierarchical);
            container.RegisterSingleton<HttpClient>();
            container.RegisterType<IMTGJsonHttpService, MTGJsonHttpService>(TypeLifetime.Hierarchical);
            return container;
        }
    }
}
