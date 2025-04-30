using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Models.Enums;

namespace PruebaTecnica.API.Models.DTOs.Libro;

public class LibroDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int Año { get; set; }
    public Genero Genero { get; set; }
    public int NumeroPaginas { get; set; }
    public int AutorId { get; set; }
    public AutorDTO? Autor { get; set; }
}