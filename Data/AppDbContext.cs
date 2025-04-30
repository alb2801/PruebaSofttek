using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models.Entities;

/// <summary>
/// Contexto de base de datos principal de la aplicación.
/// Gestiona las entidades y la configuración de Entity Framework Core.
/// </summary>
public class AppDbContext : DbContext {
    /// <summary>
    /// Constructor del contexto de base de datos.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>
    /// Tabla de autores en la base de datos.
    /// </summary>
    public DbSet<Autor> Autores { get; set; }

    /// <summary>
    /// Tabla de libros en la base de datos.
    /// </summary>
    public DbSet<Libro> Libros { get; set; }
}