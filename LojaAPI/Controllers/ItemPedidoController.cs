using LojaAPI.Models;
using LojaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemPedidoController(ItemPedidoService itemPedidoService) : ControllerBase
{
    // POST: api/itempedido
    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] ItemPedido itemPedido)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var novoItemPedido = await itemPedidoService.Inserir(itemPedido);
            return CreatedAtAction(nameof(Get), new { id = novoItemPedido.ItemPedidoId }, novoItemPedido);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message); // Exceção de dados nulos
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // Exceção de referência a Pedido ou Produto inexistente
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message); // Exceção de estoque insuficiente
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message); // Falha inesperada
        }
    }


    // GET: api/itempedido
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var itensPedido = await itemPedidoService.ObterTodos();
            return Ok(itensPedido);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }

    // GET: api/itempedido/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var itemPedido = await itemPedidoService.ObterPorId(id);
            return Ok(itemPedido);
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
    
    // PUT: api/itempedido/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] ItemPedido itemPedido)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != itemPedido.ItemPedidoId)
            return BadRequest("Id do item do pedido não encontrado.");

        try
        {
            await itemPedidoService.Atualizar(itemPedido);
            return Ok("Item do pedido atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
    
    // DELETE: api/itempedido/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await itemPedidoService.Excluir(id);
            return Ok("Item do pedido removido com sucesso.");
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