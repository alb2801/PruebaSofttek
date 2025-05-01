using PruebaTecnica.API.Models.DTOs.Libro;

namespace PruebaTecnica.API.Services.Interface;

public interface ILibroService
{
    Task<IEnumerable<LibroDTO>> GetAllAsync();
    Task<LibroDTO?> GetByIdAsync(int id);
    Task<LibroDTO> CreateAsync(CreateLibroDTO dto);
    Task UpdateAsync(int id, CreateLibroDTO dto);
    Task DeleteAsync(int id);
}