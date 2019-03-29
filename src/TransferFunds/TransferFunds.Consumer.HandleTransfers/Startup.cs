using Framework.ConsoleApp;
using Framework.MessageBroker.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using TransferFunds.Application.EventHandlers;

namespace TransferFunds.Consumer.HandleTransfers
{
    public class Startup : ConsoleAppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddRabbitBroker("TransferFunds.Consumer.HandleTransfers", "amqp://guest:guest@localhost");
            services.AddHostedService<TransferFundsHandler>();
        }
    }
}
