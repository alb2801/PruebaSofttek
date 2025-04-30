using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models.Entities;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
}