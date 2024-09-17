using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICreditProfile, CreditProfile>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
