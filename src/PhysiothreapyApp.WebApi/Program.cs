using Microsoft.AspNetCore.RateLimiting;
using PhysiothreapyApp.Application;
using PhysiothreapyApp.Domain.Options;
using PhysiothreapyApp.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region Options Binding
builder.Services.Configure<ConnectionStringOption>(builder.Configuration.GetSection(ConnectionStringOption.Key));

//builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection(CustomTokenOption.Key));
#endregion

#region Environment Configurations
string env = builder.Environment.EnvironmentName;
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
    .AddJsonFile($"appsettings.{env}.json",optional:true)
    .AddEnvironmentVariables()
    .Build();
#endregion

#region Custom Extension Services
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();
#endregion



builder.Services.AddControllers();

#region RateLimit Configuration
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", cfg =>
    {
        cfg.QueueLimit = 100;
        cfg.Window = TimeSpan.FromSeconds(5);
        cfg.PermitLimit = 100;
        cfg.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });
});
#endregion

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers().RequireRateLimiting("fixed");

app.Run();
