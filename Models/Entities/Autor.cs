using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.API.Models.Entities;

public class Autor {
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre completo es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre completo no puede exceder los 100 caracteres")]
    public required string NombreCompleto { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(100, ErrorMessage = "La ciudad de procedencia no puede exceder los 100 caracteres")]
    public string? CiudadProcedencia { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
    [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres")]
    public required string CorreoElectronico { get; set; }

    public ICollection<Libro>? Libros { get; set; }
}