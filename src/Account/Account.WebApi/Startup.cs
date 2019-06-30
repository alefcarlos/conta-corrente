using Account.Application.Commands;
using Account.Application.Data.Repositories;
using Account.Application.Services;
using Account.WebApi.Validations;
using Framework.Data.MongoDB;
using Framework.MessageBroker.RabbitMQ;
using Framework.WebAPI.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Framework.CQRS;

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
            services.AddServices();

            var rabbitUri = Environment.GetEnvironmentVariable("RABBITMQ_URI");
            services.AddRabbitBroker("Account.WebApi", rabbitUri);

            var mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
            services.AddMongoDB(mongoUri);
            services.AddMongoRepositories();

            services.AddCQRS();
            services.AddCommands();
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
