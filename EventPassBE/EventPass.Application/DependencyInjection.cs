using EventPass.Application.Common.Behaviours;
using EventPass.Application.Validators.Events;
using EventPass.Application.Validators.Performers;
using EventPass.Application.Validators.Users;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventPass.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateEventCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreatePerformerDtoValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
