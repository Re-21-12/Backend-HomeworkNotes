using HomeWorksBackEnd.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configurar Entity Framework y habilitar el registro de datos sensibles
builder.Services.AddDbContext<AdminTareasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"))
           .EnableSensitiveDataLogging());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política de CORS
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
