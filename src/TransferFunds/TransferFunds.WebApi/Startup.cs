using Framework.MessageBroker.RabbitMQ;
using Framework.WebAPI.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransferFunds.Application.Services;
using TransferFunds.Domain.Validations;

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
            services.AddServices();
            services.AddRabbitBroker("TransferFunds.WebApi", "amqp://guest:guest@localhost");
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
