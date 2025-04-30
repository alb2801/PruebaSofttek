using AutoMapper;
using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Models.DTOs.Libro;
using PruebaTecnica.API.Models.Entities;

namespace PruebaTecnica.API.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Autor, AutorDTO>();
        CreateMap<CreateAutorDTO, Autor>();
        
        CreateMap<Libro, LibroDTO>();
        CreateMap<CreateLibroDTO, Libro>();
    }
}