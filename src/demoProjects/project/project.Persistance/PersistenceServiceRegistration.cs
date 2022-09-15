using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using project.Application.Services.Repositories;
using project.Persistance.Contexts;
using project.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("CoreDevDbConntectionString")));
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();

            return services;
        }
    }
}
