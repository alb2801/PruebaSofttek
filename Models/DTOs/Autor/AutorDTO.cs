using PruebaTecnica.API.Models.DTOs.Libro;

namespace PruebaTecnica.API.Models.DTOs.Autor;

public class AutorDTO
{
    public int Id { get; set; }
    public required string NombreCompleto { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? CiudadProcedencia { get; set; }
    public required string CorreoElectronico { get; set; }
}