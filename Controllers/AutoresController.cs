using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Models.DTOs.Libro;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Controllers;

/// <summary>
/// Controlador para la gestión de autores.
/// Permite operaciones CRUD sobre los autores.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IAutorService _autorService;
    private readonly ILibroService _libroService;

    /// <summary>
    /// Constructor del controlador de autores.
    /// </summary>
    public AutoresController(IAutorService autorService, ILibroService libroService)
    {
        _autorService = autorService;
        _libroService = libroService;
    }

    /// <summary>
    /// Obtiene todos los autores registrados.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAll() => Ok(await _autorService.GetAllAsync());

    /// <summary>
    /// Obtiene un autor por su identificador.
    /// </summary>
    /// <param name="id">Identificador del autor</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<AutorDTO>> GetById(int id)
    {
        var autor = await _autorService.GetByIdAsync(id);
        if (autor == null) return NotFound();
        return Ok(autor);
    }

    /// <summary>
    /// Crea un nuevo autor.
    /// </summary>
    /// <param name="dto">Datos del autor a crear</param>
    [HttpPost]
    public async Task<ActionResult<AutorDTO>> Create(CreateAutorDTO dto)
    {
        var autor = await _autorService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
    }

    /// <summary>
    /// Actualiza un autor existente.
    /// </summary>
    /// <param name="id">Identificador del autor</param>
    /// <param name="dto">Nuevos datos del autor</param>
    /* [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateAutorDTO dto)
    {
        try
        {
            await _autorService.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    } */

    /// <summary>
    /// Elimina un autor por su identificador.
    /// </summary>
    /// <param name="id">Identificador del autor</param>
   /*  [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _autorService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    } */
}