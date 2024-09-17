using Intelliflo.Finance.Service.Helpers;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Repositories.Services;
using NETCore.MailKit.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
