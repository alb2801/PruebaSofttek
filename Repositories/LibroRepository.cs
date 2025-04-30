using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;

namespace PruebaTecnica.API.Repositories;

public class LibroRepository : ILibroRepository
{
    private readonly AppDbContext _context;

    public LibroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Libro>> GetAllAsync()
    {
        return await _context.Libros
            .Include(l => l.Autor)
            .ToListAsync();
    }

    public async Task<Libro?> GetByIdAsync(int id)
    {
        return await _context.Libros
            .Include(l => l.Autor)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Libro>> GetByAutorIdAsync(int autorId)
    {
        return await _context.Libros
            .Where(l => l.AutorId == autorId)
            .ToListAsync();
    }

    public async Task<int> GetLibroCountByAutorAsync(int autorId)
    {
        return await _context.Libros
            .CountAsync(l => l.AutorId == autorId);
    }

    public async Task<Libro> CreateAsync(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return libro;
    }

    public async Task UpdateAsync(Libro libro)
    {
        _context.Entry(libro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro != null)
        {
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
        }
    }
}