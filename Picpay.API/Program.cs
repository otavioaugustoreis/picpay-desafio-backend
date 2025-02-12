using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Picpay.Application.Mappings;
using Picpay.CrossCutting.IoC;
using Picpay.Infrastructure.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    //Documentação do Swagger
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DesafioPicPay",
        Version = "v1",
        Description = " Desafio PicPay",
        Contact = new OpenApiContact
        {
            Name = "Otavio",
            Email = "oaugusto265@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/otavio-augusto-a0a71b225/")
        },
        License = new OpenApiLicense
        {
            Name = "Usar sobre LICX",
            Url = new Uri("https://www.linkedin.com/in/otavio-augusto-a0a71b225/")
        }
    });
});

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(mySqlConnection, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
        sqlOptions.MigrationsAssembly("Picpay.Infrastructure");
    });
});

//builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddCofigurationJson();
builder.Services.AddDIPScoppedClasse();
builder.Services.AddValidator();
builder.Services.AddAutoMapper(typeof(DomainMappingProfile));

string httpClientName = builder.Configuration["HttpClient:TodoHttpClientName"];
string baseAddress = builder.Configuration["HttpClient:BaseAddress"];

builder.Services.AddHttpClient(httpClientName, client =>
{
    client.BaseAddress = new Uri(baseAddress);
    client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
