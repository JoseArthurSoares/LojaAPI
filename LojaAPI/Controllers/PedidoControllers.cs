using LojaAPI.Models;
using LojaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoControllers: ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoControllers(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pedido pedido)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var pedidoCriado = await _pedidoService.Inserir(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedidoCriado.PedidoId}, pedidoCriado);
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
            var pedidos = await _pedidoService.ObterTodos();
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
            var pedido = await _pedidoService.ObterPorId(id);
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(pedido);
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
            await _pedidoService.Atualizar(pedido);
            return NoContent();
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
            var excluido = await _pedidoService.Excluir(id);
            if (!excluido)
            {
                return NotFound("Pedido não encontrado.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}