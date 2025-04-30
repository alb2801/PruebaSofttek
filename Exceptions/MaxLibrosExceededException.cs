namespace PruebaTecnica.API.Exceptions;

public class MaxLibrosExceededException : Exception
{
    public MaxLibrosExceededException() 
        : base("No es posible registrar el libro, se alcanzó el máximo permitido.") { }
}