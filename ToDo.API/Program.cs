using BLL.Dtos;
using BLL.Helpers;
using DAL.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ToDo.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Database Settings 
builder.Services.AddDbContext<ToDoContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnection"));
});

// DI AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// DI Validatiors
builder.Services.AddTransient<IValidator<ToDoItemDto>, ToDoItemValidation>();

// DI Repositories/Services
builder.Services.AddDALRepositories();
builder.Services.AddBLLServices();

// Swagger Settings
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo.API",
        Description = "This is a RESTful API for managing todo items.",
        TermsOfService = new Uri("https://www.example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Uncle Hachik - Github",
            Url = new Uri("https://github.com/SteveKSV"),
        },
        License = new OpenApiLicense
        {
            Name = "amigo.kl08@gmail.com",
            Url = new Uri("https://amigo.kl08@gmail.com"),
        }

    });
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
