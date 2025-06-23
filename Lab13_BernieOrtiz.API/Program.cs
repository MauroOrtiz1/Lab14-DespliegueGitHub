using ClosedXML.Excel;
using Lab13_BernieOrtiz.Domain;
using Lab13_BernieOrtiz.Infrastructure;
using Lab13_BernieOrtiz.Application.Usuarios.Queries;
using Lab13_BernieOrtiz.Infrastructure.Models;
using Lab13_BernieOrtiz.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Lab13_BernieOrtiz.Domain.Interfaces;
using Lab13_BernieOrtiz.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión a PostgreSQL
builder.Services.AddDbContext<ControlCashDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

// Registro de dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<GetUsuariosQueryHandler>();
builder.Services.AddScoped<ReporteExcelUsuariosService>();

// Swagger + Controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Servicio de Excel genérico (opcional si aún lo usas)
builder.Services.AddScoped<IExcelReportGenerator, ExcelReportGenerator>();

var app = builder.Build();

// Activar Swagger SIEMPRE
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VoyceLink - Training CenterV1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger se muestre en la raíz "/"
});


app.MapControllers();
// Ruta raíz de prueba
app.MapGet("/", () => "¡API en ejecución desde publicación!");
app.Run();