using LojaAPI.Models;
using LojaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoControllers(PedidoService pedidoService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pedido pedido)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var pedidoCriado = await pedidoService.Inserir(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedidoCriado.PedidoId}, pedidoCriado);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var pedidos = await pedidoService.ObterTodos();
            return Ok(pedidos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var pedido = await pedidoService.ObterPorId(id);
            return Ok(pedido);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Pedido pedido)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await pedidoService.Atualizar(pedido);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
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
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await pedidoService.Excluir(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}