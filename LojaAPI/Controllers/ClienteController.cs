using Microsoft.AspNetCore.Mvc;
using LojaAPI.Models;
using LojaAPI.Services;

namespace LojaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController(ClienteService clienteService) : ControllerBase
{
    // POST: api/cliente
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var clienteCriado = await clienteService.Inserir(cliente);
            return CreatedAtAction(nameof(Get), new { id = clienteCriado.ClienteId }, clienteCriado);
        }
        
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    // GET: api/cliente
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var clientes = await clienteService.ObterTodos();
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    // GET: api/cliente/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var cliente = await clienteService.ObterPorId(id);
            return Ok(cliente);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Cliente não encontrado.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    // PUT: api/cliente
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await clienteService.Atualizar(cliente);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Cliente não encontrado.");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    // DELETE: api/cliente/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await clienteService.Excluir(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Cliente não encontrado.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}