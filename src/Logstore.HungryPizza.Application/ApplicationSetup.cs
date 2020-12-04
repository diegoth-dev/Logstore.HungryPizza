using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Logstore.HungryPizza.Application
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}