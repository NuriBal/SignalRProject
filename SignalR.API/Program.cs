using Scalar.AspNetCore;
using SignalR.API.Configurations;
using SignalR.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, builder.Host, typeof(IServiceInstaller).Assembly);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().CacheOutput();
    app.MapScalarApiReference();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
