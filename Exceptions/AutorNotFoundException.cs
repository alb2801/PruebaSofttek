namespace PruebaTecnica.API.Exceptions;

/// <summary>
/// Excepción lanzada cuando se intenta operar sobre un autor que no existe en la base de datos.
/// </summary>
public class AutorNotFoundException : Exception
{
    /// <summary>
    /// Inicializa una nueva instancia de la excepción <see cref="AutorNotFoundException"/>.
    /// </summary>
    public AutorNotFoundException() 
        : base("El autor no está registrado.") { }
}