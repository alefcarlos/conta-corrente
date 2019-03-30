using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Framework.Test
{
    public abstract class BaseTest<T> where T : TestStartupBase
    {
        public BaseTest()
        {
            ServiceProvider = ConfigureService();
        }

        protected readonly IServiceProvider ServiceProvider;

        private IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();
            ;
            services.AddLogging(opt => opt.AddConsole());

            var startup = Activator.CreateInstance<T>();

            startup.ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        protected TService GetService<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }
    }
}