using AutoMapper;
using PruebaTecnica.API.Exceptions;
using PruebaTecnica.API.Models.DTOs.Libro;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Services;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _libroRepository;
    private readonly IAutorRepository _autorRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly int _maxLibrosPorAutor;

    public LibroService(
        ILibroRepository libroRepository,
        IAutorRepository autorRepository,
        IMapper mapper,
        IConfiguration configuration)
    {
        _libroRepository = libroRepository;
        _autorRepository = autorRepository;
        _mapper = mapper;
        _configuration = configuration;
        _maxLibrosPorAutor = _configuration.GetValue<int>("MaxLibrosPorAutor", 3);
    }

    public async Task<IEnumerable<LibroDTO>> GetAllAsync()
    {
        var libros = await _libroRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<LibroDTO>>(libros);
    }

    public async Task<LibroDTO> GetByIdAsync(int id)
    {
        var libro = await _libroRepository.GetByIdAsync(id);
        if (libro == null)
            throw new Exception("Libro no encontrado.");

        return _mapper.Map<LibroDTO>(libro);
    }

    public async Task<LibroDTO> CreateAsync(CreateLibroDTO libroDto)
    {
        var autorExists = await _autorRepository.ExistsAsync(libroDto.AutorId);
        if (!autorExists)
            throw new AutorNotFoundException();

        var librosCount = await _libroRepository.GetLibroCountByAutorAsync(libroDto.AutorId);
        if (librosCount >= _maxLibrosPorAutor)
            throw new MaxLibrosExceededException();

        var libro = _mapper.Map<Libro>(libroDto);
        await _libroRepository.CreateAsync(libro);
        return _mapper.Map<LibroDTO>(libro);
    }

    public async Task UpdateAsync(int id, CreateLibroDTO libroDto)
    {
        var libro = await _libroRepository.GetByIdAsync(id);
        if (libro == null)
            throw new Exception("Libro no encontrado.");

        if (libro.AutorId != libroDto.AutorId)
        {
            var autorExists = await _autorRepository.ExistsAsync(libroDto.AutorId);
            if (!autorExists)
                throw new AutorNotFoundException();

            var librosCount = await _libroRepository.GetLibroCountByAutorAsync(libroDto.AutorId);
            if (librosCount >= _maxLibrosPorAutor)
                throw new MaxLibrosExceededException();
        }

        _mapper.Map(libroDto, libro);
        await _libroRepository.UpdateAsync(libro);
    }

    public async Task DeleteAsync(int id)
    {
        var libro = await _libroRepository.GetByIdAsync(id);
        if (libro == null)
            throw new Exception("Libro no encontrado.");

        await _libroRepository.DeleteAsync(id);
    }
}