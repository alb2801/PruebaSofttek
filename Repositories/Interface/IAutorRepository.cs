using PruebaTecnica.API.Models.Entities;

namespace PruebaTecnica.API.Repositories.Interface;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task<Autor?> GetByEmailAsync(string email);
    Task<Autor> CreateAsync(Autor autor);
    Task UpdateAsync(Autor autor);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}