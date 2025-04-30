using PruebaTecnica.API.Models.DTOs.Libro;

namespace PruebaTecnica.API.Models.DTOs.Autor;

public class AutorDTO
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string? CiudadProcedencia { get; set; }
    public string CorreoElectronico { get; set; } = null!;
    public ICollection<LibroDTO>? Libros { get; set; }
}