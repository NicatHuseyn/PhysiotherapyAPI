using PhysiothreapyApp.Domain.Options;
using PhysiothreapyApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region Options Bind
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
#endregion


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
