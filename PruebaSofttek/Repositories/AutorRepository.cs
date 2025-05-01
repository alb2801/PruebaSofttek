using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;

/// <summary>
/// Repositorio para la gestión de autores en la base de datos.
/// Implementa las operaciones CRUD y consultas específicas para la entidad Autor.
/// </summary>
public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Constructor del repositorio de autores.
    /// </summary>
    /// <param name="context">Contexto de base de datos de la aplicación.</param>
    public AutorRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtiene todos los autores registrados.
    /// </summary>
    public async Task<IEnumerable<Autor>> GetAllAsync() => await _context.Autores.ToListAsync();

    /// <summary>
    /// Obtiene un autor por su identificador.
    /// </summary>
    public async Task<Autor?> GetByIdAsync(int id) => await _context.Autores.FindAsync(id);

    /// <summary>
    /// Obtiene un autor por su correo electrónico.
    /// </summary>
    public async Task<Autor?> GetByEmailAsync(string email)
    {
        return await _context.Autores
            .FirstOrDefaultAsync(a => a.CorreoElectronico == email);
    }

    /// <summary>
    /// Crea un nuevo autor en la base de datos.
    /// </summary>
    public async Task<Autor> CreateAsync(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
        return autor;
    }

    /// <summary>
    /// Actualiza los datos de un autor existente.
    /// </summary>
    public async Task UpdateAsync(Autor autor)
    {
        _context.Autores.Update(autor);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Elimina un autor de la base de datos.
    /// </summary>
    public async Task DeleteAsync(Autor autor)
    {
        _context.Autores.Remove(autor);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Verifica si existe un autor por su identificador.
    /// </summary>
    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Autores.AnyAsync(a => a.Id == id);
    }
}