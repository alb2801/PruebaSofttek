using System.ComponentModel.DataAnnotations;
using PruebaTecnica.API.Models.Enums;

namespace PruebaTecnica.API.Models.DTOs.Libro;

public class CreateLibroDTO
{
    [Required(ErrorMessage = "El título es obligatorio")]
    public string Titulo { get; set; } = null!;
    
    [Required(ErrorMessage = "El año es obligatorio")]
    [Range(1000, 9999)]
    public int Año { get; set; }
    
    [Required(ErrorMessage = "El género es obligatorio")]
    public int Genero { get; set; }
    
    [Required(ErrorMessage = "El número de páginas es obligatorio")]
    [Range(1, int.MaxValue)]
    public int NumeroPaginas { get; set; }
    
    [Required(ErrorMessage = "El autor es obligatorio")]
    public int AutorId { get; set; }
}