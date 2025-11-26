using EventPass.Domain.Interfaces.Carts;
using EventPass.Domain.Interfaces.Orders;
using EventPass.Domain.Interfaces.Performers;
using EventPass.Domain.Interfaces.Reviews;
using EventPass.Domain.Interfaces.Security;
using EventPass.Domain.Interfaces.Services;
using EventPass.Domain.Interfaces.Sponsors;
using EventPass.Domain.Interfaces.Tickets;
using EventPass.Domain.Interfaces.Users;
using EventPass.Domain.Interfaces.Venues;
using EventPass.Domain.Interfaces;
using EventPass.Infrastructure.Repositories.Carts;
using EventPass.Infrastructure.Repositories.Events;
using EventPass.Infrastructure.Repositories.Orders;
using EventPass.Infrastructure.Repositories.Organizers;
using EventPass.Infrastructure.Repositories.Performers;
using EventPass.Infrastructure.Repositories.Sponsors;
using EventPass.Infrastructure.Repositories.Tickets;
using EventPass.Infrastructure.Repositories.Users;
using EventPass.Infrastructure.Repositories.Venues;
using Microsoft.Extensions.DependencyInjection;
using EventPass.Domain.Interfaces.Tokens;
using EventPass.Infrastructure.Repositories.Tokens;

namespace EventPass.Infrastructure.Dependency_Injection
{
    internal static class RepositoryRegistration
    {
        public static IServiceCollection AddRespositories(this IServiceCollection services)
        {
            services.AddScoped<IVenueTypeRepository, VenueTypeRepository>();
            services.AddScoped<IPerformerRepository, PerformerRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
            services.AddScoped<IOrdersRepository, OrderRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IPaymentsRepository, PaymentRepository>();
            services.AddScoped<ICartsRepository, CartRepository>();
            services.AddScoped<ISponsorRepository, SponsorRepository>();
            services.AddScoped<ICartItemsRepository, CartItemRepository>();
            services.AddScoped<ISponsorEventRepository, SponsorEventRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
