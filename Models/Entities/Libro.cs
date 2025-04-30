using System.ComponentModel.DataAnnotations;
using PruebaTecnica.API.Models.Enums;

/// <summary>
/// Representa un libro en el sistema.
/// </summary>
namespace PruebaTecnica.API.Models.Entities;

public class Libro {
    /// <summary>
    /// Identificador único del libro.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Título del libro. Obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
    public required string Titulo { get; set; }

    /// <summary>
    /// Año de publicación del libro. Obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El año es obligatorio")]
    [Range(1000, 9999, ErrorMessage = "El año debe estar entre 1000 y 9999")]
    public int Año { get; set; }

    /// <summary>
    /// Género del libro. Obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El género es obligatorio")]
    public Genero Genero { get; set; }

    /// <summary>
    /// Número de páginas del libro. Obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El número de páginas es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor a 0")]
    public int NumeroPaginas { get; set; }

    /// <summary>
    /// Identificador del autor del libro. Obligatorio.
    /// </summary>
    [Required(ErrorMessage = "El autor es obligatorio")]
    public int AutorId { get; set; }

    /// <summary>
    /// Autor asociado a este libro.
    /// </summary>
    public Autor? Autor { get; set; }
}