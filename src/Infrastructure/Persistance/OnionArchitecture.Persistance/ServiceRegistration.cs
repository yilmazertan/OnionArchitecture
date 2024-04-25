using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Persistance.Context;
using OnionArchitecture.Persistance.Repositories;
using OnionArchitecture.Persistance.Repositories.Products;
using OnionArchitecture.Persistance.Services.Products;

namespace OnionArchitecture.Persistance
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            });

          
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped(typeof(IProductReadRepository), typeof(ProductReadRepository));
            services.AddScoped(typeof(IProductWriteRepository), typeof(ProductWriteRepository));
       
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
           // services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
