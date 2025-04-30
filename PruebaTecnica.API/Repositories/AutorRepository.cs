using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;

namespace PruebaTecnica.API.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;

    public AutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync()
    {
        return await _context.Autores
            .Include(a => a.Libros)
            .ToListAsync();
    }

    public async Task<Autor?> GetByIdAsync(int id)
    {
        return await _context.Autores
            .Include(a => a.Libros)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Autor?> GetByEmailAsync(string email)
    {
        return await _context.Autores
            .FirstOrDefaultAsync(a => a.CorreoElectronico == email);
    }

    public async Task<Autor> CreateAsync(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
        return autor;
    }

    public async Task UpdateAsync(Autor autor)
    {
        _context.Entry(autor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await _context.Autores.FindAsync(id);
        if (autor != null)
        {
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Autores.AnyAsync(a => a.Id == id);
    }
}