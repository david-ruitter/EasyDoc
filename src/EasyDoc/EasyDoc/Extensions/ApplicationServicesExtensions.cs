﻿using EasyDoc.Application.Services;
using EasyDoc.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDoc.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHelpService, HelpService>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }
}
