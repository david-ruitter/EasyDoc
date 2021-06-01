using EasyDoc.Domain.CommandHandler;
using EasyDoc.Domain.Commands.Files;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDoc.Extensions
{
    public static class MessageHandlerExtension
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {

            return services;
        }
    }
}
