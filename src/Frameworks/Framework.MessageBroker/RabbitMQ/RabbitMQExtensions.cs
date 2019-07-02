using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Framework.MessageBroker.RabbitMQ
{
    public static class RabbitMQExtensions
    {
        public static IServiceCollection AddRabbitBroker(this IServiceCollection services, IConfiguration configuration, bool addHealthCheck = true)
        {
            services.Configure<RabbitSettings>(configuration.GetSection(nameof(RabbitSettings)));

            //Adicionar publisher como singleton, pois devemos sempre compartilhar a conexão TCP
            services.AddSingleton<RabbitMQConnectionWrapper>();

            services.AddSingleton<IRabbitMQPublisher, RabbitMQPublisher>();

            //Adicionar como transiente para garantir que NUNCA compartilharemos as intâncias dos channels por thread
            services.AddTransient<IRabbitMQSubscriber, RabbitMQSubscriber>();

            if (addHealthCheck)
            {
                var provider = services.BuildServiceProvider();
                var options = provider.GetRequiredService<IOptions<RabbitSettings>>().Value;
                services.AddHealthChecks()
                    .AddRabbitMQ(options.Uri, name: "rabbitmq", tags: new string[] { "messagebroker", "rabbitmq" });
            }

            return services;
        }
    }
}