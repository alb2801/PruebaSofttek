using System.ComponentModel.DataAnnotations;
using PruebaTecnica.API.Models.Enums;

namespace PruebaTecnica.API.Models.Entities;

public class Libro {
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
    public required string Titulo { get; set; }

    [Required(ErrorMessage = "El año es obligatorio")]
    [Range(1000, 9999, ErrorMessage = "El año debe estar entre 1000 y 9999")]
    public int Año { get; set; }

    [Required(ErrorMessage = "El género es obligatorio")]
    public Genero Genero { get; set; }

    [Required(ErrorMessage = "El número de páginas es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor a 0")]
    public int NumeroPaginas { get; set; }

    [Required(ErrorMessage = "El autor es obligatorio")]
    public int AutorId { get; set; }

    public Autor? Autor { get; set; }
}