using Application.Abstractions.DataAccess;
using Infrastructure.SqlDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class DependecyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddSql();
        }


        public static IServiceCollection AddSql(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseService, SqlService>();
            return services;
        }
        
    }
    
}
