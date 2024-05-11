using CMS.Application.Abstractions;
using CMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public static class CMSDependencyInjection
    {
        public static IServiceCollection AddCMSInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ICMSDbContext, CMSDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("Postgres"));
            });
            return services;
        }
    }
}
