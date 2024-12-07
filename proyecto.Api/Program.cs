using System;
using Microsoft.EntityFrameworkCore;
using proyecto.Infrastructure.Contract;
using proyecto.Infrastructure.Services;
using proyecto.Infrastructure;
using proyecto.Application.Core;
using proyecto.Domain.Entities;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Registro del DbContext con la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar todos los servicios
builder.Services.AddScoped<IActividadService, ActividadService>();
builder.Services.AddScoped<IMiembroService, MiembroService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IPagoService, PagoService>();

// Registrar los servicios genéricos de IBaseService<T>
builder.Services.AddScoped<IBaseService<Actividad>, ActividadService>();
builder.Services.AddScoped<IBaseService<Miembro>, MiembroService>();
builder.Services.AddScoped<IBaseService<Evento>, EventoService>();
builder.Services.AddScoped<IBaseService<Pago>, PagoService>();




// Configurar controladores
builder.Services.AddControllers();




// Configurar CORS (si es necesario para permitir llamadas desde otros orígenes)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Agregar servicios para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/api/");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});




var app = builder.Build();

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:5000") // Cambia el puerto según el cliente
          .AllowAnyHeader()
          .AllowAnyMethod());


// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
