namespace PruebaTecnica.API.Exceptions;

/// <summary>
/// Excepción lanzada cuando se intenta registrar un libro y se ha alcanzado el máximo permitido por autor.
/// </summary>
public class MaxLibrosExceededException : Exception
{
    /// <summary>
    /// Inicializa una nueva instancia de la excepción <see cref="MaxLibrosExceededException"/>.
    /// </summary>
    public MaxLibrosExceededException() 
        : base("No es posible registrar el libro, se alcanzó el máximo permitido.") { }
}