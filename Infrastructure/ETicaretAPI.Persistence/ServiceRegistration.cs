using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceService(this IServiceCollection services) 
        {

            //hangi veritabanıyla çalışacaksak onun kütüphanesini yüklüyoruz.
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
            //IOC Conteiner ' da ICustomerReadRepository istendiğinde, CustomerReadRepository dönder.
            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository,ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();
        }

    }
}
