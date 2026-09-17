using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SignalR.Bussiness.Abstract;
using SignalR.Bussiness.Concrate;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Profile).Assembly);
});

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<SignalRContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
