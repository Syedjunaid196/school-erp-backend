using FluentValidation;
using SchoolManagement.API;
using SchoolManagement.API.Middlewares.PublicMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApiServices(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
await app.UsePublicMiddleware();

app.Run();
