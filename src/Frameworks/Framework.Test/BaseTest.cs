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

        private IServiceProvider ServiceProvider { get; }

        public IServiceScope Scope => ServiceProvider.CreateScope();

        private IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();
            ;
            services.AddLogging(opt => opt.AddConsole());

            var startup = Activator.CreateInstance<T>();

            startup.ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        public void Dispose()
        {
            System.Diagnostics.Debugger.Log(0, "Dispose", "Disposing BaseTest");
            Scope.Dispose();
        }
    }
}