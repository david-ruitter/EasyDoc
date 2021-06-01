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

        public static IServiceCollection AddNotificationHandlers(this IServiceCollection services)
        {

            return services;
        }
    }
}
