﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Application.Commands
{
    public static class RegisterCommands
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateAccount));
            services.AddMediatR(typeof(PublishTransaction));

            return services;
        }
    }
}
