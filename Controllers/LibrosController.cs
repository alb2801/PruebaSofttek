using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Exceptions;
using PruebaTecnica.API.Models.DTOs.Libro;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly ILibroService _libroService;

    public LibrosController(ILibroService libroService)
    {
        _libroService = libroService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LibroDTO>>> GetAll()
    {
        var libros = await _libroService.GetAllAsync();
        return Ok(libros);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LibroDTO>> GetById(int id)
    {
        try
        {
            var libro = await _libroService.GetByIdAsync(id);
            return Ok(libro);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<LibroDTO>> Create(CreateLibroDTO libroDto)
    {
        try
        {
            var libro = await _libroService.CreateAsync(libroDto);
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }
        catch (AutorNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (MaxLibrosExceededException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLibroDTO libroDto)
    {
        try
        {
            await _libroService.UpdateAsync(id, libroDto);
            return NoContent();
        }
        catch (AutorNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (MaxLibrosExceededException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
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
    }
}