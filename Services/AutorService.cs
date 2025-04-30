using AutoMapper;
using PruebaTecnica.API.Exceptions;
using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Repositories.Interface;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Services;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;
    private readonly IMapper _mapper;

    public AutorService(IAutorRepository autorRepository, IMapper mapper)
    {
        _autorRepository = autorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AutorDTO>> GetAllAsync()
    {
        var autores = await _autorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AutorDTO>>(autores);
    }

    public async Task<AutorDTO> GetByIdAsync(int id)
    {
        var autor = await _autorRepository.GetByIdAsync(id);
        if (autor == null)
            throw new AutorNotFoundException();

        return _mapper.Map<AutorDTO>(autor);
    }

    public async Task<AutorDTO> CreateAsync(CreateAutorDTO autorDto)
    {
        var existingAutor = await _autorRepository.GetByEmailAsync(autorDto.CorreoElectronico);
        if (existingAutor != null)
            throw new Exception("Ya existe un autor con este correo electrónico.");

        var autor = _mapper.Map<Autor>(autorDto);
        await _autorRepository.CreateAsync(autor);
        return _mapper.Map<AutorDTO>(autor);
    }

    public async Task UpdateAsync(int id, CreateAutorDTO autorDto)
    {
        var autor = await _autorRepository.GetByIdAsync(id);
        if (autor == null)
            throw new AutorNotFoundException();

        var existingAutor = await _autorRepository.GetByEmailAsync(autorDto.CorreoElectronico);
        if (existingAutor != null && existingAutor.Id != id)
            throw new Exception("Ya existe un autor con este correo electrónico.");

        _mapper.Map(autorDto, autor);
        await _autorRepository.UpdateAsync(autor);
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await _autorRepository.GetByIdAsync(id);
        if (autor == null)
            throw new AutorNotFoundException();

        await _autorRepository.DeleteAsync(id);
    }
}