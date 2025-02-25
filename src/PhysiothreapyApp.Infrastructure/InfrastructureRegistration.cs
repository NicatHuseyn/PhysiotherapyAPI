using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhysiothreapyApp.Application;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Services;
using PhysiothreapyApp.Application.Filters;
using PhysiothreapyApp.Domain;
using PhysiothreapyApp.Domain.Models.IdentityModels;
using PhysiothreapyApp.Domain.Options;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;
using PhysiothreapyApp.Infrastructure.Persistence.Interceptors;
using PhysiothreapyApp.Infrastructure.Services.DoctorServices;
using Scrutor;

namespace PhysiothreapyApp.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
    {
        #region Db Configurations

        var connectionString = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

        services.AddDbContext<PhysiothreapyAppDbContext>(options =>
        {
            options.UseSqlServer(connectionString!.SqlServer, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.EnableRetryOnFailure();

                sqlServerOptionsAction.MigrationsAssembly(typeof(PhysiothreapyAppDbContext).Assembly.FullName);
            });

            options.AddInterceptors(new DbSaveChangesInterceptor());
        });
        #endregion


        #region Scrutor Configurations
        services.Scan(scan => scan
        .FromAssemblies(typeof(DomainAssembly).Assembly, typeof(ApplicationAssembly).Assembly, typeof(InfrastructureAssembly).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsMatchingInterface()
        .WithScopedLifetime()

        .AddClasses(classes => classes.AssignableTo(typeof(NotFoundFilter<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );
        #endregion


        // Closed .NET Default Messages
        services.Configure<ApiBehaviorOptions>(options=>options.SuppressModelStateInvalidFilter =true);


        #region Identity Configurations
        services
            .AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<PhysiothreapyAppDbContext>()
            .AddDefaultTokenProviders();
        #endregion

        return services;
    }
}
