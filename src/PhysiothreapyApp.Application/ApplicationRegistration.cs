using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PhysiothreapyApp.Application.Behaviors;

namespace PhysiothreapyApp.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        #region Fluent Validation Configuration
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(assembly);
        #endregion

        #region MediatR Configuration
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            //cfg.AddOpenBehavior(typeof(NotFoundPipelineBehavior<,,>));
        });
        #endregion

        return services;
    }
}
