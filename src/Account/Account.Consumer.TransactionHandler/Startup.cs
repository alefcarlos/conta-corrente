using Account.Application.Data.Repositories;
using Account.Application.EventHandlers;
using Framework.ConsoleApp;
using Framework.Data.MongoDB;
using Framework.MessageBroker.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Consumer.TransactionHandler
{
    public class Startup : ConsoleAppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<TransactionEventHandler>();

            services.AddRabbitBroker("Account.Consumer.TransactionHandler", "amqp://guest:guest@localhost");
            services.AddMongoDB("mongodb://localhost:27017/demodb");
            services.AddMongoRepositories();
        }
    }
}
