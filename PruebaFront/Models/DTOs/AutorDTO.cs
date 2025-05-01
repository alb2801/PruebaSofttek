using System.ComponentModel.DataAnnotations;

namespace PruebaFront.Models.DTOs
{
    public class AutorDto
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre completo no puede exceder los 100 caracteres")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(100, ErrorMessage = "La ciudad de procedencia no puede exceder los 100 caracteres")]
        public string? CiudadProcedencia { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres")]
        public string CorreoElectronico { get; set; } = string.Empty;
    }

    public class AutorItem
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
    }
}
