using EasyDoc.Application.Services;
using EasyDoc.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDoc.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHelpService, HelpService>();
            services.AddScoped<IFileInputService, FileInputService>();
            services.AddScoped<IFileOutputService, FileOutputService>();
            services.AddScoped<ICommandService, CommandService>();
            return services;
        }
    }
}
