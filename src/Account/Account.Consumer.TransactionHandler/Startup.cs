using Account.Application.EventHandlers;
using Account.Infra.Data.Repositories;
using Framework.ConsoleApp;
using Framework.Data.MongoDB;
using Framework.MessageBroker.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Account.Consumer.TransactionHandler
{
    public class Startup : ConsoleAppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<TransactionEventBackgroundServices>();

            var rabbitUri = Environment.GetEnvironmentVariable("RABBITMQ_URI");
            services.AddRabbitBroker("Account.Consumer.TransactionHandler", rabbitUri, false);

            var mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
            services.AddMongoDB(mongoUri);

            services.AddMongoRepositories();
        }
    }
}
