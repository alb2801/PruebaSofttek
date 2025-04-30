namespace PruebaTecnica.API.Models.Entities;

public class Autor {
    public int Id { get; set; }
    public required string PrimerNombre { get; set; }
    public string? SegundoNombre { get; set; }
    public required string PrimerApellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? CiudadProcedencia { get; set; }
    public required string CorreoElectronico { get; set; }
    public ICollection<Libro>? Libros { get; set; }
}