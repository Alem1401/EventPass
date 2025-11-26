using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventPass.Infrastructure.Persistence;
using EventPass.Domain.Interfaces.Venues;
using EventPass.Domain.Interfaces.Performers;
using EventPass.Domain.Interfaces.Security;
using EventPass.Domain.Interfaces.Users;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Reviews;
using EventPass.Domain.Interfaces.Tickets;
using EventPass.Domain.Interfaces.Orders;
using EventPass.Domain.Interfaces.Carts;
using EventPass.Infrastructure.Repositories.Carts;
using EventPass.Infrastructure.Repositories.Orders;
using EventPass.Infrastructure.Repositories.Events;
using EventPass.Infrastructure.Repositories.Tickets;
using EventPass.Infrastructure.Repositories.Venues;
using EventPass.Infrastructure.Repositories.Users;
using EventPass.Infrastructure.Repositories.Performers;
using EventPass.Infrastructure.Security;
using EventPass.Infrastructure.Repositories.Organizers;
using EventPass.Infrastructure.Repositories.Sponsors;
using EventPass.Domain.Interfaces.Sponsors;
using EventPass.Domain.Interfaces.Services;
using EventPass.Infrastructure.Dependency_Injection;

namespace EventPass.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EventPassDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services
                .AddRespositories()
                .AddServices();

            return services;
        }
    }
}
