using Example.Application.Contracts;
using Example.Infrastructure.Persistence;
using Example.Infrastructure.Repository;
using Example.Infrastructure.Repository.BaseRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton<IExampleContext, ExampleContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
