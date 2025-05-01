using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Models.Enums;

namespace PruebaTecnica.API.Models.DTOs.Libro;

public class LibroDTO
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public int Año { get; set; }
    public required string Genero { get; set; }
    public int NumeroPaginas { get; set; }
    public int AutorId { get; set; }
    public required string AutorNombre { get; set; }
}