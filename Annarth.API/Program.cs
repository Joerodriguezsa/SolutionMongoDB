using Annarth.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Registrar servicios y DbContext usando el método de extensión en Infrastructure para MongoDB
builder.Services.ImplementPersistence(builder.Configuration);

// Registrar AutoMapper u otros servicios adicionales si es necesario
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Añadir soporte para Swagger/OpenAPI si es necesario
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
