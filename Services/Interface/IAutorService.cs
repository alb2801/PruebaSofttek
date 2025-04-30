using PruebaTecnica.API.Models.DTOs.Autor;

namespace PruebaTecnica.API.Services.Interface;

public interface IAutorService
{
    Task<IEnumerable<AutorDTO>> GetAllAsync();
    Task<AutorDTO?> GetByIdAsync(int id);
    Task<AutorDTO> CreateAsync(CreateAutorDTO dto);
    Task UpdateAsync(int id, CreateAutorDTO dto);
    Task DeleteAsync(int id);
}