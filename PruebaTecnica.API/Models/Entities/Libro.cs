using PruebaTecnica.API.Models.Entities;
using PruebaTecnica.API.Models.Enums;

namespace PruebaTecnica.API.Models.Entities;

public class Libro {
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public int Año { get; set; }
    public Genero Genero { get; set; }
    public int NumeroPaginas { get; set; }
    public int AutorId { get; set; }
    public Autor? Autor { get; set; }
}