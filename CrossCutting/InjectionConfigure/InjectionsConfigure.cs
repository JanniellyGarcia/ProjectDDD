using Data.Repositories;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service.Intefaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.InjectionConfigure
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
            services.AddScoped(typeof(IClientService), typeof(ClientService));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IVendaRepository), typeof(VendaRepository));
            services.AddScoped(typeof(IVendaService), typeof(VendaService));

        }
    }
}
