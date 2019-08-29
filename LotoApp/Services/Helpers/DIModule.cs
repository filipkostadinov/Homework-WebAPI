using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataModels;

namespace Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LotoAppDbContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Admin>, AdminRepository>();
            services.AddTransient<IRepository<Session>, SessionRepository>();
            services.AddTransient<IRepository<Ticket>, TicketRepository>();

            return services;
        }
    }
}
