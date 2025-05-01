using PruebaTecnica.API.Models.Entities;

namespace PruebaTecnica.API.Repositories.Interface;

public interface ILibroRepository
{
    Task<IEnumerable<Libro>> GetAllAsync();
    Task<Libro?> GetByIdAsync(int id);
    Task<IEnumerable<Libro>> GetByAutorIdAsync(int autorId);
    Task<int> GetLibroCountByAutorAsync(int autorId);
    Task<Libro> CreateAsync(Libro libro);
    Task UpdateAsync(Libro libro);
    Task DeleteAsync(Libro libro);
}