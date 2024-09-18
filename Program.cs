using Intelliflo.Finance.Service.Helpers;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Repositories.Services;
using NETCore.MailKit.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Intelliflo.Finance.Service.Middleware;

Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .Build())
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
Log.Information("Starting up the application");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FactfindDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var mailSettings = new MailSettings();
builder.Configuration.GetSection("MailSettings").Bind(mailSettings);

// Add MailKit with manually bound configuration
builder.Services.AddMailKit(config => config.UseMailKit(mailSettings));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreditProfile, CreditProfile>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors("AllowAllOrigins");
// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();

// Enable middleware to serve Swagger UI
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

