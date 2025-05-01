namespace PruebaFront.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class LibroDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(1500, 2024, ErrorMessage = "El año debe estar entre 1500 y 2024")]
        public int Año { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un género")]
        public int Genero { get; set; }

        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor a 0")]
        public int NumeroPaginas { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un autor")]
        public int AutorId { get; set; }
    }

     // DTO para mostrar los datos de los libros en la tabla
    public class LibroTablaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Año { get; set; }
        public string Genero { get; set; } = string.Empty;
        public int NumeroPaginas { get; set; }
        public int AutorId { get; set; }
        public string AutorNombre { get; set; } = string.Empty;
    }
}
