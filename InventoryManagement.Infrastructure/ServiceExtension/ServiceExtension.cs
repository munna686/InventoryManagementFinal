using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagmentContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IInventoryManagement, InventoryManagements>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
