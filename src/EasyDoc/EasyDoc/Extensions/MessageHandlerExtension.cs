using EasyDoc.Application.Models;
using EasyDoc.Application.RequestHandlers;
using EasyDoc.Application.Requests.Documentation;
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
            services.AddScoped<IRequestHandler<WriteFileCommand, Unit>, FileCommandHandler>();
            return services;
        }

        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetJavaDocumentation, CommentOutput?>, DocumentationRequestHandler>();
            return services;
        }
    }
}
