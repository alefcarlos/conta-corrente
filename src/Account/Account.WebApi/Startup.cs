using Account.Application.Commands;
using Account.Application.HostedServices;
using Account.Application.Queries;
using Account.Infra.Data.Repositories;
using Account.WebApi.Validations;
using Framework.CQRS;
using Framework.Data.MongoDB;
using Framework.MessageBroker.RabbitMQ;
using Framework.WebAPI.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.Account
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void AfterConfigureServices(IServiceCollection services)
        {
            services.AddValidators();

            var rabbitUri = Environment.GetEnvironmentVariable("RABBITMQ_URI");
            services.AddRabbitBroker("Account.WebApi", rabbitUri);

            var mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
            services.AddMongoDB(mongoUri);
            services.AddMongoRepositories();

            services.AddCQRS();
            services.AddCommands();
            services.AddQueries();

            services.AddHostedService<TransactionEventBackgroundServices>();
        }

        public override void BeforeConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
        }

        public override void AfterConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}
