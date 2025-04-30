using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Services;

/// <summary>
/// Servicio para la gestión de autores, implementa operaciones CRUD y reglas de negocio.
/// </summary>
public class AutorService : IAutorService
{
    private readonly IAutorRepository _repo;

    /// <summary>
    /// Constructor del servicio de autores. Inyecta el repositorio de autores.
    /// </summary>
    /// <param name="repo">Repositorio de autores</param>
    public AutorService(IAutorRepository repo) => _repo = repo;

    /// <summary>
    /// Obtiene todos los autores registrados en el sistema.
    /// </summary>
    /// <returns>Lista de autores en formato DTO</returns>
    public async Task<IEnumerable<AutorDTO>> GetAllAsync()
    {
        var autores = await _repo.GetAllAsync();
        // Mapeo manual de entidad a DTO
        return autores.Select(a => new AutorDTO
        {
            Id = a.Id,
            NombreCompleto = a.NombreCompleto,
            FechaNacimiento = a.FechaNacimiento,
            CiudadProcedencia = a.CiudadProcedencia,
            CorreoElectronico = a.CorreoElectronico
        });
    }

    /// <summary>
    /// Obtiene un autor por su identificador.
    /// </summary>
    /// <param name="id">Identificador del autor</param>
    /// <returns>Autor en formato DTO o null si no existe</returns>
    public async Task<AutorDTO?> GetByIdAsync(int id)
    {
        var a = await _repo.GetByIdAsync(id);
        if (a == null) return null;
        return new AutorDTO
        {
            Id = a.Id,
            NombreCompleto = a.NombreCompleto,
            FechaNacimiento = a.FechaNacimiento,
            CiudadProcedencia = a.CiudadProcedencia,
            CorreoElectronico = a.CorreoElectronico
        };
    }

    /// <summary>
    /// Crea un nuevo autor.
    /// </summary>
    /// <param name="dto">DTO con los datos del autor a crear</param>
    /// <returns>Autor creado en formato DTO</returns>
    public async Task<AutorDTO> CreateAsync(CreateAutorDTO dto)
    {
        var autor = new Autor
        {
            NombreCompleto = dto.NombreCompleto,
            FechaNacimiento = dto.FechaNacimiento,
            CiudadProcedencia = dto.CiudadProcedencia,
            CorreoElectronico = dto.CorreoElectronico
        };
        var creado = await _repo.CreateAsync(autor);
        return new AutorDTO
        {
            Id = creado.Id,
            NombreCompleto = creado.NombreCompleto,
            FechaNacimiento = creado.FechaNacimiento,
            CiudadProcedencia = creado.CiudadProcedencia,
            CorreoElectronico = creado.CorreoElectronico
        };
    }

    /// <summary>
    /// Actualiza los datos de un autor existente.
    /// </summary>
    /// <param name="id">Identificador del autor</param>
    /// <param name="dto">DTO con los nuevos datos</param>
    /// <exception cref="Exception">Si el autor no existe</exception>
    public async Task UpdateAsync(int id, CreateAutorDTO dto)
    {
        var autor = await _repo.GetByIdAsync(id) ?? throw new Exception("Autor no encontrado");
        autor.NombreCompleto = dto.NombreCompleto;
        autor.FechaNacimiento = dto.FechaNacimiento;
        autor.CiudadProcedencia = dto.CiudadProcedencia;
        autor.CorreoElectronico = dto.CorreoElectronico;
        await _repo.UpdateAsync(autor);
    }

    /// <summary>
    /// Elimina un autor por su identificador.
    /// </summary>
    /// <param name="id">Identificador del autor</param>
    /// <exception cref="Exception">Si el autor no existe</exception>
    public async Task DeleteAsync(int id)
    {
        var autor = await _repo.GetByIdAsync(id) ?? throw new Exception("Autor no encontrado");
        await _repo.DeleteAsync(autor);
    }
}