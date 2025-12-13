using EventPass.Domain.Interfaces.Security;
using EventPass.Domain.Interfaces.Services;
using EventPass.Infrastructure.Security;
using EventPass.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventPass.Infrastructure.Dependency_Injection
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPdfService, PdfService>();  
            services.AddScoped<IQrService, QrService>();
            return services;
        }
    }
}
