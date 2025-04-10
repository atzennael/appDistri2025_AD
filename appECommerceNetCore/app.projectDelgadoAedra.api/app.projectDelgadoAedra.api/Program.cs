using Microsoft.EntityFrameworkCore;
using app.projectDelgadoAedra.accessData.Context;
using System;
using app.projectDelgadoAedra.accessData.Repositories;
using app.projectDelgadoAedra_services.Implementations;
using app.projectDelgadoAedra.common.EventMQ;
using app.projectDelgadoAedra_services.Interfaces;
using app.projectDelgadoAedra_services.EventMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conSqlServer = builder.Configuration.GetConnectionString("BDDSqlServer")!;
builder.Services.AddDbContext<appDbContext>(options =>
{
    options.UseSqlServer(conSqlServer);
    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
});

// Builder de categoria
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//Builder de cliente
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

//builder de producto
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

//builder de venta
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

//builder de venta detalle
builder.Services.AddScoped<IVentaDetalleService, VentaDetalleService>();
builder.Services.AddScoped<IVentaDetalleRepository, VentaDetalleRepository>();

//builder de usuario
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//rabbitmq
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("rabbitmq"));
builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();

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
