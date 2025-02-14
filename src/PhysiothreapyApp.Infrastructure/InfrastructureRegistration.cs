using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhysiothreapyApp.Domain;
using PhysiothreapyApp.Domain.Options;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;
using PhysiothreapyApp.Infrastructure.Persistence.Interceptors;
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
                sqlServerOptionsAction.MigrationsAssembly(typeof(PhysiothreapyAppDbContext).Assembly.FullName);
            });

            options.AddInterceptors(new DbSaveChangesInterceptor());
        });
        #endregion


        #region Scrutor Configurations
        services.Scan(scan => scan
        .FromAssemblies(typeof(DomainAssembly).Assembly, typeof(InfrastructureAssembly).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsMatchingInterface()
        .WithScopedLifetime()
        );
        #endregion


        // Closed .NET Default Messages
        services.Configure<ApiBehaviorOptions>(options=>options.SuppressModelStateInvalidFilter =true);

        return services;
    }
}
