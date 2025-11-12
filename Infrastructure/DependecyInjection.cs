using Application.Abstractions.DataAccess;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class DependecyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddInMemory();
        }


        public static IServiceCollection AddInMemory(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseService, InMemoryDatabaseService>();
            return services;
        }
        
    }
    
}
