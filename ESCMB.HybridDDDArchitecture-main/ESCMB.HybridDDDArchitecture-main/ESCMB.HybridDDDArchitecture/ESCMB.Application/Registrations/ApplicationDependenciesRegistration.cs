using Common.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ESCMB.Application.Registrations
{
    /// <summary>
    /// Aqui se deben registrar todas las dependencias de la capa de aplicacion
    /// </summary>
    public static class ApplicationDependenciesRegistration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            /* Automapper */
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            /* EventBus */
            services.AddPublishers();
            services.AddSubscribers();

            /* MediatR*/
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IEventPublisher, MediatorEventPublisher>();

            return services;
        }

        private static IServiceCollection AddPublishers(this IServiceCollection services)
        {
            //Aqui se registran los handlers que publican en el bus de eventos
            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services)
        {
            //Aqui se registran los handlers que se suscriben al bus de eventos
            return services;
        }
    }
}
