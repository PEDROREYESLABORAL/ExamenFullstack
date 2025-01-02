using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Productos.Application.Interfaces;
using Productos.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ProductosContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //    b => b.MigrationsAssembly(typeof(ProductosContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddDbContext<ProductosContext>(options =>
                        options.UseMySql(configuration.GetConnectionString("DBProducts"),
                        new MySqlServerVersion(new Version(8, 0, 21))));



            services.AddScoped<IProductosContext>(provider => provider.GetService<ProductosContext>());

            return services;
        }
    }
}
