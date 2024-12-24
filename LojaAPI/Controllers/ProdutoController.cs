using LojaAPI.Models;
using LojaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProdutoController(ProdutoService produtoService) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var produtoCriado = await produtoService.Inserir(produto);
            return CreatedAtAction(nameof(Get), new { id = produtoCriado.ProdutoId }, produtoCriado);
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
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var produtos = await produtoService.ObterTodos();
            return Ok(produtos);
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
            var produto = await produtoService.ObterPorId(id);
            return Ok(produto);
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
    public async Task<IActionResult> Put([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var produtoAtualizado = await produtoService.Atualizar(produto);
            return Ok(produtoAtualizado);
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
            await produtoService.Excluir(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}