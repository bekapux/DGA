global using DGA.Application.Features.Users.SharedValidators;
global using DGA.Application.Interfaces;
global using DGA.Domain;
global using ErrorOr;
global using FluentValidation;
global using MediatR;
global using System.Linq.Expressions;
using DGA.Application.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DGA.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(thisAssembly);
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(thisAssembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
