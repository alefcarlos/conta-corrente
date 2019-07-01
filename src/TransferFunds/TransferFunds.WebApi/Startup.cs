using Framework.CQRS;
using Framework.MessageBroker.RabbitMQ;
using Framework.WebAPI.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TransferFunds.Application.Commands;
using TransferFunds.Application.ExternalServices;
using TransferFunds.WebApi.Validations;

namespace WebApi.TransferFunds
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
            services.AddRabbitBroker("TransferFunds.WebApi", rabbitUri);

            services.AddExternalServices();
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
