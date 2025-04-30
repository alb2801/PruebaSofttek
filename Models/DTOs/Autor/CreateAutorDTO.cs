using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.API.Models.DTOs.Autor;

public class CreateAutorDTO
{
    [Required(ErrorMessage = "El nombre completo es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre completo no puede exceder los 100 caracteres")]
    public string NombreCompleto { get; set; } = null!;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(100, ErrorMessage = "La ciudad de procedencia no puede exceder los 100 caracteres")]
    public string? CiudadProcedencia { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
    [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres")]
    public string CorreoElectronico { get; set; } = null!;
}