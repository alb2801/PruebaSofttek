using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Models.DTOs.Autor;
using PruebaTecnica.API.Services.Interface;

namespace PruebaTecnica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IAutorService _autorService;

    public AutoresController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAll()
    {
        var autores = await _autorService.GetAllAsync();
        return Ok(autores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AutorDTO>> GetById(int id)
    {
        try
        {
            var autor = await _autorService.GetByIdAsync(id);
            return Ok(autor);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<AutorDTO>> Create(CreateAutorDTO autorDto)
    {
        try
        {
            var autor = await _autorService.CreateAsync(autorDto);
            return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateAutorDTO autorDto)
    {
        try
        {
            await _autorService.UpdateAsync(id, autorDto);
            return NoContent();
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
            await _autorService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}