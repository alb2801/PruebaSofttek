using PruebaTecnica.API.Exceptions;
using PruebaTecnica.API.Models.DTOs.Libro;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Models.Enums;
using PruebaTecnica.API.Repositories.Interface;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Services;

/// <summary>
/// Servicio para la gestión de libros, implementa las reglas de negocio y operaciones CRUD.
/// </summary>
public class LibroService : ILibroService
{
    private readonly ILibroRepository _repo;
    private readonly IAutorRepository _autorRepo;
    private readonly IConfiguration _configuration;
    private readonly int _maxLibrosPorAutor;

    /// <summary>
    /// Constructor del servicio de libros. Inyecta repositorios y configuración.
    /// </summary>
    /// <param name="repo">Repositorio de libros</param>
    /// <param name="autorRepo">Repositorio de autores</param>
    /// <param name="configuration">Configuración de la aplicación</param>
    public LibroService(
        ILibroRepository repo,
        IAutorRepository autorRepo,
        IConfiguration configuration)
    {
        _repo = repo;
        _autorRepo = autorRepo;
        _configuration = configuration;
        // Lee el máximo de libros permitidos por autor desde la configuración
        _maxLibrosPorAutor = _configuration.GetValue<int>("MaxLibrosPorAutor", 3);
    }

    /// <summary>
    /// Obtiene todos los libros registrados en el sistema.
    /// </summary>
    /// <returns>Lista de libros en formato DTO</returns>
    public async Task<IEnumerable<LibroDTO>> GetAllAsync()
    {
        var libros = await _repo.GetAllAsync();
        // Mapeo manual de entidad a DTO para evitar ciclos y exponer solo los datos necesarios
        return libros.Select(l => new LibroDTO
        {
            Id = l.Id,
            Titulo = l.Titulo,
            Año = l.Año,
            Genero = l.Genero.ToString(),
            NumeroPaginas = l.NumeroPaginas,
            AutorId = l.AutorId,
            AutorNombre = l.Autor?.NombreCompleto ?? ""
        });
    }

    /// <summary>
    /// Obtiene un libro por su identificador.
    /// </summary>
    /// <param name="id">Identificador del libro</param>
    /// <returns>Libro en formato DTO o null si no existe</returns>
    public async Task<LibroDTO?> GetByIdAsync(int id)
    {
        var l = await _repo.GetByIdAsync(id);
        if (l == null) return null;
        return new LibroDTO
        {
            Id = l.Id,
            Titulo = l.Titulo,
            Año = l.Año,
            Genero = l.Genero.ToString(),
            NumeroPaginas = l.NumeroPaginas,
            AutorId = l.AutorId,
            AutorNombre = l.Autor?.NombreCompleto ?? ""
        };
    }

    /// <summary>
    /// Crea un nuevo libro, validando reglas de negocio como existencia del autor y máximo permitido.
    /// </summary>
    /// <param name="dto">DTO con los datos del libro a crear</param>
    /// <returns>Libro creado en formato DTO</returns>
    /// <exception cref="AutorNotFoundException">Si el autor no existe</exception>
    /// <exception cref="MaxLibrosExceededException">Si se supera el máximo de libros permitidos</exception>
    public async Task<LibroDTO> CreateAsync(CreateLibroDTO dto)
    {
        // Verifica si el autor existe
        var autor = await _autorRepo.GetByIdAsync(dto.AutorId);
        if (autor == null)
            throw new AutorNotFoundException();

        // Verifica el máximo de libros permitidos por autor
        int maxLibros = _maxLibrosPorAutor;
        var cantidadLibros = await _repo.GetLibroCountByAutorAsync(dto.AutorId);
        if (cantidadLibros >= maxLibros)
            throw new MaxLibrosExceededException();

        // Crea la entidad libro
        var libro = new Libro
        {
            Titulo = dto.Titulo,
            Año = dto.Año,
            Genero = (Genero)dto.Genero,
            NumeroPaginas = dto.NumeroPaginas,
            AutorId = dto.AutorId
        };
        var creado = await _repo.CreateAsync(libro);

        // Devuelve el DTO del libro creado
        return new LibroDTO
        {
            Id = creado.Id,
            Titulo = creado.Titulo,
            Año = creado.Año,
            Genero = creado.Genero.ToString(),
            NumeroPaginas = creado.NumeroPaginas,
            AutorId = creado.AutorId,
            AutorNombre = autor.NombreCompleto
        };
    }

    /// <summary>
    /// Actualiza los datos de un libro existente.
    /// </summary>
    /// <param name="id">Identificador del libro</param>
    /// <param name="dto">DTO con los nuevos datos</param>
    /// <exception cref="Exception">Si el libro no existe</exception>
    public async Task UpdateAsync(int id, CreateLibroDTO dto)
    {
        var libro = await _repo.GetByIdAsync(id);
        if (libro == null)
            throw new Exception("Libro no encontrado");

        libro.Titulo = dto.Titulo;
        libro.Año = dto.Año;
        libro.Genero = (Genero)dto.Genero;
        libro.NumeroPaginas = dto.NumeroPaginas;
        libro.AutorId = dto.AutorId;
        await _repo.UpdateAsync(libro);
    }

    /// <summary>
    /// Elimina un libro por su identificador.
    /// </summary>
    /// <param name="id">Identificador del libro</param>
    /// <exception cref="Exception">Si el libro no existe</exception>
    public async Task DeleteAsync(int id)
    {
        var libro = await _repo.GetByIdAsync(id);
        if (libro == null)
            throw new Exception("Libro no encontrado");

        await _repo.DeleteAsync(libro);
    }
}