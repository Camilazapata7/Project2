using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore; // 🚨 Importante para AddDbContext y SQL Server
using Project2.API.Data; // 🚨 Importante para usar ApplicationDbContext
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// =================================================================
// 1. CONFIGURACIÓN DE SERVICIOS
// =================================================================

// 1.1. Configuración del DbContext para SQL Server (EF Core)
// Lee la cadena de conexión del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 1.2. Añadir Soporte para Controladores (API REST)
builder.Services.AddControllers();

// 1.3. Configuración de Swagger/OpenAPI (Requisito del Profesor)
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManosUnidas", Version = "v1" });

    // Define el esquema de seguridad para el token JWT (Bearer)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                        Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                        Example: 'Bearer 12345abcdef'<br /> <br />",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Aplica el requisito de seguridad Bearer a todos los endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// =================================================================
// 2. CONFIGURACIÓN DEL PIPELINE HTTP
// =================================================================

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project2 v1");
    });
    // Se elimina app.MapOpenApi() que es redundante con UseSwagger/UseSwaggerUI
}

// 2.1. Mapeo de Controladores
app.MapControllers();

app.Run();
