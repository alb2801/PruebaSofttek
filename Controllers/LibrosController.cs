using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Exceptions;
using PruebaTecnica.API.Models.DTOs.Libro;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Controllers;

/// <summary>
/// Controlador para la gestión de libros.
/// Permite operaciones CRUD y aplica reglas de negocio.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly ILibroService _libroService;

    /// <summary>
    /// Constructor del controlador de libros.
    /// </summary>
    public LibrosController(ILibroService libroService)
    {
        _libroService = libroService;
    }

    /// <summary>
    /// Obtiene todos los libros registrados.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LibroDTO>>> GetAll() => Ok(await _libroService.GetAllAsync());

    /// <summary>
    /// Obtiene un libro por su identificador.
    /// </summary>
    /// <param name="id">Identificador del libro</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<LibroDTO>> GetById(int id)
    {
        var libro = await _libroService.GetByIdAsync(id);
        if (libro == null) return NotFound();
        return Ok(libro);
    }

    /// <summary>
    /// Crea un nuevo libro, validando reglas de negocio.
    /// </summary>
    /// <param name="dto">Datos del libro a crear</param>
    [HttpPost]
    public async Task<ActionResult<LibroDTO>> Create(CreateLibroDTO dto)
    {
        try
        {
            var libro = await _libroService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }
        catch (AutorNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (MaxLibrosExceededException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }

    /// <summary>
    /// Actualiza un libro existente.
    /// </summary>
    /// <param name="id">Identificador del libro</param>
    /// <param name="dto">Nuevos datos del libro</param>
    /* [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLibroDTO dto)
    {
        try
        {
            await _libroService.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    } */

    /// <summary>
    /// Elimina un libro por su identificador.
    /// </summary>
    /// <param name="id">Identificador del libro</param>
    /* [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _libroService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    } */
}