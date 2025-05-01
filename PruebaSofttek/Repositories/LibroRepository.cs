using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;

/// <summary>
/// Repositorio para la gestión de libros en la base de datos.
/// Implementa las operaciones CRUD y consultas específicas para la entidad Libro.
/// </summary>
public class LibroRepository : ILibroRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Constructor del repositorio de libros.
    /// </summary>
    /// <param name="context">Contexto de base de datos de la aplicación.</param>
    public LibroRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtiene todos los libros registrados, incluyendo su autor.
    /// </summary>
    public async Task<IEnumerable<Libro>> GetAllAsync() => await _context.Libros.Include(l => l.Autor).ToListAsync();

    /// <summary>
    /// Obtiene un libro por su identificador, incluyendo su autor.
    /// </summary>
    public async Task<Libro?> GetByIdAsync(int id) => await _context.Libros.Include(l => l.Autor).FirstOrDefaultAsync(l => l.Id == id);

    /// <summary>
    /// Obtiene todos los libros de un autor específico.
    /// </summary>
    public async Task<IEnumerable<Libro>> GetByAutorIdAsync(int autorId)
    {
        return await _context.Libros
            .Where(l => l.AutorId == autorId)
            .ToListAsync();
    }

    /// <summary>
    /// Obtiene la cantidad de libros registrados para un autor específico.
    /// </summary>
    public async Task<int> GetLibroCountByAutorAsync(int autorId)
    {
        return await _context.Libros
            .CountAsync(l => l.AutorId == autorId);
    }

    /// <summary>
    /// Crea un nuevo libro en la base de datos.
    /// </summary>
    public async Task<Libro> CreateAsync(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return libro;
    }

    /// <summary>
    /// Actualiza los datos de un libro existente.
    /// </summary>
    public async Task UpdateAsync(Libro libro)
    {
        _context.Libros.Update(libro);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Elimina un libro de la base de datos.
    /// </summary>
    public async Task DeleteAsync(Libro libro)
    {
        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();
    }
}