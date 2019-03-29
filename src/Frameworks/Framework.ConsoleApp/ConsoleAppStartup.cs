using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Framework.ConsoleApp
{
    public abstract class ConsoleAppStartup
    {
        public void Run()
        {
            BuildHost()
                .Run();
        }
        private IHost BuildHost()
        {
            var host = new HostBuilder()
               .ConfigureLogging((hostContext, configLogging) =>
               {
                   configLogging.AddConsole();
                   configLogging.AddDebug();
               })
               .ConfigureServices((hostContext, services) =>
               {
                   ConfigureServices(services);
               })
               .UseConsoleLifetime()
               .Build();

            return host;
        }

        public abstract void ConfigureServices(IServiceCollection services);
    }
}