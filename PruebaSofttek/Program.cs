using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Repositories.Interface;
using PruebaTecnica.API.Services;
using PruebaTecnica.API.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Agrega la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazor",
        policy => policy
            .WithOrigins("https://localhost:5022", "http://localhost:5022") // Cambia los puertos según los que use tu Blazor
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Repositories
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

// Services
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ILibroService, LibroService>();

var app = builder.Build();

// Usa la política de CORS
app.UseCors("PermitirBlazor");

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
