using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Mappings;
using OnionArchitecture.Application.Repositories;
using System.Reflection;

namespace OnionArchitecture.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {

                    new ProductProfile(),
                    new   CategoryProfile()
                });
            });


        }
    }
}
