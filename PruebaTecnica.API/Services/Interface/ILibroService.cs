using PruebaTecnica.API.Models.DTOs.Libro;

namespace PruebaTecnica.API.Services.Interface;

public interface ILibroService
{
    Task<IEnumerable<LibroDTO>> GetAllAsync();
    Task<LibroDTO> GetByIdAsync(int id);
    Task<LibroDTO> CreateAsync(CreateLibroDTO libroDto);
    Task UpdateAsync(int id, CreateLibroDTO libroDto);
    Task DeleteAsync(int id);
}