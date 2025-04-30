using System.ComponentModel.DataAnnotations;

/// <summary>
/// Representa un autor de libros en el sistema.
/// </summary>
namespace PruebaTecnica.API.Models.Entities;

public class Autor {
    /// <summary>
    /// Identificador único del autor.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre completo del autor. Obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El nombre completo es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre completo no puede exceder los 100 caracteres")]
    public required string NombreCompleto { get; set; }

    /// <summary>
    /// Fecha de nacimiento del autor. Obligatoria.
    /// </summary>
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public DateTime FechaNacimiento { get; set; }

    /// <summary>
    /// Ciudad de procedencia del autor (opcional).
    /// </summary>
    [StringLength(100, ErrorMessage = "La ciudad de procedencia no puede exceder los 100 caracteres")]
    public string? CiudadProcedencia { get; set; }

    /// <summary>
    /// Correo electrónico del autor. Obligatorio y debe tener formato válido.
    /// </summary>
    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
    [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres")]
    public required string CorreoElectronico { get; set; }

    /// <summary>
    /// Colección de libros asociados a este autor.
    /// </summary>
    public ICollection<Libro>? Libros { get; set; }
}