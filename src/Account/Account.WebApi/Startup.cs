using Account.Application.Commands;
using Account.Application.HostedServices;
using Account.Application.Queries;
using Account.Infra.Data.Repositories;
using Account.WebApi.Validations;
using Framework.Data.MongoDB;
using Framework.MessageBroker.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlusUltra.WebApi.Hosting;

namespace WebApi.Account
{
    public class Startup : WebApiStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment, useAuthentication: false)
        {
        }

        public override void AfterConfigureServices(IServiceCollection services)
        {
            services.AddValidators();

            services.AddRabbitBroker(Configuration);

            services.AddMongoDB(Configuration);
            services.AddMongoRepositories();

            services.AddMediatrServices();
            services.AddCommands();
            services.AddQueries();

            services.AddHostedService<TransactionEventBackgroundServices>();
        }

        public override void BeforeConfigureApp(IApplicationBuilder app)
        {
        }

        public override void ConfigureAfterRouting(IApplicationBuilder app)
        {
        }

        public override void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
        }

        public override void AfterConfigureApp(IApplicationBuilder app)
        {
        }
    }
}
