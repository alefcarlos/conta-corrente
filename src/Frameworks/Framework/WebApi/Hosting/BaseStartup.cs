﻿using FluentValidation.AspNetCore;
using Framework.WebAPI.Documetation;
using Framework.WebAPI.HealthCheck;
using Framework.WebAPI.Hosting.Cors;
using Framework.WebAPI.Hosting.JWT;
using Framework.WebAPI.Hosting.Middlewares;
using Framework.WebAPI.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;

namespace Framework.WebAPI.Hosting
{
    public abstract class BaseStartup
    {
        public BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSecurity();

            services.AddCustomCors();

            services.AddHealthCheck();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation()
                .AddJsonOptions(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);

            services.AddApiVersion();
            services.AddDocumentation();

            AfterConfigureServices(services);
        }

        public abstract void AfterConfigureServices(IServiceCollection services);


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            BeforeConfigureApp(app, env);

            app.UseCustomCors();

            app.UseHealthCheck();

            app.UseMiddleware<HttpExceptionMiddleware>()
                .UseMvc();

            //app.UseAuthentication();

            app.UseDocumentation(provider);

            AfterConfigureApp(app, env);

        }

        public abstract void BeforeConfigureApp(IApplicationBuilder app, IHostingEnvironment env);

        public abstract void AfterConfigureApp(IApplicationBuilder app, IHostingEnvironment env);
    }
}
