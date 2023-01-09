using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.Patcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MTGDeckBuilder
{
    internal static class IoCBootstrapper
    {
        public static IUnityContainer BootstrapIoC()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMTGConfiguration, MTGDeckBuilderConfiguration>(TypeLifetime.Hierarchical);
            container.RegisterType<MTGDeckBuilderContext>(TypeLifetime.Hierarchical);
            container.RegisterType<IMTGDeckBuilderDbPatcher, MTGDeckBuilderDbPatcherSQLite>(TypeLifetime.Hierarchical);
            //container.RegisterType<IMTGDeckBuilderRepository, MTGDeckBuilderRepository>(TypeLifetime.Hierarchical);
            //container.RegisterType<MTGCardService, MTGCardService>(TypeLifetime.Hierarchical);
            return container;
        }
    }
}
